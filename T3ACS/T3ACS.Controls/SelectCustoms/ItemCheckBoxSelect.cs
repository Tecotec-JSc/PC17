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
    public partial class ItemCheckBoxSelect : UserControl
    {
        public ItemCheckBoxSelect()
        {
            InitializeComponent();
        }
        public EventHandler _eventSelect;



        private void ItemCheckBoxSelect_MouseEnter(object sender, EventArgs e)
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
        public Color HoverColorG { get; set; } = Color.FromArgb(250, 250, 250);
        public bool hovered;
        public bool hoverNow;
        public bool _Checked;
        private void ItemCheckBoxSelect_MouseLeave(object sender, EventArgs e)
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

        public void SetValue(string text, bool value)
        {
            Texts = text;
            _Checked = value;
            checkBoxCustom1.Checked = value;

        }
        public bool _ready;

        private void checkBoxCustom1_CheckedChanged(object sender, EventArgs e)
        {
            if (_ready)
            {
                _Checked = checkBoxCustom1.Checked;
                 _eventSelect?.Invoke(this, EventArgs.Empty);
            }
            
        }

        private void checkBoxCustom1_Click(object sender, EventArgs e)
        {
            if(!_ready) _ready = true;
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
