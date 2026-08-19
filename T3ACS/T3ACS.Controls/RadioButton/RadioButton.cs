namespace T3ACS.Controls.RadioButton
{
    public class RadioButton : System.Windows.Forms.Control
    {
        public bool Checked { get; set; } = false;

        public Color CheckedColor { get; set; } = Color.FromArgb(0, 120, 215); // xanh
        public Color BorderColor { get; set; } = Color.Gray;

        public RadioButton()
        {
            this.Size = new Size(20, 20);
            this.DoubleBuffered = true;
            this.Cursor = Cursors.Hand;
        }

        protected override void OnClick(EventArgs e)
        {
            if (!Checked)
            {
                Checked = true;

                UncheckSiblings();
            }

            Invalidate();
            base.OnClick(e);
        }
        private void UncheckSiblings()
        {
            if (this.Parent == null) return;

            foreach (System.Windows.Forms.Control ctrl in this.Parent.Controls)
            {
                if (ctrl is RadioButton rb && rb != this)
                {
                    rb.Checked = false;
                    rb.Invalidate();
                }
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int size = Math.Min(Width, Height) - 2;
            Rectangle rect = new Rectangle(1, 1, size, size);

            if (Checked)
            {
                using (Brush brush = new SolidBrush(CheckedColor))
                    e.Graphics.FillEllipse(brush, rect);

                int innerSize = size / 2;
                Rectangle inner = new Rectangle(
                    rect.X + (size - innerSize) / 2,
                    rect.Y + (size - innerSize) / 2,
                    innerSize,
                    innerSize);

                e.Graphics.FillEllipse(Brushes.White, inner);
            }
            else
            {
                e.Graphics.FillEllipse(Brushes.White, rect);
                using (Pen pen = new Pen(BorderColor, 2))
                    e.Graphics.DrawEllipse(pen, rect);
            }
        }
    }
}
