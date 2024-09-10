namespace RTDSimulatorDesktopApp
{
    partial class frmPreview
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPreview));
            txtPayload = new TextBox();
            btnClose = new Button();
            lblMsgIndex = new Label();
            barMsgIndex = new TrackBar();
            ((System.ComponentModel.ISupportInitialize)barMsgIndex).BeginInit();
            SuspendLayout();
            // 
            // txtPayload
            // 
            txtPayload.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtPayload.Font = new Font("Consolas", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPayload.ForeColor = Color.Maroon;
            txtPayload.Location = new Point(12, 42);
            txtPayload.Multiline = true;
            txtPayload.Name = "txtPayload";
            txtPayload.ScrollBars = ScrollBars.Both;
            txtPayload.Size = new Size(776, 363);
            txtPayload.TabIndex = 6;
            txtPayload.Text = resources.GetString("txtPayload.Text");
            txtPayload.WordWrap = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnClose.Location = new Point(713, 415);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = true;
            // 
            // lblMsgIndex
            // 
            lblMsgIndex.AutoSize = true;
            lblMsgIndex.Font = new Font("Segoe UI", 12F);
            lblMsgIndex.ForeColor = SystemColors.ControlDarkDark;
            lblMsgIndex.Location = new Point(12, 9);
            lblMsgIndex.Name = "lblMsgIndex";
            lblMsgIndex.Size = new Size(115, 21);
            lblMsgIndex.TabIndex = 19;
            lblMsgIndex.Text = "Message Index:";
            // 
            // barMsgIndex
            // 
            barMsgIndex.Location = new Point(170, 9);
            barMsgIndex.Name = "barMsgIndex";
            barMsgIndex.Size = new Size(367, 45);
            barMsgIndex.TabIndex = 20;
            barMsgIndex.ValueChanged += barMsgIndex_ValueChanged;
            // 
            // frmPreview
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPayload);
            Controls.Add(barMsgIndex);
            Controls.Add(lblMsgIndex);
            Controls.Add(btnClose);
            KeyPreview = true;
            Name = "frmPreview";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Payload Preview (example)";
            Load += frmPreview_Load;
            ((System.ComponentModel.ISupportInitialize)barMsgIndex).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public TextBox txtPayload;
        private Button btnClose;
        private Label lblMsgIndex;
        private TrackBar barMsgIndex;
    }
}