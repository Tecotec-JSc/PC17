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

namespace T3ACS.Controls.Card
{
    public partial class CardSelectBoolean : UserControl
    {
        private Color borderColor = Color.DarkGray;
        private Color borderFocusColor = Color.FromArgb(3, 120, 212);
        private int borderSize = 1;
        private bool isFocused = false;
        private bool isSelected = false;
        private Color foreColor = Color.FromArgb(0, 32, 77);
        private Color BachColor = Color.White;
        private Color BachColorHightlight = Color.FromArgb(0, 32, 77);
        private Color BachColorDisable = Color.FromArgb(204, 203, 203);
        private int borderRadius = 5;
        public bool _Enable;
        public bool? _Value;
        public event EventHandler _ClickControl;
        public CardSelectBoolean()
        {
            InitializeComponent();
            btnPass._ClickControl += clickPass;
            btnNottPass._ClickControl += clickNotPass;
            var pathApp = AppDomain.CurrentDomain.BaseDirectory + "Image\\btn\\";
            //btnBack
            SetImagae(Image.FromFile(pathApp + "btnPassDisable.png"), Image.FromFile(pathApp + "btnPassDefault.png"), Image.FromFile(pathApp + "btnPassHover.png"), Image.FromFile(pathApp + "btnPassActive.png"), Image.FromFile(pathApp + "btnNotPassDisable.png"), Image.FromFile(pathApp + "btnNotPassDefault.png"), Image.FromFile(pathApp + "btnNotPassHover.png"), Image.FromFile(pathApp + "btnNotPassActive.png"));
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
                Color ColorBorder;
                if (isSelected) ColorBorder = borderFocusColor;
                else ColorBorder = borderColor;
                using (GraphicsPath pathBorderSmooth = GetFigurePath(rectBorderSmooth, borderRadius))
                using (GraphicsPath pathBorder = GetFigurePath(rectBorder, borderRadius - borderSize))
                using (Pen penBorderSmooth = new Pen(this.Parent.BackColor, smoothSize))

                using (Pen penBorder = new Pen(ColorBorder, borderSize))
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

        public void SetValue(string text, bool?  value)
        {
           

            label1.Text = text;
            btnPass.SetEnable(true);
            btnNottPass.SetEnable(true);
            _Value= value;
            if (value.HasValue&& value.Value)
            {
                btnPass.SelectControl(true);
                btnNottPass.SelectControl(false);
            }else if(value.HasValue) 
            {
                btnPass.SelectControl(false);
                btnNottPass.SelectControl(true);
            }
        }
        public void SetImagae(Image PassDisable, Image PassDefault, Image PassHover, Image PassSelect, Image NotPassDisable, Image NotPassDefault, Image NotPassHover, Image NotPassSelect
)
        {
            btnPass.imageDisable = PassDisable;
            btnPass.imageDefault = PassDefault;
            btnPass.imageHover = PassHover;
            btnPass.imageSelect = PassSelect;
            btnNottPass.imageDisable = NotPassDisable;
            btnNottPass.imageDefault = NotPassDefault;
            btnNottPass.imageHover = NotPassHover;
            btnNottPass.imageSelect = NotPassSelect;
        }
        private void clickPass(object sender, EventArgs e)
        {
            _Value = true;
            btnPass.SelectControl(true );
            btnNottPass.SelectControl(false );
        }
        private void clickNotPass(object sender, EventArgs e)
        {
            _Value = false;
            btnPass.SelectControl(false);
            btnNottPass.SelectControl(true);
        }
       public string GetText()
        {
            return label1.Text;
        }
    }
}
