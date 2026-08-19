using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3ACS.Controls;
using T3ACS.Controls.SelectCustoms;
using T3ACS.Model;

namespace T3ACS.CreateStep
{
    public partial class FormCreateDefault : Form
    {
        public FormCreateDefault()
        {
            InitializeComponent();
        }
        public List<ProcedureVariableViewModel> _variableProcedure;
        public List<ProcedureVariableViewModel> _variableStep;
        public List<ProcedureVariableViewModel> _variableFormName;
        public List<string> _listv;
        public List<string> _listvSelect;
        public void LoadData(List<ProcedureVariableViewModel> varisAll, TableProcedureViewModel step)
        {
            if (varisAll == null) varisAll = new List<ProcedureVariableViewModel>();
            _variableProcedure = varisAll.ToList();
            var varisLoad = new List<ProcedureVariableViewModel>();
            if (step.Variables != null && step.Variables.Count > 0)
            {
                foreach (var va in step.Variables)
                {
                    var item = varisAll.Where(t => t.Name == va.Name).FirstOrDefault(); ;
                    item.Value = va.Value;
                    item.TypeInput = va.TypeInput;
                    item.Title = va.Title;
                    item.Report = va.Report;
                    varisLoad.Add(item);

                }
            }
            _variableFormName = new List<ProcedureVariableViewModel>();
            _variableStep = new List<ProcedureVariableViewModel>();
            if (step.Functions != null && step.Functions.Count > 0)
            {
                foreach (var function in step.Functions)
                {

                    if (function.FunctionVariables != null && function.FunctionVariables.Count > 0)
                    {
                        int i = 0;
                        foreach (var variable in function.FunctionVariables)
                        {
                            var item = _variableProcedure.Where(t => t.Name == variable.VariableName).FirstOrDefault();
                            if (item != null)
                            {
                                if (i == 0)
                                {
                                    if (_variableFormName.Count(t => t.Name == item.Name) == 0)
                                        _variableFormName.Add(item);
                                }
                                else
                                {
                                    if (_variableStep.Count(t => t.Name == item.Name || t.OldName == Name) == 0)
                                    {
                                        var itemo = varisLoad.Where(t => t.Name == item.Name).FirstOrDefault();
                                        itemo.OldName = itemo.Name;
                                        itemo.Type = item.Type;
                                        itemo.TypeInput = item.TypeInput;
                                        _variableStep.Add(itemo);
                                    }

                                }
                                i++;
                            }

                        }


                    }
                }
            }
            tableDefaultVariable1.LoadData(_variableStep);
            tableDefaultVariable1.ResizeC();
        }
        public bool CheckSave(out string mess)
        {
            if (tableDefaultVariable1.CheckSave(out mess))
            {

                var result = tableDefaultVariable1.GetVariables();
                foreach (var v in result)
                {
                    if (_variableStep.Count(t => t.Name == v.Name) > 0)
                    {
                        var oldv = _variableStep.Where(t => t.Name == v.Name).FirstOrDefault();
                        if (oldv.Type != v.Type)
                        {
                            mess = "Parameter " + v.Name + " cannot be changed to this type.It must be of type " + oldv.Type + ".";
                            return false;
                        }
                        else if (oldv.Unit != v.Unit)
                        {
                            mess = "Parameter '" + v.Name + "' cannot be changed to this unit. It must remain '" + oldv.Unit + "'.";
                        }
                    }
                }
                return true;
            }
            else return false;
        }
        public List<ProcedureVariableViewModel> _result;
        public bool SaveValue()
        {
            _result = tableDefaultVariable1.GetVariables();
            int i = 0;
            foreach (var v in _result)
            {
                v.OldName = _variableStep[i].Name;
                i++;
            }
            return true;
        }
        /// <summary>
        /// 1: success, 2 warning, 3 Error
        /// </summary>
        /// <param name="title"></param>
        /// <param name="strmess"></param>
        /// <param name="status"></param>
        private void ShowMess(string title, string strmess, int status)
        {
            FormBlur blur = new FormBlur();
            blur.Size = new Size(1920, 1030);
            blur.Location = this.Location;
            blur.StartPosition = FormStartPosition.Manual;
            blur.Owner = this;
            blur.Show();
            FormNotiAll frmNoti = new FormNotiAll();
            frmNoti.LoadData(title, strmess, status);
            frmNoti.ShowDialog();
            frmNoti.Dispose();
            // Cleanup
            blur.Close();
            blur.Dispose();
        }
      

        private void tableDefaultVariable1__ShowError(object sender, EventArgs e)
        {
            ShowMess("Notification", tableDefaultVariable1._StrError, 2);
        }
    }
}
