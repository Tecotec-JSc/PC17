using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Controls
{
    public class CheckBoxCustom : CheckBox
    {
        public int BoxSize { get; set; } = 20;
        public Color BoxBackColor { get; set; } = Color.White;
        public Color BoxBorderColor { get; set; } = Color.Transparent;
        public Color BoxBackCheckColor { get; set; } = Color.FromArgb(191,216,230);
        public Color CheckColor { get; set; } = Color.FromArgb(0,82,130);

        public CheckBoxCustom()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer, true);

            AutoSize = false;
            Size = new Size(20, 20);
            Text = "";
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.Clear(Parent.BackColor);

            Rectangle r = new Rectangle(0, 0, BoxSize - 1, BoxSize - 1);
            GraphicsPath path = GetPath(r);
            if(!Checked)
            using (SolidBrush br = new SolidBrush(BoxBackColor))
                e.Graphics.FillPath(br, path);
            else
                using (SolidBrush br = new SolidBrush(BoxBackCheckColor))
                    e.Graphics.FillPath(br, path);
            using (Pen pen = new Pen(BoxBorderColor)) 
                e.Graphics.DrawPath(pen, path);

            if (Checked)
            {
                using (Pen pen = new Pen(CheckColor, 2.2f))
                {
                    pen.StartCap = LineCap.Round;
                    pen.EndCap = LineCap.Round;
                    pen.LineJoin = LineJoin.Round;

                    Point p1 = new Point(BoxSize / 4, BoxSize / 2);
                    Point p2 = new Point(BoxSize / 2 - 1, BoxSize * 3 / 4);
                    Point p3 = new Point(BoxSize * 3 / 4, BoxSize / 4);

                    e.Graphics.DrawLines(pen, new[] { p1, p2, p3 });
                }
            }
        }

        private GraphicsPath GetPath(Rectangle r)
        {
            int tl = 3;
            int tr = 3;
            int bl = 3;
            int br = 3;

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
