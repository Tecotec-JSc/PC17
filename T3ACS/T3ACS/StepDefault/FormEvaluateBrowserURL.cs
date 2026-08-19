using Newtonsoft.Json;
using T3ACS.Controls;
using T3ACS.Controls.Card;
using T3ACS.Model;
using T3.Configuration;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace T3ACS.StepDefault
{
    public partial class FormEvaluateBrowserURL : Form
    {

        private Point stickyControlOriginalLocation;
        public bool? _Maskdone;
        private List<ProcedureVariableViewModel>? _globalVariables;

        public FormEvaluateBrowserURL()
        {
            InitializeComponent();

            stickyControlOriginalLocation = new Point(12, 723);
            LoadButtonBot();
            panelForm.AutoScroll = true;
            panelForm.HorizontalScroll.Enabled = false;
            panelForm.HorizontalScroll.Visible = false;
            panelForm.AutoScrollMinSize = new Size(0, 804);
          //  this.panelForm.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelForm_MouseWheel);
        }

        private void panelForm_MouseWheel(object? sender, System.Windows.Forms.MouseEventArgs e)
        {
            panelStickBottom.Location = new Point(stickyControlOriginalLocation.X, stickyControlOriginalLocation.Y + this.AutoScrollPosition.Y);
        }

        private void FormEvaluate_Scroll(object sender, ScrollEventArgs e)
        {
            panelStickBottom.Location = new Point(stickyControlOriginalLocation.X, stickyControlOriginalLocation.Y + this.AutoScrollPosition.Y);
        }

        public void LoadButtonBot()
        {
            var pathApp = AppDomain.CurrentDomain.BaseDirectory + "Image\\btn\\";
            btnPass._ImageDefault = Image.FromFile(pathApp + "PassDefault.png");
            btnPass._ImageSelect = Image.FromFile(pathApp + "PassActive.png");
            btnPass._ImageDisable = Image.FromFile(pathApp + "PassDisable.png");
            btnPass.SetEnalbe(true);

            btnFailed._ImageDefault = Image.FromFile(pathApp + "FailedDefault.png");
            btnFailed._ImageSelect = Image.FromFile(pathApp + "FailedActive.png");
            btnFailed._ImageDisable = Image.FromFile(pathApp + "FailedDisable.png");
            btnFailed.SetEnalbe(true);

            btnExport._ImageDefault = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport._ImageSelect = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport._ImageDisable = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport.Cursor = Cursors.No;
            btnExport.SetEnalbe(false);

            btnQuit.Texts = "Quit";
            btnQuit.BorderColor = Color.FromArgb(0, 112, 203);
            btnQuit.ForeColor = Color.FromArgb(0, 112, 203);
        }

        public void LoadData(TableProcedureViewModel step)
        {

            _Maskdone = step.MaskDone;
            MaskDone();

            if (string.IsNullOrEmpty(step.Comment)) rtbNote.Texts = step.Comment;

            panelString.Controls.Clear();
            int heightNow = 0;
            int index = 1;
            foreach (var config in step.ListURL)
            {
                var card = new CardURLConfig();
                card.Index = index++;
                card.LabelText = config.Title;
                card.URLText = config.URL;
                card.IsReadOnly = true;
                card.IsCheckButtonVisible = false;
                card.Width = panelString.Width - 10;
                card.Margin = new Padding(1, 7, 1, 7);

                // Wire check status
                card.CheckStatusClicked += async (s, targetUrl) =>
                {
                    card.SetStatus(CardURLConfig.StatusState.Checking, "Checking connection...");
                    try
                    {
                        OpenBrowserTab(config.Title, targetUrl);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Could not open browser: {ex.Message}", "Browser Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    // Check status
                    try
                    {
                        var handler = new System.Net.Http.HttpClientHandler();
                        handler.ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true;

                        using (var client = new System.Net.Http.HttpClient(handler))
                        {
                            client.Timeout = TimeSpan.FromSeconds(5);
                            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36");
                            var response = await client.GetAsync(targetUrl);
                            card.SetStatus(CardURLConfig.StatusState.Success, "Connection successful");
                        }
                    }
                    catch (Exception)
                    {
                        card.SetStatus(CardURLConfig.StatusState.Failed, "Connection failed - Unable to reach this address");
                    }
                };

                panelString.Controls.Add(card);
                heightNow += card.Height + 14;
            }




            if (heightNow > 546)
            {
                panelString.Height = heightNow;
                panelHold.Location = new Point(panelStickBottom.Location.X, panelStickBottom.Location.Y + (heightNow - 546));
            }
            panelStickBottom.Location = new Point(12, 723);
        }

        private FormLoadBrowserURL? _activeBrowserForm = null;
        private void OpenBrowserTab(string tabTitle, string url)
        {
            if (_activeBrowserForm == null || _activeBrowserForm.IsDisposed)
            {
                _activeBrowserForm = new FormLoadBrowserURL();
                _activeBrowserForm.Show();
            }

            string title = string.IsNullOrWhiteSpace(tabTitle) ? "New Tab" : tabTitle;
            _activeBrowserForm.AddTab(title, url);
            _activeBrowserForm.BringToFront();
        }

        private void MaskDone()
        {
            if (_Maskdone.HasValue)
            {
                btnPass.SetValue(_Maskdone.Value);
                btnFailed.SetValue(!_Maskdone.Value);
            }
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            _Maskdone = true;
            MaskDone();
        }

        private void btnFailed_Click(object sender, EventArgs e)
        {
            _Maskdone = false;
            MaskDone();
        }
        public event EventHandler _StopProcedure;
        private void btnQuit_Click(object sender, EventArgs e)
        {
            // Close form if opened as dialog or container
            _StopProcedure?.Invoke(null, EventArgs.Empty);
        }

        public bool CheckSave(out string mess)
        {
            mess = "";
            return true;
        }
        public List<URLViewModel> _urls;
        public void SaveValue()
        {
            _urls = new List<URLViewModel>();
            foreach (CardURLConfig item in panelString.Controls)
            {
                URLViewModel newi = new URLViewModel();
                newi.Title = item.LabelText;
                newi.URL = item.URLText;
                _urls.Add(newi);
            }
        }

        public string GetNote()
        {
            return rtbNote.Texts;
        }
    }
}
