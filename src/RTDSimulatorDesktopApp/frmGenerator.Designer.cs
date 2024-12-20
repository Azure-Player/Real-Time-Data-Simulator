﻿using RTDSimulatorDesktopApp.FormControls;

namespace RTDSimulatorDesktopApp
{
    partial class frmGenerator
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmGenerator));
            label1 = new Label();
            label2 = new Label();
            txtCnnStr = new TextBox();
            txtEventHubName = new TextBox();
            label3 = new Label();
            txtPayload = new TextBox();
            btnRun = new Button();
            imageList1 = new ImageList(components);
            progressBar1 = new NewProgressBar();
            label4 = new Label();
            groupBox1 = new GroupBox();
            label9 = new Label();
            SettingsWaitTimeSec = new NumericUpDown();
            label8 = new Label();
            SettingsTotalMsgCount = new NumericUpDown();
            SettingsMsgPerBatchNumber = new NumericUpDown();
            SettingsBatchesPerThreadNumber = new NumericUpDown();
            SettingsThreadsNumber = new NumericUpDown();
            statusStrip1 = new StatusStrip();
            statusBatches = new ToolStripStatusLabel();
            status = new ToolStripStatusLabel();
            statusTime = new ToolStripStatusLabel();
            menuStrip1 = new MenuStrip();
            FileMenu = new ToolStripMenuItem();
            loadMessageTemplateToolStripMenuItem = new ToolStripMenuItem();
            saveMessageTemplateToolStripMenuItem = new ToolStripMenuItem();
            saveAsToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            mnuAbout = new ToolStripMenuItem();
            groupBox2 = new GroupBox();
            btnTestCnn = new Button();
            btnPreview = new Button();
            btnCancel = new Button();
            lastErrorTextBox = new TextBox();
            groupBox3 = new GroupBox();
            btnAzureAuth = new Button();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)SettingsWaitTimeSec).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsTotalMsgCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsMsgPerBatchNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsBatchesPerThreadNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)SettingsThreadsNumber).BeginInit();
            statusStrip1.SuspendLayout();
            menuStrip1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 35);
            label1.Name = "label1";
            label1.Size = new Size(157, 15);
            label1.TabIndex = 0;
            label1.Text = "Endpoint &Connection String:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 97);
            label2.Name = "label2";
            label2.Size = new Size(139, 15);
            label2.TabIndex = 1;
            label2.Text = "&Topic / Event Hub Name:";
            // 
            // txtCnnStr
            // 
            txtCnnStr.Location = new Point(15, 53);
            txtCnnStr.Name = "txtCnnStr";
            txtCnnStr.Size = new Size(424, 23);
            txtCnnStr.TabIndex = 2;
            txtCnnStr.Text = "Endpoint=sb://****fkawjq507mc.servicebus.windows.net/;SharedAccessKeyName=key_0000;SharedAccessKey=****";
            // 
            // txtEventHubName
            // 
            txtEventHubName.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtEventHubName.Location = new Point(15, 115);
            txtEventHubName.Name = "txtEventHubName";
            txtEventHubName.Size = new Size(424, 21);
            txtEventHubName.TabIndex = 3;
            txtEventHubName.Text = "es_08960000000000000000";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(13, 70);
            label3.Name = "label3";
            label3.Size = new Size(159, 15);
            label3.TabIndex = 4;
            label3.Text = "Payload (message) template:";
            // 
            // txtPayload
            // 
            txtPayload.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPayload.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPayload.ForeColor = Color.Maroon;
            txtPayload.Location = new Point(15, 88);
            txtPayload.Multiline = true;
            txtPayload.Name = "txtPayload";
            txtPayload.ScrollBars = ScrollBars.Both;
            txtPayload.Size = new Size(599, 414);
            txtPayload.TabIndex = 5;
            txtPayload.Text = resources.GetString("txtPayload.Text");
            txtPayload.WordWrap = false;
            txtPayload.TextChanged += txtPayload_TextChanged;
            // 
            // btnRun
            // 
            btnRun.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRun.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRun.ImageAlign = ContentAlignment.MiddleLeft;
            btnRun.ImageKey = "Visualpharm-Must-Have-Play.ico";
            btnRun.ImageList = imageList1;
            btnRun.Location = new Point(900, 447);
            btnRun.Name = "btnRun";
            btnRun.Size = new Size(201, 54);
            btnRun.TabIndex = 6;
            btnRun.Text = "RUN (F5)";
            btnRun.UseVisualStyleBackColor = true;
            btnRun.Click += btnRun_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageStream = (ImageListStreamer)resources.GetObject("imageList1.ImageStream");
            imageList1.TransparentColor = Color.Transparent;
            imageList1.Images.SetKeyName(0, "Visualpharm-Must-Have-Play.ico");
            imageList1.Images.SetKeyName(1, "Visualpharm-Must-Have-Preview.ico");
            imageList1.Images.SetKeyName(2, "Visualpharm-Must-Have-Stop.ico");
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.ForeColor = Color.LawnGreen;
            progressBar1.Location = new Point(3, 141);
            progressBar1.Margin = new Padding(15, 3, 15, 3);
            progressBar1.Maximum = 1000;
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1094, 43);
            progressBar1.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(21, 41);
            label4.Name = "label4";
            label4.Size = new Size(398, 21);
            label4.TabIndex = 8;
            label4.Text = "Threads   x   Batches   x   Messages   =   TOTAL Messages";
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(SettingsWaitTimeSec);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(SettingsTotalMsgCount);
            groupBox1.Controls.Add(SettingsMsgPerBatchNumber);
            groupBox1.Controls.Add(SettingsBatchesPerThreadNumber);
            groupBox1.Controls.Add(SettingsThreadsNumber);
            groupBox1.Controls.Add(label4);
            groupBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            groupBox1.Location = new Point(643, 279);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(458, 158);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Publisher settings";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F);
            label9.Location = new Point(407, 118);
            label9.Name = "label9";
            label9.Size = new Size(32, 21);
            label9.TabIndex = 20;
            label9.Text = "sec";
            // 
            // SettingsWaitTimeSec
            // 
            SettingsWaitTimeSec.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            SettingsWaitTimeSec.Location = new Point(320, 116);
            SettingsWaitTimeSec.Maximum = new decimal(new int[] { 300, 0, 0, 0 });
            SettingsWaitTimeSec.Name = "SettingsWaitTimeSec";
            SettingsWaitTimeSec.Size = new Size(81, 29);
            SettingsWaitTimeSec.TabIndex = 19;
            SettingsWaitTimeSec.TextAlign = HorizontalAlignment.Right;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F);
            label8.ForeColor = SystemColors.ControlDarkDark;
            label8.Location = new Point(22, 116);
            label8.Name = "label8";
            label8.Size = new Size(209, 21);
            label8.TabIndex = 18;
            label8.Text = "Wait time (between batches):";
            // 
            // SettingsTotalMsgCount
            // 
            SettingsTotalMsgCount.Enabled = false;
            SettingsTotalMsgCount.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            SettingsTotalMsgCount.Location = new Point(299, 76);
            SettingsTotalMsgCount.Maximum = new decimal(new int[] { 2000000, 0, 0, 0 });
            SettingsTotalMsgCount.Name = "SettingsTotalMsgCount";
            SettingsTotalMsgCount.Size = new Size(120, 29);
            SettingsTotalMsgCount.TabIndex = 17;
            SettingsTotalMsgCount.TextAlign = HorizontalAlignment.Right;
            SettingsTotalMsgCount.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // SettingsMsgPerBatchNumber
            // 
            SettingsMsgPerBatchNumber.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            SettingsMsgPerBatchNumber.Location = new Point(188, 76);
            SettingsMsgPerBatchNumber.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            SettingsMsgPerBatchNumber.Name = "SettingsMsgPerBatchNumber";
            SettingsMsgPerBatchNumber.Size = new Size(80, 29);
            SettingsMsgPerBatchNumber.TabIndex = 15;
            SettingsMsgPerBatchNumber.TextAlign = HorizontalAlignment.Right;
            SettingsMsgPerBatchNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            SettingsMsgPerBatchNumber.ValueChanged += SettingsMsgPerBatchNumber_ValueChanged;
            // 
            // SettingsBatchesPerThreadNumber
            // 
            SettingsBatchesPerThreadNumber.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            SettingsBatchesPerThreadNumber.Location = new Point(106, 76);
            SettingsBatchesPerThreadNumber.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            SettingsBatchesPerThreadNumber.Name = "SettingsBatchesPerThreadNumber";
            SettingsBatchesPerThreadNumber.Size = new Size(76, 29);
            SettingsBatchesPerThreadNumber.TabIndex = 13;
            SettingsBatchesPerThreadNumber.TextAlign = HorizontalAlignment.Right;
            SettingsBatchesPerThreadNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            SettingsBatchesPerThreadNumber.ValueChanged += SettingsBatchesPerThreadNumber_ValueChanged;
            // 
            // SettingsThreadsNumber
            // 
            SettingsThreadsNumber.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            SettingsThreadsNumber.Location = new Point(15, 76);
            SettingsThreadsNumber.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            SettingsThreadsNumber.Name = "SettingsThreadsNumber";
            SettingsThreadsNumber.Size = new Size(85, 29);
            SettingsThreadsNumber.TabIndex = 11;
            SettingsThreadsNumber.TextAlign = HorizontalAlignment.Right;
            SettingsThreadsNumber.Value = new decimal(new int[] { 1, 0, 0, 0 });
            SettingsThreadsNumber.ValueChanged += SettingsThreadsNumber_ValueChanged;
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusBatches, status, statusTime });
            statusStrip1.Location = new Point(0, 694);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1124, 22);
            statusStrip1.TabIndex = 10;
            statusStrip1.Text = "statusStrip1";
            // 
            // statusBatches
            // 
            statusBatches.Name = "statusBatches";
            statusBatches.Size = new Size(79, 17);
            statusBatches.Text = "Batches sent: ";
            // 
            // status
            // 
            status.Name = "status";
            status.Size = new Size(64, 17);
            status.Text = "Status: Idle";
            // 
            // statusTime
            // 
            statusTime.Name = "statusTime";
            statusTime.Size = new Size(12, 17);
            statusTime.Text = "-";
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { FileMenu, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1124, 24);
            menuStrip1.TabIndex = 11;
            menuStrip1.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            FileMenu.DropDownItems.AddRange(new ToolStripItem[] { loadMessageTemplateToolStripMenuItem, saveMessageTemplateToolStripMenuItem, saveAsToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            FileMenu.Name = "FileMenu";
            FileMenu.Size = new Size(37, 20);
            FileMenu.Text = "&File";
            // 
            // loadMessageTemplateToolStripMenuItem
            // 
            loadMessageTemplateToolStripMenuItem.Name = "loadMessageTemplateToolStripMenuItem";
            loadMessageTemplateToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            loadMessageTemplateToolStripMenuItem.Size = new Size(186, 22);
            loadMessageTemplateToolStripMenuItem.Text = "Open...";
            loadMessageTemplateToolStripMenuItem.Click += loadMessageTemplateToolStripMenuItem_Click;
            // 
            // saveMessageTemplateToolStripMenuItem
            // 
            saveMessageTemplateToolStripMenuItem.Name = "saveMessageTemplateToolStripMenuItem";
            saveMessageTemplateToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
            saveMessageTemplateToolStripMenuItem.Size = new Size(186, 22);
            saveMessageTemplateToolStripMenuItem.Text = "Save";
            saveMessageTemplateToolStripMenuItem.Click += saveMessageTemplateToolStripMenuItem_Click;
            // 
            // saveAsToolStripMenuItem
            // 
            saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            saveAsToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
            saveAsToolStripMenuItem.Size = new Size(186, 22);
            saveAsToolStripMenuItem.Text = "Save As...";
            saveAsToolStripMenuItem.Click += saveAsToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(183, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.ShortcutKeys = Keys.Alt | Keys.F4;
            exitToolStripMenuItem.Size = new Size(186, 22);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuAbout });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // mnuAbout
            // 
            mnuAbout.Name = "mnuAbout";
            mnuAbout.Size = new Size(107, 22);
            mnuAbout.Text = "About";
            mnuAbout.Click += mnuAbout_Click;
            // 
            // groupBox2
            // 
            groupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            groupBox2.Controls.Add(btnAzureAuth);
            groupBox2.Controls.Add(btnTestCnn);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(txtCnnStr);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(txtEventHubName);
            groupBox2.Location = new Point(643, 88);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(458, 185);
            groupBox2.TabIndex = 12;
            groupBox2.TabStop = false;
            groupBox2.Text = "Destination: EventHub";
            // 
            // btnTestCnn
            // 
            btnTestCnn.Location = new Point(257, 141);
            btnTestCnn.Margin = new Padding(3, 2, 3, 2);
            btnTestCnn.Name = "btnTestCnn";
            btnTestCnn.Size = new Size(181, 39);
            btnTestCnn.TabIndex = 4;
            btnTestCnn.Text = "Test Connection";
            btnTestCnn.UseVisualStyleBackColor = true;
            btnTestCnn.Click += btnTestCnn_Click;
            // 
            // btnPreview
            // 
            btnPreview.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPreview.ImageAlign = ContentAlignment.MiddleLeft;
            btnPreview.ImageIndex = 1;
            btnPreview.ImageList = imageList1;
            btnPreview.Location = new Point(497, 57);
            btnPreview.Name = "btnPreview";
            btnPreview.Size = new Size(117, 28);
            btnPreview.TabIndex = 13;
            btnPreview.Text = "Preview (F3)";
            btnPreview.UseVisualStyleBackColor = true;
            btnPreview.Click += btnPreview_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCancel.Enabled = false;
            btnCancel.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancel.ImageKey = "Visualpharm-Must-Have-Stop.ico";
            btnCancel.ImageList = imageList1;
            btnCancel.Location = new Point(693, 447);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(201, 54);
            btnCancel.TabIndex = 14;
            btnCancel.Text = "CANCEL";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lastErrorTextBox
            // 
            lastErrorTextBox.Dock = DockStyle.Top;
            lastErrorTextBox.Location = new Point(3, 19);
            lastErrorTextBox.Multiline = true;
            lastErrorTextBox.Name = "lastErrorTextBox";
            lastErrorTextBox.ReadOnly = true;
            lastErrorTextBox.ScrollBars = ScrollBars.Vertical;
            lastErrorTextBox.Size = new Size(1094, 118);
            lastErrorTextBox.TabIndex = 4;
            // 
            // groupBox3
            // 
            groupBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox3.AutoSize = true;
            groupBox3.Controls.Add(lastErrorTextBox);
            groupBox3.Controls.Add(progressBar1);
            groupBox3.Location = new Point(10, 507);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(1100, 187);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            // 
            // btnAzureAuth
            // 
            btnAzureAuth.Location = new Point(15, 141);
            btnAzureAuth.Margin = new Padding(3, 2, 3, 2);
            btnAzureAuth.Name = "btnAzureAuth";
            btnAzureAuth.Size = new Size(181, 39);
            btnAzureAuth.TabIndex = 5;
            btnAzureAuth.Text = "Azure: Sign in";
            btnAzureAuth.UseVisualStyleBackColor = true;
            btnAzureAuth.Click += btnAzureAuth_Click;
            // 
            // frmGenerator
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 716);
            Controls.Add(groupBox3);
            Controls.Add(btnCancel);
            Controls.Add(btnPreview);
            Controls.Add(groupBox2);
            Controls.Add(menuStrip1);
            Controls.Add(groupBox1);
            Controls.Add(btnRun);
            Controls.Add(txtPayload);
            Controls.Add(label3);
            Controls.Add(statusStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1140, 753);
            Name = "frmGenerator";
            StartPosition = FormStartPosition.CenterScreen;
            Tag = "Real-Time Data Simulator (for Windows)";
            Text = "Real-Time Data Simulator (for Windows)";
            Load += Form1_Load;
            KeyUp += frmGenerator_KeyUp;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)SettingsWaitTimeSec).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsTotalMsgCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsMsgPerBatchNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsBatchesPerThreadNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)SettingsThreadsNumber).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtCnnStr;
        private TextBox txtEventHubName;
        private Label label3;
        private TextBox txtPayload;
        private Button btnRun;
        private Label label4;
        private GroupBox groupBox1;
        private NumericUpDown SettingsThreadsNumber;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusBatches;
        private ToolStripStatusLabel status;
        private NumericUpDown SettingsBatchesPerThreadNumber;
        private NumericUpDown SettingsTotalMsgCount;
        private NumericUpDown SettingsMsgPerBatchNumber;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem FileMenu;
        private ToolStripMenuItem loadMessageTemplateToolStripMenuItem;
        private ToolStripMenuItem saveMessageTemplateToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private GroupBox groupBox2;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripStatusLabel statusTime;
        private Label label9;
        private NumericUpDown SettingsWaitTimeSec;
        private Label label8;
        private Button btnPreview;
        private Button btnCancel;
        private NewProgressBar progressBar1;
        private TextBox lastErrorTextBox;
        private GroupBox groupBox3;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem mnuAbout;
        private ImageList imageList1;
        private Button btnTestCnn;
        private Button btnAzureAuth;
    }
}
