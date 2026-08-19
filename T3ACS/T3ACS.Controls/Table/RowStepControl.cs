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
    public partial class RowStepControl : UserControl
    {
        private Color borderColor = Color.DarkGray;
        private Color backgroundColor = Color.White;
        private Color hightlightColor = Color.FromArgb(0, 82, 130);
        private Color textColor = Color.FromArgb(0, 32, 77);
        private Color hightlightTextColor = Color.White;
        private Color backgroundColorHover = Color.LightGray;
        public RowStepControl()
        {
            InitializeComponent();
            lblDefaultTitle.AutoSize = false;
            lblDefaultTitle.Width = this.Width - 40;
        }
        public int _NumberOrder;
        public void ChangeNumberOrder(int numberOrder)
        {
            _NumberOrder = numberOrder;
            var strText = lblDefaultTitle.Text;
            var contentText = lblDefaultTitle.Text.Substring(lblDefaultTitle.Text.IndexOf(".") + 1);
            lblDefaultTitle.Text = numberOrder + ". " + contentText;
        }
        public void SetValue(string stepName, string textTile, int numberOrder)
        {
            this.Name = stepName;
            _NumberOrder = numberOrder;
            lblDefaultTitle.Text = textTile;
            UpdateControlHeight();
        }
        public event EventHandler _ClickControl;
        public bool _Selected;
        public void SetText(string text)
        {
            lblDefaultTitle.Text = text;
            UpdateControlHeight();
        }
        private void UpdateControlHeight()
        {
            lblDefaultTitle.Width = this.Width - 40;
            Size textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblDefaultTitle.Font,
    new Size(lblDefaultTitle.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );

            lblDefaultTitle.Height = textSize.Height;
            this.Height = 24 + lblDefaultTitle.Height;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics graph = e.Graphics;
            //Draw border
            using (Pen penBorder = new Pen(borderColor, 1))
            {
                this.Region = new Region(this.ClientRectangle);

                graph.DrawLine(penBorder, 0, 0, this.Width, 0);
                // graph.DrawRectangle(penBorder, 0, 0, this.Width - 0.5F, this.Height - 0.5F);
            }
        }
        public void SetSelect(bool valueinput)
        {
            _Selected = valueinput;
            ChangeStyleSelect();
        }
        public void ChangeStyleSelect()
        {
            if (_Selected)
            {
                this.BackColor = hightlightColor;
                lblDefaultTitle.BackColor = hightlightColor;
                lblDefaultTitle.ForeColor = hightlightTextColor;
            }
            else
            {
                this.BackColor = backgroundColor;
                lblDefaultTitle.BackColor = backgroundColor;
                lblDefaultTitle.ForeColor = textColor;
            }
        }
        private void hover(bool valueInput)
        {
            if (!_Selected)
            {
                if (valueInput)
                {
                    this.BackColor = backgroundColorHover;
                    lblDefaultTitle.BackColor = backgroundColorHover;
                }
                else
                {
                    this.BackColor = backgroundColor;
                    lblDefaultTitle.BackColor = backgroundColor;

                }
            }
        }
        private void lblDefaultTitle_Click(object sender, EventArgs e)
        {
            _ClickControl?.Invoke(this, e);
        }

        private void RowStepControl_Click(object sender, EventArgs e)
        {
            _ClickControl?.Invoke(this, e);
        }

        private void lblDefaultTitle_Enter(object sender, EventArgs e)
        {
            hover(true);
        }

        private void lblDefaultTitle_Leave(object sender, EventArgs e)
        {
            hover(false);
        }

        private void lblDefaultTitle_MouseEnter(object sender, EventArgs e)
        {
            hover(true);
        }

        private void lblDefaultTitle_MouseLeave(object sender, EventArgs e)
        {
            hover(false);
        }

        private void RowStepControl_Enter(object sender, EventArgs e)
        {
            hover(true);
        }

        private void RowStepControl_Leave(object sender, EventArgs e)
        {
            hover(false);
        }

        private void RowStepControl_MouseEnter(object sender, EventArgs e)
        {
            hover(true);
        }

        private void RowStepControl_MouseLeave(object sender, EventArgs e)
        {
            hover(false);
        }
    }
}
