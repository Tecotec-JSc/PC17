using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace  T3ACS.Controls
{
    public partial class SwitchOnOFF : UserControl
    {
        public SwitchOnOFF()
        {
            InitializeComponent();
        }
        public event EventHandler _ChangeSelect;
        public bool _Selected {
            get
            {  return _checked; }
            set { 
                _checked = value;
                ChangeImage();
            } }
        private bool _checked;
        private void label1_Click(object sender, EventArgs e)
        {
            _Selected = !_Selected;
            ChangeImage();
            if (_ChangeSelect != null)
                _ChangeSelect.Invoke(this, e);
        }
        private void ChangeImage()
        {
            if (!_Selected)
            {
                label1.Image = Properties.Resources.Base_ControlNoActive;
                label2.Text = TextNoChecked;
            }

            else
            {
                label1.Image = Properties.Resources.Base_Control;
                label2.Text = TextChecked;
            }
                
        }
        public void SetSelect( bool select)
        {          
            _Selected= select;
            ChangeImage();
        }
        [Category("RJ Code Advance")]
        public string TextS
        {
            get
            {          
                
                 return label2.Text;

            }
            set
            {
             label2.Text= value;
                updateWidth();
            }
        }
        public string TextChecked { get; set; }
        public string TextNoChecked { get; set; }
        private void updateWidth()
        {
            var texta = label2.Text;
            if(!string.IsNullOrEmpty(texta)) {
                Size size = TextRenderer.MeasureText(texta, label2.Font);
                label2.Width = size.Width;
                this.Width = 45 + size.Width;
            }else
            {
                label2.Width = 0;
                this.Width = 45 + 0;
            } 
   
            Invalidate();
        }
    }
}
