using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using RTDSimulatorDesktopApp.FormControls;
using System.Text;
using System.Data;
using Azure.Core;
using Azure.Identity;
using Microsoft.Graph;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using System.Net;

namespace RTDSimulatorDesktopApp
{
    public partial class frmGenerator : Form
    {
        public frmGenerator()
        {
            InitializeComponent();
        }

        private const string FILES_FILTER = "Text files (*.txt)|*.txt|JSON files (*.json)|*.json|All files (*.*)|*.*";
        private const Double BytesToMbps = 1024 * 1024 / 8;

        private string _FileName = "GenerationByFuelType";
        private bool _IsPayloadChanged = false;
        private decimal _TotalMsgCount = 0;
        private decimal _TotalBatchCount = 0;
        private int _BatchSent = 0;
        private int _MsgSent = 0;
        private Int64 _TotalSizeInBytes = 0;
        private DateTime _StartTime = DateTime.MinValue;
        private DateTime _EndTime = DateTime.MinValue;
        private CancellationTokenSource _CancellationTokenSource;
        private TargetConnection _conn;
        private InteractiveBrowserCredential _credential;

        public bool IsPayloadChanged
        {
            get { return _IsPayloadChanged; }
            set
            {
                _IsPayloadChanged = value;
                RefreshAppTitle();
            }
        }

        private void ResetCounters()
        {
            _BatchSent = 0;
            _MsgSent = 0;
            _StartTime = DateTime.Now;
            _TotalSizeInBytes = 0;
        }

        private async void btnRun_Click(object sender, EventArgs e)
        {
            RecalcTotal();
            lastErrorTextBox.Text = "";
            progressBar1.ForeColor = Color.LimeGreen;

            btnRun.Enabled = false;
            progressBar1.Maximum = (int)_TotalBatchCount;
            progressBar1.Value = 0;
            ResetCounters();

            statusBatches.Text = $"Batches sent: {_BatchSent} / {_TotalBatchCount}";
            status.Text = "Status: In Progress...";
            statusTime.Text = "";

            List<(int, Task)> sendTasks = new List<(int, Task)>();

            _conn = new TargetConnection(txtCnnStr.Text, txtEventHubName.Text, _credential);

            EventSender s = new EventSender(txtPayload.Text);
            s.OnBatchSent += EventSender_OnBatchSent;
            _CancellationTokenSource = new CancellationTokenSource();

            for (int i = 0; i < this.SettingsThreadsNumber.Value; i++)
            {
                s.BatchesNo = (int)SettingsBatchesPerThreadNumber.Value;
                s.EventsPerBatch = (int)SettingsMsgPerBatchNumber.Value;
                s.WaitTime = new TimeSpan(0, 0, (int)SettingsWaitTimeSec.Value);
                sendTasks.Add((i, s.Send(_conn, _CancellationTokenSource.Token)));
            }

            try
            {
                btnCancel.Enabled = true;
                await Task.WhenAll(sendTasks.Select(x => x.Item2));
                if (_CancellationTokenSource.IsCancellationRequested)
                {
                    btnCancel.Enabled = false;
                    OnCancelled();
                }
                else
                {
                    btnCancel.Enabled = false;
                    OnCompleted();
                }
            }
            catch (Exception ex)
            {
                progressBar1.ForeColor = Color.Red;
                var allExceptions = sendTasks.Where(x => x.Item2.Exception != null).Select(x => (x.Item1, x.Item2.Exception));

                StringBuilder sb = new StringBuilder();
                allExceptions.ToList().ForEach(x => sb.AppendLine($"Exception on thread {x.Item1}: {x.Exception?.Message ?? "Unknown exception occured during sending"}"));
                OnFailed(sb.ToString());
            }

        }

        private void UpdateStatus(string Status)
        {
            _EndTime = DateTime.Now;
            TimeSpan ts = _EndTime - _StartTime;
            status.Text = $"Status: {Status}.";
            statusBatches.Text = $"Sent {_MsgSent} messages in {_TotalBatchCount} batches. Total time: {ts:c} (TPS: {(_MsgSent / ts.TotalSeconds):F2}) | Bytes sent: {_TotalSizeInBytes:0,0} ({(_TotalSizeInBytes / BytesToMbps / ts.TotalSeconds):F2} Mbps)";
        }

        private void OnCompleted()
        {
            progressBar1.Maximum = progressBar1.Value;
            UpdateStatus("Completed");
            btnRun.Enabled = true;
        }

        private void OnCancelled()
        {
            if (progressBar1.Value == 0)
            {
                progressBar1.Value = 1;
            }
            progressBar1.Maximum = progressBar1.Value;
            UpdateStatus("Cancelled");
            btnRun.Enabled = true;
        }

        private void OnFailed(string errorMessage)
        {
            if (progressBar1.Value == 0)
            {
                progressBar1.Value = 1;
            }
            progressBar1.Maximum = progressBar1.Value;
            UpdateStatus("Failed");
            lastErrorTextBox.Text = errorMessage;
            btnRun.Enabled = true;
            btnCancel.Enabled = false;
        }

        private void EventSender_OnBatchSent(object? sender, EventArgs e)
        {
            progressBar1.Increment(1);
            _BatchSent++;
            _MsgSent += (int)SettingsMsgPerBatchNumber.Value;
            TimeSpan ts = DateTime.Now - _StartTime;
            _TotalSizeInBytes += ((EventSender)sender).BatchSizeInBytes;
            statusBatches.Text = $"Batches sent: {_BatchSent} / {_TotalBatchCount} (TPS: {(_MsgSent / ts.TotalSeconds):F2}) | Bytes sent: {_TotalSizeInBytes:0,0} ({(_TotalSizeInBytes / BytesToMbps / ts.TotalSeconds):F2} Mbps)";
            //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/tokens/interpolated
        }

        private void RecalcTotal()
        {
            _TotalBatchCount = SettingsThreadsNumber.Value * SettingsBatchesPerThreadNumber.Value;
            _TotalMsgCount = _TotalBatchCount * SettingsMsgPerBatchNumber.Value;
            SettingsTotalMsgCount.Value = _TotalMsgCount;
        }
        private void RefreshAppTitle()
        {
            this.Text = (_IsPayloadChanged ? "*" : "") + _FileName + (_FileName.Length > 0 ? " - " : "") + this.Tag;
        }

        private void SettingsThreadsNumber_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotal();
        }

        private void SettingsBatchesPerThreadNumber_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotal();
        }

        private void SettingsMsgPerBatchNumber_ValueChanged(object sender, EventArgs e)
        {
            RecalcTotal();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = FILES_FILTER;
            saveFileDialog.FileName = _FileName;
            DialogResult dr = saveFileDialog.ShowDialog();
            if (dr == DialogResult.OK && saveFileDialog.FileName.Length > 0)
            {
                SaveFile(saveFileDialog.FileName);
            }
        }

        private void saveMessageTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(_FileName);
        }

        private void SaveFile(string FileName)
        {
            System.IO.File.WriteAllText(FileName, txtPayload.Text);
            _FileName = new System.IO.FileInfo(FileName).Name;
            IsPayloadChanged = false;
        }

        private void loadMessageTemplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FILES_FILTER;
            openFileDialog.ShowDialog();
            if (openFileDialog.FileName.Length > 0)
            {
                txtPayload.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
                _FileName = openFileDialog.SafeFileName;
            }
            IsPayloadChanged = false;
        }

        private void txtPayload_TextChanged(object sender, EventArgs e)
        {
            IsPayloadChanged = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshAppTitle();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            EventSender s = new EventSender(txtPayload.Text);
            frmPreview f = new frmPreview();
            f.gen = s;
            f.ShowDialog();
        }

        private async void btnCancel_Click(object sender, EventArgs e)
        {
            progressBar1.ForeColor = Color.Yellow;
            btnCancel.Enabled = false;
            _CancellationTokenSource.Cancel();
        }

        private void frmGenerator_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.F5)
            {
                btnRun_Click(sender, e);
            }
            if (e.KeyData == Keys.F3)
            {
                btnPreview_Click(sender, e);
            }
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            frmAboutApp f = new frmAboutApp();
            f.ShowDialog();
        }

        private async void btnTestCnn_Click(object sender, EventArgs e)
        {
            try
            {
                _conn = new TargetConnection(txtCnnStr.Text, txtEventHubName.Text, _credential);
                var r = _conn.Connect();
                lastErrorTextBox.Text = "Connection successful.";
            }
            catch (Exception ex)
            {
                lastErrorTextBox.Text = ex.ToString();
            }
        }

        private void btnAzureAuth_Click(object sender, EventArgs e)
        {
            AzureInteractiveAuth().Wait();
        }

        private async Task AzureInteractiveAuth()
        {
            if (_credential == null)
            {
                _credential = new InteractiveBrowserCredential();
            }

            // Define the resource scope you want to access
            var scope = new[] { "https://graph.microsoft.com/.default" };

            try
            {
                // Use the credential to get an access token
                AccessToken token = await _credential.GetTokenAsync(new TokenRequestContext(scope));
                lastErrorTextBox.Text = $"Access Token: {token.Token.Substring(0,8)}***";
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                lastErrorTextBox.Text = $"Error: {ex.Message}";
            }
        }


    }
}
