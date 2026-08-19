using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace  T3ACS.Controls
{
    public partial class ButtonImageNoBorder : UserControl
    {
        public Image imageDefault;
        public Image imageSelect;
        public Image imageDisable;
        public Image imageHover;
        public bool _IsSelected, _Enable;
        public event EventHandler _ClickControl;
        public ButtonImageNoBorder()
        {
            InitializeComponent();
        }
        public void SelectControl(bool value)
        {
            _IsSelected = value;
            ChangeImaage();
        }
        private void Entert()
        {
            if (!_IsSelected)
            {
                label1.Image = imageHover; ;
            }

        }
        private void Leavet()
        {
            if (!_IsSelected)
            {
                label1.Image = imageDefault;
            }
        }
        private void label1_Enter(object sender, EventArgs e)
        {
            if (_Enable)
                Entert();
        }
        private void label1_Leave(object sender, EventArgs e)
        {
            if (_Enable)
                Leavet();
        }
        public void SetEnable(bool value)
        {
            _Enable = value;
            if (_Enable)
            {
                label1.Image = imageDefault;
            }
            else
            {
                label1.Image = imageDisable;
            }
        }
        private void ChangeImaage()
        {
            if (_IsSelected)
            {
                label1.Image = imageSelect;
            }
            else
            {
                label1.Image = imageDefault;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            _ClickControl?.Invoke(this, EventArgs.Empty);
            if (_Enable)
            {
                _IsSelected = true;
                ChangeImaage();
            }
        }
    }
}
