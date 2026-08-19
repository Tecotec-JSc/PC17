using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Controls.PanelCustoms
{
    public class flowpanelCustomShowScroll : FlowLayoutPanel
    {
        //Show scroll
        private const int SB_VERT = 1;
        private const int SB_HORZ = 0;
        private const int SB_BOTH = 3;

        private const int ESB_ENABLE_BOTH = 0x0;
        private const int ESB_DISABLE_BOTH = 0x3;

        [DllImport("user32.dll")]
        private static extern int ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);

        [DllImport("user32.dll")]
        private static extern int EnableScrollBar(IntPtr hWnd, int wSBflags, int wArrows);

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            ShowScrollBar(this.Handle, SB_VERT, true); // luôn hiện scroll dọc
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            bool needScroll = this.DisplayRectangle.Height > this.ClientSize.Height;

            // Enable hoặc disable scroll
            EnableScrollBar(this.Handle, SB_VERT,
                needScroll ? ESB_ENABLE_BOTH : ESB_DISABLE_BOTH);
        }
        //End scroll

        public int RadiusTopLeft { get; set; } = 5;
        public int RadiusTopRight { get; set; } = 5;
        public int RadiusBottomLeft { get; set; } = 5;
        public int RadiusBottomRight { get; set; } = 5;

        public Color BorderColor { get; set; } = Color.DarkGray;
        public int BorderSize { get; set; } = 1;

        // danh sách các điểm X để vẽ line dọc
        public List<int> VerticalPoints { get; set; } = new List<int>();

        public flowpanelCustomShowScroll()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath path = GetPath(rect);

            using (Pen borderPen = new Pen(BorderColor, BorderSize))
            {
                borderPen.Alignment = PenAlignment.Inset;
                g.DrawPath(borderPen, path);
            }

            // vẽ các line dọc theo danh sách point X
            using (Pen linePen = new Pen(BorderColor, 1))
            {
                foreach (int x in VerticalPoints)
                {
                    g.DrawLine(linePen, x, 0, x, Height);
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
    }
}
