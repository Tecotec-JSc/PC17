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

namespace  T3ACS.Controls
{
    public partial class ParaControl : UserControl
    {
        private Color borderColor = Color.FromArgb(204, 215, 230);
        private Color borderFocusColor = Color.FromArgb(3, 120, 212);
        private Color backGround = Color.White;
        private Color hoverGround = Color.DarkGray;
        private Color foreColor = Color.FromArgb(0, 32, 77);
        private int borderSize = 1;
        private int borderRadius = 5;
        public ParaControl()
        {
            InitializeComponent();           
        }
        public void LoadData(string name,string title, string value, string rank)
        {
            this.Name= name;
            lblDefaultTitle.Text = title;
            lblTextName.Text ="Name: "+ name;
            lblTextValue.Text = value;
            lblTextRank.Text = rank;
            btnEdit.ForeColor = Color.FromArgb(0, 135, 214);
            btnRemove.ForeColor = Color.Red;
        }
        public event EventHandler EventEdit;
        public event EventHandler EventRemove;
        private void btnRemove_Click(object sender, EventArgs e)
        {
            EventRemove?.Invoke(this, EventArgs.Empty);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            EventEdit?.Invoke(this, EventArgs.Empty);
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
    }
}
