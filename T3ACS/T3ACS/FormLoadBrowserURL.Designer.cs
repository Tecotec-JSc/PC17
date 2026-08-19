namespace T3ACS.StepDefault
{
    partial class FormLoadBrowserURL
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
            panelHeader = new Panel();
            flowLayoutPanelTabs = new FlowLayoutPanel();
            lblWindowClose = new Label();
            panelAddressBar = new Panel();
            btnBack = new Label();
            btnForward = new Label();
            btnRefresh = new Label();
            txtAddress = new T3ACS.Controls.RJTextBox32();
            tabControlBrowser = new TabControl();
            btnAddTabControl = new Label();
            panelHeader.SuspendLayout();
            panelAddressBar.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(6, 16, 20);
            panelHeader.Controls.Add(flowLayoutPanelTabs);
            panelHeader.Controls.Add(lblWindowClose);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1280, 40);
            panelHeader.TabIndex = 0;
            panelHeader.MouseDown += PanelHeader_MouseDown;
            // 
            // flowLayoutPanelTabs
            // 
            flowLayoutPanelTabs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelTabs.BackColor = Color.FromArgb(6, 16, 20);
            flowLayoutPanelTabs.Controls.Add(btnAddTabControl);
            flowLayoutPanelTabs.Location = new Point(0, 0);
            flowLayoutPanelTabs.Margin = new Padding(0);
            flowLayoutPanelTabs.Name = "flowLayoutPanelTabs";
            flowLayoutPanelTabs.Size = new Size(1230, 40);
            flowLayoutPanelTabs.TabIndex = 2;
            flowLayoutPanelTabs.WrapContents = false;
            flowLayoutPanelTabs.MouseDown += PanelHeader_MouseDown;
            // 
            // btnAddTabControl
            // 
            btnAddTabControl.Text = "＋";
            btnAddTabControl.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnAddTabControl.ForeColor = Color.FromArgb(153, 166, 184);
            btnAddTabControl.Size = new Size(32, 40);
            btnAddTabControl.TextAlign = ContentAlignment.MiddleCenter;
            btnAddTabControl.Cursor = Cursors.Hand;
            btnAddTabControl.Click += BtnAddTabControl_Click;
            btnAddTabControl.MouseEnter += BtnAddTabControl_MouseEnter;
            btnAddTabControl.MouseLeave += BtnAddTabControl_MouseLeave;
            // 
            // lblWindowClose
            // 
            lblWindowClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblWindowClose.AutoSize = true;
            lblWindowClose.Cursor = Cursors.Hand;
            lblWindowClose.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWindowClose.ForeColor = Color.FromArgb(153, 166, 184);
            lblWindowClose.Location = new Point(1248, 9);
            lblWindowClose.Name = "lblWindowClose";
            lblWindowClose.Size = new Size(20, 21);
            lblWindowClose.TabIndex = 0;
            lblWindowClose.Text = "✕";
            lblWindowClose.Click += LblWindowClose_Click;
            lblWindowClose.MouseEnter += LblWindowClose_MouseEnter;
            lblWindowClose.MouseLeave += LblWindowClose_MouseLeave;
            // 
            // panelAddressBar
            // 
            panelAddressBar.BackColor = Color.FromArgb(10, 25, 30);
            panelAddressBar.Controls.Add(btnBack);
            panelAddressBar.Controls.Add(btnForward);
            panelAddressBar.Controls.Add(btnRefresh);
            panelAddressBar.Controls.Add(txtAddress);
            panelAddressBar.Dock = DockStyle.Top;
            panelAddressBar.Location = new Point(0, 40);
            panelAddressBar.Name = "panelAddressBar";
            panelAddressBar.Size = new Size(1280, 42);
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
            txtAddress.Size = new Size(1160, 28);
            txtAddress.TabIndex = 3;
            txtAddress.Texts = "";
            txtAddress.UnderlinedStyle = false;
            // 
            // tabControlBrowser
            // 
            tabControlBrowser.Appearance = TabAppearance.FlatButtons;
            tabControlBrowser.Dock = DockStyle.Fill;
            tabControlBrowser.ItemSize = new Size(0, 1);
            tabControlBrowser.Location = new Point(0, 82);
            tabControlBrowser.Name = "tabControlBrowser";
            tabControlBrowser.SelectedIndex = 0;
            tabControlBrowser.Size = new Size(1280, 618);
            tabControlBrowser.SizeMode = TabSizeMode.Fixed;
            tabControlBrowser.TabIndex = 2;
            // 
            // FormLoadBrowserURL
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 32, 39);
            ClientSize = new Size(1280, 700);
            Controls.Add(tabControlBrowser);
            Controls.Add(panelAddressBar);
            Controls.Add(panelHeader);
            Font = new Font("Segoe UI", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormLoadBrowserURL";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Web UI Browser";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelAddressBar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHeader;
        private Label lblWindowClose;
        private FlowLayoutPanel flowLayoutPanelTabs;
        private Panel panelAddressBar;
        private Label btnBack;
        private Label btnForward;
        private Label btnRefresh;
        private T3ACS.Controls.RJTextBox32 txtAddress;
        private TabControl tabControlBrowser;
        private Label btnAddTabControl;
    }
}
