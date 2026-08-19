namespace T3ACS
{
    partial class FormBrowser
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
            panel1 = new Panel();
            panelAddressBar = new Panel();
            btnBack = new Label();
            btnForward = new Label();
            btnRefresh = new Label();
            txtAddress = new T3ACS.Controls.RJTextBox32();
            panelAddressBar.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Segoe UI Variable Text", 10.5F);
            panel1.ForeColor = Color.FromArgb(0, 32, 77);
            panel1.Location = new Point(0, 42);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(442, 774);
            panel1.TabIndex = 0;
            // 
            // panelAddressBar
            // 
            panelAddressBar.BackColor = Color.FromArgb(10, 25, 30);
            panelAddressBar.Controls.Add(btnBack);
            panelAddressBar.Controls.Add(btnForward);
            panelAddressBar.Controls.Add(btnRefresh);
            panelAddressBar.Controls.Add(txtAddress);
            panelAddressBar.Dock = DockStyle.Top;
            panelAddressBar.Location = new Point(0, 0);
            panelAddressBar.Name = "panelAddressBar";
            panelAddressBar.Size = new Size(442, 42);
            panelAddressBar.TabIndex = 1;
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(10, 10);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(25, 25);
            btnBack.TabIndex = 0;
            btnBack.Text = "←";
            btnBack.TextAlign = ContentAlignment.MiddleCenter;
            btnBack.Click += BtnBack_Click;
            btnBack.MouseEnter += NavigationButton_MouseEnter;
            btnBack.MouseLeave += NavigationButton_MouseLeave;
            // 
            // btnForward
            // 
            btnForward.Cursor = Cursors.Hand;
            btnForward.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnForward.ForeColor = Color.White;
            btnForward.Location = new Point(40, 10);
            btnForward.Name = "btnForward";
            btnForward.Size = new Size(25, 25);
            btnForward.TabIndex = 1;
            btnForward.Text = "→";
            btnForward.TextAlign = ContentAlignment.MiddleCenter;
            btnForward.Click += BtnForward_Click;
            btnForward.MouseEnter += NavigationButton_MouseEnter;
            btnForward.MouseLeave += NavigationButton_MouseLeave;
            // 
            // btnRefresh
            // 
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(70, 10);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(25, 25);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "↻";
            btnRefresh.TextAlign = ContentAlignment.MiddleCenter;
            btnRefresh.Click += BtnRefresh_Click;
            btnRefresh.MouseEnter += NavigationButton_MouseEnter;
            btnRefresh.MouseLeave += NavigationButton_MouseLeave;
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtAddress.BackColor = Color.FromArgb(6, 16, 20);
            txtAddress.BorderColor = Color.FromArgb(14, 82, 98);
            txtAddress.BorderFocusColor = Color.FromArgb(0, 162, 194);
            txtAddress.BorderRadius = 4;
            txtAddress.BorderSize = 1;
            txtAddress.Font = new Font("Segoe UI Variable Display", 10F);
            txtAddress.ForeColor = Color.White;
            txtAddress.Location = new Point(105, 7);
            txtAddress.Margin = new Padding(4);
            txtAddress.Multiline = false;
            txtAddress.Name = "txtAddress";
            txtAddress.Padding = new Padding(10, 5, 10, 5);
            txtAddress.PasswordChar = false;
            txtAddress.PlaceholderColor = Color.FromArgb(80, 100, 110);
            txtAddress.PlaceholderText = "";
            txtAddress.ReadOnly = false;
            txtAddress.Size = new Size(327, 28);
            txtAddress.TabIndex = 3;
            txtAddress.Texts = "";
            txtAddress.UnderlinedStyle = false;
            // 
            // FormBrowser
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 816);
            Controls.Add(panel1);
            Controls.Add(panelAddressBar);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormBrowser";
            Text = "FormBrowser";
            panelAddressBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panelAddressBar;
        private Label btnBack;
        private Label btnForward;
        private Label btnRefresh;
        private T3ACS.Controls.RJTextBox32 txtAddress;
    }
}