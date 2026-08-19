using T3ACS.Controls.Card;
using T3ACS.Controls.Variable;
using T3ACS.Model;
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
    public partial class FormPopUpTemplate : Form
    {
        public FormPopUpTemplate()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }
        public void LoadData(List<List<string>> data)
        {

            if (data != null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    CardTitleDes card = new CardTitleDes();
                    var title = "";
                    if (item.Count > 1) title = item[1];

                    card.SetText(item[0], title);
                    card.Margin = new Padding(0);
                    card._SelectCard += Card__SelectCard;
                    flowPanelBorderRadius1.Controls.Add(card);

                }
            }
        }
        public string _SelectedItem;
        public event EventHandler _SelectCard;
        private void Card__SelectCard(object sender, EventArgs e)
        {
            if (sender is CardTitleDes cardTitleDes)
            {
                _SelectedItem = cardTitleDes._Name;
                if (_SelectCard != null)
                    _SelectCard.Invoke(this, e);
            }
        }
        
        private void FormPopUpTemplate_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
