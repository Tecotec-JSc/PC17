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
using System.Xml;

namespace T3ACS.Controls
{
    public partial class ACSTextSearch : UserControl
    {
        public ACSTextSearch()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint |
            ControlStyles.AllPaintingInWmPaint |
            ControlStyles.OptimizedDoubleBuffer |
            ControlStyles.ResizeRedraw, true);
            textBox1.Dock = DockStyle.None;
            textBox1.Location = new Point(28, 8);
            textBox1.Size = new Size(Width - 35, Height - 10);
            UpdateStyles();
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
 
        public Color BorderColorG { get; set; } = Color.FromArgb(14, 82, 98);
        [Category("Border Advance")]
        public int BorderSize { get; set; } = 1;
        private Color placeholderColor = Color.FromArgb(153, 166, 184);
        private Color backColor = Color.White;
        [Category("Code Advance")]
        public Color BackColorG
        {
            get { return backColor; }
            set
            {
                backColor = value;
                if(backColor != Color.Transparent)
                textBox1.BackColor = backColor;
                label1.BackColor = value;
                Invalidate();
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            if (Parent != null)
            {
                using (SolidBrush b = new SolidBrush(Parent.BackColor))
                {
                    g.FillRectangle(b, ClientRectangle);
                }
            }

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

                using (Pen pen = new Pen(BorderColorG, BorderSize))
                {
                    g.DrawPath(pen, path);
                }
            }
        }
    

        private GraphicsPath GetPath(Rectangle r)
        {
            GraphicsPath gp = new GraphicsPath();

            int tl = RadiusTopLeft * 2;
            int tr = RadiusTopRight * 2;
            int br = RadiusBottomRight * 2;
            int bl = RadiusBottomLeft * 2;

            gp.StartFigure();

            gp.AddArc(r.Left, r.Top, tl, tl, 180, 90);
            gp.AddArc(r.Right - tr, r.Top, tr, tr, 270, 90);
            gp.AddArc(r.Right - br, r.Bottom - br, br, br, 0, 90);
            gp.AddArc(r.Left, r.Bottom - bl, bl, bl, 90, 90);

            gp.CloseFigure();

            return gp;
        }
        #endregion
        private bool isFocused = false;
        public event EventHandler _TextChanged;
        private string placeholderText = "";
        private bool isPlaceholder = false;
        private Color foreColor = Color.White;
        //TextBox-> TextChanged event
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (_TextChanged != null)
                _TextChanged.Invoke(sender, e);
        }
        private void textBox1_Enter(object sender, EventArgs e)
        {
            isFocused = true;
            this.Invalidate();
            RemovePlaceholder();
        }
        private void textBox1_Leave(object sender, EventArgs e)
        {
            isFocused = false;
            this.Invalidate();
            SetPlaceholder();
        }
        private void RemovePlaceholder()
        {
            if (isPlaceholder && placeholderText != "")
            {
                isPlaceholder = false;
                textBox1.Text = "";
                textBox1.ForeColor = foreColor;             
            }
        }       

        [Category("RJ Code Advance")]
        public Color ForeColorG
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                textBox1.ForeColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public  Font FontG
        {
            get { return base.Font; }
            set
            {
                base.Font = value;
                textBox1.Font = value;               
            }
        }

        [Category("RJ Code Advance")]
        public string Texts
        {
            get
            {
                if (isPlaceholder) return "";
                else return textBox1.Text;
            }
            set
            {
                textBox1.Text = value;
                SetPlaceholder();
            }
        }
        [Category("RJ Code Advance")]
        public Color PlaceholderColor
        {
            get { return placeholderColor; }
            set
            {
                placeholderColor = value;
                if (isPlaceholder)
                    textBox1.ForeColor = value;
            }
        }
        private void SetPlaceholder()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) && placeholderText != "")
            {
                isPlaceholder = true;
                textBox1.Text = placeholderText;
                textBox1.ForeColor = placeholderColor;      
            }
        }
    }
}
