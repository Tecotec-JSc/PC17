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
    public partial class ComboboxGroup : UserControl
    {
        public ComboboxGroup()
        {
            InitializeComponent();
        }
        public event EventHandler OnSelectedIndexChanged;//Default event
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // handle potential no selection error
            if (listView1.SelectedItems.Count == 0) return;

            int ndx = listView1.SelectedIndices[0];
            string txt = listView1.Items[ndx].Text;

            // write the selected value to the TextBox
            textBox1.Text = txt; ;

            // collapse the UserControl
            this.Height = textBox1.Height;

            // invoke the Event
            OnLVSelectedIndexChanged(new LVEventArgs(ndx, txt));
        }
        private void lvCombo1_LVSelectedIndexChanged(object sender, LVEventArgs e)
        {
            // write the information out to a TextBox on the Form, 'textBox1
            textBox1.Text = string.Format("index: {0} value: {1}", e.CurrentIndex, e.CurrentText);
        }
        public event EventHandler<LVEventArgs> LVSelectedIndexChanged;

        // the Event code
        protected virtual void OnLVSelectedIndexChanged(LVEventArgs e)
        {
            EventHandler<LVEventArgs> handler = LVSelectedIndexChanged;
            if (handler != null) handler(this, e);
        }

    }
    public class LVEventArgs : EventArgs
    {
        public int CurrentIndex;
        public string CurrentText;

        public LVEventArgs(int i, string s)
        {
            CurrentIndex = i;
            CurrentText = s;
        }
        // the Event declaration
       
    }
}
