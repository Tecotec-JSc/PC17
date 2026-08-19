using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace T3ACS.Controls.Variable
{
    public partial class CardVariableSelect : UserControl
    {
        public CardVariableSelect()
        {
            InitializeComponent();
        }
        private void CardLable_Enter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(250, 250, 250);
        }
        public event EventHandler _SelectCard;
        private void CardLable_Leave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
        public string _Name;
        public void SetText(string txtName, string txtDes)
        {
            _Name = txtName;
            lblName.Text = txtName;
            lblDes.Text = txtDes;
        }

        private void panelCustomBorder1_Click(object sender, EventArgs e)
        {
            if (_SelectCard != null)
                _SelectCard.Invoke(this, e);
        }
        
    }
}
