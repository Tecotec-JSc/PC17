using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS.Controls.CardCustoms
{
    public partial class CardRadius : UserControl
    {
        public CardRadius()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
        #region Border
        // Vẽ viền
        [Category("Code Advance")]
        public int RadiusTopLeft { get; set; } = 5;
        [Category("Code Advance")]
        public int RadiusTopRight { get; set; } = 5;
        [Category("Code Advance")]
        public int RadiusBottomLeft { get; set; } = 5;
        [Category("Code Advance")]
        public int RadiusBottomRight { get; set; } = 5;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            GraphicsPath path = GetPath(rect);
            using (SolidBrush brush = new SolidBrush(BackColorG))
            {
                g.FillPath(brush, path);
            }

            using (Pen borderPen = new Pen(Color.FromArgb(30, borderColor), BorderSize))
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

        public Font FontTexts
        {
            get { return label1.Font; }
            set { label1.Font = value; }
        }
        public int BorderSize { get; set; } = 1;
        private Color borderColor = Color.DarkGray;
        #endregion
        #region hover    
        private Color originalColor = Color.White;
        [Category("Code Advance")]
        public bool HoverG { get { return hover; } set { hover = value; } }
        private bool hover = true;
        private void UserControl_MouseEnter(object sender, EventArgs e)
        {
            if (hover)
            {

                _hover = true;
                this.BackColor = DarkerColor(originalColor, 0.90f); // giảm 15%
                label1.BackColor = DarkerColor(originalColor, 0.90f);
            }


        }
        public bool _hover;
        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            if (hover)
            {
                _hover = false;
                this.BackColor = originalColor;
                label1.BackColor = originalColor;
            }   

        }
        private Color DarkerColor(Color color, float factor)
        {
            return Color.FromArgb(
                color.A,
                (int)(color.R * factor),
                (int)(color.G * factor),
                (int)(color.B * factor)
            );
        }
        #endregion

        [Category("Code Advance")]
        public string Texts
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }
        public event EventHandler _EventSelect;
        [Category("Code Advance")]
        public ContentAlignment TextAlign { get { return label1.TextAlign; } set { label1.TextAlign = value; } }
        [Category("Code Advance")]
        public Color ForeColorG { get { return label1.ForeColor; } set { label1.ForeColor = value; } }
        [Category("Code Advance")]
        public Font FontG { get { return label1.Font; } set { label1.Font = value; } }

        [Category("Code Advance")]
        public Color BackColorG { get { return label1.BackColor; } set { label1.BackColor = value; } }

        [Category("Code Advance")]
        public Color BorderColorG { get { return borderColor; } set { borderColor = value; } }
        private void label1_Click(object sender, EventArgs e)
        {
            _EventSelect?.Invoke(this, e);
        }
    }
}
