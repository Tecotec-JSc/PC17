using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace T3ACS.Controls
{
    public partial class ButtonControl : UserControl
    {
        private Color borderColor1;
        private Color borderColor = Color.FromArgb(227, 242, 253);
        private Color borderFocusColor = Color.FromArgb(3, 120, 212);
        private Color backGround = Color.White;
        private Color hoverGround = Color.DarkGray;
        private Color foreColor = Color.FromArgb(0, 32, 77);
        private int borderSize = 1;
        private int borderRadius = 5;
        public event EventHandler btnClick;
        public ButtonControl()
        {
            InitializeComponent();
        }
        private GraphicsPath GetFigurePath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;

            if (borderRadius > 1)//Rounded TextBox
            {
                //-Fields
                var rectBorderSmooth = this.ClientRectangle;

                var rectBorder = Rectangle.Inflate(rectBorderSmooth, -borderSize, -borderSize);
                int smoothSize = borderSize > 0 ? borderSize : 1;

                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    //-Drawing
                    this.Region = new Region(pathBorderSmooth);//Set the rounded region of UserControl

                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    penBorder.Alignment = System.Drawing.Drawing2D.PenAlignment.Center;

                    //Draw border smoothing
                    graph.DrawPath(penBorderSmooth, pathBorderSmooth);
                    //Draw border
                    graph.DrawPath(penBorder, pathBorder);

                }
            }
            else //Square/Normal TextBox
            {
                //Draw border
                using (Pen penBorder = new Pen(borderColor, borderSize))
                {
                    this.Region = new Region(this.ClientRectangle);
                    graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
            }
        }

        private void label1_Enter(object sender, EventArgs e)
        {
            Entert();
        }
        private void Entert()
        {
            this.BackColor = hoverGround;
            lblbtn1.BackColor = hoverGround;
            this.borderColor = hoverGround;
        }
        private void Leavet()
        {
            this.BackColor = backGround;
            lblbtn1.BackColor = backGround;
            this.borderColor = borderColor1;
        }

        private void label1_Leave(object sender, EventArgs e)
        {
            Entert();
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            Entert();
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            Leavet();
        }

        private void lblbtn1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        [Category("RJ Code Advance")]
        public string Texts
        {
            get
            {
                return lblbtn1.Text;

            }
            set
            {
                lblbtn1.Text = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value;
                borderColor1 = value;
                this.Invalidate();
            }
        }

        [Category("RJ Code Advance")]
        public Color BorderFocusColor
        {
            get { return borderFocusColor; }
            set {
                borderFocusColor = value;
           
            }
        }

        [Category("RJ Code Advance")]
        public int BorderSize
        {
            get { return borderSize; }
            set
            {
                if (value >= 1)
                {
                    borderSize = value;
                    this.Invalidate();
                }
            }
        }

        [Category("RJ Code Advance")]
        public  Color BackColors
        {
            get { return backGround; }
            set
            {
                backGround = value;
                base.BackColor = value;
                lblbtn1.BackColor = value;
            }
        }

        [Category("RJ Code Advance")]
        public Color HoverColors
        {
            get { return hoverGround; }
            set
            {
                hoverGround = value;
            }
        }

        [Category("RJ Code Advance")]
        public  Color ForeColors
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                lblbtn1.ForeColor = value;
            }
        }
        [Category("RJ Code Advance")]
        public int BorderRadius
        {
            get { return borderRadius; }
            set
            {
                if (value >= 0)
                {
                    borderRadius = value;
                    this.Invalidate();//Redraw control
                }
            }
        }
    }
}
