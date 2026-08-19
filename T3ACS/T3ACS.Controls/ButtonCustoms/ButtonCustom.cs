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
using T3.Configuration;
using T3ACS.Model.Interface;

namespace T3ACS.Controls.Buttons
{
    public partial class ButtonCustom : UserControl, IThemeSupport
    {
        public void ApplyTheme()
        {
            BackColorG = ThemeManager.GetColorBy(BackColorG, 0);
            BackColor = ThemeManager.GetColorBy(BackColor, 0);
            BorderColorG = ThemeManager.GetColorBy(BorderColorG, 2);
            HoverColor= ThemeManager.GetColorBy(HoverColor, 3);
            ForeColorG = ThemeManager.GetColorBy(ForeColorG,1);
            var imag = ThemeManager.GetImageBy(this.Name);
            if (imag != null) ImageAd = imag;
            Invalidate();
        }
        public ButtonCustom()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
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
        public Color BorderColorG { get; set; } = Color.DarkGray;
        [Category("Border Advance")]
        public int BorderSize { get; set; } = 1;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath path = GetPath(rect);
            var colorDraWBorder = BorderColorG;
            //if (selected) colorDraWBorder = selectedBorderColor;
            var backcolorfill = backColor;
            if (hovered) backcolorfill = hoverColor;
            using (SolidBrush brush = new SolidBrush(backcolorfill))
            {
                lblIcon.BackColor = backcolorfill;
                lblText.BackColor = backcolorfill;
                g.FillPath(brush, path);
             
            }
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
        [Category("Code Advance")]
        public Color BackColorG
        {
            get { return backColor; }
            set
            {
                backColor = value;
                lblIcon.BackColor = backColor;
                lblText.BackColor = backColor;
                Invalidate();
            }
        }
        private Color backColor = Color.White;

        #region hover    
        public bool HoverG { get { return hovered; } set { hovered = value; } }
        private Color originalColor;
        private bool hoverNow;
        private bool hovered;
        public Color HoverColor
        {
            get { return hoverColor; }
            set
            {
                hoverColor = value;            
                Invalidate();
            }
        }
        private Color hoverColor { get; set; } = Color.FromArgb(232, 232, 232);
        private void UserControl_MouseEnter(object sender, EventArgs e)
        {
            if (!hovered)
            {
                hovered = true;
              
                lblIcon.BackColor = hoverColor;
                lblText.BackColor = hoverColor;

                Invalidate();
            }

        }
        public bool _hover;
        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            if (hovered)
            {
                hovered = false;             
                lblIcon.BackColor = backColor;
                lblText.BackColor = backColor;
                Invalidate();
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
        #region Properties
        [Category("Code Advance")]
        public string Texts
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }
        public event EventHandler _EventSelect;
        [Category("Code Advance")]
        public ContentAlignment TextAlign { get { return lblText.TextAlign; } set { lblText.TextAlign = value; } }
        [Category("Code Advance")]
        public Color ForeColorG { get { return lblText.ForeColor; } set { lblText.ForeColor = value; } }
        [Category("Code Advance")]
        public Font FontG { get { return lblText.Font; } set { lblText.Font = value; } }

        [Category("Code Advance")]
        public Image ImageAd { get { return lblIcon.Image; } set { lblIcon.Image = value; } }


        [Category("Code Advance")]
        public Point TextLocation
        {
            get { return lblText.Location; }
            set {
                lblText.Location = value;              
            }
        }
        [Category("Code Advance")]
        public Size TextSizes
        {
            get { return lblText.Size; }
            set
            {
                lblText.Size = value;
            }
        }

        [Category("Code Advance")]
        public Point iConLocation
        {
            get { return lblIcon.Location; }
            set { lblIcon.Location = value; }
        }
        private bool _selected;

       
        #endregion

        private void All_Click(object sender, EventArgs e)
        {
            _EventSelect?.Invoke(this, EventArgs.Empty);
        }
    }
}
