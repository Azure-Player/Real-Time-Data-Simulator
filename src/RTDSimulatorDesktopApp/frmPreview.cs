using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTDSimulatorDesktopApp
{
    public partial class frmPreview : Form
    {
        public EventSender gen;

        public frmPreview()
        {
            InitializeComponent();
            barMsgIndex.Value = 0;
        }

        private void frmPreview_Load(object sender, EventArgs e)
        {
            GenerateMessage(0);
        }

        private void GenerateMessage(int msgIndex)
        {
            String ExamplePayload = gen.GetPayload(msgIndex).ConfigureAwait(false).GetAwaiter().GetResult();
            this.txtPayload.Text = ExamplePayload;
            lblMsgIndex.Text = "Message Index: " + barMsgIndex.Value.ToString();
        }

        private void barMsgIndex_ValueChanged(object sender, EventArgs e)
        {
            GenerateMessage(barMsgIndex.Value);
        }
    }
}
