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
    public partial class itemCheckListControl : UserControl
    {
        Color originalColor;
        public itemCheckListControl()
        {
            InitializeComponent();
            originalColor = this.BackColor;
            AddMouseEvent(this);
        }
        public event EventHandler _ChangeSelect;
        public bool _Select;
        public string _Name;
        public void SetValue(string name, bool check)
        {
            label2.Text = name;
            _Select = check;
            ChangeImage();
        }
        private void AddMouseEvent(System.Windows.Forms.Control parent)
        {
            parent.MouseEnter += UserControl_MouseEnter;
            parent.MouseLeave += UserControl_MouseLeave;

            foreach (System.Windows.Forms.Control c in parent.Controls)
            {
                AddMouseEvent(c);
            }
        }
        private void UserControl_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(225, 223, 221); // màu khi hover
        }

        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = originalColor; // trả lại màu ban đầu
        }

        private void label1_Click(object sender, EventArgs e)
        {
            if (_ChangeSelect != null)
                _ChangeSelect.Invoke(this, new EventArgs());
        }
        public void SetChangeSelect(bool select)
        {
            _Select = select;
            ChangeImage();
        }
        private void ChangeImage()
        {
            if (_Select)
                label1.Image = Properties.Resources.Checked;
            else label1.Image = Properties.Resources.NotChecked;
        }
        private void UpdateHeight()
        {

        }
    }
}
