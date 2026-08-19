using T3.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class FormCreateProcedure : Form
    {
        IMain _imain;
        public FormCreateProcedure(IMain imain)
        {
            InitializeComponent();
            _imain = imain;
            showTemplate();       
        }
        string TypeShow;
        public void Addbtn()
        {
            sortCard1.AddSort(new List<string>() { "New Procedure", "Recent", "Tutorials" }, new List<string>() { "NewProcedure", "Recent", "Tutorials" });
        }

        private void sortCard1_ButtonClick(object sender, EventArgs e)
        {
            var type = sortCard1.BtnName;
            if(type!=TypeShow)
            {
                TypeShow=type; ;
            }
        }
        FormChoseTemplateProcedure _frmChoseTemplate;
        private void showTemplate()
        {
            if (_frmChoseTemplate == null)
            {
                _frmChoseTemplate=new FormChoseTemplateProcedure(_imain);
                _frmChoseTemplate.TopLevel = false;
            }
            panelContent.Controls.Clear();
            panelContent.Controls.Add(_frmChoseTemplate);
            _frmChoseTemplate.Show();
            Main.FormNames = "ChoseTemplate";
        }
    }
}
