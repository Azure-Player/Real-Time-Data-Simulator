namespace RTDSimulatorDesktopApp
{
    partial class frmAboutApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            picAppLogo = new PictureBox();
            lblAppName = new Label();
            lblVersion = new Label();
            btnOK = new Button();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            lblAuthor = new Label();
            ((System.ComponentModel.ISupportInitialize)picAppLogo).BeginInit();
            SuspendLayout();
            // 
            // picAppLogo
            // 
            picAppLogo.Image = Properties.Resources.sc_real_time_computing_stream_computing_512;
            picAppLogo.Location = new Point(31, 23);
            picAppLogo.Name = "picAppLogo";
            picAppLogo.Size = new Size(87, 81);
            picAppLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picAppLogo.TabIndex = 0;
            picAppLogo.TabStop = false;
            // 
            // lblAppName
            // 
            lblAppName.AutoSize = true;
            lblAppName.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAppName.ForeColor = Color.FromArgb(0, 0, 192);
            lblAppName.Location = new Point(133, 23);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(392, 45);
            lblAppName.TabIndex = 1;
            lblAppName.Text = "Real-Time Data Simulator";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblVersion.Location = new Point(142, 68);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(40, 15);
            lblVersion.TabIndex = 2;
            lblVersion.Text = "label2";
            // 
            // btnOK
            // 
            btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnOK.Location = new Point(440, 238);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(108, 30);
            btnOK.TabIndex = 3;
            btnOK.Text = "OK";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 130);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 4;
            label1.Text = "Source Code:";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(142, 130);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(324, 15);
            linkLabel1.TabIndex = 5;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://github.com/Azure-Player/Real-Time-Data-Simulator";
            // 
            // lblAuthor
            // 
            lblAuthor.AutoSize = true;
            lblAuthor.Location = new Point(142, 89);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(89, 15);
            lblAuthor.TabIndex = 6;
            lblAuthor.Text = "Kamil Nowinski";
            // 
            // frmAboutApp
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnOK;
            ClientSize = new Size(560, 280);
            Controls.Add(lblAuthor);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(btnOK);
            Controls.Add(lblVersion);
            Controls.Add(lblAppName);
            Controls.Add(picAppLogo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmAboutApp";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About Real-Time Data Simulator";
            Load += frmAboutApp_Load;
            ((System.ComponentModel.ISupportInitialize)picAppLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox picAppLogo;
        private Label lblAppName;
        private Label lblVersion;
        private Button btnOK;
        private Label label1;
        private LinkLabel linkLabel1;
        private Label lblAuthor;
    }
}