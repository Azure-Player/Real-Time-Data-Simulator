using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Scripting;
using Newtonsoft.Json;

namespace RTDSimulatorDesktopApp
{
    public class EventSender
    {
        public int messagesCount = 0;
        public int BatchesNo = 1;
        public int EventsPerBatch = 1;
        public Dictionary<string, string> Variables = new Dictionary<string, string>();
        public TimeSpan WaitTime = TimeSpan.FromSeconds(0);

        string _payload = "";
        string _connectionString = "sb://";
        string _eventHubName = "es_";

        private Lazy<EventHubProducerClient> _producerClient;

        private Dictionary<string, string> Expressions = new Dictionary<string, string>();
        private ConcurrentDictionary<string, Script<Object>> preCompiledScripts { get; set; } = new ConcurrentDictionary<string, Script<Object>>();

        public EventSender(string connectionString, string EventhubName, string payload)
        {
            _payload = payload;
            _connectionString = connectionString;
            if (!_connectionString.StartsWith("Endpoint=")) { _connectionString = "Endpoint=" + _connectionString; }
            _eventHubName = EventhubName;

            Variables.Add("UserId", "Random(5000,5100)");
            Variables.Add("ProductId", "Random(700,999)");
            Variables.Add("Device", "RandomItem(mobile|tablet|pc)");
            Variables.Add("DateTime.Now", "$DateTime.Now");
            Variables.Add("FuelType(MessageIndex)", "BIOMASS|CCGT|COAL|INTELEC|INTEW|INTFR|INTIFA2|INTIRL|INTNED|INTNEM|INTNSL|INTVKL|NPSHYD|NUCLEAR|OCGT|OIL|OTHER|PS|WIND");
            Variables.Add("SettlementPeriod", "48");

            // Finding expressions...
            // Example of an expression definition: {{$DateTime.Now}}   {{$new Random().Next(100,200)}}
            var pattern = @"{{(\$.*?)}}";
            var matches = Regex.Matches(_payload, pattern);
            foreach (Match m in matches)
            {
                if (!Expressions.ContainsKey(m.Value))
                {
                    Expressions.Add(m.Value, m.Value.Substring(3, m.Value.Length - 5));
                }
            }

            _producerClient = new Lazy<EventHubProducerClient>(() => new EventHubProducerClient(_connectionString, _eventHubName));
        }

        ~EventSender()
        {
            if( _producerClient.IsValueCreated)
            {
                _producerClient.Value.DisposeAsync().GetAwaiter().GetResult();
            }
        }

        public async Task Send()
        {
            DateTime nextRun = DateTime.Now;
            for (int batch = 0; batch < BatchesNo; batch++)
            {
                using EventDataBatch eventBatch = await _producerClient.Value.CreateBatchAsync();
                for (int m = 0; m < EventsPerBatch; m++)
                {
                    string payload = await GetPayload(m);
                    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(payload)));
                    messagesCount++;
                }
                await SleepUntil(nextRun);
                await _producerClient.Value.SendAsync(eventBatch);
                OnBatchSent(this, new EventArgs());

                nextRun = DateTime.Now.Add(this.WaitTime);   //Thread.Sleep(WaitTime);
            }
        }

        private async Task SleepUntil(DateTime t)
        {
            TimeSpan waitTime = t.Subtract(DateTime.Now);
            if (waitTime <= TimeSpan.Zero) return;
            await Task.Delay(waitTime);
        }

        public async Task<string> GetPayload(int msgIndex)
        {
            Random rnd = new Random();
            string payload = _payload;

            // Evaluating Variables
            foreach (var v in Variables)
            {
                string val = v.Value;
                string key = v.Key;
                if (val == "$DateTime.Now") { val = DateTime.Now.ToString("O"); };
                if (val.StartsWith("Random(") && val.EndsWith(")"))
                {
                    val = val.Substring(7, val.Length - 8);
                    int min = int.Parse(val.Split(',')[0]);
                    int max = int.Parse(val.Split(',')[1]);
                    val = rnd.Next(min, max).ToString();
                }
                if (val.StartsWith("RandomItem(") && val.EndsWith(")"))
                {
                    val = val.Substring(11, val.Length - 12);
                    String[] arr = val.Split("|");
                    int i = rnd.Next(0, arr.Length);
                    val = arr[i];
                }
                if (key == "FuelType(MessageIndex)")
                {
                    String[] arr = val.Split("|");
                    int i = msgIndex % arr.Length; // iterate through fuel types
                    val = arr[i];
                }
                payload = payload.Replace("{{" + v.Key + "}}", val);
            }

            // Evaluating Expressions
            // https://github.com/dotnet/roslyn/blob/main/docs/wiki/Scripting-API-Samples.md
            foreach (string key in Expressions.Keys) {
                String exp = Expressions[key];

                if(!preCompiledScripts.TryGetValue(exp, out Script<Object> script))
                {
                    script = CSharpScript.Create(exp, ScriptOptions.Default.WithImports("System"));
                    preCompiledScripts.TryAdd(exp, script);
                }

                var result = await script.RunAsync();

                payload = payload.Replace(key, result.ReturnValue.ToString());
            }

            return payload;
        }

        public event EventHandler OnBatchSent;



    }
}
