using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3ACS.Controls;
using T3ACS.Model;
using T3ACS.Util;
using T3ACS.ViewModel;

namespace T3ACS.CreateStep
{
    public partial class FormCreateCustom : Form
    {
        public FormCreateCustom()
        {
            InitializeComponent();           
        }

        public void LoadData(Form form)
        {
            panelContent.Controls.Clear();
            if (form != null)
            {
                form.TopLevel = false;
                form.Dock = DockStyle.Fill;              
                panelContent.Controls.Add(form);
                form.Show();
                form.BringToFront();
            }     
 
            panelContent.ResumeLayout();
        }




    }
}
