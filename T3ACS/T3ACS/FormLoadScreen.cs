namespace VSat.Spectrum
{
    public partial class FormLoadScreen : Form
    {
        private int _progress = 0;
        public int Progress
        {
            get => _progress;
            set
            {
                _progress = Math.Max(0, Math.Min(100, value));
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        lblPercent.Text = $"{_progress}%";
                        panelFill.Width = (int)(panelTrack.Width * (_progress / 100.0));
                    }));
                }
            }
        }

        private string _statusText = "Initializing system...";
        public string StatusText
        {
            get => _statusText;
            set
            {
                _statusText = value ?? string.Empty;
                if (this.IsHandleCreated)
                {
                    this.BeginInvoke(new Action(() =>
                    {
                        lblStatus.Text = _statusText;
                    }));
                }
            }
        }

        public FormLoadScreen()
        {
            InitializeComponent();

            // Set form to borderless, center screen, and disable taskbar display
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = false;

            // Enable double buffering to avoid flickering
            this.DoubleBuffered = true;
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);

            // Run a background thread to simulate the loading process
            Task.Run(async () =>
            {
                string[] loadSteps = new string[]
                {
                    "Initializing system...",
                    "Loading dll libraries...",
                    "Connecting to spectrum...",
                    "Configuring channels...",
                    "System ready!"
                };

                for (int i = 0; i <= 100; i += 2)
                {
                    int stepIndex = Math.Min(i / 20, loadSteps.Length - 1);
                    this.StatusText = loadSteps[stepIndex];
                    this.Progress = i;
                    await Task.Delay(100); // 5s total load time
                }

                // Close the load screen on the UI thread
                this.BeginInvoke(new Action(() => this.Close()));
            });
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            // Calculate scale factors based on actual client size versus native image size (1920x1080)
            float scaleX = (float)this.ClientSize.Width / 1920.0f;
            float scaleY = (float)this.ClientSize.Height / 1080.0f;

            // 1. Cover the static progress bar and text in the background image.
            // In 1920x1080, clean background is at Y=720..765, static bar/text is at Y=670..715.
            if (this.BackgroundImage != null)
            {
                int destX = (int)(740 * scaleX);
                int destY = (int)(670 * scaleY);
                int width = (int)(440 * scaleX);
                int height = (int)(45 * scaleY);

                Rectangle srcRect = new Rectangle(
                    (int)(740.0f / 1920.0f * this.BackgroundImage.Width),
                    (int)(720.0f / 1080.0f * this.BackgroundImage.Height),
                    (int)(440.0f / 1920.0f * this.BackgroundImage.Width),
                    (int)(45.0f / 1080.0f * this.BackgroundImage.Height)
                );
                Rectangle destRect = new Rectangle(destX, destY, width, height);

                g.DrawImage(this.BackgroundImage, destRect, srcRect, GraphicsUnit.Pixel);
            }
        }
    }
}
