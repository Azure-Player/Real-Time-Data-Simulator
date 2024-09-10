using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTDSimulatorDesktopApp
{
    public partial class frmAboutApp : Form
    {
        public frmAboutApp()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAboutApp_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version: " + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
