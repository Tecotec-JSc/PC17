using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace T3ACS.Controls
{
    public partial class ItemCheckListSelected : UserControl
    {
        public ItemCheckListSelected()
        {
            InitializeComponent();
        }
        int borderRadius = 5;
        int borderSize = 1;
        Color borderColor = Color.FromArgb(225, 223, 221);
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, -borderSize, -borderSize);

            using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, borderRadius - borderSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                this.Region = new Region(pathSurface);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                e.Graphics.DrawPath(penBorder, pathBorder);
            }
        }
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }
        public event EventHandler _Remove;
        private void ItemCheckListSelected_Load(object sender, EventArgs e)
        {

        }
        public string _Value;
        public void SetValue(string value)
        {
            _Value = value;
            label2.Text = _Value;
            Size size = TextRenderer.MeasureText(_Value, label2.Font);
            this.Width = 34 + size.Width;
            label2.Width= size.Width;
            Invalidate();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (_Remove != null)
                _Remove.Invoke(this, new EventArgs());
        }
    }
}
