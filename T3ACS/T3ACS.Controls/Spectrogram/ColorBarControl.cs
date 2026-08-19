using System;
using System.Drawing;
using System.Windows.Forms;

namespace T3ACS.Controls.Spectrogram
{
    public class ColorBarControl : Control
    {
        private double _dbMin = -120;
        private double _dbMax = -20;

        public double DbMin
        {
            get => _dbMin;
            set { _dbMin = value; Invalidate(); }
        }

        public double DbMax
        {
            get => _dbMax;
            set { _dbMax = value; Invalidate(); }
        }

        public ColorBarControl()
        {
            this.DoubleBuffered = true;
            this.Width = 70;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (Width <= 0 || Height <= 0)
                return;

            try
            {
                var g = e.Graphics;
                int width = this.Width;
                int height = this.Height;

                int barWidth = width - 5;

                for (int y = 0; y < height; y++)
                {
                    double fraction = height > 1 ? 1.0 - (double)y / (height - 1) : 0;
                    double dbm = DbMin + fraction * (DbMax - DbMin);

                    using (Pen pen = new Pen(GetColor(dbm)))
                    {
                        g.DrawLine(pen, 0, y, barWidth, y);
                    }
                }

                //using (Font font = new Font("Segoe UI", 9, FontStyle.Bold))
                //using (Brush brush = Brushes.Black)
                //{
                //    string topText = DbMax.ToString("F2");
                //    var topSize = g.MeasureString(topText, font);
                //    g.DrawString(topText, font, brush, (width - topSize.Width) / 2, 0);

                //    string bottomText = DbMin.ToString("F2");
                //    var bottomSize = g.MeasureString(bottomText, font);
                //    g.DrawString(bottomText, font, brush,
                //        (width - bottomSize.Width) / 2,
                //        height - bottomSize.Height);
                //}
            }
            catch
            {
                // tránh crash Designer
            }
        }


        private Color GetColor(double value)
        {
            value = Math.Max(DbMin, Math.Min(DbMax, value));

            var stops = new (double val, Color color)[]
            {
                (-120, Color.Blue),
                ( -90, Color.Cyan),
                ( -70, Color.Lime),
                ( -50, Color.Yellow),
                ( -20, Color.Red)
            };

            for (int i = 0; i < stops.Length - 1; i++)
            {
                if (value >= stops[i].val && value <= stops[i + 1].val)
                {
                    double t = (value - stops[i].val) /
                               (stops[i + 1].val - stops[i].val);

                    return Color.FromArgb(
                        (int)(stops[i].color.R + (stops[i + 1].color.R - stops[i].color.R) * t),
                        (int)(stops[i].color.G + (stops[i + 1].color.G - stops[i].color.G) * t),
                        (int)(stops[i].color.B + (stops[i + 1].color.B - stops[i].color.B) * t));
                }
            }

            return Color.Black;
        }
    }
}