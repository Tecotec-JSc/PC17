using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS.Controls
{ 
    public partial class SelectCustomD : UserControl
    {
        public SelectCustomD()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            _data= new List<string>();
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
        public Color BorderColor { get; set; } = Color.DarkGray;
        [Category("Border Advance")]
        public int BorderSize { get; set; } = 1;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            GraphicsPath path = GetPath(rect);
            var colorDraWBorder = BorderColor;
            //if (selected) colorDraWBorder = selectedBorderColor;
            using (Pen borderPen = new Pen(colorDraWBorder, BorderSize))
            {
                borderPen.Alignment = PenAlignment.Inset;
                g.DrawPath(borderPen, path);
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
        #endregion 
        private Color arrowColor = Color.FromArgb(0, 32, 77);

        [Category("Code Advance")]
        public Color ArrowColor
        {
            get => arrowColor;
            set
            {
                arrowColor = value;
                label2.Invalidate();
            }
        }

        public override Color ForeColor
        {
            get => base.ForeColor;
            set
            {
                base.ForeColor = value;
                lblContent.ForeColor = value;
                arrowColor = value;
                label2.Invalidate();
            }
        }

        private void label2_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(arrowColor, 1.5f))
            {
                Point[] points = new Point[]
                {
                    new Point(2, 6),
                    new Point(6, 10),
                    new Point(10, 6)
                };
                g.DrawLines(pen, points);
            }
        }

        public bool ShowArrow
        {
            get => label2.Visible;
            set
            {
                label2.Visible = value;
                if (!value)
                {
                    lblContent.Click -= OpenPopup;
                    label2.Click     -= OpenPopup;
                    this.Click       -= OpenPopup;
                }
            }
        }

        public List<string> _data;
        public string _title;
        public void SetData(List<string> data, string Title)
        {
            _data = data;
            _title= Title;
            lblContent.Text= _title;
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
            Rectangle screen = Screen.FromControl(this).WorkingArea;

            Point p = this.PointToScreen(new Point(0, this.Height));

            // Nếu phía dưới không đủ chỗ thì hiển thị lên trên
            if (p.Y + popup.Height > screen.Bottom)
            {
                p.Y = this.PointToScreen(Point.Empty).Y - popup.Height;
            }

            // Nếu phía trên cũng không đủ thì ép sát mép trên màn hình
            if (p.Y < screen.Top)
            {
                p.Y = screen.Top;
            }
            popup.Location = p;
            popup.Show();
            popup.BringToFront();
        }
        private void Popup_ItemSelected(object sender, EventArgs e)
        {
            if (sender != null)
            {
                lblContent.Text = sender.ToString();
                _title = sender.ToString();
                _EventSelect?.Invoke(_title, e);
            }
      
        }
    }
}
