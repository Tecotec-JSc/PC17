using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS
{
    public class CustomProgressBar : Control
    {
        private double _progress;

        public CustomProgressBar()
        {
            DoubleBuffered = true;
            ResizeRedraw = true;
            Height = 12;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            // Background
            using (GraphicsPath bgPath = GetRoundRect(rect, Height))
            using (SolidBrush bgBrush = new SolidBrush(Color.FromArgb(235, 235, 235)))
            {
                g.FillPath(bgBrush, bgPath);
            }

            int fillWidth = (int)(Width * _progress);

            if (fillWidth > 0)
            {
                Rectangle fillRect =
                    new Rectangle(0, 0, fillWidth, Height);

                using (GraphicsPath fillPath =
                       GetRoundRect(fillRect, Height))
                using (LinearGradientBrush brush =
                       new LinearGradientBrush(
                           fillRect,
                           Color.FromArgb(52, 152, 219),
                           Color.FromArgb(243, 120, 32),
                           LinearGradientMode.Horizontal))
                {
                    g.FillPath(brush, fillPath);
                }
            }
        }

        private GraphicsPath GetRoundRect(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddArc(r.X, r.Y, radius, radius, 180, 90);
            path.AddArc(r.Right - radius, r.Y, radius, radius, 270, 90);
            path.AddArc(r.Right - radius, r.Bottom - radius, radius, radius, 0, 90);
            path.AddArc(r.X, r.Bottom - radius, radius, radius, 90, 90);

            path.CloseFigure();

            return path;
        }

        /// <summary>
        /// Chạy từ 0 -> 100% trong durationMs
        /// </summary>
        public async Task StartLoadingAsync(int durationMs = 3000)
        {
            Stopwatch sw = Stopwatch.StartNew();

            while (sw.ElapsedMilliseconds < durationMs)
            {
                double t = sw.ElapsedMilliseconds / (double)durationMs;

                // EaseOutCubic cực mượt
                _progress = 1 - Math.Pow(1 - t, 3);

                Invalidate();

                await Task.Delay(16); // ~60 FPS
            }

            _progress = 1.0;
            Invalidate();
        }

        public void Reset()
        {
            _progress = 0;
            Invalidate();
        }
    }
}
