using T3ACS.Controls;
using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class FormInputParameter : Form
    {
        public FormInputParameter()
        {
            InitializeComponent();
        
        }
        public List<ProcedureVariableViewModel> _data;
        public List<string> parameterName;
        public List<string> _titles;
 
        FormAddPara addPara;
        string _stepType;
        //public void LoadData(TableProcedureViewModel step, List<ProcedureVariableViewModel>  variables)
        //{
        //    if (step.Variables != null && step.Variables.Count > 0)
        //    {
        //        _data = variables;
        //        _stepType = step.StepType;
        //        parameterName = new List<string>();
        //        _titles = new List<string>();
        //        panelInput.Controls.Clear();
        //        addPara = new FormAddPara();
        //        addPara.Loaddata(_data);
        //        if (step.StepType == "String")
        //        {
        //            btnAddMetaData.Text = "Add String Input";
        //        }
        //        else if (step.StepType == "Boolean")
        //        {
        //            btnAddMetaData.Text = "Add Boolean Input";
        //        }
        //        else if (step.StepType == "File Attach")
        //        {
        //            btnAddMetaData.Text = "Add FileAttach";
        //        }
        //        addPara.TopLevel = false;
        //        addPara.Dock = DockStyle.Fill;
        //        panelInput.Controls.Add(addPara);
        //        addPara.Show();
        //        if (_data != null)
        //        {
        //            foreach (var item in _data)
        //            {
        //                parameterName.Add(item.Name);
        //                _titles.Add(item.Title);
        //            }
        //        }
        //    }
            
        //    else
        //    {
        //        _data = new List<ProcedureVariableViewModel>();
        //    }
        //}      

        public void AddParameter(ProcedureVariableViewModel para)
        {
            _data.Add(para);

        }
        private void btnAddMetaData_Click(object sender, EventArgs e)
        {
            //FormBlur blur = new FormBlur();
            //blur.Size = new Size(1920, 1030);
            //blur.Location = this.Location;
            //blur.StartPosition = FormStartPosition.Manual;
            //blur.Owner = this;
            //blur.Show();
            //if (_stepType.ToUpper() == "STRING")
            //{
            //    FormAddStringInputValue frmString = new FormAddStringInputValue();
            //    frmString.LoadData(parameterName, _titles);
            //    if (frmString.ShowDialog() == DialogResult.OK)
            //    {
            //        var data = frmString.GetValueInput();
            //        var newp = new ProcedureDetailValueViewModel()
            //        {
            //            Name = data[0],
            //            Value = data[1],            
            //            Title = data[2],
            //            NumberOder = _data.Count + 1,
            //            Type = "String",
            //            StrValueType = "InputValue"
            //        };                
            //        addPara.AddPara(newp);
            //        if (!_data.Contains(newp)) _data.Add(newp);
            //    }
            //}
            //else if(_stepType.ToUpper() == "NUMBER")
            //{
            //    FormAddNumberInputValue frmNumber = new FormAddNumberInputValue();
            //    frmNumber.LoadData(parameterName, _titles);
            //    // Cleanup

            //    if (frmNumber.ShowDialog() == DialogResult.OK)
            //    {
            //        var data = frmNumber.GetValueInput();
            //        var newp = new ProcedureDetailValueViewModel()
            //        {
            //            Name = data[0],
            //            Value = data[1],
            //            Unit = data[4],
            //            Title = data[5],
            //            NumberOder = _data.Count + 1,
            //            Type = "Double",
            //            StrValueType = "InputValue"
            //        };
            //        if (!string.IsNullOrEmpty(data[2])) newp.Min = double.Parse(data[2]);
            //        if (!string.IsNullOrEmpty(data[3])) newp.Max = double.Parse(data[3]);
            //        addPara.AddPara(newp);
            //        if (!_data.Contains(newp)) _data.Add(newp);
            //    }
            //    frmNumber.Dispose();
            //}
            //else if (_stepType.ToUpper() == "BOOLEAN")
            //{
            //    FormAddBooleanInputValue frmBoolean = new FormAddBooleanInputValue();
            //    frmBoolean.LoadData(parameterName, _titles);
            //    // Cleanup

            //    if (frmBoolean.ShowDialog() == DialogResult.OK)
            //    {
            //        var data = frmBoolean.GetValueInput();
            //        var newp = new ProcedureDetailValueViewModel()
            //        {
            //            Name = data[0],
            //            Value = data[1],                     
            //            Title = data[2],
            //            NumberOder = _data.Count + 1,
            //            Type = "Boolean",
            //            StrValueType = "InputValue"
            //        };                    
            //        addPara.AddPara(newp);
            //        if (!_data.Contains(newp)) _data.Add(newp);
            //    }
            //    frmBoolean.Dispose();
            //}
            //else if (_stepType.ToUpper() == "File Attach")
            //{
            //    FormAddFileInputValue frmFile = new FormAddFileInputValue();
            //    frmFile.LoadData(parameterName, _titles);
            //    // Cleanup

            //    if (frmFile.ShowDialog() == DialogResult.OK)
            //    {
            //        var data = frmFile.GetValueInput();
            //        var newp = new ProcedureDetailValueViewModel()
            //        {
            //            Name = data[0],
            //            Value = data[1],
            //            Title = data[2],
            //            NumberOder = _data.Count + 1,
            //            Type = "File Attach",
            //            StrValueType = "InputValue"
            //        };
            //        addPara.AddPara(newp);
            //        if (!_data.Contains(newp)) _data.Add(newp);
            //    }
            //    frmFile.Dispose();
            //}
            //blur.Close();
            //blur.Dispose();
        }
    }
}
