using Microsoft.Web.WebView2.WinForms;
using System.Runtime.InteropServices;

namespace T3ACS.StepDefault
{
    public partial class FormLoadBrowserURL : Form
    {
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        private List<TabItem> _tabs = new List<TabItem>();
        private TabItem? _activeTab = null;
        public FormLoadBrowserURL()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Allow form dragging on header panel
            panelHeader.MouseDown += PanelHeader_MouseDown;
        }

        private void BtnAddTabControl_Click(object sender, EventArgs e)
        {
            AddTab("New Tab", "https://www.google.com");
        }

        private void BtnAddTabControl_MouseEnter(object sender, EventArgs e)
        {
            btnAddTabControl.ForeColor = Color.White;
        }

        private void BtnAddTabControl_MouseLeave(object sender, EventArgs e)
        {
            btnAddTabControl.ForeColor = Color.FromArgb(153, 166, 184);
        }

        public void AddTab(string title, string url)
        {
            // Standardize URL
            string targetUrl = url.Trim();
            if (string.IsNullOrEmpty(targetUrl))
            {
                targetUrl = "about:blank";
            }
            else if (!targetUrl.StartsWith("http://") && !targetUrl.StartsWith("https://") && targetUrl != "about:blank")
            {
                targetUrl = "http://" + targetUrl;
            }

            // 1. Create a new TabPage for TabControl
            TabPage tabPage = new TabPage();
            tabPage.BackColor = Color.FromArgb(15, 32, 39);

            // Create WebView2
            WebView2 webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            tabPage.Controls.Add(webView);
            tabControlBrowser.TabPages.Add(tabPage);

            // 2. Create custom Tab Item Header
            TabItem tabItem = new TabItem(this, title, targetUrl, tabPage, webView);
            _tabs.Add(tabItem);

            // Update UI layout
            RenderTabs();
            SetActiveTab(tabItem);

            // Load WebView2 URL
            InitializeWebView(webView, targetUrl, tabItem);
        }

        private async void InitializeWebView(WebView2 webView, string url, TabItem tabItem)
        {
            try
            {
                string userDataFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "T3ACS", "WebView2");
                var env = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(null, userDataFolder);
                await webView.EnsureCoreWebView2Async(env);

                // Always bypass self-signed certificate warnings for local devices
                webView.CoreWebView2.ServerCertificateErrorDetected += (s, args) =>
                {
                    args.Action = Microsoft.Web.WebView2.Core.CoreWebView2ServerCertificateErrorAction.AlwaysAllow;
                };

                webView.Source = new Uri(url);
                webView.ZoomFactor = 0.8;

                // Wire navigation events to update UI
                webView.SourceChanged += (s, e) =>
                {
                    if (_activeTab == tabItem)
                    {
                        txtAddress.Texts = webView.Source.ToString();
                    }
                };

                webView.NavigationCompleted += (s, e) =>
                {
                    if (e.IsSuccess && webView.CoreWebView2 != null)
                    {
                        // Update tab title with page title
                        string docTitle = webView.CoreWebView2.DocumentTitle;
                        if (!string.IsNullOrEmpty(docTitle))
                        {
                            tabItem.Title = docTitle;
                        }
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"WebView2 failed to load: {ex.Message}");
            }
        }

        public void RemoveTab(TabItem tabItem)
        {
            // Remove from lists
            _tabs.Remove(tabItem);
            tabControlBrowser.TabPages.Remove(tabItem.TabPage);
            tabItem.WebView.Dispose();

            // Select another tab if we closed the active one
            if (_activeTab == tabItem)
            {
                if (_tabs.Count > 0)
                {
                    SetActiveTab(_tabs[_tabs.Count - 1]);
                }
                else
                {
                    _activeTab = null;
                    txtAddress.Texts = "";
                    this.Close(); // Close window if no tabs left
                }
            }

            RenderTabs();
        }

        public void SetActiveTab(TabItem tabItem)
        {
            _activeTab = tabItem;
            tabControlBrowser.SelectedTab = tabItem.TabPage;
            txtAddress.Texts = tabItem.WebView.Source?.ToString() ?? tabItem.Url;

            // Highlight active tab visually
            foreach (var tab in _tabs)
            {
                tab.IsActive = (tab == tabItem);
            }
        }

        private void RenderTabs()
        {
            flowLayoutPanelTabs.Controls.Clear();
            foreach (var tab in _tabs)
            {
                flowLayoutPanelTabs.Controls.Add(tab.HeaderControl);
            }
            flowLayoutPanelTabs.Controls.Add(btnAddTabControl);
        }

        private void TxtAddress_TextChanged(object sender, EventArgs e)
        {
            // Detect Enter key press in RJTextBox32 (uses standard KeyPress mapping, but we can hook into control manually if needed)
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Capture Enter key when editing address bar
            if (keyData == Keys.Enter && txtAddress.ContainsFocus)
            {
                string url = txtAddress.Texts.Trim();
                if (!string.IsNullOrEmpty(url) && _activeTab != null)
                {
                    if (!url.StartsWith("http://") && !url.StartsWith("https://") && url != "about:blank")
                    {
                        url = "http://" + url;
                    }
                    _activeTab.WebView.Source = new Uri(url);
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (_activeTab != null && _activeTab.WebView.CanGoBack)
            {
                _activeTab.WebView.GoBack();
            }
        }

        private void BtnForward_Click(object sender, EventArgs e)
        {
            if (_activeTab != null && _activeTab.WebView.CanGoForward)
            {
                _activeTab.WebView.GoForward();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (_activeTab != null)
            {
                _activeTab.WebView.Reload();
            }
        }

        private void NavigationButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl) lbl.ForeColor = Color.FromArgb(0, 162, 194);
        }

        private void NavigationButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl) lbl.ForeColor = Color.White;
        }

        private void LblWindowClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LblWindowClose_MouseEnter(object sender, EventArgs e)
        {
            lblWindowClose.ForeColor = Color.Red;
        }

        private void LblWindowClose_MouseLeave(object sender, EventArgs e)
        {
            lblWindowClose.ForeColor = Color.FromArgb(153, 166, 184);
        }

        private void PanelHeader_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, 0x112, 0xf012, 0);
            }
        }
    }

    // Helper class representing a single tab instance
    public class TabItem
    {
        private FormLoadBrowserURL _form;
        private string _title;
        private string _url;
        private TabPage _tabPage;
        private WebView2 _webView;
        private Panel _headerControl = null!;
        private Label _lblTitle = null!;
        private Label _lblCloseTab = null!;
        private bool _isActive;

        public TabPage TabPage => _tabPage;
        public WebView2 WebView => _webView;
        public string Url => _url;
        public Panel HeaderControl => _headerControl;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                // Limit title length to prevent overflow
                _lblTitle.Text = _title.Length > 16 ? _title.Substring(0, 14) + ".." : _title;
            }
        }

        public bool IsActive
        {
            get => _isActive;
            set
            {
                _isActive = value;
                _headerControl.BackColor = _isActive ? Color.FromArgb(15, 32, 39) : Color.FromArgb(6, 16, 20);
                _lblTitle.ForeColor = _isActive ? Color.White : Color.FromArgb(153, 166, 184);
            }
        }

        public TabItem(FormLoadBrowserURL form, string title, string url, TabPage tabPage, WebView2 webView)
        {
            _form = form;
            _title = title;
            _url = url;
            _tabPage = tabPage;
            _webView = webView;

            CreateHeaderControl();
        }

        private void CreateHeaderControl()
        {
            _headerControl = new Panel();
            _headerControl.Size = new Size(130, 40);
            _headerControl.BackColor = Color.FromArgb(6, 16, 20);
            _headerControl.Margin = new Padding(0);
            _headerControl.Cursor = Cursors.Hand;
            _headerControl.Click += (s, e) => _form.SetActiveTab(this);

            // Globe Icon
            Label lblIcon = new Label();
            lblIcon.Text = "🌐";
            lblIcon.Font = new Font("Segoe UI", 9F);
            lblIcon.ForeColor = Color.FromArgb(0, 162, 194);
            lblIcon.Size = new Size(20, 40);
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblIcon.Location = new Point(6, 0);
            lblIcon.Click += (s, e) => _form.SetActiveTab(this);
            _headerControl.Controls.Add(lblIcon);

            // Title Label
            _lblTitle = new Label();
            _lblTitle.Text = _title.Length > 12 ? _title.Substring(0, 10) + ".." : _title;
            _lblTitle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            _lblTitle.ForeColor = Color.FromArgb(153, 166, 184);
            _lblTitle.Size = new Size(76, 40);
            _lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            _lblTitle.Location = new Point(26, 0);
            _lblTitle.Click += (s, e) => _form.SetActiveTab(this);
            _headerControl.Controls.Add(_lblTitle);

            // Close Tab Label "x"
            _lblCloseTab = new Label();
            _lblCloseTab.Text = "✕";
            _lblCloseTab.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            _lblCloseTab.ForeColor = Color.FromArgb(153, 166, 184);
            _lblCloseTab.Size = new Size(22, 40);
            _lblCloseTab.TextAlign = ContentAlignment.MiddleCenter;
            _lblCloseTab.Location = new Point(102, 0);
            _lblCloseTab.Click += (s, e) => _form.RemoveTab(this);
            _lblCloseTab.MouseEnter += (s, e) => _lblCloseTab.ForeColor = Color.Red;
            _lblCloseTab.MouseLeave += (s, e) => _lblCloseTab.ForeColor = Color.FromArgb(153, 166, 184);
            _headerControl.Controls.Add(_lblCloseTab);

            // Hover effect on the entire tab panel and its children
            _headerControl.MouseEnter += (s, e) =>
            {
                if (!_isActive) _headerControl.BackColor = Color.FromArgb(10, 25, 30);
            };
            _headerControl.MouseLeave += (s, e) =>
            {
                if (!_isActive) _headerControl.BackColor = Color.FromArgb(6, 16, 20);
            };
            lblIcon.MouseEnter += (s, e) =>
            {
                if (!_isActive) _headerControl.BackColor = Color.FromArgb(10, 25, 30);
            };
            lblIcon.MouseLeave += (s, e) =>
            {
                if (!_isActive) _headerControl.BackColor = Color.FromArgb(6, 16, 20);
            };
            _lblTitle.MouseEnter += (s, e) =>
            {
                if (!_isActive) _headerControl.BackColor = Color.FromArgb(10, 25, 30);
            };
            _lblTitle.MouseLeave += (s, e) =>
            {
                if (!_isActive) _headerControl.BackColor = Color.FromArgb(6, 16, 20);
            };
        }
    }
}
