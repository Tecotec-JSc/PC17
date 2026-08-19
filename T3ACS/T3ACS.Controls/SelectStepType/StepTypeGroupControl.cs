using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS.Controls
{
    public partial class StepTypeGroupControl : UserControl
    {
        public StepTypeGroupControl()
        {
            InitializeComponent();
        }
        public bool _Expand;
        public event EventHandler _ClickControl;
        private Color backgroundColor = Color.White;
        private Color backgroundColorHover = Color.LightGray;
        public void SetValue(bool expand, string text)
        {
            lblDefaultTitle.Text = text;
            _Expand = expand;
            ChangeIcon();
        }
        public void ChangeIcon()
        {
            if (_Expand)
            {
                label1.Image = Properties.Resources.ArrowDown;
            }
            else label1.Image = Properties.Resources.arrowRight;
        }

        public string GroupName;
        private void label1_Click(object sender, EventArgs e)
        {
            _ClickControl?.Invoke(this, e);
        }

        private void lblDefaultTitle_Click(object sender, EventArgs e)
        {
            _ClickControl?.Invoke(this, e);
        }
          
        private void hover(bool valueInput)
        {

            if (valueInput)
            {
                // this.BackColor = backgroundColorHover;
                lblDefaultTitle.BackColor = backgroundColorHover;
                label1.BackColor = backgroundColorHover;
                panel1.BackColor = backgroundColorHover;
            }
            else
            {
                // this.BackColor = backgroundColor;
                lblDefaultTitle.BackColor = backgroundColor;
                label1.BackColor = backgroundColor;
                panel1.BackColor = backgroundColor;
            }
        }
        private void HoverOn(object sender, EventArgs e)
        {
            hover(true);
        }

        private void HoverLeave(object sender, EventArgs e)
        {
            hover(false);
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            _ClickControl?.Invoke(this, e);
        }
    }
}
