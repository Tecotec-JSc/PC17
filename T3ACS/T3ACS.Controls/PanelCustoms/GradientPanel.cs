using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace T3ACS
{
    public class GradientPanel : Panel
    {
        public GradientPanel()
        {
            this.Width = 60;
            this.Height = 300;
            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = this.ClientRectangle;

            using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.Red, Color.Blue, 90f))
            {
                ColorBlend cb = new ColorBlend();

                cb.Colors = new Color[]
                {
                Color.Red,        // top
                Color.Yellow,
                Color.Lime,       // xanh lá
                Color.Cyan,
                Color.Blue        // bottom
                };

                cb.Positions = new float[]
                {
                0.0f,
                0.25f,
                0.5f,
                0.75f,
                1.0f
                };

                brush.InterpolationColors = cb;

                e.Graphics.FillRectangle(brush, rect);
            }
        }
    }
}
