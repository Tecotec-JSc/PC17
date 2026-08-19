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
    public partial class SortCard : UserControl
    {
        public event EventHandler ButtonClick;
        public SortCard()
        {
            InitializeComponent();
        }
        List<System.Windows.Forms.Button> bts;
        public string BtnName;
        public void AddSort(List<string> lstTitle,List<string> lstName)
        {
            bts=new List<Button>();
            if (lstTitle != null && lstName != null && lstTitle.Count == lstName.Count)
            {
                var wi = this.Width;
                var nowX = 0;
                var i = 0;
                foreach (var item in lstTitle)
                {
                    Button bt = new Button();
                    bt.Location = new Point(0, nowX);
                    bt.Margin = new Padding(0);
                    bt.Name = lstName[i];
                    bt.Size = new Size(wi, 37);
                    bt.TabIndex = 0;
                    bt.Text = item;
                    bt.FlatAppearance.BorderSize = 0;               
                    bt.FlatStyle = FlatStyle.Flat;
                    bt.UseVisualStyleBackColor = true;
                    bt.TextAlign = ContentAlignment.MiddleLeft;
                    bt.MouseEnter += Btn_MouseEnter;
                    bt.MouseLeave += Btn_MouseLeave;
                    bt.Click += Btn_Click;
                    Controls.Add(bt);
                    bts.Add(bt);
                     nowX += 37;
                    if (i == 0) ChangeCode(bt.Name);
                    i++;
                }
            }
        }
        public void AddNewListSort(List<SortCardViewModel> sortCard)
        {
           
            bts = new List<Button>();
            if (sortCard != null &&sortCard.Count>0)
            {
                var wi = this.Width;
                var nowX = 0;
                var i = 0;
                foreach (var item in sortCard)
                {
                    Button bt = new Button();
                    bt.Location = new Point(0, nowX);
                    bt.Margin = new Padding(0);
                    bt.Name = item.Name;
                    bt.Size = new Size(wi, 37);
                    bt.TabIndex = 0;
                    bt.Text = item.Content;
                    bt.FlatAppearance.BorderSize = 0;
                    bt.FlatStyle = FlatStyle.Flat;
                    bt.UseVisualStyleBackColor = true;
                    bt.TextAlign = ContentAlignment.MiddleLeft;
                    bt.MouseEnter += Btn_MouseEnter;
                    bt.MouseLeave += Btn_MouseLeave;
                    bt.Click += Btn_Click;
                    Controls.Add(bt);
                    bts.Add(bt);
                    nowX += 37;                
                    i++;
                }
            }
        }
        private void Btn_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if(btn!=null&& btn.Name!= BtnName)
             btn.BackColor = DarkerColor(BackColorG,0.85f);   // Hover effect
        }
        public void SelectCard(string cardName)
        {

        }
        private void Btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Name != BtnName)
                btn.BackColor = BackColorG; // Normal color
        }
        private Color DarkerColor(Color color, float factor)
        {
            return Color.FromArgb(
                color.A,
                (int)(color.R * factor),
                (int)(color.G * factor),
                (int)(color.B * factor)
            );
        }
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            ChangeCode(btn.Name);
            // Raise event ra ngoài
            ButtonClick?.Invoke(this, EventArgs.Empty);

            // (Option) Raise luôn Click của UserControl
            this.OnClick(e);
        }
        public void ChangeCode(string nameb)
        {
            foreach(var item in bts)
            {
                if(item.Name == nameb)
                {
                    BtnName= nameb;
                    item.BackColor = BackColorSelectA;
                    item.ForeColor = ForeColorSelectA;
                }
                else
                {
                    item.BackColor = BackColorG;
                    item.ForeColor = ForeColorG;
                }
            }
        }
        public Color BackColorG { get; set; } = Color.White;
        public Color ForeColorG { get; set; } = Color.Black;
        public Color BackColorSelectA { get; set; } = Color.FromArgb(0, 82, 130);
        public Color ForeColorSelectA { get;set; } = Color.White;
    }
}
