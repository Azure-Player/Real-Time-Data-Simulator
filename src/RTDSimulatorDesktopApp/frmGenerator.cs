using System.Windows.Forms;

namespace RTDSimulatorDesktopApp
{
    public partial class frmGenerator : Form
    {
        public frmGenerator()
        {
            InitializeComponent();
        }

        private const string FILES_FILTER = "Text files (*.txt)|*.txt|JSON files (*.json)|*.json|All files (*.*)|*.*";

        private string _FileName = "GenerationByFuelType";
        private bool _IsPayloadChanged = false;
        private decimal _TotalMsgCount = 0;
        private decimal _TotalBatchCount = 0;
        private int _BatchSent = 0;
        private int _MsgSent = 0;
        private DateTime _StartTime = DateTime.MinValue;
        private DateTime _EndTime = DateTime.MinValue;

        public bool IsPayloadChanged
        {
            get { return _IsPayloadChanged; }
            set
            {
                _IsPayloadChanged = value;
                RefreshAppTitle();
            }
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            btnRun.Enabled = false;
            status.Text = "Status: In Progress...";
            statusTime.Text = "";
            progressBar1.Maximum = (int)_TotalBatchCount;
            progressBar1.Value = 0;
            _BatchSent = 0;
            _MsgSent = 0;
            _StartTime = DateTime.Now;

            for (int i = 0; i < this.SettingsThreadsNumber.Value; i++)
            {
                EventSender s = new EventSender(txtCnnStr.Text, txtEventHubName.Text, txtPayload.Text);
                s.BatchesNo = (int)SettingsBatchesPerThreadNumber.Value;
                s.EventsPerBatch = (int)SettingsMsgPerBatchNumber.Value;
                s.WaitTime = new TimeSpan(0, 0, (int)SettingsWaitTimeSec.Value);
                s.OnBatchSent += EventSender_OnBatchSent;
                s.OnCompleted += EventSender_OnCompleted;
                s.Send();
            }
        }

        private void EventSender_OnCompleted(object? sender, EventArgs e)
        {
            progressBar1.Maximum = progressBar1.Value;
            _EndTime = DateTime.Now;
            TimeSpan ts = _EndTime - _StartTime;
            status.Text = $"Status: Completed.";
            statusTime.Text = $"Sent {_MsgSent} messages in {ts:c}";
            btnRun.Enabled = true;
        }

        private void EventSender_OnBatchSent(object? sender, EventArgs e)
        {
            progressBar1.Increment(1);
            _BatchSent++;
            _MsgSent += (int)SettingsMsgPerBatchNumber.Value;
            statusBatches.Text = $"Batches sent: {_BatchSent} / {_TotalBatchCount}";
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
            EventSender s = new EventSender("", "", txtPayload.Text);
            String ExamplePayload = s.GetPayload(0);
            frmPreview f = new frmPreview();
            f.txtPayload.Text = ExamplePayload;
            f.ShowDialog();
        }
    }
}
