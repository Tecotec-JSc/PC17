using System;
using System.Text;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class FormShowLog : Form
    {
        private StringBuilder _str;

        public FormShowLog()
        {
            InitializeComponent();
        }

        public void AddLog(string str)
        {
            if (_str == null) _str = new StringBuilder();
            _str.AppendLine("[" + DateTime.Now.ToString("HH:mm:ss") + "] " + str);
            rtbLog.Text = _str.ToString();
        }

        private void rtbLog_TextChanged(object sender, EventArgs e)
        {
            rtbLog.SelectionStart = rtbLog.Text.Length;
            // Tự cuộn xuống dòng cuối.
            rtbLog.ScrollToCaret();
        }

        public string GetText()
        {
            return rtbLog.Text;
        }

        public void SetText(string content)
        {
            if (_str == null) _str = new StringBuilder();
            _str.Append(content);
            rtbLog.Text = _str.ToString();
        }
    }
}
