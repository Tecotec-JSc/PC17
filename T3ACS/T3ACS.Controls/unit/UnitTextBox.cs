using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace T3ACS.Controls.unit
{

    public class UnitTextBox : UserControl
    {
        private Label lblContent;

        private T3ACS.FormDropDownPopUp popup;

        public string[] Items { get; set; }

        #region BORDER
        [Category("Border Advance")]
        public int RadiusTopLeft { get; set; } = 5;

        [Category("Border Advance")]
        public int RadiusTopRight { get; set; } = 5;

        [Category("Border Advance")]
        public int RadiusBottomLeft { get; set; } = 5;

        [Category("Border Advance")]
        public int RadiusBottomRight { get; set; } = 5;

        [Category("Border Advance")]
        public Color BorderColor { get; set; } = Color.DarkGray;

        [Category("Border Advance")]
        public int BorderSize { get; set; } = 1;
        #endregion

        public string Texts
        {
            get => lblContent.Text;
            set => lblContent.Text = value;
        }

        public int SelectedIndex
        {
            get
            {
                if (Items == null) return -1;
                return Array.IndexOf(Items, Texts);
            }
            set
            {
                if (Items == null) return;
                if (value >= 0 && value < Items.Length)
                    Texts = Items[value];
            }
        }

        public UnitTextBox()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        private void InitializeComponent()
        {
            lblContent = new Label();
            SuspendLayout();
            // 
            // lblContent
            // 
            lblContent.BackColor = Color.White;
            lblContent.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblContent.Location = new Point(10, 8);
            lblContent.Margin = new Padding(10, 0, 0, 0);
            lblContent.Name = "lblContent";
            lblContent.Padding = new Padding(0, 0, 0, 4);
            lblContent.Size = new Size(24, 16);
            lblContent.TabIndex = 1;
            lblContent.Text = "dB";
            lblContent.TextAlign = ContentAlignment.MiddleLeft;
            lblContent.Click += OpenPopup;
            // 
            // UnitTextBox
            // 
            BackColor = Color.White;
            Controls.Add(lblContent);
            Font = new Font("Segoe UI", 7.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            Margin = new Padding(0);
            Name = "UnitTextBox";
            Size = new Size(45, 28);
            Click += OpenPopup;
            ResumeLayout(false);
        }

        private void OpenPopup(object sender, EventArgs e)
        {
            if (Items == null || Items.Length == 0) return;

            popup = new T3ACS.FormDropDownPopUp(this.Width, new List<string>(Items));
            popup._EventSelect += (val, ev) =>
            {
                if (val != null)
                {
                    Texts = val.ToString();
                }
            };

            var p = this.PointToScreen(new Point(0, this.Height + 1));
            popup.Location = p;
            popup.Show();
            popup.BringToFront();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = GetPath(rect))
            using (Pen pen = new Pen(BorderColor, BorderSize))
            {
                pen.Alignment = PenAlignment.Inset;
                e.Graphics.DrawPath(pen, path);
            }
        }

        private GraphicsPath GetPath(Rectangle r)
        {
            int tl = RadiusTopLeft;
            int tr = RadiusTopRight;
            int bl = RadiusBottomLeft;
            int br = RadiusBottomRight;

            GraphicsPath path = new GraphicsPath();

            path.StartFigure();

            if (tl > 0)
                path.AddArc(r.X, r.Y, tl * 2, tl * 2, 180, 90);

            path.AddLine(r.X + tl, r.Y, r.Right - tr, r.Y);

            if (tr > 0)
                path.AddArc(r.Right - tr * 2, r.Y, tr * 2, tr * 2, 270, 90);

            path.AddLine(r.Right, r.Y + tr, r.Right, r.Bottom - br);

            if (br > 0)
                path.AddArc(r.Right - br * 2, r.Bottom - br * 2, br * 2, br * 2, 0, 90);

            path.AddLine(r.Right - br, r.Bottom, r.X + bl, r.Bottom);

            if (bl > 0)
                path.AddArc(r.X, r.Bottom - bl * 2, bl * 2, bl * 2, 90, 90);

            path.AddLine(r.X, r.Bottom - bl, r.X, r.Y + tl);

            path.CloseFigure();

            return path;
        }

        private GraphicsPath GetRoundPath(Rectangle r, int radius)
        {
            int d = radius * 2;
            GraphicsPath path = new GraphicsPath();

            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
    }
}
