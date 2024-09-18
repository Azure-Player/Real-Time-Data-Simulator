using Azure.Identity;
using Azure.Messaging.EventHubs.Producer;

namespace RTDSimulatorDesktopApp
{
    public class TargetConnection
    {
        string _connectionString = "sb://";
        string _eventHubName = "es_";
        InteractiveBrowserCredential _credential;

        public TargetConnection(string connectionString, string eventHubName, InteractiveBrowserCredential credential)
        {
            _connectionString = connectionString;
            _eventHubName = eventHubName;
            _credential = credential;
        }

        public EventHubProducerClient Connect()
        {
            //return new Lazy<EventHubProducerClient>(() => new EventHubProducerClient(_connectionString, _eventHubName, cred));
            if (_credential == null)
            {
                return new EventHubProducerClient(_connectionString, _eventHubName);
            }
            else
            {
                return new EventHubProducerClient(_connectionString, _eventHubName, _credential);
            }
        }
    }
}
