using System;
using System.Drawing;
using System.Windows.Forms;

namespace T3ACS.Controls
{
    public class VerticalChannelControl : Control
    {
        private double[] chY = new double[] { 6, 2, -2, -6 };
        private bool[] chEnable = new bool[] { true, true, true, true };
        private int draggingIndex = -1;

        public double YMin { get; set; } = -10;
        public double YMax { get; set; } = 10;

        public event Action<int, double> ChannelMoved;

        private readonly Color[] colors = new[]
        {
            Color.Yellow, Color.Cyan, Color.Magenta, Color.Lime
        };

        public VerticalChannelControl()
        {
            DoubleBuffered = true;
            BackColor = Color.Black;
            Width = 48;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            int H = Height;

            // trục
            using (var p = new Pen(Color.White, 1))
                g.DrawLine(p, Width - 1, 0, Width - 1, H);

            // tick (0.5 div)
            using (var p = new Pen(Color.FromArgb(120, Color.White), 1))
            {
                for (double y = YMin; y <= YMax; y += 0.5)
                {
                    float py = YToPixel(y);
                    g.DrawLine(p, Width - 6, py, Width, py);
                }
            }

            // markers
            for (int i = 0; i < 4; i++)
            {
                if (!chEnable[i]) continue;
                float y = YToPixel(chY[i]);

                PointF[] arrow =
                {
                    new PointF(0, y),
                    new PointF(12, y - 7),
                    new PointF(12, y + 7)
                };
                using (var b = new SolidBrush(colors[i]))
                    g.FillPolygon(b, arrow);

                var rect = new RectangleF(12, y - 9, 22, 18);
                using (var b = new SolidBrush(colors[i]))
                    g.FillRectangle(b, rect);

                using (var b = new SolidBrush(Color.Black))
                using (var f = new Font("Segoe UI", 8, FontStyle.Bold))
                {
                    var sf = new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                    g.DrawString((i + 1).ToString(), f, b, rect, sf);
                }
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                float py = YToPixel(chY[i]);
                if (Math.Abs(e.Y - py) < 10) { draggingIndex = i; return; }
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (draggingIndex < 0) return;

            double y = PixelToY(e.Y);
            y = Math.Max(YMin, Math.Min(YMax, y));
            chY[draggingIndex] = y;

            ChannelMoved?.Invoke(draggingIndex, y);
            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            draggingIndex = -1;
        }

        public void SetChannelY(int ch, double y) { chY[ch] = y; Invalidate(); }
        public void SetEnable(int ch, bool en) { chEnable[ch] = en; Invalidate(); }

        private float YToPixel(double y)
        {
            double r = (y - YMin) / (YMax - YMin);
            return (float)((1 - r) * Height);
        }
        private double PixelToY(float py)
        {
            double r = 1 - (py / Height);
            return YMin + r * (YMax - YMin);
        }
    }
}