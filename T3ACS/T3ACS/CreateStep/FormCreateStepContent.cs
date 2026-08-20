using Newtonsoft.Json;
using System.Data;
using T3ACS.CreateStep;
using T3ACS.Model;
using T3ACS.Service;
using T3ACS.StepDefault;
using T3ACS.Util;
using T3ACS.ViewModel;

namespace T3ACS
{
    public partial class FormCreateStepContent : BaseForm
    {
        public int _dutId;
        public FormCreateStepContent()
        {
            InitializeComponent();
            _service = new FormService();
        }
        IFormService _service;
        TableProcedureViewModel _step;
        FormCreateParameter _frmAddPara;
        FormCreateDefault _frmCreateDefault;
        FormCreateCustom _frmCreateCustom;
        FormURLConfiguration _frmUrlConfiguration;
        FormCreateReview _frmCreateReview;
        FormCreateReport _frmCreateReport;
        FormCreateDUTConfiguration _frmCreateDUTConfiguration;
        FormCreateCorrection _frmCreateCorrection;
        FormCreateCalculate _frmCreateCalculate;

        public List<ProcedureVariableViewModel> _variables;
        public List<ProcedureVariableViewModel> _Data;
        public List<ProcedureVariableViewModel> _DataSelect;
        public List<string> _Names;
        public List<string> _NamesSelect;
        public void LoadVariable()
        {
            //Load Variable
            if (_variables != null && _variables.Count > 0)
            {
                if (_step.Variables != null && _step.Variables.Count > 0)
                {
                    _NamesSelect = _variables.Where(t => _step.Variables.Select(i => i.ProcedureVariableId).ToList().Contains(t.ProcedureVariableId)).Select(t => t.Name).ToList();
                    _DataSelect = _variables.Where(t => _step.Variables.Select(i => i.ProcedureVariableId).ToList().Contains(t.ProcedureVariableId)).ToList();
                }
            }
            if (_step.StepType == "Device Under Test")
            {
                _frmCreateDUTConfiguration.LoadDataDUT(_dutId, _variables);
            }
        }
        private void ResizePanelGenContent()
        {
            if (_step.StepType == "Number" || _step.StepType == "String" || _step.StepType == "Boolean" || _step.StepType == "File Attach")
            {
                panelContentStep.Height = _frmAddPara.Height;

            }
            else if (_step.StepType == "URL Configuration")
            {
                panelContentStep.Height = _frmUrlConfiguration.Height;
            }
            else if (_step.StepType == "Device Under Test")
            {
                panelContentStep.Height = _frmCreateDUTConfiguration.Height;
            }
            else if (_step.StepType == "Correction")
            {
                panelContentStep.Height = _frmCreateCorrection.Height;

            }
            else if (_frmCreateDefault != null && _frmCreateDefault.CanFocus)
            {
                panelContentStep.Height = _frmCreateDefault.Height;

            }
        }
        public TemplateViewModel _vm;
        public void LoadData(TemplateViewModel vm)
        {
            _vm = vm;
            _step = _vm.TableProcedures[vm.CurrentStep - 1];
            _variables = vm.Variables;
            loadImageRequired();
            txtStepName.Texts = _step.Title;
            try
            {
                txaDescription.Rtf = _step.Description;
            }
            catch
            {
                txaDescription.Texts = _step.Description;
            }

            txtStepType.Texts = _step.StepType;
            txtRepeatCount.Texts = _step.LoopInput.ToString();
            string steptype = _step.StepType;
            // Step Input
            if (steptype == "Number" || steptype == "String" || steptype == "Boolean" || steptype == "File Attach" || steptype == "Add Parameter")
            {
                if (_frmAddPara != null && _frmAddPara.CanFocus) _frmAddPara.Dispose();
                _frmAddPara = new FormCreateParameter();
                _frmAddPara.TopLevel = false;
                _frmAddPara.Dock = DockStyle.Fill;
                panelContentStep.Controls.Clear();
                panelContentStep.Controls.Add(_frmAddPara);
                _frmAddPara.Show();
                _frmAddPara.LoadData(_variables, _step.Variables);
                //LoadVariable();
            }
            else if (steptype == "URL Configuration")
            {
                _frmUrlConfiguration = new FormURLConfiguration();
                _frmUrlConfiguration.TopLevel = false;
                _frmUrlConfiguration.Dock = DockStyle.Fill;
                _frmUrlConfiguration.LoadData(_step.ListURL);
                panelContentStep.Controls.Clear();
                panelContentStep.Controls.Add(_frmUrlConfiguration);
                _frmUrlConfiguration.Show();
            }
            else if (steptype == "Review")
            {
                _frmCreateReview = new FormCreateReview();
                _frmCreateReview.TopLevel = false;
                _frmCreateReview.Dock = DockStyle.Fill;
                _frmCreateReview.LoadData(vm);
                panelContentStep.Controls.Clear();
                panelContentStep.Controls.Add(_frmCreateReview);
                _frmCreateReview.Show();
            }
            else if (steptype == "Report")
            {
                _frmCreateReport = new FormCreateReport();
                _frmCreateReport.TopLevel = false;
                _frmCreateReport.Dock = DockStyle.Fill;
                _frmCreateReport.LoadData(vm);
                panelContentStep.Controls.Clear();
                panelContentStep.Controls.Add(_frmCreateReport);
                _frmCreateReport.Show();
            }
            else if (steptype == "Device Under Test")
            {
                _frmCreateDUTConfiguration = new FormCreateDUTConfiguration();
                _frmCreateDUTConfiguration.TopLevel = false;
                _frmCreateDUTConfiguration.Dock = DockStyle.Fill;
                _frmCreateDUTConfiguration.LoadDataDUT(_dutId, _variables);
                panelContentStep.Controls.Clear();
                panelContentStep.Controls.Add(_frmCreateDUTConfiguration);
                _frmCreateDUTConfiguration.Show();

            }
            else if (steptype == "Correction")
            {
                _frmCreateCorrection = new FormCreateCorrection();
                _frmCreateCorrection.TopLevel = false;
                _frmCreateCorrection.Dock = DockStyle.Fill;
                panelContentStep.Controls.Clear();
                panelContentStep.Controls.Add(_frmCreateCorrection);
                _frmCreateCorrection.Show();
                _frmCreateCorrection.LoadData(_variables, _step.Variables, _step.NumberOder);
            }
            else if (steptype == "Calculate")
            {
                _frmCreateCalculate = new FormCreateCalculate();
                _frmCreateCalculate.TopLevel = false;
                _frmCreateCalculate.Dock = DockStyle.Fill;
                panelContentStep.Controls.Clear();
                panelContentStep.Controls.Add(_frmCreateCalculate);
                _frmCreateCalculate.Show();
                _frmCreateCalculate.LoadData(_variables, _step);
            }
            else
            {
                var loadViewCreate = _step.Functions.Where(t => t.FunctionName == "LoadViewCreate").FirstOrDefault();

                if (loadViewCreate == null)
                {
                    _frmCreateDefault = new FormCreateDefault();
                    _frmCreateDefault.TopLevel = false;
                    _frmCreateDefault.Dock = DockStyle.Fill;
                    _frmCreateDefault.LoadData(_variables, _step);
                    panelContentStep.Controls.Clear();
                    panelContentStep.Controls.Add(_frmCreateDefault);
                    _frmCreateDefault.Show();
                }
                else          
                if (!loadViewCreate.Default)
                {
                    _DataSelect = _variables.Where(t => loadViewCreate.FunctionVariables.Select(i => i.VariableName).ToList().Contains(t.Name)).ToList();
                    _frmCreateCustom = new FormCreateCustom();
                    _frmCreateCustom.TopLevel = false;
                    _frmCreateCustom.Dock = DockStyle.Fill;
                    var formcontent = (Form)_service.CallFunctionLoad(_vm, "LoadViewCreate", out string mess);
                    if (formcontent == null) Shownoti(mess);
                    _frmCreateCustom.LoadData(formcontent);
                    panelContentStep.Controls.Clear();
                    panelContentStep.Controls.Add(_frmCreateCustom);
                    _frmCreateCustom.Show();
                }

            }


            ResizePanelGenContent();
        }
        public TemplateViewModel SaveValue()
        {
            _step.Title = txtStepName.Texts;
            _step.StepType = txtStepType.Texts;
            _step.LoopInput = int.Parse(txtRepeatCount.Texts);
            _step.Description = txaDescription.Rtf;
            if (CheckValue())
            {
                if (_step.StepType == "Number" || _step.StepType == "String" || _step.StepType == "Boolean" || _step.StepType == "File Attach" || _step.StepType == "File Attach" || _step.StepType == "Add Parameter")
                {
                    _step.Variables = new List<ProcedureDetaiVariableViewModel>();
                    _frmAddPara.SaveValue();
                    var lstv = _frmAddPara._result;
                    int numberOrder = 1;
                    foreach (var item in lstv)
                    {
                        ProcedureDetaiVariableViewModel items = new ProcedureDetaiVariableViewModel();
                        items.Name = item.Name;
                        items.Value = item.Value;
                        items.Title = item.Title;
                        items.TypeInput = item.TypeInput;
                        items.NumberOrder = numberOrder;
                        items.Report = item.Report;
                        items.Required = item.Required;
                        items.ProcedureDetailId = _step.ProcedureDetailId;
                        _step.Variables.Add(items);
                        if (_variables.Count(t => t.Name == item.Name) == 0)
                        {
                            _variables.Add(item);
                        }
                        numberOrder++;
                    }
                }
                else if (_step.StepType == "Device Under Test")
                {
                    _step.Variables = new List<ProcedureDetaiVariableViewModel>();
                    _frmCreateDUTConfiguration.SaveValue();
                    var lstv = _frmCreateDUTConfiguration._result;
                    int numberOrder = 1;
                    foreach (var item in lstv)
                    {
                        ProcedureDetaiVariableViewModel items = new ProcedureDetaiVariableViewModel();
                        items.Name = item.Name;
                        items.Value = item.Value;
                        items.Title = item.Title;
                        items.TypeInput = item.TypeInput;
                        items.NumberOrder = numberOrder;
                        items.Report = item.Report;
                        items.Required = item.Required;
                        items.ProcedureDetailId = _step.ProcedureDetailId;
                        _step.Variables.Add(items);
                        if (_variables.Count(t => t.Name == item.Name) == 0)
                        {
                            _variables.Add(item);
                        }
                        numberOrder++;
                    }
                    IDUTModel modeldut = new DUTModel();
                    modeldut.UpdateDUTOption(_dutId, JsonConvert.SerializeObject(lstv));
                }
                else if (_step.StepType == "URL Configuration")
                {
                    _step.Variables = new List<ProcedureDetaiVariableViewModel>();
                    _step.ListURL = _frmUrlConfiguration.SaveData();
                }
                else if (_step.StepType == "Calculate")
                {
                    _step.Variables = new List<ProcedureDetaiVariableViewModel>();
                    _frmCreateCalculate.SaveValue();
                    _step.PathDll = _frmCreateCalculate._filedll;
                    _step.PathSource = _frmCreateCalculate._fileCalib;
                    var lstv = _frmCreateCalculate._result;
                    int numberOrder = 1;
                    foreach (var item in lstv)
                    {
                        ProcedureDetaiVariableViewModel items = new ProcedureDetaiVariableViewModel();
                        items.Name = item.Name;
                        items.Value = item.Value;
                        items.Title = item.Title;
                        items.TypeInput = item.TypeInput;
                        items.NumberOrder = numberOrder;
                        items.Report = item.Report;
                        items.Required = item.Required;
                        items.ProcedureDetailId = _step.ProcedureDetailId;
                        _step.Variables.Add(items);
                        if (_variables.Count(t => t.Name == item.Name) == 0)
                        {
                            _variables.Add(item);
                        }
                        numberOrder++;
                    }
                }
                else if (_step.StepType == "Correction")
                {
                    _step.Variables = new List<ProcedureDetaiVariableViewModel>();
                    _frmCreateCorrection.SaveData();
                    _step.Variables = _frmCreateCorrection._data.OrderBy(t => t.NumberOrder).ToList(); ;
                    _variables = _frmCreateCorrection._varis;
                }
                else if (_step.StepType == "Review")
                {
                    _frmCreateReview.SaveData(out string mess);
                    _vm = _frmCreateReview._vm;
                }
                else if (_step.StepType == "Report")
                {
                    _frmCreateReport.SaveData();
                    _vm = _frmCreateReport._vm;

                }
                else
                {
                    if (_frmCreateCustom != null && !_frmCreateCustom.IsDisposed && _frmCreateCustom.CanFocus)
                    {

                    }
                    else if (_frmCreateDefault != null && _frmCreateDefault.CanFocus)
                    {
                        _frmCreateDefault.SaveValue();
                        _step.Variables = new List<ProcedureDetaiVariableViewModel>();
                        var lstv = _frmCreateDefault._result;
                        var lstf = _frmCreateDefault._variableFormName;
                        int numberOrder = 1;
                        foreach (var item in lstf)
                        {
                            ProcedureDetaiVariableViewModel items = new ProcedureDetaiVariableViewModel();
                            items.Name = item.Name;
                            items.Value = item.Value;
                            items.Title = item.Title;
                            items.TypeInput = item.TypeInput;
                            items.NumberOrder = numberOrder;
                            items.Report = item.Report;
                            items.Required = item.Required;
                            items.ProcedureDetailId = _step.ProcedureDetailId;
                            _step.Variables.Add(items);
                            if (_variables.Count(t => t.Name == item.Name) == 0)
                            {
                                _variables.Add(item);
                            }
                            numberOrder++;
                        }
                        foreach (var item in lstv)
                        {
                            if (item.Name != item.OldName)
                            {
                                if (_step.Functions != null && _step.Functions.Count > 0)
                                {
                                    foreach (var func in _step.Functions)
                                    {
                                        if (func.FunctionVariables != null && func.FunctionVariables.Count > 0)
                                        {
                                            foreach (var variable in func.FunctionVariables)
                                            {
                                                if (variable.VariableName == item.OldName) variable.VariableName = item.Name;
                                            }
                                        }
                                    }
                                }
                            }
                            ProcedureDetaiVariableViewModel items = new ProcedureDetaiVariableViewModel();
                            items.Name = item.Name;
                            items.Value = item.Value;
                            items.Title = item.Title;
                            items.TypeInput = item.TypeInput;
                            items.Report = item.Report;
                            items.NumberOrder = numberOrder;
                            items.Required = item.Required;
                            items.ProcedureDetailId = _step.ProcedureDetailId;
                            _step.Variables.Add(items);
                            if (_variables.Count(t => t.Name == item.Name) == 0)
                            {
                                _variables.Add(item);
                            }
                            numberOrder++;
                        }
                    }
                }
                _vm.TableProcedures[_vm.CurrentStep - 1] = _step;
            }

            return _vm;
        }
        public bool CheckValue()
        {
            bool result = true;
            var strStepName = txtStepName.Texts;
            string error = string.Empty;
            if (!MeasurementValidator.ValidateTitle("Step name", strStepName, 3, 100, null, out error))
            {
                Shownoti(error);
                result = false;
            }
            var txtlop = txtRepeatCount.Texts;
            if (!MeasurementValidator.CheckValue("Repeat Count", txtlop, "1", "100", "Integer", out error))
            {
                Shownoti(error);
                result = false;
            }
            if (_frmAddPara != null && _frmAddPara.CanFocus)
            {
                if (!_frmAddPara.CheckSave(out string mess))
                {
                    Shownoti(mess);
                    result = false; ;
                }
            }

            else
            {
                if (_frmCreateCustom != null && !_frmCreateCustom.IsDisposed && _frmCreateCustom.CanFocus)
                {
                    if ((bool)_service.CallFunctionSave(_vm, "SaveDataCreate", out string mess, out TemplateViewModel outResult))
                    {
                        _step = outResult.TableProcedures[outResult.CurrentStep - 1];
                    }
                    else
                    {
                        Shownoti(mess);
                        result = false;
                    }
                }
                else if (_frmUrlConfiguration != null && _frmUrlConfiguration.CanFocus)
                {
                    if (!_frmUrlConfiguration.CheckSave(out string mess))
                    {
                        Shownoti(mess);
                        result = false;
                    }
                }
                else if (_frmCreateDUTConfiguration != null && _frmCreateDUTConfiguration.CanFocus)
                {
                    if (!_frmCreateDUTConfiguration.CheckSave(out string mess))
                    {
                        Shownoti(mess);
                        result = false;
                    }
                    else
                    {
                        _frmCreateDUTConfiguration.SaveValue();
                        var lstV = _frmCreateDUTConfiguration._result;
                        if (lstV != null && lstV.Count > 0)
                        {
                            foreach (var v in lstV)
                            {
                                if (_variables.Count(t => t.Name == v.Name) > 0)
                                {
                                    var olv = _variables.Where(t => t.Name == v.Name).FirstOrDefault();
                                    if (olv.Type != v.Type)
                                    {
                                        mess = $"{v.Title} has a different type than in another step. The type must be {olv.Type}.";
                                        result = false;
                                    }
                                    else if (olv.Unit != v.Unit)
                                    {
                                        mess = "Parameter '" + v.Name + "' cannot be changed to this unit. It must remain '" + olv.Unit + "'.";
                                    }
                                }
                            }
                        }

                    }
                }
                else if (_frmAddPara != null && _frmAddPara.CanFocus)
                {
                    if (!_frmAddPara.CheckSave(out string mess))
                    {
                        Shownoti(mess);
                        result = false;
                    }
                    else
                    {
                        _frmAddPara.SaveValue();
                        var lstV = _frmAddPara._result;
                        if (lstV != null && lstV.Count > 0)
                        {
                            foreach (var v in lstV)
                            {
                                if (_variables.Count(t => t.Name == v.Name) > 0)
                                {
                                    var olv = _variables.Where(t => t.Name == v.Name).FirstOrDefault();
                                    if (olv.Type != v.Type)
                                    {
                                        mess = $"{v.Title} has a different type than in another step. The type must be {olv.Type}.";
                                        result = false;
                                    }
                                    else if (olv.Unit != v.Unit)
                                    {
                                        mess = "Parameter '" + v.Name + "' cannot be changed to this unit. It must remain '" + olv.Unit + "'.";
                                    }
                                }
                            }
                        }

                    }
                }
                else if (_frmCreateReport != null && _frmCreateReport.CanFocus)
                {
                    if (!_frmCreateReport.CheckSave(out string mess))
                    {
                        Shownoti(mess);
                        result = false;
                    }
                }
                else if (_frmCreateCalculate != null && _frmCreateCalculate.CanFocus)
                {
                    if (!_frmCreateCalculate.CheckSave(out string mess))
                    {
                        Shownoti(mess);
                        result = false;
                    }
                    else
                    {
                        _frmCreateCalculate.SaveValue();
                        var lstV = _frmCreateCalculate._result;
                        if (lstV != null && lstV.Count > 0)
                        {
                            foreach (var v in lstV)
                            {
                                if (_variables.Count(t => t.Name == v.Name) > 0)
                                {
                                    var olv = _variables.Where(t => t.Name == v.Name).FirstOrDefault();
                                    if (olv.Type != v.Type)
                                    {
                                        mess = $"{v.Title} has a different type than in another step. The type must be {olv.Type}.";
                                        result = false;
                                    }
                                    else if (olv.Unit != v.Unit)
                                    {
                                        mess = "Parameter '" + v.Name + "' cannot be changed to this unit. It must remain '" + olv.Unit + "'.";
                                    }
                                }

                            }
                        }
                    }
                }
                else if (_frmCreateDefault != null && _frmCreateDefault.CanFocus)
                {
                    if (!_frmCreateDefault.CheckSave(out string mess))
                    {
                        Shownoti(mess);
                        result = false;
                    }
                    else
                    {
                        _frmCreateDefault.SaveValue();
                        var lstV = _frmCreateDefault._result;
                        if (lstV != null && lstV.Count > 0)
                        {
                            foreach (var v in lstV)
                            {
                                if (_variables.Count(t => t.Name == v.Name) == 0) continue;
                                var olv = _variables.Where(t => t.Name == v.Name).FirstOrDefault();
                                if (olv.Type != v.Type)
                                {
                                    mess = $"{v.Title} has a different type than in another step. The type must be {olv.Type}.";
                                    result = false;
                                }

                            }
                        }

                    }
                }
                else if (_frmCreateCorrection != null && _frmCreateCorrection.CanFocus)
                {
                    if (!_frmCreateCorrection.checkSave(out string mess))
                    {
                        Shownoti(mess);
                        result = false;
                    }
                }
            }

            return result;
        }
        public DialogResult Shownoti(string str)
        {
            FormBlur blur = new FormBlur();
            blur.Size = new Size(1920, 1030);
            blur.Location = this.Location;
            blur.StartPosition = FormStartPosition.Manual;
            blur.Owner = this;
            blur.Show();
            FormNotiAll frmNoti = new FormNotiAll();
            frmNoti.LoadData("Validate User Input", str, 2);
            var result = frmNoti.ShowDialog();
            frmNoti.Dispose();
            // Cleanup
            blur.Close();
            blur.Dispose();
            return result;

        }
        public event EventHandler<string> _StepNameChange;


        private void lblCheck_Click(object sender, EventArgs e)
        {
            _step.Required = !_step.Required;
            loadImageRequired();
        }
        private void loadImageRequired()
        {
            if (_step.Required) lblCheck.Image = Properties.Resources.Radio_Button;
            else lblCheck.Image = Properties.Resources.rdonocheck;
        }

        private void btnAddMedia_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(*.jpg) | *.jpg";
            if (open.ShowDialog() == DialogResult.OK)
            {
                Image img = Image.FromFile(open.FileName);
                Clipboard.SetImage(img);
                txaDescription.Paste();
            }
        }

        private void txtStepName__TextChanged_1(object sender, EventArgs e)
        {
            _StepNameChange?.Invoke(null, txtStepName.Text);
        }
    }
}
