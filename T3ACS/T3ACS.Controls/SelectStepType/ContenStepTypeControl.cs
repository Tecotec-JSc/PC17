using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace T3ACS.Controls
{
    public partial class ContenStepTypeControl : UserControl
    {
        private Color borderColor = Color.FromArgb(204,215,230);
        private Color backgroundColor = Color.White;
        private Color backgroundColorHover = Color.LightGray;
        private Color borderFocusColor = Color.FromArgb(3, 120, 212);

        private Color hoverGround = Color.DarkGray;
        private Color foreColor = Color.FromArgb(0, 32, 77);
        private int borderSize = 1;
        private int borderRadius = 0;
        public event EventHandler _ClickControl;
        public string StepType;
        public ContenStepTypeControl()
        {
            InitializeComponent();
            lblTextDescription.AutoSize = false;
            lblTextDescription.Width = this.Width - 67;
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
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (this.DesignMode)
                UpdateControlHeight();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateControlHeight();
        }

        private void UpdateControlHeight()
        {
            Size textSize = TextRenderer.MeasureText(
    lblTextDescription.Text,
            lblTextDescription.Font,
    new Size(lblTextDescription.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );

            lblTextDescription.Height = textSize.Height;
            this.Height = 65 + lblTextDescription.Height;
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

                    graph.DrawLine(penBorder, 0, this.Height - 1, this.Width, this.Height - 1);
                    // graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
                }
            }
        }
        [Category("Code Advance")]
        public string TextTitle
        {
            get
            {
                return lblDefaultTitle.Text;
            }
            set
            {
                lblDefaultTitle.Text = value;
            }
        }
        [Category("Code Advance")]
        public string TextContent
        {
            get
            {
                return lblTextDescription.Text;
            }
            set
            {
                lblTextDescription.Text = value;
                UpdateControlHeight();
            }
        }    
        public void SetValue(string name, string title, string content)
        {
            this.Name = name;
            StepType = title;
            lblDefaultTitle.Text = title;
            lblTextDescription.Text = content;
            UpdateControlHeight();
        }
        public string GroupName;

        private void ContenStepTypeControl_Click(object sender, EventArgs e)
        {
            if (!selectedG)
            {
                selectedG = true;
                _ClickControl?.Invoke(this, e);
            }
        }      
        private void hover(bool valueInput)
        {

            if (valueInput)
            {
                this.BackColor = backgroundColorHover;
                lblDefaultTitle.BackColor = backgroundColorHover;
                lblTextDescription.BackColor = backgroundColorHover;
            }
            else
            {
                this.BackColor = backgroundColor;
                lblDefaultTitle.BackColor = backgroundColor;
                lblTextDescription.BackColor = backgroundColor;

            }

        }

        private void HoverOn(object sender, EventArgs e)
        {
            hover(true);
        }

        private void HoverLeave(object sender, EventArgs e)
        {
            if (SelectedG)
                hover(true);
            else hover(false);
        }
        private bool selectedG;
        [Category("Code Advance")]
        public bool SelectedG
        {
            get
            {
                return selectedG;
            }
            set
            {
                selectedG = value;
                if (SelectedG)
                {
                    this.BackColor = backgroundColorHover;
                    lblDefaultTitle.BackColor = backgroundColorHover;
                    lblTextDescription.BackColor = backgroundColorHover;
                }
                else
                {
                    this.BackColor = backgroundColor;
                    lblDefaultTitle.BackColor = backgroundColor;
                    lblTextDescription.BackColor = backgroundColor;
                }
            }
        }
    }
}
