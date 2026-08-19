using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace T3ACS.Controls
{
    public partial class CardSelect : UserControl
    {
        public CardSelect()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }
        public event EventHandler _EventSelect;
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
            var backcolorfill = _backColor;
            if (SelectedV) backcolorfill = ColorSelected;
            else if (hovered) backcolorfill = DarkerColor(_backColor, 0.85f);
            using (SolidBrush brush = new SolidBrush(backcolorfill))
            {

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
            get { return _backColor; }
            set
            {
                _backColor = value;
                lblCardContent.BackColor = _backColor;
                lblCardCheck.BackColor = _backColor;
                lblCardTitle.BackColor = _backColor;
                this.BackColor = _backColor;
                Invalidate();
            }
        }
        private Color _backColor = Color.White;

        #region hover    
        public bool HoverG { get { return hovered; } set { hovered = value; } }
        private Color originalColor;
        private bool hoverNow;
        private bool hovered;
        public Color HoverColor { get; set; }
        private void UserControl_MouseEnter(object sender, EventArgs e)
        {
            if (!SelectedV)
            {
                panelCardC = true;
                if (!hovered)
                {
                    hovered = true;
                    //  this.BackColor = DarkerColor(backColor, 0.85f);
                    lblCardContent.BackColor = DarkerColor(_backColor, 0.85f); // giảm 15%
                    lblCardCheck.BackColor = DarkerColor(_backColor, 0.85f); // giảm 15%
                    lblCardTitle.BackColor = DarkerColor(_backColor, 0.85f); // giảm 15%
                    Invalidate();
                }
            }
        }
        public bool _hover;
        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            if (!SelectedV)
            {
                panelCardC = false;
                if (hovered)
                {
                    hovered = false;
                    //    this.BackColor = backColor;
                    lblCardCheck.BackColor = _backColor;
                    lblCardContent.BackColor = _backColor;
                    lblCardTitle.BackColor = _backColor;

                    Invalidate();
                }
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

        public Color ColorSelected { get; set; } = Color.FromArgb(232, 232, 232);


        public bool SelectedV;
        private bool panelCardC, panelCardNCC;
        private bool lbltitleCardC;
        private bool lbldescriptionCardC;
        private bool lblCheckCardC;
        private bool cardSelectC;

        private Color titleColor;
        private Color descriptionColor;

        [Category("RJ Code Advance")]
        public Color TitleColor
        {
            get { return this.titleColor; }
            set
            {
                this.titleColor = value;
                lblCardTitle.ForeColor = value;
            }
        }
        [Category("RJ Code Advance")]
        public Color ContentColor
        {
            get { return this.descriptionColor; }
            set
            {
                this.descriptionColor = value;
                lblCardContent.ForeColor = value;
            }
        }
        private bool borderhight;
 

        private void clickCard(object sender, EventArgs e)
        {
            if (!SelectedV)
            {
                SelectedV = true;
                // lblCardTitle.ForeColor = Color.FromArgb(3, 120, 212);
                lblCardCheck.Image = Properties.Resources.Checked;
                lblCardTitle.BackColor = ColorSelected;
                lblCardContent.BackColor = ColorSelected;
                lblCardCheck.BackColor = ColorSelected;               
                Invalidate();
            }
            _EventSelect?.Invoke(this, e);
        }
       
        public void DeSelected()
        {
            SelectedV = false;
            // lblCardTitle.ForeColor = titleColor;
            lblCardCheck.Image = Properties.Resources.NotChecked;
            lblCardTitle.BackColor = _backColor;
            lblCardContent.BackColor = _backColor;
            lblCardCheck.BackColor = _backColor;
            hovered= false;
            Invalidate();
        }
        public void SetValue(string title, string content)
        {
            lblCardTitle.Text = title;
            lblCardContent.Text = content;
        }


     
    }
}
