using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class FormShowLog : Form
    {
        StringBuilder _str;
        public FormShowLog()
        {
            InitializeComponent();
            
        }
        public void AddLog(string str)
        {
            if (_str == null) _str = new StringBuilder();
            _str.AppendLine("["+DateTime.Now.ToString("HH:mm:ss")+"] "+ str);
            richTextBox1.Text = _str.ToString();            
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            // scroll it automatically
            richTextBox1.ScrollToCaret();
        }
        public string GetText()
        {
            return richTextBox1.Text;
        }
        public void SetText(string content)
        {
            if (_str == null) _str = new StringBuilder();
            _str.Append(content);
            richTextBox1.Text = _str.ToString();
        }
    }
}
