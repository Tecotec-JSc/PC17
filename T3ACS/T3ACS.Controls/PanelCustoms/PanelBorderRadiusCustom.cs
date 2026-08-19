using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using T3.Configuration;
using T3ACS.Model.Interface;

namespace T3ACS.Controls
{
    public class PanelBorderRadiusCustom : Panel, IThemeSupport
    {
        public void ApplyTheme()
        {
            BackColorG =ThemeManager.GetColorBy(BackColorG, 0);         
            BorderColor = ThemeManager.GetColorBy(BorderColor, 2);
            Invalidate();
        }     
        // danh sách các điểm X để vẽ line dọc
        public List<int> VerticalPoints { get; set; } = new List<int>();
        protected override void OnScroll(ScrollEventArgs se)
        {
            base.OnScroll(se);
            Invalidate();
        }
        public PanelBorderRadiusCustom()
        {
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
        public Color BorderColor { get; set; } = Color.FromArgb(14, 82, 98);
        [Category("Border Advance")]
        public int BorderSize { get; set; } = 1;
        private Color placeholderColor = Color.FromArgb(153, 166, 184);
        private Color backColor = Color.White;
        public Color BackColorG
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = ClientRectangle;
            rect.Width--;
            rect.Height--;

            using (GraphicsPath path = GetPath(rect))
            {
                using (SolidBrush brush = new SolidBrush(backColor))
                {
                    g.FillPath(brush, path);
                }

                if(BorderSize > 0)
                {
                    using (Pen pen = new Pen(BorderColor, BorderSize))
                    {
                        pen.Alignment = PenAlignment.Inset;

                        g.DrawPath(pen, path);

                        foreach (int x in VerticalPoints)
                        {
                            g.DrawLine(pen, x, 0, x, Height);
                        }
                    }
                }
              
              
            }
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        private GraphicsPath GetPath(Rectangle r)
        {
            GraphicsPath gp = new GraphicsPath();

            int tl = Math.Min(RadiusTopLeft * 2, Math.Min(r.Width, r.Height));
            int tr = Math.Min(RadiusTopRight * 2, Math.Min(r.Width, r.Height));
            int br = Math.Min(RadiusBottomRight * 2, Math.Min(r.Width, r.Height));
            int bl = Math.Min(RadiusBottomLeft * 2, Math.Min(r.Width, r.Height));

            gp.StartFigure();

            // Top Left
            if (tl > 0)
                gp.AddArc(r.Left, r.Top, tl, tl, 180, 90);
            else
                gp.AddLine(r.Left, r.Top, r.Left, r.Top);

            // Top Right
            if (tr > 0)
                gp.AddArc(r.Right - tr, r.Top, tr, tr, 270, 90);
            else
                gp.AddLine(r.Right, r.Top, r.Right, r.Top);

            // Bottom Right
            if (br > 0)
                gp.AddArc(r.Right - br, r.Bottom - br, br, br, 0, 90);
            else
                gp.AddLine(r.Right, r.Bottom, r.Right, r.Bottom);

            // Bottom Left
            if (bl > 0)
                gp.AddArc(r.Left, r.Bottom - bl, bl, bl, 90, 90);
            else
                gp.AddLine(r.Left, r.Bottom, r.Left, r.Bottom);

            gp.CloseFigure();

            return gp;
        }
        #endregion


    }
}
