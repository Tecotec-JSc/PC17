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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;

namespace T3ACS.Controls
{
    public partial class ButtonActionControl : UserControl
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
        private Image iconDefault/*=Properties.Resources.iconStopDefault*/;
        private Image iconSelect/* = Properties.Resources.iconStopActive*/;
        private Image iconDisable/* = Properties.Resources.iconStopDisable*/;
        private int borderRadius = 5;
        public bool _Enable;
        public event EventHandler _ClickControl;
        public ButtonActionControl()
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

        private void ButtonActionControl_Click(object sender, EventArgs e)
        {
            if (_Enable)
            {
                SelectControl(true);
                ClickControl();
            }         
        }
        public void SelectControl(bool value)
        {
            isSelected = value;
            this.Invalidate();
        }

        private void ButtonActionControl_Enter(object sender, EventArgs e)
        {
            if (_Enable)
                Entert();
        }
        private void ClickControl()
        {
            _ClickControl?.Invoke(this, EventArgs.Empty);
        }
        private void ButtonActionControl_Leave(object sender, EventArgs e)
        {
            if (_Enable)
                Leavet();
        }
        private void Entert()
        {
            if (!isSelected)
            {
                lblIcon.Image = iconSelect;
            }
          
        }
        private void Leavet()
        {
            if (!isSelected)
            {
                lblIcon.Image = iconDefault;
            }
        }
        [Category("RJ Code Advance")]
        public string Texts
        {
            get
            {
                return lblContent.Text;

            }
            set
            {
                lblContent.Text = value;
            }
        }
        [Category("RJ Code Advance")]
        public Color ForeColors
        {
            get { return foreColor; }
            set
            {
                foreColor = value;
                lblContent.ForeColor = value;
            }
        }
        public void SetEnalbled(bool value)
        {
            _Enable=value;
            if (value)
            {
                lblContent.Cursor = Cursors.Hand;
                lblIcon.Cursor = Cursors.Hand;
                this.Cursor = Cursors.Hand;
                lblIcon.Image = iconDefault;
                lblContent.ForeColor = foreColor;
                lblContent.BackColor = BachColor;
                lblIcon.BackColor = BachColor;
                this.BackColor = BachColor;
            }
            else
            {
                lblContent.Cursor = Cursors.No;
                lblIcon.Cursor = Cursors.No;
                this.Cursor = Cursors.No;
                lblIcon.Image = iconDisable;
                lblContent.ForeColor = Color.Black;
                lblContent.BackColor = BachColorDisable;
                lblIcon.BackColor = BachColorDisable;
                this.BackColor = BachColorDisable;
            }
        }
        [Category("RJ Code Advance")]
        public Image IconDefault
        {
            get
            {
                return iconDefault;

            }
            set
            {
                iconDefault=value;
                lblIcon.Image = value;
            }
        }
        [Category("RJ Code Advance")]
        public Image IconActive
        {
            get
            {
                return iconSelect;

            }
            set
            {
                iconSelect = value;
                lblIcon.Image = value;
            }
        }
        [Category("RJ Code Advance")]
        public Image IconDisable
        {
            get
            {
                return iconDisable;

            }
            set
            {
                iconDisable = value;
                lblIcon.Image = value;
            }
        }
    }
}
