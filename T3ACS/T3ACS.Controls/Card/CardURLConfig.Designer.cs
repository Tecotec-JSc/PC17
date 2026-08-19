namespace T3ACS.Controls.Card
{
    partial class CardURLConfig
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblTitle = new Label();
            btnClose = new Label();
            lblLabel = new Label();
            txtLabel = new RJTextBox32();
            lblUrl = new Label();
            lblAsterisk = new Label();
            txtUrl = new RJTextBox32();
            btnCheck = new ButtonControl();
            panelStatus = new Panel();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(78, 19);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Web UI #1";
            // 
            // btnClose
            // 
            btnClose.AutoSize = true;
            btnClose.Cursor = Cursors.Hand;
            btnClose.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnClose.ForeColor = Color.FromArgb(153, 166, 184);
            btnClose.Location = new Point(850, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(22, 20);
            btnClose.TabIndex = 1;
            btnClose.Text = "✕";
            btnClose.Click += BtnClose_Click;
            btnClose.MouseEnter += BtnClose_MouseEnter;
            btnClose.MouseLeave += BtnClose_MouseLeave;
            // 
            // lblLabel
            // 
            lblLabel.AutoSize = true;
            lblLabel.Font = new Font("Segoe UI", 9.5F);
            lblLabel.ForeColor = Color.FromArgb(153, 166, 184);
            lblLabel.Location = new Point(15, 42);
            lblLabel.Name = "lblLabel";
            lblLabel.Size = new Size(39, 17);
            lblLabel.TabIndex = 2;
            lblLabel.Text = "Label";
            // 
            // txtLabel
            // 
            txtLabel.BackColor = Color.FromArgb(6, 16, 20);
            txtLabel.BorderColor = Color.FromArgb(14, 82, 98);
            txtLabel.BorderFocusColor = Color.FromArgb(0, 162, 194);
            txtLabel.BorderRadius = 4;
            txtLabel.BorderSize = 1;
            txtLabel.Font = new Font("Segoe UI Variable Display", 10.5F);
            txtLabel.ForeColor = Color.White;
            txtLabel.Location = new Point(15, 65);
            txtLabel.Margin = new Padding(4);
            txtLabel.Multiline = false;
            txtLabel.Name = "txtLabel";
            txtLabel.Padding = new Padding(10, 7, 10, 7);
            txtLabel.PasswordChar = false;
            txtLabel.PlaceholderColor = Color.FromArgb(80, 100, 110);
            txtLabel.PlaceholderText = "";
            txtLabel.ReadOnly = false;
            txtLabel.Size = new Size(180, 32);
            txtLabel.TabIndex = 3;
            txtLabel.Texts = "";
            txtLabel.UnderlinedStyle = false;
            // 
            // lblUrl
            // 
            lblUrl.AutoSize = true;
            lblUrl.Font = new Font("Segoe UI", 9.5F);
            lblUrl.ForeColor = Color.FromArgb(153, 166, 184);
            lblUrl.Location = new Point(210, 42);
            lblUrl.Name = "lblUrl";
            lblUrl.Size = new Size(31, 17);
            lblUrl.TabIndex = 4;
            lblUrl.Text = "URL";
            // 
            // lblAsterisk
            // 
            lblAsterisk.AutoSize = true;
            lblAsterisk.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            lblAsterisk.ForeColor = Color.Red;
            lblAsterisk.Location = new Point(241, 42);
            lblAsterisk.Name = "lblAsterisk";
            lblAsterisk.Size = new Size(14, 17);
            lblAsterisk.TabIndex = 5;
            lblAsterisk.Text = "*";
            // 
            // txtUrl
            // 
            txtUrl.BackColor = Color.FromArgb(6, 16, 20);
            txtUrl.BorderColor = Color.FromArgb(14, 82, 98);
            txtUrl.BorderFocusColor = Color.FromArgb(0, 162, 194);
            txtUrl.BorderRadius = 4;
            txtUrl.BorderSize = 1;
            txtUrl.Font = new Font("Segoe UI Variable Display", 10.5F);
            txtUrl.ForeColor = Color.White;
            txtUrl.Location = new Point(210, 65);
            txtUrl.Margin = new Padding(4);
            txtUrl.Multiline = false;
            txtUrl.Name = "txtUrl";
            txtUrl.Padding = new Padding(10, 7, 10, 7);
            txtUrl.PasswordChar = false;
            txtUrl.PlaceholderColor = Color.FromArgb(80, 100, 110);
            txtUrl.PlaceholderText = "";
            txtUrl.ReadOnly = false;
            txtUrl.Size = new Size(520, 32);
            txtUrl.TabIndex = 6;
            txtUrl.Texts = "";
            txtUrl.UnderlinedStyle = false;
            // 
            // btnCheck
            // 
            btnCheck.BackColor = Color.FromArgb(6, 16, 20);
            btnCheck.BackColors = Color.FromArgb(6, 16, 20);
            btnCheck.BorderColor = Color.FromArgb(14, 82, 98);
            btnCheck.BorderFocusColor = Color.FromArgb(3, 120, 212);
            btnCheck.BorderRadius = 4;
            btnCheck.BorderSize = 1;
            btnCheck.Font = new Font("Segoe UI Variable Text Semibold", 9.5F, FontStyle.Bold);
            btnCheck.ForeColors = Color.White;
            btnCheck.HoverColors = Color.FromArgb(14, 82, 98);
            btnCheck.Location = new Point(745, 65);
            btnCheck.Name = "btnCheck";
            btnCheck.Size = new Size(110, 32);
            btnCheck.TabIndex = 7;
            btnCheck.Texts = "Check Status";
            btnCheck.Click += BtnCheck_Click;
            // 
            // panelStatus
            // 
            panelStatus.Location = new Point(15, 105);
            panelStatus.Name = "panelStatus";
            panelStatus.Size = new Size(840, 25);
            panelStatus.TabIndex = 8;
            panelStatus.Paint += PanelStatus_Paint;
            // 
            // CardURLConfig
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 16, 20);
            Controls.Add(panelStatus);
            Controls.Add(btnCheck);
            Controls.Add(txtUrl);
            Controls.Add(lblAsterisk);
            Controls.Add(lblUrl);
            Controls.Add(txtLabel);
            Controls.Add(lblLabel);
            Controls.Add(btnClose);
            Controls.Add(lblTitle);
            Font = new Font("Segoe UI", 10.5F);
            Name = "CardURLConfig";
            Size = new Size(880, 140);
            Load += CardURLConfig_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;
        private Label btnClose;
        private Label lblLabel;
        private RJTextBox32 txtLabel;
        private Label lblUrl;
        private Label lblAsterisk;
        private RJTextBox32 txtUrl;
        private ButtonControl btnCheck;
        private Panel panelStatus;
    }
}
