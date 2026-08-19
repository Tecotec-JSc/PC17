using Newtonsoft.Json;
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

namespace T3ACS.StepDefault
{
    public partial class FormSetupCorrection : Form
    {
        public FormSetupCorrection()
        {
            InitializeComponent();
        }
        List<ProcedureDetaiVariableViewModel> _stepVaris;
        public void LoadData(List<ProcedureVariableViewModel> varis,TableProcedureViewModel step)
        {
            var str= JsonConvert.SerializeObject(varis);
            var functionLoadView = step.Functions.Where(t => t.Name == "LoadViewCreate").FirstOrDefault();
            if(functionLoadView != null )
            {
                if(functionLoadView.FunctionVariables.Count > 0)
                {
                    var pathFile = functionLoadView.FunctionVariables[0].Value;
                    selectedFileCalibration.Texts = pathFile;
                }
                if (functionLoadView.FunctionVariables.Count > 1)
                {

                }
            }

        }
        

        
    }
}
