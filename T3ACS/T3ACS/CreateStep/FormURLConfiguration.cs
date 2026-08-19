using T3ACS.Controls.Card;
using T3ACS.Model;

namespace T3ACS.StepDefault
{
    public partial class FormURLConfiguration : BaseForm
    {
        private FormLoadBrowserURL? _activeBrowserForm = null;

        public FormURLConfiguration()
        {
            InitializeComponent();

            this.BackColor = Color.FromArgb(15, 32, 39);
            flowLayoutPanelCards.BackColor = Color.FromArgb(15, 32, 39);
        }

        //private void FormURLConfiguration_Load(object sender, EventArgs e)
        //{
        //    // Only populate default mockup list if no cards are already added
        //    if (flowLayoutPanelCards.Controls.Count == 0)
        //    {
        //        AddCard("ACU", "http://192.168.0.1");
        //        AddCard("Modem", "http://192.168.0.2");
        //        AddCard("", "");
        //    }
        //}

        public void LoadData(List<URLViewModel> data)
        {
            flowLayoutPanelCards.Controls.Clear();
            if (data != null&&data.Count>0)
            { 
                foreach (var item in data)
                {
                    AddCard(item.Title, item.URL);
                }            
            }
        }

        private void btnAddUrl_Click(object sender, EventArgs e)
        {
            AddCard("", "");
        }

        private void AddCard(string label, string url)
        {
            var card = new CardURLConfig();
            card.LabelText = label;
            card.URLText = url;
            card.Width = flowLayoutPanelCards.Width - 25; // Leave room for vertical scrollbar

            // Wire up the delete event
            card.DeleteRequested += (s, ev) =>
            {
                flowLayoutPanelCards.Controls.Remove(card);
                card.Dispose();
                UpdateCardIndices();
            };

            // Wire up the check status event
            card.CheckStatusClicked += async (s, targetUrl) =>
            {
                // Set checking state in UI
                card.SetStatus(CardURLConfig.StatusState.Checking, "Checking connection...");

                // Open or add tab to the active browser form (1280x700)
                try
                {
                    if (_activeBrowserForm == null || _activeBrowserForm.IsDisposed)
                    {
                        _activeBrowserForm = new FormLoadBrowserURL();
                        _activeBrowserForm.Show();
                    }

                    // Use the card's label name as the tab title, default to URL if empty
                    string tabTitle = string.IsNullOrWhiteSpace(card.LabelText) ? "New Tab" : card.LabelText;
                    _activeBrowserForm.AddTab(tabTitle, targetUrl);
                    _activeBrowserForm.BringToFront();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Could not open browser: {ex.Message}", "Browser Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Asynchronously check connectivity in background
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
                    card.SetStatus(CardURLConfig.StatusState.Failed, "Connection failed — Unable to reach this address");
                }
            };

            flowLayoutPanelCards.Controls.Add(card);
            UpdateCardIndices();
            
            // Scroll to the bottom to show the newly added card if it goes off-screen
            flowLayoutPanelCards.ScrollControlIntoView(card);
        }

        private void flowLayoutPanelCards_SizeChanged(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanelCards.Controls)
            {
                if (control is CardURLConfig card)
                {
                    card.Width = flowLayoutPanelCards.Width - 25;
                }
            }
        }

        private void UpdateCardIndices()
        {
            int index = 1;
            foreach (Control control in flowLayoutPanelCards.Controls)
            {
                if (control is CardURLConfig card)
                {
                    card.Index = index++;
                }
            }
        }

        public void LoadUrlConfigs(List<UrlConfigItem> configs)
        {
            flowLayoutPanelCards.Controls.Clear();
            if (configs == null || configs.Count == 0)
            {
                AddCard("ACU", "http://192.168.0.1");
                AddCard("Modem", "http://192.168.0.2");
                AddCard("", "");
            }
            else
            {
                foreach (var config in configs)
                {
                    AddCard(config.Label, config.Url);
                }
                AddCard("", "");
            }
        }
        public bool CheckSave(out string mess)
        {
            mess = "";
            var check = true;
            var count = 0;
            foreach(CardURLConfig item in flowLayoutPanelCards.Controls)
            {
                if(item != null)
                {
                    if (string.IsNullOrEmpty(item.LabelText) || string.IsNullOrEmpty(item.URLText))
                    {
                        check=false;
                        mess = "You must enter all URL information before saving the step.";
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            if (check && count == 0) { 
                check = false;
                mess = "You must enter at least one URL before saving the step.";
            }
            return check;
        }
        public List<URLViewModel> SaveData()
        {
            List<URLViewModel> result = new List<URLViewModel>();
            foreach(CardURLConfig item in flowLayoutPanelCards.Controls)
            {
                URLViewModel url = new URLViewModel();
                url.URL = item.URLText;
                url.Title = item.LabelText;
                result.Add(url);
            }
            return result;
        }

        public List<UrlConfigItem> GetUrlConfigs()
        {
            var list = new List<UrlConfigItem>();
            foreach (Control control in flowLayoutPanelCards.Controls)
            {
                if (control is CardURLConfig card)
                {
                    // Ignore empty cards
                    if (!string.IsNullOrWhiteSpace(card.LabelText) || !string.IsNullOrWhiteSpace(card.URLText))
                    {
                        list.Add(new UrlConfigItem
                        {
                            Label = card.LabelText,
                            Url = card.URLText
                        });
                    }
                }
            }
            return list;
        }
    }

    public class UrlConfigItem
    {
        public string Label { get; set; }
        public string Url { get; set; }
    }
}
