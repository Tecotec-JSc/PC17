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

namespace T3ACS.Controls
{
    public partial class SelectCustomTypeButton : UserControl
    {
        public SelectCustomTypeButton()
        {
            InitializeComponent();
            _data= new List<string>();
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
        [Category("Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;

            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath path = GetPath(rect);
            if (hovered && hoverNow)
            {
                if (selected)
                {
                    using (SolidBrush brush = new SolidBrush(DarkerColor(selectedColor, 0.85f)))
                    {
                        g.FillPath(brush, path);
                    }
                    using (Pen borderPen = new Pen(DarkerColor(selectedColor, 0.85f), BorderSize))
                    {
                        borderPen.Alignment = PenAlignment.Inset;
                        g.DrawPath(borderPen, path);
                    }
                }
                else
                {
                    using (Pen borderPen = new Pen(borderColor, BorderSize))
                    {
                        borderPen.Alignment = PenAlignment.Inset;
                        g.DrawPath(borderPen, path);
                    }
                }
            }
            else
            {
                if (selected)
                {
                    using (SolidBrush brush = new SolidBrush(selectedColor))
                    {
                        g.FillPath(brush, path);
                    }
                    using (Pen borderPen = new Pen(selectedColor, BorderSize))
                    {
                        borderPen.Alignment = PenAlignment.Inset;
                        g.DrawPath(borderPen, path);
                    }
                }
                else
                {
                    using (Pen borderPen = new Pen(borderColor, BorderSize))
                    {
                        borderPen.Alignment = PenAlignment.Inset;
                        g.DrawPath(borderPen, path);
                    }
                }
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
        private Color selectedColor = Color.FromArgb(49, 102, 156);
        private Color backColor = Color.DarkGray;
        private Color borderColor = Color.DarkGray;
        public Font FontTexts
        {
            get { return label1.Font; }
            set { label1.Font = value; }
        }
        [Category("Code Advance")]
        public Color SelectedColor
        {
            get { return selectedColor; }
            set
            {
                selectedColor = value;
                if (selected)
                    label1.BackColor = value;
                Invalidate();
            }
        }
        [Category("Code Advance")]
        public Color BackGColor
        {
            get { return backColor; }
            set
            {
                backColor = value;
                if (!selected)
                    label1.BackColor = value;
                Invalidate();
            }
        }
        [Category("Code Advance")]

        public void ChangeSelect(bool select)
        {
            SelectedG = select;
            Invalidate();
            if (selected)
            {
                label1.BackColor = selectedColor;
                label1.ForeColor = forceColorSelect;
            }
            else
            {
                label1.BackColor = backColor;
                label1.ForeColor = forceColor;
            }

        }
        private Color forceColor;
        private Color forceColorSelect;

        public Color Forcolor
        {
            get { return forceColor; }
            set
            {
                forceColor = value;
                if (!selected)
                    lblContent.ForeColor = value;
                Invalidate();
            }
        }
        public Color ForcolorSelect
        {
            get { return forceColorSelect; }
            set
            {
                forceColorSelect = value;
                if (selected)
                {
                    lblContent.ForeColor = value;
                    Invalidate();
                }

            }
        }
        private bool selected = true;
        private bool hovered;
        [Category("Code Advance")]
        public bool SelectedG { get { return selected; } set { selected = value; } }
        [Category("Code Advance")]
        public bool HoverG { get { return hovered; } set { hovered = value; } }
        [Category("Code Advance")]
        public int BorderSize { get; set; } = 1;
        #endregion

        #region hover    
        private Color originalColor;
        private bool hoverNow;
        private void UserControl_MouseEnter(object sender, EventArgs e)
        {
            if (hovered)
            {
                hoverNow = true;
                if (selected)
                {
                    label1.BackColor = DarkerColor(selectedColor, 0.85f); // giảm 15%
                }
                else
                {

                    label1.BackColor = DarkerColor(originalColor, 0.85f); // giảm 15%
                }
                Invalidate();
            }

        }
        public bool _hover;
        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            if (hovered)
            {
                hoverNow = false;
                if (selected)
                {
                    label1.BackColor = selectedColor;
                }
                else
                {
                    label1.BackColor = originalColor;
                }
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

        #region Data select
        public List<string> _data;
        public string _title;
        public void SetData(List<string> data, string Title)
        {
            _data = data;
            _title = Title;
            lblContent.Text = _title;

        }
        public string[] Items { get { return _data.ToArray(); } set { _data = value.ToList(); } }
        public string Texts
        {
            get { return lblContent.Text; }
            set { lblContent.Text = value; }
        }
        FormDropDownPopUp popup;
        public event EventHandler _EventSelect;
        private void OpenPopup(object sender, EventArgs e)
        {
            popup = new FormDropDownPopUp(this.Width, _data);       
            popup._EventSelect += Popup_ItemSelected;
            var p = this.PointToScreen(new Point(0, this.Height +2));
            popup.Location = p;
            popup.Show();
            popup.BringToFront();
        }
        private void Popup_ItemSelected(object sender, EventArgs e)
        {
                  
                _EventSelect?.Invoke(sender.ToString(), e);
      

        }
        #endregion
    }
}