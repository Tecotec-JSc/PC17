using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace T3ACS.Controls.SelectCustoms
{
    public partial class ItemSelect : UserControl
    {
        public ItemSelect()
        {
            InitializeComponent();
        }
        public EventHandler _eventSelect;

        private void ItemSelect_Click(object sender, EventArgs e)
        {
            _eventSelect?.Invoke(this, EventArgs.Empty);
        }

        private void ItemSelect_MouseEnter(object sender, EventArgs e)
        {
            if (!hovered)
            {
                hovered = true;
                hoverNow = true;           
                label1.BackColor = HoverColorG;
                panelBorderRadiusCustom1.BackColor = HoverColorG;
                Invalidate();
            }
        }
        public Color BackColorG { get; set; }
        public Color HoverColorG { get; set; } = Color.FromArgb(250,250,250);
        public bool hovered;
              public bool hoverNow;
        private void ItemSelect_MouseLeave(object sender, EventArgs e)
        {
            if (hovered)
            {
                hovered = false;
                hoverNow = false;
                label1.BackColor = BackColorG;
                panelBorderRadiusCustom1.BackColor = BackColorG;
                Invalidate();
            }
        }
        [Category("RJ Code Advance")]
        public string Texts
        {
            get
            {                
                 return label1.Text;
            }
            set
            {
                label1.Text = value;               
            }
        }



    }
}
