using System.ComponentModel;
using System.Drawing.Drawing2D;

namespace T3ACS.Controls
{
    public partial class RJEditor : UserControl
    {
        //Fields

        private Color borderFocusColor = Color.FromArgb(3, 120, 212);
        private bool underlinedStyle = false;
        private bool isFocused = false;
        private Color foreColor = Color.FromArgb(0, 32, 77);
        private int borderRadius = 5;
        private Color placeholderColor = Color.FromArgb(153, 166, 184);
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private bool isPasswordChar = false;
        public RJEditor()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }
        #region border
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
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath path = GetPath(rect);
            var colorDraWBorder = BorderColor;
            //if (selected) colorDraWBorder = selectedBorderColor;
            using (Pen borderPen = new Pen(colorDraWBorder, BorderSize))
            {
                borderPen.Alignment = PenAlignment.Inset;
                g.DrawPath(borderPen, path);
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

            // Top left
            if (tl > 0)
                path.AddArc(r.X, r.Y, tl * 2, tl * 2, 180, 90);
            else
                path.AddLine(r.X, r.Y, r.X, r.Y);

            // Top
            path.AddLine(r.X + tl, r.Y, r.Right - tr, r.Y);

            // Top right
            if (tr > 0)
                path.AddArc(r.Right - tr * 2, r.Y, tr * 2, tr * 2, 270, 90);

            // Right
            path.AddLine(r.Right, r.Y + tr, r.Right, r.Bottom - br);

            // Bottom right
            if (br > 0)
                path.AddArc(r.Right - br * 2, r.Bottom - br * 2, br * 2, br * 2, 0, 90);

            // Bottom
            path.AddLine(r.Right - br, r.Bottom, r.X + bl, r.Bottom);

            // Bottom left
            if (bl > 0)
                path.AddArc(r.X, r.Bottom - bl * 2, bl * 2, bl * 2, 90, 90);

            // Left
            path.AddLine(r.X, r.Bottom - bl, r.X, r.Y + tl);

            path.CloseFigure();

            return path;
        }
        #endregion


        #region -> Private methods
        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                richTextBox1.Text = placeholderText;
                richTextBox1.ForeColor = placeholderColor;

            }
        }
        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                richTextBox1.Text = "";
                richTextBox1.ForeColor = foreColor;
            }
        }



        #endregion


        [Category("RJ Code Advance")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set { borderFocusColor = value; }
        }



        [Category("RJ Code Advance")]
        public bool UnderlinedStyle
        {
            get { return underlinedStyle; }
            set
            {
                underlinedStyle = value;
                this.Invalidate();
            }
        }


        public void Paste()
        {
            richTextBox1.Paste();
        }


        [Category("RJ Code Advance")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                base.BackColor = value;
                richTextBox1.BackColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public override Color ForeColor
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                richTextBox1.ForeColor = value;
                Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public override Font Font
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                richTextBox1.Font = value;
            }
        }

        [Category("RJ Code Advance")]
        public string Rtf
        {
            get { return richTextBox1.Rtf; }
            set
            {
                try
                {
                    richTextBox1.Rtf = value;
                }
                catch
                {

                }

            }
        }


        [Category("RJ Code Advance")]
        public string Texts
        {
            get
            {
                if (isPlaceholder) return "";
                else return richTextBox1.Text;
            }
            set
            {

                if (string.IsNullOrEmpty(value))
                    SetPlaceholder();
                else
                {
                    isPlaceholder = false;
                    richTextBox1.Text = value;
                    richTextBox1.ForeColor = foreColor;
                }
            }
        }

        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();//Redraw control
                }
            }
        }

        [Category("RJ Code Advance")]
        public bool ReadOnly
        {
            get { return richTextBox1.ReadOnly; }
            set
            {
                richTextBox1.ReadOnly = value;
            }
        }
        [Category("RJ Code Advance")]
        public Color PlaceholderColor
        {
            get { return placeholderColor; }
            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                    richTextBox1.ForeColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public string PlaceholderText
        {
            get { return placeholderText; }
            set
            {
                placeholderText = value;
                richTextBox1.Text = "";
                SetPlaceholder();
            }
        }

        #region -> Overridden methods
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        #endregion
        //Default Event
        //public event EventHandler _TextChanged;
        ////TextBox-> TextChanged event
        //private void richTextBox1_TextChanged(object sender, EventArgs e)
        //{       
        //        _TextChanged.Invoke(sender, e);
        //}
        private void richTextBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceholder();
        }
        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }
        private void richTextBox1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
        private void richTextBox1_MouseEnter(object sender, EventArgs e)
        {
            this.OnMouseEnter(e);
        }
        private void richTextBox1_MouseLeave(object sender, EventArgs e)
        {
            this.OnMouseLeave(e);
        }
        private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
    }
}
