using System.Drawing.Drawing2D;

namespace T3ACS.Controls
{
    public class SelectCustomCH : UserControl
    {
        private Label lblContent;
        private Label label2;

        private List<string> _data = new List<string>();
        private string _title = "";

        private bool isHover = false;
        private bool isActive = false;

        private FormDropDownPopUp popup;

        public event EventHandler EventSelect;

        public SelectCustomCH()
        {
            InitUI();
            DoubleBuffered = true;

            this.MouseEnter += (s, e) => { isHover = true; Invalidate(); };
            this.MouseLeave += (s, e) => { isHover = false; Invalidate(); };

            foreach (Control ctl in Controls)
            {
                ctl.MouseEnter += (s, e) => { isHover = true; Invalidate(); };
                ctl.MouseLeave += (s, e) => { isHover = false; Invalidate(); };
                ctl.Click += OpenPopup;
            }

            this.Click += OpenPopup;
        }



        // ===== INIT UI =====
        private void InitUI()
        {
            this.Size = new Size(140, 24);
            this.BackColor = Color.Transparent;

            lblContent = new Label();
            lblContent.Text = "CH1";
            lblContent.Font = new Font("Segoe UI", 9F);
            lblContent.AutoSize = true;

            label2 = new Label();
            label2.Image = Properties.Resources.icon_Down;
            label2.Size = new Size(12, 12);

            Controls.Add(lblContent);
            Controls.Add(label2);

            UpdateLayoutUI();
        }

        // ===== FIX NULL + LAYOUT =====
        private void UpdateLayoutUI()
        {
            if (lblContent == null || label2 == null) return;

            lblContent.Location = new Point(
                28,
                (this.Height - lblContent.Height) / 2
            );

            label2.Location = new Point(
                this.Width - label2.Width - 6,
                (this.Height - label2.Height) / 2
            );
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            UpdateLayoutUI();
        }

        // ===== DATA =====
        public void SetData(List<string> data, string title)
        {
            _data = data ?? new List<string>();
            _title = title ?? "";

            lblContent.Text = _title;
            UpdateLayoutUI();
            Invalidate();
        }

        public string Texts
        {
            get => lblContent.Text;
            set
            {
                lblContent.Text = value;
                _title = value;
                UpdateLayoutUI();
                Invalidate();
            }
        }

        // ===== DRAW =====
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath path = GetRoundPath(rect, 6);

            Color back = Color.White;

            if (isActive)
                back = Color.FromArgb(235, 225, 180);
            else if (isHover)
                back = Color.FromArgb(245, 245, 245);

            using (SolidBrush br = new SolidBrush(back))
                g.FillPath(br, path);

            using (Pen pen = new Pen(isActive ? Color.Goldenrod : Color.DarkGray, 1))
                g.DrawPath(pen, path);

            // ===== DOT 12x12 =====
            Color dotColor = GetChannelColor(_title);

            Rectangle dotRect = new Rectangle(8, (Height - 12) / 2, 12, 12);

            using (SolidBrush br = new SolidBrush(dotColor))
                g.FillEllipse(br, dotRect);

            using (Pen p = new Pen(Color.White, 1))
                g.DrawEllipse(p, dotRect);
        }

        private GraphicsPath GetRoundPath(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(r.X, r.Y, radius, radius, 180, 90);
            path.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90);
            path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90);
            path.CloseFigure();

            return path;
        }

        // ===== COLOR =====
        private Color GetChannelColor(string ch)
        {
            if (string.IsNullOrEmpty(ch)) return Color.Gray;

            if (ch.Contains("1")) return Color.Gold;
            if (ch.Contains("2")) return Color.DeepSkyBlue;
            if (ch.Contains("3")) return Color.HotPink;
            if (ch.Contains("4")) return Color.LimeGreen;

            return Color.Gray;
        }

        // ===== POPUP =====
        private void OpenPopup(object sender, EventArgs e)
        {
            if (popup != null && !popup.IsDisposed) return;

            isActive = true;
            Invalidate();

            popup = new FormDropDownPopUp(this.Width, _data);

            popup.ItemSelected += (value) =>
            {
                Texts = value;
                EventSelect?.Invoke(this, EventArgs.Empty);
            };

            popup.FormClosed += (s, ev) =>
            {
                isActive = false;
                Invalidate();
            };

            var p = this.PointToScreen(new Point(0, this.Height + 2));
            popup.Location = p;
            popup.Show();
        }
        public int SelectedIndex
        {
            get
            {
                if (_data == null || string.IsNullOrEmpty(_title))
                    return -1;

                return _data.IndexOf(_title);
            }
            set
            {
                if (_data == null) return;

                if (value >= 0 && value < _data.Count)
                {
                    _title = _data[value];
                    lblContent.Text = _title;

                    Invalidate();
                }
            }
        }

        // ================= POPUP =================
        private class FormDropDownPopUp : Form
        {
            public event Action<string> ItemSelected;

            public FormDropDownPopUp(int width, List<string> data)
            {


                FormBorderStyle = FormBorderStyle.None;
                StartPosition = FormStartPosition.Manual;
                ShowInTaskbar = false;
                TopMost = true;

                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Dock = DockStyle.Fill;
                panel.FlowDirection = FlowDirection.TopDown;
                panel.WrapContents = false;
                panel.BackColor = Color.White;

                Controls.Add(panel);

                Width = width;
                Height = data.Count * 28 + 4;

                foreach (var item in data)
                    panel.Controls.Add(CreateItem(item));

                Deactivate += (s, e) => Close();
            }

            private Control CreateItem(string text)
            {
                Panel p = new Panel();
                p.Width = Width - 2;
                p.Height = 28;
                p.Margin = new Padding(0);

                // DOT
                Panel dot = new Panel();
                dot.Size = new Size(12, 12);
                dot.Location = new Point(10, (p.Height - 12) / 2);

                dot.Paint += (s, e) =>
                {
                    var g = e.Graphics;
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    using (SolidBrush br = new SolidBrush(GetChannelColor(text)))
                        g.FillEllipse(br, 0, 0, 12, 12);
                };

                // TEXT
                Label lbl = new Label();
                lbl.Text = text;
                lbl.AutoSize = true;
                lbl.Location = new Point(30, (p.Height - lbl.Height) / 2);

                p.Controls.Add(dot);
                p.Controls.Add(lbl);

                p.MouseEnter += (s, e) => p.BackColor = Color.FromArgb(240, 240, 240);
                p.MouseLeave += (s, e) => p.BackColor = Color.White;

                void click()
                {
                    ItemSelected?.Invoke(text);
                    Close();
                }

                p.Click += (s, e) => click();
                lbl.Click += (s, e) => click();
                dot.Click += (s, e) => click();

                return p;
            }

            private Color GetChannelColor(string ch)
            {
                if (ch.Contains("1")) return Color.Gold;
                if (ch.Contains("2")) return Color.DeepSkyBlue;
                if (ch.Contains("3")) return Color.HotPink;
                if (ch.Contains("4")) return Color.LimeGreen;
                return Color.Gray;
            }


        }
    }
}