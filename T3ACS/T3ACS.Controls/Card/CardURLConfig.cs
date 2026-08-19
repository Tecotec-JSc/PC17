using System.Drawing.Drawing2D;

namespace T3ACS.Controls.Card
{
    public partial class CardURLConfig : UserControl
    {
        private int _index = 1;
        private StatusState _statusState = StatusState.Unchecked;
        private string _statusMessage = "";

        public event EventHandler DeleteRequested;
        public event EventHandler<string> CheckStatusClicked;

        public enum StatusState
        {
            Unchecked,
            Checking,
            Success,
            Failed
        }

        public int Index
        {
            get => _index;
            set
            {
                _index = value;
                lblTitle.Text = $"Web UI #{_index}";
            }
        }

        public string LabelText
        {
            get => txtLabel.Texts;
            set => txtLabel.Texts = value;
        }

        public string URLText
        {
            get => txtUrl.Texts;
            set => txtUrl.Texts = value;
        }

        private bool _isReadOnly = false;
        public bool IsReadOnly
        {
            get => _isReadOnly;
            set
            {
                _isReadOnly = value;
                txtLabel.ReadOnly = _isReadOnly;
                txtUrl.ReadOnly = _isReadOnly;
                btnClose.Visible = !_isReadOnly;
            }
        }

        public bool IsCheckButtonVisible
        {
            get => btnCheck.Visible;
            set
            {
                btnCheck.Visible = value;
                OnResize(EventArgs.Empty);
            }
        }

        public CardURLConfig()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        private void CardURLConfig_Load(object sender, EventArgs e)
        {
            lblAsterisk.Location = new Point(lblUrl.Right - 4, lblUrl.Top);
            OnResize(EventArgs.Empty);
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            DeleteRequested?.Invoke(this, EventArgs.Empty);
        }

        private void BtnClose_MouseEnter(object sender, EventArgs e)
        {
            btnClose.ForeColor = Color.Red;
        }

        private void BtnClose_MouseLeave(object sender, EventArgs e)
        {
            btnClose.ForeColor = Color.FromArgb(153, 166, 184);
        }

        private void BtnCheck_Click(object sender, EventArgs e)
        {
            string url = txtUrl.Texts.Trim();
            if (string.IsNullOrEmpty(url))
            {
                SetStatus(StatusState.Failed, "Connection failed — URL cannot be empty");
                return;
            }

            string targetUrl = url;
            if (!targetUrl.StartsWith("http://") && !targetUrl.StartsWith("https://"))
            {
                targetUrl = "http://" + targetUrl;
            }

            CheckStatusClicked?.Invoke(this, targetUrl);
        }

        public void SetStatus(StatusState state, string message)
        {
            _statusState = state;
            _statusMessage = message;
            panelStatus.Invalidate();
        }

        private void PanelStatus_Paint(object sender, PaintEventArgs e)
        {
            if (_statusState == StatusState.Unchecked)
                return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color drawColor = Color.White;
            bool isSuccess = false;
            bool isChecking = false;

            switch (_statusState)
            {
                case StatusState.Checking:
                    drawColor = Color.FromArgb(153, 166, 184);
                    isChecking = true;
                    break;
                case StatusState.Success:
                    drawColor = Color.FromArgb(46, 196, 182);
                    isSuccess = true;
                    break;
                case StatusState.Failed:
                    drawColor = Color.FromArgb(231, 76, 60);
                    break;
            }

            // Draw circle outline
            using (Pen pen = new Pen(drawColor, 1.8f))
            {
                g.DrawEllipse(pen, 2, 4, 16, 16);
            }

            if (isChecking)
            {
                using (SolidBrush brush = new SolidBrush(drawColor))
                {
                    g.FillEllipse(brush, 8, 10, 4, 4);
                }
            }
            else if (isSuccess)
            {
                using (Pen pen = new Pen(drawColor, 1.8f))
                {
                    g.DrawLine(pen, 6, 12, 9, 15);
                    g.DrawLine(pen, 9, 15, 14, 9);
                }
            }
            else
            {
                using (Pen pen = new Pen(drawColor, 1.8f))
                {
                    g.DrawLine(pen, 6, 8, 14, 16);
                    g.DrawLine(pen, 14, 8, 6, 16);
                }
            }

            using (SolidBrush textBrush = new SolidBrush(drawColor))
            {
                using (Font font = new Font("Segoe UI", 9.5F, FontStyle.Regular))
                {
                    g.DrawString(_statusMessage, font, textBrush, 26, 3);
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color borderColor = Color.FromArgb(14, 82, 98);
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);

            int radius = 6;
            using (GraphicsPath path = GetFigurePath(rect, radius))
            {
                using (SolidBrush brush = new SolidBrush(this.BackColor))
                {
                    g.FillPath(brush, path);
                }
                using (Pen pen = new Pen(borderColor, 1.0f))
                {
                    g.DrawPath(pen, path);
                }
            }
        }

        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            
            float scale = this.DeviceDpi / 96f;
            int rightMargin = (int)(25 * scale);
            int gap = (int)(15 * scale);
            int btnWidth = (int)(110 * scale);
            int btnLeft = this.Width - btnWidth - rightMargin;

            if (btnClose != null)
            {
                int closeRightMargin = (int)(30 * scale);
                btnClose.Location = new Point(this.Width - closeRightMargin, 10);
            }
            if (btnCheck != null)
            {
                btnCheck.Width = btnWidth; // Explicitly enforce scaled width
                btnCheck.Location = new Point(btnLeft, 65);
            }
            if (txtUrl != null)
            {
                if (btnCheck != null && btnCheck.Visible)
                {
                    txtUrl.Width = btnLeft - txtUrl.Left - gap;
                }
                else
                {
                    txtUrl.Width = this.Width - txtUrl.Left - (int)(30 * scale);
                }
            }
            if (panelStatus != null)
            {
                panelStatus.Width = this.Width - (int)(30 * scale);
            }
        }

        private void btnCheck_Click_1(object sender, EventArgs e)
        {

        }
    }
}
