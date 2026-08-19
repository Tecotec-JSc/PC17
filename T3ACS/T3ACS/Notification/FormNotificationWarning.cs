using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
namespace T3ACS
{
    public partial class FormNotificationWarning : Form
    {
        public FormNotificationWarning()
        {
            InitializeComponent();
         
        }
        public void loadData(string title, string content, string btnCancel, string btnOK)
        {
            if (!string.IsNullOrEmpty(title))
                lblHugeTitle.Text = title;
            if (!string.IsNullOrEmpty(content))
                lblTextContent.Text = content;
            if (!string.IsNullOrEmpty(btnCancel))
                buttonControl1.Texts = btnCancel;
            if (!string.IsNullOrEmpty(btnOK))
                buttonControl2.Texts = btnOK;






        }
        
        private void buttonControl1_Load(object sender, EventArgs e)
        {
            this.Close();
        }
   
        private void buttonControl2_Load(object sender, EventArgs e)
        {
  
            this.Close();
        }
    }
}
