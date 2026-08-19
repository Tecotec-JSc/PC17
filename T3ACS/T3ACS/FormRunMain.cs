using Newtonsoft.Json;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using T3.Configuration;
using T3ACS.Controls;
using T3ACS.Model;
using T3ACS.Service;
using T3ACS.StepDefault;
using T3ACS.ViewModel;

namespace T3ACS
{
    public partial class FormRunMain : Form
    {
        public FormRunMain()
        {
            InitializeComponent();
            LoadForm();
        }
        private void LoadForm()
        {
            _service = new FormService();
            _stepBasics = new List<string>() { StepTypeName.Number, StepTypeName.String, StepTypeName.FileAttach, StepTypeName.Boolean, StepTypeName.Correction, StepTypeName.UrlConfiguration, StepTypeName.DeviceUnderTest, StepTypeName.Calculate, StepTypeName.Review, StepTypeName.Report };
            InitializeDynamicTabControls();
        }
        public event EventHandler _SendAction;
        #region properties
        Form _frmEvaluate;
        FormEvaluateDefault _frmEvalueateDefault;
        IFormService _service;
        public int _statusAction, _statusActionStep;
        public TemplateViewModel _Vm;
        private List<SortCardViewModel> _sortCart;
        private string _stepClick;
        private FormShowLog _frmShowLog;
        private FormTableInfo _frmTableInfo;
        FormEvaluateParameter _frmEvaluateParameter;
        FormEvaluateNumber _frmEvaluateNumber;
        FormEvaluateBoolean _frmEvaluateBoolean;
        FormEvaluateString _frmEvaluateString;
        FormEvaluateFileAttach _frmEvaluateFileAttach;
        FormEvaluateCorrection _frmEvaluateCorrection;
        FormEvaluateReview _frmEvaluateReview;
        FormEvaluateReport _frmEvaluateReport;
        FormEvaluateCalculation _frmEvaluateCalculation;
        FormEvaluateBrowserURL _frmEvaluateBrowserURL;
        FormEvaluateDUTInformation _frmEvaluateDUTInformation;
        List<string> _stepBasics;
        public List<ProcedureVariableViewModel> _variables;
        #endregion
        #region Button
        /// <summary>
        /// 0: Disable, 1: Default, 2: Active.
        /// </summary>
        /// <param name="btnBack"></param>
        /// <param name="btnStop"></param>
        /// <param name="btnStart"></param>
        /// <param name="btnNext"></param>
        public void LoadBtnStatus(int btnBack, int btnStop, int btnStart, int btnNext)
        {
            switch (btnBack)
            {
                case 0:
                    btnActionBack.SetEnalbled(false);
                    break;
                case 1:
                    btnActionBack.SetEnalbled(true);
                    btnActionBack.SelectControl(false);
                    break;
                case 2:
                    btnActionBack.SetEnalbled(true);
                    btnActionBack.SelectControl(true);
                    break;
            }
            switch (btnStop)
            {
                case 0:
                    btnActionStop.SetEnalbled(false);
                    break;
                case 1:
                    btnActionStop.SetEnalbled(true);
                    btnActionStop.SelectControl(false);
                    break;
                case 2:
                    btnActionStop.SetEnalbled(true);
                    btnActionStop.SelectControl(true);
                    break;
            }
            switch (btnStart)
            {
                case 0:
                    btnActionRun.SetEnalbled(false);
                    break;
                case 1:
                    btnActionRun.SetEnalbled(true);
                    btnActionRun.SelectControl(false);
                    break;
                case 2:
                    btnActionRun.SetEnalbled(true);
                    btnActionRun.SelectControl(true);
                    break;
            }
            switch (btnNext)
            {
                case 0:
                    btnActionNext.SetEnalbled(false);
                    break;
                case 1:
                    btnActionNext.SetEnalbled(true);
                    btnActionNext.SelectControl(false);
                    break;
                case 2:
                    btnActionNext.SetEnalbled(true);
                    btnActionNext.SelectControl(true);
                    break;
            }
        }
        private void LoadBtn()
        {
            var pathApp = AppDomain.CurrentDomain.BaseDirectory + "Image\\btn\\";
            //btnBack
            btnActionBack.IconActive = Image.FromFile(pathApp + "iconBackActive.png");
            btnActionBack.IconDefault = Image.FromFile(pathApp + "iconBackDefault.png");
            btnActionBack.IconDisable = Image.FromFile(pathApp + "iconBackDisable.png");
            btnActionBack.Texts = "Back";
            btnActionBack._ClickControl += btnBackClick;
            btnActionBack.ForeColors = Color.FromArgb(37, 158, 238);
            //btnStop
            btnActionStop.IconActive = Image.FromFile(pathApp + "iconStopActive.png");
            btnActionStop.IconDefault = Image.FromFile(pathApp + "iconStopDefault.png");
            btnActionStop.IconDisable = Image.FromFile(pathApp + "iconStopDisable.png");
            btnActionStop.Texts = "Stop";
            btnActionStop._ClickControl += btnStopClick;
            btnActionStop.ForeColors = Color.FromArgb(255, 55, 80);
            //btnRun
            btnActionRun.IconActive = Image.FromFile(pathApp + "iconRunActive.png");
            btnActionRun.IconDefault = Image.FromFile(pathApp + "iconRunDefault.png");
            btnActionRun.IconDisable = Image.FromFile(pathApp + "iconRunDisable.png");
            btnActionRun.Texts = "Run";
            btnActionRun._ClickControl += btnRunClick;
            btnActionRun.ForeColors = Color.FromArgb(50, 177, 151);
            //btnNext
            btnActionNext.IconActive = Image.FromFile(pathApp + "iconNextActive.png");
            btnActionNext.IconDefault = Image.FromFile(pathApp + "iconNextDefault.png");
            btnActionNext.IconDisable = Image.FromFile(pathApp + "iconNextDisable.png");
            btnActionNext.Texts = "Next";
            btnActionNext._ClickControl += btnNextClick;
            btnActionNext.ForeColors = Color.FromArgb(37, 158, 238);
        }
        private void btnBackClick(object sender, EventArgs e)
        {
            backStep();
        }
        private void btnStopClick(object sender, EventArgs e)
        {
            stopStepClick();
        }
        private void btnRunClick(object sender, EventArgs e)
        {
         
        }
        private void btnNextClick(object sender, EventArgs e)
        {
            NextStep();
        }
        #endregion
        #region public function

        // async Task để nơi gọi có thể await: dựng xong nội dung RỒI mới Show() (tránh nháy trống),
        // trong khi phần đọc DB vẫn chạy nền (không treo UI).
        public async Task RunProcedureId(int procedureId)
        {
            LoadBtn();
            _sortCart = new List<SortCardViewModel>();
            _statusAction = 1;
            _statusActionStep = 0;
            ProcedureModel model = new ProcedureModel();
            // Đọc procedure từ DB (nặng, thuần dữ liệu) chạy nền để không treo UI.
            // Sau await, luồng quay lại UI thread nên phần dựng giao diện bên dưới vẫn an toàn.
            _Vm = await UiTask.RunAsync(() => model.GetProcedureById(procedureId));
            _variables = _Vm.Variables;
            _Vm.CurrentStep = 1;
            _Vm.StartTime = DateTime.Now;
   
            lblHugProcedureName.Size = Convert.GetTextSize(_Vm.Subject, lblHugProcedureName.Font, 580, 25);
            lblHugProcedureName.Text = _Vm.Subject;
            lblHugIDProcedure.Text = "ID: " + _Vm.Id;
            lblHugVersionProcedure.Text = "Ver " + _Vm.Version;
            lblTextDescription.Text = _Vm.Description;
            if (_Vm.TableProcedures.Count > 0)
            {
                _Vm.CurrentStep = 1;
                _Vm.StartTime = DateTime.Now;
                //LoadTableStep
                foreach (var item in _Vm.TableProcedures)
                {
                    var card = new SortCardViewModel
                    {
                        Name = "Step" + item.NumberOder,
                        Content = item.NumberOder + ". " + item.Title,
                        NumberOrder = item.NumberOder
                    };
                    _sortCart.Add(card);
                }
                tblStep.LoadFormData(_sortCart);
                _stepClick = _sortCart[0].Name;
                tblStep.SetActive(1);
                // LoadTerminal
                _frmShowLog = new FormShowLog();
                _frmShowLog.TopLevel = false;
                _frmShowLog.Dock = DockStyle.Fill;
                panelRight2.Controls.Add(_frmShowLog);
                _frmShowLog.Show();
                addLog("Run procedure: " + _Vm.Subject);
                addLog("Load Step " + _Vm.CurrentStep + ": " + _Vm.TableProcedures[0].Title);
                // Panel Modem
                // Panel info
                LoadPanelInfo(_Vm.TableProcedures[0], 0);
                showPanelRight(0);
                //LoadBtnAction
                if (_stepBasics.Contains(_Vm.TableProcedures[0].StepType))
                    LoadBtnStatus(0, 1, 0, 1);
                else LoadBtnStatus(0, 1, 1, 1);
                //LoadStepContent
                loadEvaluateStep(_Vm.CurrentStep);
            }
        }

        public bool SaveProcedure(bool done)
        {
            _Vm.Log = _frmShowLog.GetText();
            _Vm.EndTime = DateTime.Now;
            if (done) _Vm.Status = 1;
            else _Vm.Status = 2;
            // save to physiscal
            string pathTemplate = AppDomain.CurrentDomain.BaseDirectory + "DataResult\\";
            if (!Directory.Exists(pathTemplate))
            {
                Directory.CreateDirectory(pathTemplate);
            }        
            ProcedureModel model = new ProcedureModel();
            _Vm.UserId = 2;
            _Vm.Type = 0;
            _Vm.ProcedureJson = JsonConvert.SerializeObject(_Vm);
            model.InsertResultProcedure(_Vm);
            ShowMess("Notification", "Save result successfully.", 1);
            _SendAction?.Invoke("ClearFormMain", EventArgs.Empty);
            return true;
        }
        #endregion
        #region private function
    

      
       


        private void loadEvaluateStep(int numberrStep)
        {
            RestoreLayoutCollapse();
            //ClearDynamicTabs();
            var currentStep = _Vm.TableProcedures[numberrStep - 1];
            // setup value prestep
            if (_Vm.CurrentStep > 1)
            {
                for (int i = 0; i < _Vm.CurrentStep - 1; i++)
                {
                    var preStep = _Vm.TableProcedures[i];
                    var lstp = preStep.Variables;
                    if (lstp != null && lstp.Count > 0)
                    {
                        if (currentStep.Variables != null && currentStep.Variables.Count > 0)
                        {
                            foreach (var item in currentStep.Variables)
                            {
                                foreach (var item2 in lstp)
                                {
                                    if (item.Name == item2.Name)
                                    {
                                        item.Value = item2.Value;
                                    }
                                }
                            }
                        }
                    }

                }
            }
            if (_stepBasics.Contains(currentStep.StepType))
            {
                if (panelContent.Controls.Count > 0)
                {
                    foreach (Control control in panelContent.Controls)
                    {
                        control.Dispose();
                    }
                }
                panelContent.Controls.Clear();
                if (currentStep.StepType == StepTypeName.Number || currentStep.StepType == StepTypeName.Boolean || currentStep.StepType == StepTypeName.String || currentStep.StepType == StepTypeName.FileAttach || currentStep.StepType == StepTypeName.AddParameter)
                {
                    _frmEvaluateParameter = new FormEvaluateParameter();
                    _frmEvaluateParameter._StopProcedure += _frmEvaluate_StopProcedure;
                    _frmEvaluateParameter.TopLevel = false;
                    _frmEvaluateParameter.Dock = DockStyle.Fill;
                    panelContent.Controls.Add(_frmEvaluateParameter);
                    _frmEvaluateParameter.Show();
                    _frmEvaluateParameter.LoadData(currentStep, _Vm.Variables);
                }
                else if (currentStep.StepType == StepTypeName.Correction)
                {
                    _frmEvaluateCorrection = new FormEvaluateCorrection();
                    _frmEvaluateCorrection.LoadData(currentStep);
                    _frmEvaluateCorrection._StopProcedure += _frmEvaluate_StopProcedure;
                    _frmEvaluateCorrection.TopLevel = false;
                    _frmEvaluateCorrection.Dock = DockStyle.Fill;
                    panelContent.Controls.Add(_frmEvaluateCorrection);
                    _frmEvaluateCorrection.Show();
                }
                else if (currentStep.StepType == StepTypeName.Review)
                {
                    _frmEvaluateReview = new FormEvaluateReview();
                    _frmEvaluateReview.LoadData(_Vm);
                    _frmEvaluateReview._StopProcedure += _frmEvaluate_StopProcedure;
                    _frmEvaluateReview.TopLevel = false;
                    _frmEvaluateReview.Dock = DockStyle.Fill;
                    panelContent.Controls.Add(_frmEvaluateReview);
                    _frmEvaluateReview.Show();
                }
                else if (currentStep.StepType == StepTypeName.Report)
                {
                    _frmEvaluateReport = new FormEvaluateReport();
                    _frmEvaluateReport.LoadData(_Vm);
                    _frmEvaluateReport._StopProcedure += _frmEvaluate_StopProcedure;
                    _frmEvaluateReport.TopLevel = false;
                    _frmEvaluateReport.Dock = DockStyle.Fill;
                    _frmEvaluateReport._exprort += EventExport;
                    panelContent.Controls.Add(_frmEvaluateReport);
                    _frmEvaluateReport.Show();
                }
                else if (currentStep.StepType == StepTypeName.Calculate)
                {
                    _frmEvaluateCalculation = new FormEvaluateCalculation();
                    _frmEvaluateCalculation.LoadData(currentStep, _variables);
                    _frmEvaluateCalculation._StopProcedure += _frmEvaluate_StopProcedure;
                    _frmEvaluateCalculation.TopLevel = false;
                    _frmEvaluateCalculation.Dock = DockStyle.Fill;
                    panelContent.Controls.Add(_frmEvaluateCalculation);
                    _frmEvaluateCalculation.Show();
                }
                else if (currentStep.StepType == StepTypeName.UrlConfiguration)
                {
                    _frmEvaluateBrowserURL = new FormEvaluateBrowserURL();
                    _frmEvaluateBrowserURL.LoadData(currentStep);
                    _frmEvaluateBrowserURL._StopProcedure += _frmEvaluate_StopProcedure;
                    _frmEvaluateBrowserURL.TopLevel = false;
                    _frmEvaluateBrowserURL.Dock = DockStyle.Fill;
                    panelContent.Controls.Add(_frmEvaluateBrowserURL);
                    _frmEvaluateBrowserURL.Show();

                    InitializeUrlTabsForStep(currentStep);
                }
                else if (currentStep.StepType == StepTypeName.DeviceUnderTest)
                {
                    _frmEvaluateDUTInformation = new FormEvaluateDUTInformation();
                    _frmEvaluateDUTInformation.LoadData(currentStep, _Vm.Variables, _Vm.DUTIds[0]);
                    _frmEvaluateDUTInformation._StopProcedure += _frmEvaluate_StopProcedure;
                    _frmEvaluateDUTInformation.TopLevel = false;
                    _frmEvaluateDUTInformation.Dock = DockStyle.Fill;
                    panelContent.Controls.Add(_frmEvaluateDUTInformation);
                    _frmEvaluateDUTInformation.Show();
                }
            }
            else
            {
                if (_frmEvaluate != null && _frmEvaluate.CanFocus) _frmEvaluate.Dispose();
                if (currentStep.Functions != null && currentStep.Functions.Where(t => t.FunctionName == StepFunctionName.LoadView).Count() > 0)
                {
                    var form =(Form) _service.CallFunctionLoad(_Vm, StepFunctionName.LoadView, out string mess);
                    _frmEvalueateDefault = new FormEvaluateDefault();
                    _frmEvalueateDefault.ShowEvalueate(form, currentStep.Comment, currentStep.MaskDoneValue);
                    _frmEvalueateDefault.TopLevel = false;
                    _frmEvalueateDefault._StopProcedure += _frmEvaluate_StopProcedure;
                    _frmEvalueateDefault.Dock = DockStyle.Fill;
                    panelContent.Controls.Clear();
                    panelContent.Controls.Add(_frmEvalueateDefault);
                    _frmEvalueateDefault.Show();                   
                }
            }
            if (currentStep.Functions != null && currentStep.Functions.Any(t => t.FunctionName == "Monitor"))
            {
                InitializeMonitorTabForStep(currentStep);
            }
        }



        private void _frmEvaluate_StopProcedure(object? sender, EventArgs e)
        {
            stopStepClick();
        }
        private void LoadPanelInfo(TableProcedureViewModel step, int startCycle)
        {
            if (panelRight.Controls.Count > 0)
            {
                foreach (Control item in panelRight.Controls)
                {
                    item.Dispose();
                }
                panelRight.Controls.Clear();
            }
            _frmTableInfo = new FormTableInfo(_Vm.TableProcedures[_Vm.CurrentStep - 1], 0);
            _frmTableInfo.TopLevel = false;
            _frmTableInfo.Dock = DockStyle.Fill;
            panelRight.Controls.Add(_frmTableInfo);
            _frmTableInfo.Show();
        }
        private void addLog(string msg)
        {
            _frmShowLog.AddLog(msg);
        }
        // true: show detai, false show terminal
        private void showPanelRight(int value)
        {
            ResetDynamicTabsState();
            if (value == 0 && panelBorderDetail != null && flowTabsContainer != null)
            {
                flowTabsContainer.ScrollControlIntoView(panelBorderDetail);
            }
            else if (value == 1 && panelBorderTerminal != null && flowTabsContainer != null)
            {
                flowTabsContainer.ScrollControlIntoView(panelBorderTerminal);
            }
            switch (value)
            {
                case 0:
                    panelRight2.Visible = false;
                    //panelRightACU.Visible = false;
                    panelRightModem.Visible = false;
                    panelRight.Visible = true;
                    panelBorderDetail.BackColor = Color.White;

                    lblHugDetail.BackColor = Color.White;
                    lblHugTerminal.BackColor = Color.FromArgb(227, 227, 227);
                    panelBorderTerminal.BackColor = Color.FromArgb(227, 227, 227);
                    //lblTitleModem.BackColor = Color.FromArgb(227, 227, 227);
                    //panelTitleModem.BackColor = Color.FromArgb(227, 227, 227);
                    //lblTitleACU.BackColor = Color.FromArgb(227, 227, 227);
                    //panelTitleACU.BackColor = Color.FromArgb(227, 227, 227);
                    break;
                case 1:
                    panelRight2.Visible = true;
                    //panelRightACU.Visible = false;
                    panelRightModem.Visible = false;
                    panelRight.Visible = false;
                    panelBorderDetail.BackColor = Color.FromArgb(227, 227, 227);
                    lblHugDetail.BackColor = Color.FromArgb(227, 227, 227);
                    lblHugTerminal.BackColor = Color.White;
                    panelBorderTerminal.BackColor = Color.White;
                    //lblTitleModem.BackColor = Color.FromArgb(227, 227, 227);
                    //panelTitleModem.BackColor = Color.FromArgb(227, 227, 227);
                    //lblTitleACU.BackColor = Color.FromArgb(227, 227, 227);
                    //panelTitleACU.BackColor = Color.FromArgb(227, 227, 227);
                    break;
                case 2:
                    panelRight2.Visible = false;
                    //panelRightACU.Visible = false;
                    panelRightModem.Visible = true;
                    panelRight.Visible = false;
                    panelBorderDetail.BackColor = Color.FromArgb(227, 227, 227);
                    lblHugDetail.BackColor = Color.FromArgb(227, 227, 227);
                    lblHugTerminal.BackColor = Color.FromArgb(227, 227, 227);
                    panelBorderTerminal.BackColor = Color.FromArgb(227, 227, 227);
                    //lblTitleModem.BackColor = Color.White;
                    //panelTitleModem.BackColor = Color.White;
                    //lblTitleACU.BackColor = Color.FromArgb(227, 227, 227);
                    //panelTitleACU.BackColor = Color.FromArgb(227, 227, 227);
                    break;
                case 3:
                    panelRight2.Visible = false;
                    //panelRightACU.Visible = true;
                    //panelRightModem.Visible = false;
                    panelRight.Visible = false;
                    panelBorderDetail.BackColor = Color.FromArgb(227, 227, 227);
                    lblHugDetail.BackColor = Color.FromArgb(227, 227, 227);
                    lblHugTerminal.BackColor = Color.FromArgb(227, 227, 227);
                    panelBorderTerminal.BackColor = Color.FromArgb(227, 227, 227);
                    //lblTitleModem.BackColor = Color.FromArgb(227, 227, 227);
                    //panelTitleModem.BackColor = Color.FromArgb(227, 227, 227);
                    //lblTitleACU.BackColor = Color.White;
                    //panelTitleACU.BackColor = Color.White;
                    break;
            }
        }
        private string CheckPreStepDone(int numberStep)
        {
            var result = "";
            var stepCheck = _Vm.TableProcedures[numberStep - 1];
            if (!stepCheck.Done.HasValue || !stepCheck.Done.Value)
            {
                result = numberStep.ToString();

                if (stepCheck.Required && numberStep > 1)
                {
                    var pre = CheckPreStepDone(numberStep - 1);
                    if (!string.IsNullOrEmpty(pre)) result += "," + pre;
                }

            }
            return result;
        }
        #endregion
        #region control Action
     
        public void NextStep()
        {
            if (btnActionNext._Enable)
            {
                var currentSetp = _Vm.TableProcedures[_Vm.CurrentStep - 1];
                string messError = "";
                if (currentSetp.StepType == StepTypeName.Boolean || currentSetp.StepType == StepTypeName.Number || currentSetp.StepType == StepTypeName.String || currentSetp.StepType == StepTypeName.FileAttach || currentSetp.StepType == StepTypeName.AddParameter)
                {
                    if (_frmEvaluateParameter.CheckSave(out messError))
                    {
                        _frmEvaluateParameter.SaveValue();
                        currentSetp.Comment = _frmEvaluateParameter.GetNote();
                        currentSetp.Variables = _frmEvaluateParameter._Variable;
                        currentSetp.MaskDoneValue = _frmEvaluateParameter._Maskdone;
                        currentSetp.Done = true;
                        nextStepReady();
                    }
                    else ShowMess("Notification", messError, 3);

                }
                else if (currentSetp.StepType == StepTypeName.Review)
                {
                    _Vm = _frmEvaluateReview._vm;
                    nextStepReady();
                }
                else if (currentSetp.StepType == StepTypeName.Report)
                {
                    _frmEvaluateReport.SaveData();
                    _Vm = _frmEvaluateReport._vm;
                    nextStepReady();
                }
                else if (currentSetp.StepType == StepTypeName.UrlConfiguration)
                {
                    currentSetp.Comment = _frmEvaluateBrowserURL.GetNote();
                    _frmEvaluateBrowserURL.SaveValue();
                    currentSetp.ListURL = _frmEvaluateBrowserURL._urls;
                    currentSetp.MaskDoneValue = _frmEvaluateBrowserURL._Maskdone;
                    currentSetp.Done = true;
                    nextStepReady();
                }
                else if (currentSetp.StepType == StepTypeName.DeviceUnderTest)
                {
                    if (_frmEvaluateDUTInformation.CheckSave(out messError))
                    {
                        _frmEvaluateDUTInformation.SaveValue();
                        currentSetp.Comment = _frmEvaluateDUTInformation.GetNote();
                        currentSetp.Variables = _frmEvaluateDUTInformation._Variable;
                        currentSetp.MaskDoneValue = _frmEvaluateDUTInformation._Maskdone;
                        currentSetp.Done = true;
                        nextStepReady();
                    }
                    else ShowMess("Notification", messError, 3);

                }
                else if (currentSetp.StepType == StepTypeName.Correction)
                {
                    if (_frmEvaluateCorrection.CheckSave(out messError))
                    {
                        _frmEvaluateCorrection.SaveValue();
                        currentSetp.Comment = _frmEvaluateCorrection.GetNote();
                        var newv = _frmEvaluateCorrection._newV;
                        if (newv.Count > 0)
                        {
                            _Vm.Variables.AddRange(newv);
                        }
                        currentSetp.Variables = _frmEvaluateCorrection._Data;
                        currentSetp.MaskDoneValue = _frmEvaluateCorrection._Maskdone;
                        currentSetp.Done = true;
                        nextStepReady();
                    }
                    else ShowMess("Notification", messError, 3);

                }
                else if (currentSetp.StepType == StepTypeName.Calculate)
                {
                    if (_frmEvaluateCalculation.CheckSave(out messError))
                    {
                        _frmEvaluateCalculation.SaveValue();
                        currentSetp.Comment = _frmEvaluateCalculation.GetNote();
                        currentSetp.Variables = _frmEvaluateCalculation._Variable;
                        currentSetp.MaskDoneValue = _frmEvaluateCalculation._Maskdone;
                        currentSetp.Done = true;
                        nextStepReady();
                    }
                    else ShowMess("Notification", messError, 3);
                }
                else
                {
                    if (!currentSetp.Done.HasValue || !currentSetp.Done.Value)
                    {
                        if(_service.CallFunctionSave(_Vm, StepFunctionName.SaveData, out string mess, out TemplateViewModel outR))
                        {
                            _Vm = outR;
                            _Vm.TableProcedures[_Vm.CurrentStep-1].MaskDoneValue = _frmEvalueateDefault._Maskdone;
                            nextStepReady();
                        }
                        else ShowMess("Notification",mess, 3);
                    }
                }             
            }
        }
        private void LoadStepReady(int stepNumber)
        {
            // table Step
            _Vm.CurrentStep = stepNumber;
            _stepClick = _sortCart[stepNumber - 1].Name;
            tblStep.SetActive(stepNumber);
            //loadStepContent
            loadEvaluateStep(stepNumber);
            // Panel info
            LoadPanelInfo(_Vm.TableProcedures[stepNumber - 1], 0);
            //LoadBtnAction
            LoadBtnStatus(1, 1, 0, 1);
            // LoadTerminal
            addLog("Load Step " + stepNumber + ": " + _Vm.TableProcedures[stepNumber - 1].Title);
        }
        private void nextStepReady()
        {
            if (_Vm.CurrentStep < _Vm.TableProcedures.Count)
            {
                _Vm.CurrentStep++;
                LoadStepReady(_Vm.CurrentStep);
            }
            else
            {
                FormExportAndSave frm = new FormExportAndSave();
                frm._EventExport += EventExport;
                if(ShowFormDialogResult(frm)==DialogResult.OK)              
                    SaveProcedure(true);
            }

        }
        private async void EventExport(object sender, EventArgs e)
        {
            string ext = ".xlsx";
            if (_frmEvaluateReport != null && _frmEvaluateReport.CanFocus)
                _Vm = _frmEvaluateReport._vm;
            if (_Vm.ExportPDF) ext = ".PDF";

            var vm = _Vm;
            try
            {
                // Xuất báo cáo (Excel/PDF) là thao tác I/O nặng -> chạy nền để không treo UI.
                string message = await UiTask.RunAsync(() => _service.ExportReport(ext, vm));
                ShowMess("Notification", message, 2);
            }
            catch (Exception ex)
            {
                Logger.Log("EventExport error: " + ex);
                ShowMess("Notification", "Không thể xuất báo cáo: " + ex.Message, 3);
            }
        }
        private void stopStepClick()
        {          
            FormYesNoCancel frmOK = new FormYesNoCancel();
            frmOK.LoadData("Confirm Action", "Want to Stop this procedure? If you click 'NO', all test results will be lost. If you click 'YES', test results will be saved temporarily.", "YES", "NO", "Cancel", 2);
            var dialogResult = ShowFormDialogResult(frmOK);
            if (dialogResult == DialogResult.OK || dialogResult == DialogResult.No)
            {
                var currentStep = _Vm.TableProcedures[_Vm.CurrentStep - 1];
                if (!_stepBasics.Contains(currentStep.StepType))
                {
                    if (!_service.CallFunctionStop(_Vm, out string mess))
                    {
                        ShowMess("Notification", mess, 3);
                        return;
                    }                    
                }
                if (dialogResult == DialogResult.OK)
                {
                    SaveProcedure(false);
                }
                else if (dialogResult == DialogResult.No)
                {
                    _SendAction?.Invoke("ClearFormMain", EventArgs.Empty);
                }
            }         
        }

 
        private void tblStep__ClickControl(object sender, EventArgs e)
        {
            // Check this step
            if (_statusActionStep != 1)
            {
                RowStepControl row = sender as RowStepControl;
                if (row.Name != _stepClick)
                {
                    var toStep = _Vm.TableProcedures[row._NumberOrder - 1];
                    if (toStep.Required && (!toStep.Done.HasValue || !toStep.Done.Value) && row._NumberOrder > 1)
                    {
                        var strCheck = CheckPreStepDone(row._NumberOrder - 1);
                        if (string.IsNullOrEmpty(strCheck))
                        {
                            LoadStepReady(row._NumberOrder);
                        }
                        else
                        {
                            ShowMess("Notification", "This step requires steps " + strCheck + " to be completed first.", 2);
                        }
                    }
                    else
                    {
                        LoadStepReady(row._NumberOrder);
                    }
                }
            }
        }
        #endregion
        /// <summary>
        /// 1: success, 2 warning, 3 Error
        /// </summary>
        /// <param name="title"></param>
        /// <param name="strmess"></param>
        /// <param name="status"></param>

        private void backStep()
        {
            if (_Vm.CurrentStep > 1)
            {
                if (!_Vm.TableProcedures[_Vm.CurrentStep - 1].Done.HasValue || !_Vm.TableProcedures[_Vm.CurrentStep - 1].Done.Value)
                {
              
                    FormOKCancelAll frmOK = new FormOKCancelAll();
                    frmOK.LoadData("Confirm Action", "The data of the current step will not be saved. Select \"OK\" to go back to previous step!", "OK", "Cancel", 2);
                    if (ShowFormDialogResult(frmOK)==  DialogResult.OK)
                    {
                        var currentStep = _Vm.TableProcedures[_Vm.CurrentStep - 1];
                        _Vm.CurrentStep--;
                        LoadStepReady(_Vm.CurrentStep);
                    }                   
                }
            }
        }

        #region panel Right
        private void panelBorderDetail_Click(object sender, EventArgs e)
        {
            showPanelRight(0);
        }
        private void panelBorderTerminal_Click(object sender, EventArgs e)
        {
            showPanelRight(1);
        }
        public void InitializeMonitorTabForStep(TableProcedureViewModel step)
        {
            CreateMonitorTab(step);
            // Find and select the MONITORING tab
            for (int i = 0; i < _dynamicTabs.Count; i++)
            {
                var lbl = _dynamicTabs[i].Controls[0] as Label;
                if (lbl != null && lbl.Text == "MONITORING")
                {
                    SelectDynamicTab(i);
                    break;
                }
            }
        }
        private void CreateMonitorTab(TableProcedureViewModel step)
        {
            if (step == null || step.Functions == null)
                return;

            var functionMonitor = step.Functions.FirstOrDefault(t => t.FunctionName == "Monitor");
            if (functionMonitor == null)
                return;

            // Check if MONITORING tab is already present
            bool alreadyExists = false;
            foreach (var tab in _dynamicTabs)
            {
                var tabLabel = tab.Controls[0] as Label;
                if (tabLabel != null && tabLabel.Text == "MONITORING")
                {
                    alreadyExists = true;
                    break;
                }
            }
            if (alreadyExists)
                return;

            float scale = this.DeviceDpi / 96f;
            int tabWidth = (int)(111 * scale);
            int tabHeight = (int)(40 * scale);

            object[] varmonitor = null;
            if (functionMonitor.FunctionVariables?.Count > 0)
            {
                varmonitor = ConvertFromVariable(functionMonitor.FunctionVariables, step.Variables);
            }
            object firstVar = (varmonitor != null && varmonitor.Length > 0) ? varmonitor[0] : null;
            object[] inputs3 = new object[2] { firstVar, "" };
            try
            {
                Form monitorForm = (Form)_service.CallFunction(
                    functionMonitor.PathDll,
                    functionMonitor.Assembly,
                    functionMonitor.AssemblyType,
                    functionMonitor.Value,
                    inputs3);

                if (monitorForm != null)
                {
                    monitorForm.TopLevel = false;
                    monitorForm.FormBorderStyle = FormBorderStyle.None;
                    monitorForm.Dock = DockStyle.None;
                    monitorForm.Location = new Point(0, 0);
                    monitorForm.Size = panelRightModem.ClientSize;   
                    // Apply custom layout scaling
                    ResizeMonitorFormControls(monitorForm);
                    panelRightModem.Controls.Add(monitorForm);
                    _dynamicBrowsers.Add(monitorForm);
                    panelRightModem.SizeChanged += (s, e) =>
                    {
                        if (monitorForm != null && !monitorForm.IsDisposed)
                        {
                            monitorForm.Size = panelRightModem.ClientSize;
                            ResizeMonitorFormControls(monitorForm);
                            monitorForm.Invalidate(true);
                            monitorForm.Update();
                        }
                    };
                    monitorForm.Show();
                    ResizeMonitorFormControls(monitorForm); // layout again once shown
                    monitorForm.Invalidate(true);
                    monitorForm.Update();
                }
            }
            catch (Exception ex)
            {
                addLog("Error loading Monitor Form: " + ex.Message);
            }

            PanelBorderRadiusCustom tabBtn = new PanelBorderRadiusCustom();
            tabBtn.Name = "panelDynamicTab_Monitor_" + _dynamicTabs.Count;
            tabBtn.Size = new Size(tabWidth, tabHeight);
            tabBtn.Margin = new Padding(0);
            tabBtn.BorderSize = 1;
            tabBtn.BorderColor = Color.DarkGray;
            tabBtn.BackColor = Color.FromArgb(227, 227, 227);
            tabBtn.BackColorG = Color.Empty;
            tabBtn.RadiusTopLeft = 0;
            tabBtn.RadiusTopRight = 0;
            tabBtn.RadiusBottomLeft = 0;
            tabBtn.RadiusBottomRight = 0;

            Label lbl = new Label();
            lbl.Text = "MONITORING";
            lbl.Font = new Font("Segoe UI Variable Display Semibold", 9.5F, FontStyle.Bold);
            lbl.ForeColor = Color.Black;
            lbl.BackColor = Color.Transparent;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Dock = DockStyle.Fill;

            int index = _dynamicTabs.Count;
            tabBtn.Click += (s, e) => SelectDynamicTab(index);
            lbl.Click += (s, e) => SelectDynamicTab(index);

            tabBtn.Controls.Add(lbl);
            if (flowTabsContainer != null)
            {
                flowTabsContainer.Controls.Add(tabBtn);
            }
            _dynamicTabs.Add(tabBtn);

            if (btnCycleTab != null)
            {
                btnCycleTab.Visible = _dynamicTabs.Count > 2;
            }
        }
        private void ResizeMonitorFormControls(Form monitorForm)
        {
            if (monitorForm == null) return;
            var chart = monitorForm.Controls["chartPower"];
            var header = monitorForm.Controls["panelLable"];
            var ctrlPanel = monitorForm.Controls["panelControl"];
            var borderPanel = monitorForm.Controls["panelCustomBorder1"];
            int formWidth = monitorForm.ClientSize.Width;
            int formHeight = monitorForm.ClientSize.Height;
            // 1. Resize header to fit full width
            if (header != null)
            {
                header.Location = new Point(4, 0);
                header.Size = new Size(formWidth - 8, 50);
                // Align buttons in header to the right
                var btn10 = header.Controls["btn10M"];
                var btn30 = header.Controls["btn30M"];
                if (btn10 != null && btn30 != null)
                {
                    btn10.Location = new Point(header.Width - btn10.Width - 8, btn10.Location.Y);
                    btn30.Location = new Point(btn10.Location.X - btn30.Width - 6, btn30.Location.Y);
                }
            }

            // 2. Handle middle controls
            int topOffset = 56;
            int bottomOffset = 10;
            int remainingHeight = formHeight - topOffset - bottomOffset;
            if (remainingHeight < 100) remainingHeight = 100;
            // Check if right-side control panels are visible and fit the screen width
            bool showRightPanel = (ctrlPanel != null && ctrlPanel.Visible && formWidth > 650);
            if (showRightPanel)
            {
                // Position control panel on the right side
                ctrlPanel.Location = new Point(formWidth - ctrlPanel.Width - 4, topOffset);
                ctrlPanel.Height = remainingHeight;
                if (borderPanel != null)
                {
                    borderPanel.Location = new Point(ctrlPanel.Location.X, borderPanel.Location.Y);
                    borderPanel.Height = remainingHeight - (borderPanel.Top - ctrlPanel.Top);
                }
                // Chart takes the remaining left area
                if (chart != null)
                {
                    chart.Location = new Point(4, topOffset);
                    chart.Size = new Size(ctrlPanel.Location.X - chart.Location.X - 6, remainingHeight);
                }
            }
            else
            {
                // Hide right panels if screen is too narrow
                if (ctrlPanel != null) ctrlPanel.Visible = false;
                if (borderPanel != null) borderPanel.Visible = false;
                // Chart takes full width
                if (chart != null)
                {
                    chart.Location = new Point(4, topOffset);
                    chart.Size = new Size(formWidth - 8, remainingHeight);
                }
            }
        }
        public void ResetDynamicTabsState()
        {
            RestoreLayoutCollapse();
            foreach (var tab in _dynamicTabs)
            {
                tab.BackColor = Color.FromArgb(227, 227, 227);
                var lbl = tab.Controls[0] as Label;
                if (lbl != null) lbl.BackColor = Color.Transparent;
            }
            foreach (var browser in _dynamicBrowsers)
            {
                browser.Visible = false;
            }
        }
        private void CreateUrlTabs(TableProcedureViewModel step)
        {
            if (step == null || step.ListURL == null || step.ListURL.Count == 0)
                return;

            float scale = this.DeviceDpi / 96f;
            int tabWidth = (int)(111 * scale);
            int tabHeight = (int)(40 * scale);

            for (int i = 0; i < step.ListURL.Count; i++)
            {
                var config = step.ListURL[i];
                int index = i;

                // Check if a browser with the exact same URL is already present in _dynamicBrowsers
                bool alreadyExists = false;
                foreach (var b in _dynamicBrowsers)
                {
                    if (b is FormBrowser browser && browser.Tag as string == config.URL)
                    {
                        alreadyExists = true;
                        break;
                    }
                }
                if (alreadyExists)
                    continue;
                // 1. Create Browser for this URL tab
                FormBrowser newBrowser = new FormBrowser(config.URL);
                newBrowser.Tag = config.URL; // Store URL in Tag for duplicate checking!
                newBrowser.Dock = DockStyle.Fill;
                newBrowser.TopLevel = false;
                panelRightModem.Controls.Add(newBrowser);
                _dynamicBrowsers.Add(newBrowser);

                // 2. Create Tab Button (PanelBorderRadiusCustom)
                PanelBorderRadiusCustom tabBtn = new PanelBorderRadiusCustom();
                tabBtn.Name = "panelDynamicTab_" + _dynamicTabs.Count;
                tabBtn.Size = new Size(tabWidth, tabHeight);
                tabBtn.Margin = new Padding(0);
                tabBtn.BorderSize = 1;
                tabBtn.BorderColor = Color.DarkGray;
                tabBtn.BackColor = Color.FromArgb(227, 227, 227);
                tabBtn.BackColorG = Color.Empty;
                tabBtn.RadiusTopLeft = 0;
                tabBtn.RadiusTopRight = 0;
                tabBtn.RadiusBottomLeft = 0;
                tabBtn.RadiusBottomRight = 0;
                // Label inside Tab
                Label lbl = new Label();
                lbl.Text = string.IsNullOrWhiteSpace(config.Title) ? "URL " + (_dynamicTabs.Count + 1) : config.Title;
                lbl.Font = new Font("Segoe UI Variable Display Semibold", 9.5F, FontStyle.Bold);
                lbl.ForeColor = Color.Black;
                lbl.BackColor = Color.Transparent;
                lbl.TextAlign = ContentAlignment.MiddleCenter;
                lbl.Dock = DockStyle.Fill;

                // Wire click events
                int tabIndex = _dynamicTabs.Count;
                tabBtn.Click += (s, e) => SelectDynamicTab(tabIndex);
                lbl.Click += (s, e) => SelectDynamicTab(tabIndex);

                tabBtn.Controls.Add(lbl);
                if (flowTabsContainer != null)
                {
                    flowTabsContainer.Controls.Add(tabBtn);
                }
                _dynamicTabs.Add(tabBtn);
            }

            if (btnCycleTab != null)
            {
                btnCycleTab.Visible = _dynamicTabs.Count > 2;
            }
        }
        private void RestoreLayoutCollapse()
        {
            if (!_isExpanded)
            {
                if (btnExpand != null) btnExpand.Visible = false;
                return;
            }
            _isExpanded = false;
            panelContent.Visible = true;
            if (panelCustomRadius1 != null) panelCustomRadius1.Visible = true;

            int rightEdge = panelTitleRight.Left + panelTitleRight.Width;
            if (_originalRightPanelWidth != -1)
            {
                panelTitleRight.Left = rightEdge - _originalRightPanelWidth;
                panelTitleRight.Width = _originalRightPanelWidth;

                panelRightModem.Left = rightEdge - _originalRightPanelWidth;
                panelRightModem.Width = _originalRightPanelWidth;

                if (panelTabsWrapper != null)
                {
                    int btnSize = btnExpand.Width;
                    panelTabsWrapper.Width = panelTitleRight.Width - btnSize * 2;
                }
            }

            if (btnExpand != null)
            {
                btnExpand.Text = "⤢";
                btnExpand.Visible = false;
            }
        }
        FormBrowser _formBrowserModem;
        FormBrowser _formBrowserACU;
        private List<PanelBorderRadiusCustom> _dynamicTabs = new List<PanelBorderRadiusCustom>();
        private List<Form> _dynamicBrowsers = new List<Form>();
        private Label btnExpand;
        private Label btnCycleTab;
        private Panel panelTabsWrapper;
        private FlowLayoutPanel flowTabsContainer;
        private bool _isExpanded = false;
        private int _originalRightPanelWidth = -1;
        private void InitializeDynamicTabControls()
        {
            float scale = this.DeviceDpi / 96f;
            int btnSize = (int)(40 * scale);
            Color textBlue = Color.FromArgb(0, 32, 77);
            _originalRightPanelWidth = panelTitleRight.Width;
            // 1. Create Wrapper Panel to clip and hide the scrollbar
            panelTabsWrapper = new Panel();
            panelTabsWrapper.Name = "panelTabsWrapper";
            panelTabsWrapper.Location = new Point(0, 0);
            panelTabsWrapper.Size = new Size(panelTitleRight.Width - btnSize * 2, panelTitleRight.Height);
            panelTabsWrapper.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            panelTabsWrapper.BackColor = Color.Transparent;
            panelTabsWrapper.Margin = new Padding(0);
            panelTabsWrapper.Padding = new Padding(0);

            // 2. Create FlowLayoutPanel to hold all tabs (height is taller to hide scrollbar)
            flowTabsContainer = new FlowLayoutPanel();
            flowTabsContainer.Name = "flowTabsContainer";
            flowTabsContainer.FlowDirection = FlowDirection.LeftToRight;
            flowTabsContainer.WrapContents = false;
            flowTabsContainer.AutoScroll = true;
            flowTabsContainer.Location = new Point(0, 0);
            flowTabsContainer.Size = new Size(panelTabsWrapper.Width, panelTabsWrapper.Height + 20);
            flowTabsContainer.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            flowTabsContainer.BackColor = Color.Transparent;
            flowTabsContainer.Margin = new Padding(0);
            flowTabsContainer.Padding = new Padding(0);

            // Move existing static tabs (DETAIL, TERMINAL) into flowTabsContainer
            panelTitleRight.Controls.Remove(panelBorderDetail);
            panelTitleRight.Controls.Remove(panelBorderTerminal);

            panelBorderDetail.Margin = new Padding(0);
            panelBorderTerminal.Margin = new Padding(0);

            flowTabsContainer.Controls.Add(panelBorderDetail);
            flowTabsContainer.Controls.Add(panelBorderTerminal);
            panelTabsWrapper.Controls.Add(flowTabsContainer);
            panelTitleRight.Controls.Add(panelTabsWrapper);

            // 3. Create Expand/Collapse Button (Neo cứng bên phải)
            btnExpand = new Label();
            btnExpand.Name = "btnExpand";
            btnExpand.Size = new Size(btnSize, btnSize);
            btnExpand.Location = new Point(panelTitleRight.Width - btnSize, 0);
            btnExpand.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExpand.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExpand.ForeColor = textBlue;
            btnExpand.BackColor = Color.Transparent;
            btnExpand.Text = "⤢";
            btnExpand.TextAlign = ContentAlignment.MiddleCenter;
            btnExpand.Cursor = Cursors.Hand;
            btnExpand.Visible = false;
            btnExpand.Click += btnExpand_Click;
            btnExpand.MouseEnter += NavigationButton_MouseEnter;
            btnExpand.MouseLeave += NavigationButton_MouseLeave;

            // 4. Create Cycle Tab Button (>>)
            btnCycleTab = new Label();
            btnCycleTab.Name = "btnCycleTab";
            btnCycleTab.Size = new Size(btnSize, btnSize);
            btnCycleTab.Location = new Point(panelTitleRight.Width - btnSize * 2, 0);
            btnCycleTab.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCycleTab.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnCycleTab.ForeColor = textBlue;
            btnCycleTab.BackColor = Color.Transparent;
            btnCycleTab.Text = "»";
            btnCycleTab.TextAlign = ContentAlignment.MiddleCenter;
            btnCycleTab.Cursor = Cursors.Hand;
            btnCycleTab.Visible = false;
            btnCycleTab.Click += btnCycleTab_Click;
            btnCycleTab.MouseEnter += NavigationButton_MouseEnter;
            btnCycleTab.MouseLeave += NavigationButton_MouseLeave;

            panelTitleRight.Controls.Add(btnExpand);
            panelTitleRight.Controls.Add(btnCycleTab);
        }
        private void btnExpand_Click(object sender, EventArgs e)
        {
            if (_originalRightPanelWidth == -1)
            {
                _originalRightPanelWidth = panelTitleRight.Width;
            }
            _isExpanded = !_isExpanded;
            int rightEdge = panelTitleRight.Left + panelTitleRight.Width;
            if (_isExpanded)
            {
                panelContent.Visible = false;
                if (panelCustomRadius1 != null) panelCustomRadius1.Visible = false;

                panelTitleRight.Left = panelContent.Left;
                panelTitleRight.Width = rightEdge - panelContent.Left;

                panelRightModem.Left = panelContent.Left;
                panelRightModem.Width = rightEdge - panelContent.Left;

                if (panelTabsWrapper != null)
                {
                    int btnSize = btnExpand.Width;
                    panelTabsWrapper.Width = panelTitleRight.Width - btnSize * 2;
                }
                if (btnExpand != null) btnExpand.Text = "⤡";
            }
            else
            {
                panelContent.Visible = true;
                if (panelCustomRadius1 != null) panelCustomRadius1.Visible = true;
                panelTitleRight.Left = rightEdge - _originalRightPanelWidth;
                panelTitleRight.Width = _originalRightPanelWidth;
                panelRightModem.Left = rightEdge - _originalRightPanelWidth;
                panelRightModem.Width = _originalRightPanelWidth;
                if (panelTabsWrapper != null)
                {
                    int btnSize = btnExpand.Width;
                    panelTabsWrapper.Width = panelTitleRight.Width - btnSize * 2;
                }
                if (btnExpand != null) btnExpand.Text = "⤢";
            }
        }
        private void btnCycleTab_Click(object sender, EventArgs e)
        {
            if (flowTabsContainer == null || flowTabsContainer.Controls.Count == 0)
                return;
            int activeIndex = -1;
            for (int i = 0; i < flowTabsContainer.Controls.Count; i++)
            {
                if (flowTabsContainer.Controls[i].BackColor == Color.White)
                {
                    activeIndex = i;
                    break;
                }
            }
            int nextIndex = (activeIndex + 1) % flowTabsContainer.Controls.Count;
            if (nextIndex == 0)
            {
                showPanelRight(0);
            }
            else if (nextIndex == 1)
            {
                showPanelRight(1);
            }
            else
            {
                int dynamicIndex = nextIndex - 2;
                if (dynamicIndex >= 0 && dynamicIndex < _dynamicTabs.Count)
                {
                    SelectDynamicTab(dynamicIndex);
                }
            }
        }
        private void SelectDynamicTab(int index)
        {
            if (btnExpand != null)
            {
                btnExpand.Visible = true;
            }
            // Reset DETAIL and TERMINAL tabs to inactive
            panelBorderDetail.BackColor = Color.FromArgb(227, 227, 227);
            lblHugDetail.BackColor = Color.FromArgb(227, 227, 227);
            panelBorderTerminal.BackColor = Color.FromArgb(227, 227, 227);
            lblHugTerminal.BackColor = Color.FromArgb(227, 227, 227);

            // Update active states of dynamic tabs
            for (int i = 0; i < _dynamicTabs.Count; i++)
            {
                var tab = _dynamicTabs[i];
                var lbl = tab.Controls[0] as Label;
                if (i == index)
                {
                    tab.BackColor = Color.White;
                    if (lbl != null) lbl.BackColor = Color.White;
                }
                else
                {
                    tab.BackColor = Color.FromArgb(227, 227, 227);
                    if (lbl != null) lbl.BackColor = Color.Transparent;
                }
            }
            // Show browser container and hide other panels
            panelRight.Visible = false;
            panelRight2.Visible = false;
            panelRightModem.Visible = true;

            // Show selected browser and hide others
            for (int i = 0; i < _dynamicBrowsers.Count; i++)
            {
                var browser = _dynamicBrowsers[i];
                if (i == index)
                {
                    browser.Visible = true;
                    browser.Size = panelRightModem.ClientSize;
                    if (!(browser is FormBrowser))
                    {
                        ResizeMonitorFormControls(browser);
                    }
                    browser.Show();
                    browser.Invalidate(true);
                    browser.Update();
                }
                else
                {
                    browser.Visible = false;
                }
            }

            // Scroll the active tab into view
            if (index >= 0 && index < _dynamicTabs.Count && flowTabsContainer != null)
            {
                flowTabsContainer.ScrollControlIntoView(_dynamicTabs[index]);
            }
        }
        private void NavigationButton_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(0, 162, 194);
            }
        }

        private void NavigationButton_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label lbl)
            {
                lbl.ForeColor = Color.FromArgb(0, 32, 77);
            }
        }
        public void InitializeUrlTabsForStep(TableProcedureViewModel step)
        {
            CreateUrlTabs(step);
            if (step.ListURL != null && step.ListURL.Count > 0)
            {
                string targetUrl = step.ListURL[0].URL;
                for (int i = 0; i < _dynamicBrowsers.Count; i++)
                {
                    if (_dynamicBrowsers[i] is FormBrowser b && b.Tag as string == targetUrl)
                    {
                        SelectDynamicTab(i);
                        break;
                    }
                }
            }
        }

        private void LogControlHierarchy(Control parent, string indent, List<string> lines)
        {
            if (parent == null) return;
            foreach (Control c in parent.Controls)
            {
                lines.Add($"{indent}- Name: {c.Name}, Type: {c.GetType().FullName}, Bounds: {c.Bounds}, Anchor: {c.Anchor}, Dock: {c.Dock}");
                LogControlHierarchy(c, indent + "  ", lines);
            }
        }
        #endregion
        #region private

        private DialogResult ShowFormDialogResult(Form form)
        {
            FormBlur blur = new FormBlur();
            blur.Size = new Size(1920, 1030);
            blur.Location = this.Location;
            blur.StartPosition = FormStartPosition.Manual;
            blur.Owner = this;
            blur.Show();
            var result = form.ShowDialog();
            form.Dispose();
            // Cleanup
            blur.Close();
            blur.Dispose();
            return result;
        }
        private void ShowMess(string title, string strmess, int status)
        {
            FormNotiAll frmNoti = new FormNotiAll();
            frmNoti.LoadData(title, strmess, status);
            ShowFormDialogResult(frmNoti);
        }
        private object[] ConvertFromVariable(List<ProcedureDetailFunctionVariable> varis, List<ProcedureDetaiVariableViewModel> stepvaris)
        {
            object[] result = new object[varis.Count];
            int index = 0;
            foreach (ProcedureDetailFunctionVariable var in varis)
            {
                var item = _variables.Where(t => t.Name == var.VariableName).FirstOrDefault();
                var obj = stepvaris.Where(t => t.Name == var.VariableName).FirstOrDefault();
                switch (item.Type)
                {
                    case VariableType.Float:
                        if (var.IsList)
                        {
                            result[index] = JsonConvert.DeserializeObject<List<float>>(item.Value);
                        }
                        else
                        {
                            if (obj == null || string.IsNullOrEmpty(obj.Value))
                                result[index] = float.Parse(item.Value, CultureInfo.InvariantCulture);
                            else result[index] = float.Parse(obj.Value, CultureInfo.InvariantCulture);
                        }
                        break;
                    case VariableType.Integer:
                        if (var.IsList)
                        {
                            result[index] = JsonConvert.DeserializeObject<List<int>>(item.Value);
                        }
                        else
                        {
                            if (obj == null || string.IsNullOrEmpty(obj.Value))
                                result[index] = int.Parse(item.Value);
                            else result[index] = int.Parse(obj.Value);
                        }
                        break;
                    case VariableType.Double:
                        if (var.IsList)
                        {
                            result[index] = JsonConvert.DeserializeObject<List<double>>(item.Value);
                        }
                        else
                        {
                            if (obj == null || string.IsNullOrEmpty(obj.Value))
                                result[index] = double.Parse(item.Value, CultureInfo.InvariantCulture);
                            else result[index] = double.Parse(obj.Value, CultureInfo.InvariantCulture);
                        }
                        break;
                    case VariableType.String:
                        if (obj == null || string.IsNullOrEmpty(obj.Value))
                            result[index] = item.Value;
                        else result[index] = obj.Value;
                        break;
                    case VariableType.Boolean:
                        if (string.IsNullOrEmpty(item.Value)) result[index] = false;
                        else
                        {
                            if (obj == null || string.IsNullOrEmpty(obj.Value))
                                result[index] = bool.Parse(item.Value);
                            else result[index] = bool.Parse(obj.Value);
                        }
                        break;
                    case VariableType.PathFile:
                        if (obj == null)
                            result[index] = item.Value;
                        else result[index] = obj.Value;
                        break;
                }
                index++;
            }
            return result;
        }

        #endregion
    }
}