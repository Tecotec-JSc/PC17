using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace T3ACS
{
    public partial class FormBrowser : Form
    {
        private WebView2 webView;
        public string _linkhtml;

        public FormBrowser(string linkhtml)
        {
            InitializeComponent();
            _linkhtml = linkhtml;
            webView = new WebView2();
            webView.Dock = DockStyle.Fill;
            panel1.Controls.Add(webView); 
            Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(async () =>
            {
                try
                {
                    // Diagnostic logging
                    try
                    {
                        var logLines = new List<string>();
                        logLines.Add($"--- FormBrowser Load Event ---");
                        logLines.Add($"Time: {DateTime.Now}");
                        logLines.Add($"FormBrowser: Size={this.Size}, ClientSize={this.ClientSize}, Visible={this.Visible}, Enabled={this.Enabled}");
                        logLines.Add($"Parent: Name={this.Parent?.Name}, Type={this.Parent?.GetType().FullName}, Visible={this.Parent?.Visible}");
                        logLines.Add($"panel1: Size={panel1.Size}, ClientSize={panel1.ClientSize}, Visible={panel1.Visible}");
                        logLines.Add($"webView: Size={webView.Size}, ClientSize={webView.ClientSize}, Visible={webView.Visible}, IsHandleCreated={webView.IsHandleCreated}");
                        logLines.Add($"URL: {_linkhtml}");
                        System.IO.File.WriteAllLines(@"d:\T3ACS\browser_log.txt", logLines);
                    }
                    catch { }

                    string userDataFolder = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "T3ACS", "WebView2");
                    var env = await Microsoft.Web.WebView2.Core.CoreWebView2Environment.CreateAsync(null, userDataFolder);
                    await webView.EnsureCoreWebView2Async(env);

                    // Always bypass self-signed certificate warnings for local devices
                    webView.CoreWebView2.ServerCertificateErrorDetected += (s, args) =>
                    {
                        args.Action = Microsoft.Web.WebView2.Core.CoreWebView2ServerCertificateErrorAction.AlwaysAllow;
                    };

                    string targetUrl = _linkhtml.Trim();
                    if (!targetUrl.StartsWith("http://") && !targetUrl.StartsWith("https://") && targetUrl != "about:blank")
                    {
                        targetUrl = "http://" + targetUrl;
                    }

                    webView.Source = new Uri(targetUrl);
                    webView.ZoomFactor = 0.8;

                    // Sync URL back to address bar on navigation
                    webView.SourceChanged += (s, args) =>
                    {
                        txtAddress.Texts = webView.Source?.ToString() ?? "";
                    };
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"FormBrowser WebView2 Error: {ex.Message}\nStack Trace:\n{ex.StackTrace}", "WebView2 Initialization Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            if (webView != null && webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void BtnForward_Click(object sender, EventArgs e)
        {
            if (webView != null && webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            if (webView != null)
            {
                panel1.Controls.Clear();
               
                webView = new WebView2();
                webView.Dock = DockStyle.Fill;
                Form1_Load(null,EventArgs.Empty) ;
                panel1.Controls.Add(webView);
                //webView.Reload();
            }
        }

        private void NavigationButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(0, 162, 194);
            }
        }

        private void NavigationButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.White;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && txtAddress.ContainsFocus)
            {
                string url = txtAddress.Texts.Trim();
                if (!string.IsNullOrEmpty(url) && webView != null)
                {
                    if (!url.StartsWith("http://") && !url.StartsWith("https://") && url != "about:blank")
                    {
                        url = "http://" + url;
                    }
                    try
                    {
                        webView.Source = new Uri(url);
                        _linkhtml=url;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Invalid URL: {ex.Message}");
                    }
                }
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
