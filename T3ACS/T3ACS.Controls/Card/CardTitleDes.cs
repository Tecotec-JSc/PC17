using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS.Controls.Card
{
    public partial class CardTitleDes : UserControl
    {
        public CardTitleDes()
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
            if (string.IsNullOrEmpty(txtDes))
            {
                lblDes.Visible = false;
                this.Height = 37;
                panelCustomBorder1.Height = 37;
            }
            else if (this.Height == 37)
            {
                this.Height = 62;
                panelCustomBorder1.Height = 62;
            }
        }

        private void panelCustomBorder1_Click(object sender, EventArgs e)
        {
            if (_SelectCard != null)
                _SelectCard.Invoke(this, e);
        }
    }

}
