using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3ACS.Model;

namespace T3ACS.CreateStep
{
    public partial class FormAddOneVariable : Form
    {
        public FormAddOneVariable()
        {
            InitializeComponent();
            lblError.Visible = false;
        }
        public void LoadData(List<ProcedureVariableViewModel> varis)
        {
            tableVariableControl1.LoadData(varis);
            tableVariableControl1.AddNewRow(false, 0, "", "","", "", "", "", "", "Double", "Input", true, true, true);
            tableVariableControl1.ResizeC();
            flowPanelBorderRadius1.Height = tableVariableControl1.Height + 93;
            this.Height = flowPanelBorderRadius1.Height;
        }
        private void btnCancel__EventSelect(object sender, EventArgs e)
        {
            this.Close();
        }
        public List<ProcedureVariableViewModel> _variables;  

        private void btnSave__EventSelect(object sender, EventArgs e)
        {
            if (!tableVariableControl1.CheckSave(out string mess))
            {
                lblError.Visible = true;
                lblError.Text = mess;
                return;    
            }
            _variables = tableVariableControl1.GetVariables();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
