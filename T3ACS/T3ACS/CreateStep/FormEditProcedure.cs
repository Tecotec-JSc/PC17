using Newtonsoft.Json;
using System.Data;
using System.Reflection;
using T3.Configuration;
using T3ACS.Controls;
using T3ACS.Model;
using T3ACS.ViewModel;

namespace T3ACS
{
    public partial class FormEditProcedure : BaseForm
    {
        public FormEditProcedure()
        {
            InitializeComponent();
            _model = new ProcedureModel();
            loadForm();   
        }
        public event EventHandler _SendAction;
        #region propertiss
        TemplateViewModel _vm;
        ProcedureModel _model;
        public string _stepClick;
        public List<ContenStepTypeControl> _contenSteps;

        bool _Edited, mouseDown;
        Panel _popup;
        List<SortCardViewModel> _sortCart;
        int RowNumberI;
        int numberOrderN;
        FormCreateStepContent _frmCreateStep;
        List<StepTypeViewModel> _stepTypes;
        List<string> _groupName;
        string _stepTypeNow;
        #endregion
        #region Public function
        private void ResetTableStep()
        {
            _sortCart = new List<SortCardViewModel>();
            foreach (var item in _vm.TableProcedures)
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
        }
        public void LoadProcedure(int procedureId)
        {
            _sortCart = new List<SortCardViewModel>();
            _contenSteps = new List<ContenStepTypeControl>();
            string steptypen = "";
            if (procedureId > 0)
            {
                _vm = _model.GetProcedureById(procedureId);
                _vm.CurrentStep = 1;
                lblDefaultDescription.Text = _vm.Description;
                lblTitleProcedure.Text = _vm.Subject;
                lblIdProcedure.Text = "ID: " + _vm.Id;
                lblVersionProcedure.Text = "Version: " + _vm.Version;
                if (_vm.TableProcedures != null && _vm.TableProcedures.Count > 0)
                {
                    RowNumberI = _vm.TableProcedures.Count;
                    ResetTableStep();
                    _stepClick = _sortCart[0].Name;
                    tblStep.SetActive(1);
                    if (_frmCreateStep != null && _frmCreateStep.CanFocus) _frmCreateStep.Dispose();       
                    if (_vm.DUTIds == null) _vm.DUTIds = new List<int> { 0 };
                    _frmCreateStep = new FormCreateStepContent();                  
                    _frmCreateStep.LoadData(_vm);
                    panelCenterContent.Controls.Clear();
                    _frmCreateStep.TopLevel = false;
                    _frmCreateStep.Dock = DockStyle.Fill;
                    panelCenterContent.Controls.Add(_frmCreateStep);
                    _frmCreateStep.Show();
                    //_frmCreateStep._StepNameChange += changeStepName;
                }
                // LoadSteptype
                _stepTypes = _model.GetSteptypes();
                panelStepType.Controls.Clear();
                string groupNow = "";
                int numberInGroup = 1;
                int numberGroup = 0;
                _groupName = new List<string>();
                foreach (var steptype in _stepTypes)
                {
                    if (steptype.GroupName != groupNow)
                    {
                        groupNow = steptype.GroupName;
                        _groupName.Add(groupNow.Replace(" ", ""));
                        numberInGroup = 1;
                        numberGroup++;
                        StepTypeGroupControl grpCtrl = new StepTypeGroupControl();
                        grpCtrl.GroupName = steptype.GroupName;
                        grpCtrl.SetValue(false, groupNow);
                        grpCtrl.Width = panelStepType.Width;
                        grpCtrl._ClickControl += clickGrpStepType;
                        panelStepType.Controls.Add(grpCtrl);
                    }
                    ContenStepTypeControl item = new ContenStepTypeControl();

                    item.SetValue("GroupT" + numberGroup + "_" + numberInGroup, steptype.StepType, steptype.Description);
                    item.Width = panelStepType.Width;
                    item.GroupName = steptype.GroupName;
                    item._ClickControl += clickStepType;
                    panelStepType.Controls.Add(item);
                }
                if (_vm.TableProcedures == null || _vm.TableProcedures.Count == 0)
                    selectStepType("");
                else loadStepType(_vm.TableProcedures[_vm.CurrentStep - 1].StepType);
            }
        }
        #endregion
        #region ButtonClick
        private void tblStep__ClickControl(object sender, EventArgs e)
        {
            RowStepControl row = sender as RowStepControl;
            if (row.Name != _stepClick)
            {
                if (_frmCreateStep.CheckValue())
                {
                    _frmCreateStep.SaveValue();
                    _vm = _frmCreateStep._vm;
                    ResetTableStep();
                    _stepClick = row.Name;
                    tblStep.RowSelect(row);
                    loadStepContent(row._NumberOrder);
                    loadStepType(_vm.TableProcedures[row._NumberOrder - 1].StepType);
                }
            }

        }
        private void btnSetting_Click(object sender, EventArgs e)
        {
            FormBlur blur = new FormBlur();
            blur.Size = new Size(1920, 1030);
            blur.Location = this.Location;
            blur.StartPosition = FormStartPosition.Manual;
            blur.Owner = this;
            blur.Show();
            FormConfigureNewProcedure frm = new FormConfigureNewProcedure();
            frm.LoadData(_vm.ProcedureId, "Update procedure", _vm.Subject, _vm.Id, _vm.Category, _vm.Duration, _vm.DUTName, _vm.Description, _vm.MetaData, _vm.LinkModem, _vm.LinkACU, _vm.Variables);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                _vm.Variables = frm._variables;

                _vm.Subject = frm._strName;
                _vm.Category = frm._strCategory;
                _vm.Description = frm._strDescription;
                _vm.DUTName = frm._strDUT;
                _vm.MetaData = frm._strMeta;
                _vm.Version = frm._strVersion;
                var str = frm._strDUT;
                var bran = str.Substring(str.LastIndexOf(";") + 1);
                str = str.Substring(0, str.LastIndexOf(";"));
                var model = str.Substring(str.LastIndexOf(";") + 1);
                var namedut = str.Substring(0, str.LastIndexOf(";"));
                DUTModel dUTModel = new DUTModel();

                var idDUT = dUTModel.GetIdBy(namedut, model, bran);
                if (_vm.DUTIds == null)
                    _vm.DUTIds = new List<int>() { 0 };
                _vm.DUTIds[0] = idDUT; ;
                if (_frmCreateStep != null && _frmCreateStep.CanFocus)
                {
                    _frmCreateStep._variables = frm._variables;
                    _frmCreateStep._dutId = idDUT;
                    _frmCreateStep.LoadVariable();
                }
                lblTitleProcedure.Text = _vm.Subject;
                lblIdProcedure.Text = _vm.Id;
                lblVersionProcedure.Text = _vm.Version;

            }
            frm.Dispose();
            // Cleanup
            blur.Close();
            blur.Dispose();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            FormOKCancelAll frm = new FormOKCancelAll();
            frm.LoadData("Discard changes?", "You have unsaved changes. Are you sure you want to cancel? All changes will be lost.", "Discard Change", "Continue Editing", 2);
            if (ShowForm(frm) == DialogResult.OK)
            {
                _SendAction?.Invoke("ClearFormMain", EventArgs.Empty);
            }       
        }
        private void btnCreateProcedure_Click(object sender, EventArgs e)
        {
            if (_frmCreateStep != null)
            {
                if (_frmCreateStep.CheckValue())
                {
                    _vm = _frmCreateStep.SaveValue();
                    _vm.Variables = _frmCreateStep._variables;

                    string error = "";
                    if (_model.UpdateProcedure(_vm, out error))
                    {
                        ShowNoti("Notification", "Update inspection: " + _vm.Subject + " is successfully.", 1);
                                _SendAction?.Invoke("ClearFormMain", EventArgs.Empty);
                    }
                    else
                    {
                        ShowNoti("Notification", "Update inspection Error.", 3);
                    }
                }
            }
            else
            {
                ShowNoti("Notification", "You must insert at least one step to save the procedure.", 2);
            }
        }
        private void clickGrpStepType(object sender, EventArgs e)
        {
            StepTypeGroupControl item = sender as StepTypeGroupControl;
            if (item != null)
            {
                item._Expand = !item._Expand;
                item.ChangeIcon();
                foreach (var item2 in panelStepType.Controls)
                {
                    if (item2 is ContenStepTypeControl)
                    {
                        var item3 = item2 as ContenStepTypeControl;
                        if (item3.GroupName == item.GroupName)
                        {
                            item3.Visible = item._Expand;
                        }
                    }
                }
            }
        }
        private void clickStepType(object sender, EventArgs e)
        {
            ContenStepTypeControl item = sender as ContenStepTypeControl;
            if (item != null)
            {
                _stepTypeSelectedName = item.StepType;
                foreach (Control ct in panelStepType.Controls)
                {
                    if (ct is ContenStepTypeControl cti)
                    {
                        if (cti != item)
                        {
                            cti.SelectedG = false;
                        }
                    }
                }
                var item2 = _stepTypes.Where(t => t.StepType == _stepTypeSelectedName).FirstOrDefault();
                lblTextStepNameDT.Text = _stepTypeSelectedName;
                if (item2 != null)
                {
                    lblTextDesDT.Text = item2.Description;
                    lblTextRepeatCountDT.Text = item2.RepeatCount;
                }
            }
        }
        private void btnDeleteMetaData_Click(object sender, EventArgs e)
        {
            //if (!mouseDown)
            //{
            //    mouseDown = true;
            //    registerMouseDown(this);
            //}
            _popup.Location =
                new Point(9, 775);
            _popup.Visible = !_popup.Visible;
        }
        #endregion
        #region private function        
         
        void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (_popup.Visible && !_popup.Bounds.Contains(PointToScreen(e.Location)))
                _popup.Visible = false;
        }
        private void lblVisibal_TextChanged(object sender, EventArgs e)
        {
            var strchange = lblVisibal.Text;
            if (!string.IsNullOrEmpty(strchange))
            {
                if (strchange == "Delete")
                {
                    if (_vm.TableProcedures != null && _vm.TableProcedures.Count > 0)
                    {
                        FormBlur blur = new FormBlur();
                        blur.Size = new Size(1920, 1030);
                        blur.Location = this.Location;
                        blur.StartPosition = FormStartPosition.Manual;
                        blur.Owner = this;
                        blur.Show();
                        FormOKCancelAll frm = new FormOKCancelAll();
                        frm.LoadData("Confirm Action", "Are you sure you want to delete this step?", "Delete", "Cancel", 2);
                        if (frm.ShowDialog() == DialogResult.OK)
                        {
                            _vm.TableProcedures.Remove(_vm.TableProcedures[_vm.CurrentStep - 1]);
                            foreach (var item in _vm.TableProcedures)
                            {
                                if (item.NumberOder > _vm.CurrentStep)
                                    item.NumberOder--;
                            }
                            tblStep.RemoveStep(_vm.CurrentStep);
                            _vm.CurrentStep--;
                            if (_vm.CurrentStep == 0) _vm.CurrentStep = 1;
                            if (_vm.TableProcedures.Count > 0)
                            {
                                loadStepContent(_vm.TableProcedures[_vm.CurrentStep - 1].NumberOder);
                                loadStepType(_vm.TableProcedures[_vm.CurrentStep - 1].StepType);
                            }
                            else
                            {
                                if (panelCenterContent.Controls.Count > 0)
                                {
                                    panelCenterContent.Controls.Clear();
                                }
                            }

                        }
                        frm.Dispose();
                        blur.Close();
                        blur.Dispose();
                    }
                }
                else
                {
                    var check = true;
                    if (_frmCreateStep != null && _vm.TableProcedures != null && _vm.TableProcedures.Count > 0)
                    {
                        if (!_frmCreateStep.CheckValue()) check = false;
                        else _vm = _frmCreateStep.SaveValue();
                    }
                    if (check)
                    {
                        if (strchange == "Move up")
                        {
                            if (_vm.TableProcedures != null && _vm.TableProcedures.Count > 1 && _vm.CurrentStep > 1)
                            {
                                _vm.TableProcedures[_vm.CurrentStep - 1].NumberOder--;
                                _vm.TableProcedures[_vm.CurrentStep - 2].NumberOder++;
                                _vm.TableProcedures = _vm.TableProcedures.OrderBy(x => x.NumberOder).ToList();
                                tblStep.ChangeIndexControl(_vm.CurrentStep, _vm.CurrentStep - 1);
                                _vm.CurrentStep--;
                            }
                        }
                        else if (strchange == "Move down")
                        {
                            if (_vm.TableProcedures != null && _vm.TableProcedures.Count > 1 && _vm.CurrentStep < _vm.TableProcedures.Count)
                            {
                                _vm.TableProcedures[_vm.CurrentStep - 1].NumberOder++;
                                _vm.TableProcedures[_vm.CurrentStep].NumberOder--;
                                _vm.TableProcedures = _vm.TableProcedures.OrderBy(x => x.NumberOder).ToList();
                                tblStep.ChangeIndexControl(_vm.CurrentStep, _vm.CurrentStep + 1);
                                _vm.CurrentStep++;
                            }
                        }
                        else if (strchange == "Duplicate")
                        {
                            if (_vm.TableProcedures != null && _vm.TableProcedures.Count > 0)
                            {
                                RowNumberI++;
                                var currentStep = _vm.TableProcedures[_vm.CurrentStep - 1];
                                var newsetp = JsonConvert.DeserializeObject<TableProcedureViewModel>(JsonConvert.SerializeObject(currentStep));
                                var newName = currentStep.Title + " Duplicate 1";
                                int i = 2;
                                while (_vm.TableProcedures.Count
                                    (t => t.Title == newName) > 0)
                                {
                                    newName = currentStep.Title + " Duplicate " + i;
                                    i++;
                                }
                                newsetp.Title = newName;
                                newsetp.NumberOder = _vm.TableProcedures.Count + 1;
                                _vm.TableProcedures.Add(newsetp);
                                _vm.CurrentStep = _vm.TableProcedures.Count;
                                tblStep.AddNewStep("Step" + RowNumberI, newsetp.NumberOder + ". " + newsetp.Title, newsetp.NumberOder);
                                tblStep.SetActive(newsetp.NumberOder);
                                loadStepContent(newsetp.NumberOder);
                                loadStepType(newsetp.StepType);
                                _stepClick = "Step" + RowNumberI;
                            }
                        }
                    }
                }
                lblVisibal.Text = "";
            }
        }
        private void loadStepType(string stepType)
        {
            selectStepType(stepType);
            var item = _stepTypes.Where(t => t.StepType == stepType).FirstOrDefault();
            lblTextStepNameDT.Text = stepType;
            if (item != null)
            {
                lblTextDesDT.Text = item.Description;
                lblTextRepeatCountDT.Text = item.RepeatCount;
            }

        }
        private void selectStepType(string stepType)
        {
            var steptypevm = _stepTypes.Where(t => t.StepType == stepType).FirstOrDefault();

            foreach (Control item in panelStepType.Controls)
            {
                if (item is StepTypeGroupControl)
                {
                    var item2 = item as StepTypeGroupControl;

                    if (steptypevm != null && item2.GroupName == steptypevm.GroupName)
                    {
                        item2._Expand = true;
                    }
                    else
                        item2._Expand = false;
                    item2.ChangeIcon();

                }
                else if (item is ContenStepTypeControl)
                {
                    var item3 = item as ContenStepTypeControl;
                    if (steptypevm != null && item3.GroupName == steptypevm.GroupName)
                    {
                        item3.Visible = true;
                    }
                    else item3.Visible = false;
                }
            }
        }
        private void loadForm()
        {
            _popup = new Panel();
            _popup.Size = new Size(331, 150);
            _popup.BackColor = Color.White;
            _popup.BorderStyle = BorderStyle.FixedSingle;
            _popup.Visible = false;
            var colorNomand = Color.FromArgb(0, 32, 77);

            _popup.Controls.Add(createItem(Properties.Resources.iconDelete, "Delete", Color.Red));
            _popup.Controls.Add(createItem(Properties.Resources.iconMoveDown, "Move down", colorNomand));
            _popup.Controls.Add(createItem(Properties.Resources.iconMoveUP, "Move up", colorNomand));
            _popup.Controls.Add(createItem(Properties.Resources.iconDuplicate, "Duplicate", colorNomand));
            this.Controls.Add(_popup);
            _popup.BringToFront();
        }
        private void loadStepContent(int stepNumber)
        {
            _vm.CurrentStep = stepNumber;
            // setup value prestep
            var currentStep = _vm.TableProcedures[_vm.CurrentStep - 1];
            if (_vm.CurrentStep > 1)
            {
                for (int i = 0; i < _vm.CurrentStep - 1; i++)
                {
                    var preStep = _vm.TableProcedures[i];
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
            // Filter variables
            var lstVariable = _vm.Variables;
            if (lstVariable != null && lstVariable.Count > 0)
            {
                var lstRemoveItem = new List<ProcedureVariableViewModel>();
                foreach (var item in lstVariable)
                {
                    var count = 0;
                    foreach (var step in _vm.TableProcedures)
                    {
                        if (step.Variables != null && step.Variables.Count(t => t.Name == item.Name) > 0)
                            count++;
                    }
                    if (count == 0) lstRemoveItem.Add(item);
                }
                foreach (var item in lstRemoveItem)
                {
                    lstVariable.Remove(item);
                }
            }
            if (panelCenterContent.Controls.Count > 0)
            {
                foreach (Control item in panelCenterContent.Controls)
                    item.Dispose();
                panelCenterContent.Controls.Clear();
            }
            if (_frmCreateStep != null) _frmCreateStep.Dispose();
            var stepNow = _vm.TableProcedures[stepNumber - 1];          
            _frmCreateStep = new FormCreateStepContent();
            _frmCreateStep.TopLevel = false;
            _frmCreateStep.Dock = DockStyle.Fill;
            //_frmCreateStep._StepNameChange += changeStepName;
            panelCenterContent.Controls.Add(_frmCreateStep);
            _frmCreateStep.Show();
            _frmCreateStep.LoadData(_vm);
        }
        private void changeStepName(object sender, string text)
        {
            tblStep.SetText(_vm.CurrentStep, text);
        }
        #endregion
        #region public function
        int _stepTypeSelectedId;
        string _stepTypeSelectedName;

        #endregion
        Panel createItem(System.Drawing.Image img, string text, Color forColor)
        {
            Panel item = new Panel();
            item.Height = 30;
            item.Dock = DockStyle.Top;
            item.BackColor = Color.White;
            item.Cursor = Cursors.Hand;
            PictureBox pic = new PictureBox();
            pic.Image = img;
            pic.SizeMode = PictureBoxSizeMode.CenterImage;
            pic.Size = new Size(20, 20);
            pic.Location = new Point(5, 4);
            Label lbl = new Label();
            lbl.Text = text;
            lbl.AutoSize = false;
            lbl.TextAlign = ContentAlignment.MiddleLeft;
            lbl.Location = new Point(45, 0);
            lbl.Size = new Size(150, 30);
            lbl.ForeColor = forColor;
            // Hover effect
            item.MouseEnter += (_, __) => item.BackColor = Color.FromArgb(230, 240, 255);
            item.MouseLeave += (_, __) => item.BackColor = Color.White;
            lbl.MouseEnter += (_, __) => item.BackColor = Color.FromArgb(230, 240, 255);
            lbl.MouseLeave += (_, __) => item.BackColor = Color.White;
            pic.MouseEnter += (_, __) => item.BackColor = Color.FromArgb(230, 240, 255);
            pic.MouseLeave += (_, __) => item.BackColor = Color.White;
            // Click
            item.Click += (_, __) =>
            {
                lblVisibal.Text = text;
                _popup.Visible = false;
            };
            // Cho click cả label & image
            lbl.Click += (_, __) =>
            {
                lblVisibal.Text = text;
                _popup.Visible = false;
            };
            pic.Click += (_, __) =>
            {
                lblVisibal.Text = text;
                _popup.Visible = false;
            };
            item.Controls.Add(pic);
            item.Controls.Add(lbl);
            return item;
        }
        private void registerMouseDown(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                c.MouseDown += Control_MouseDown;
                if (c.HasChildren)
                    registerMouseDown(c);
            }
        }
        /// <summary>
        /// 1: success, 2 warning, 3 Error
        /// </summary>
        /// <param name="title"></param>
        /// <param name="strmess"></param>
        /// <param name="status"></param>
        private void ShowNoti(string title, string strmess, int status)
        {
      
            FormNotiAll frmNoti = new FormNotiAll();
            frmNoti.LoadData(title, strmess, status);
            ShowForm(frmNoti);
        }

        private DialogResult ShowForm(Form frm)
        {
            FormBlur blur = new FormBlur();
            blur.Size = new Size(1920, 1030);
            blur.Location = this.Location;
            blur.StartPosition = FormStartPosition.Manual;
            blur.Owner = this;
            blur.Show();
            var result=  frm.ShowDialog();
            frm.Dispose();
            // Cleanup
            blur.Close();
            blur.Dispose();
            return result;
        }
        private void rjTextSeach1__TextChanged(object sender, EventArgs e)
        {

        }
        FormPopUpTemplate _popTemplate;
        private void btnMoreTemplate_Click(object sender, EventArgs e)
        {
            var p = btnMoreTemplate.PointToScreen(new Point(-160, btnMoreTemplate.Height));
            if (_popTemplate == null || !_popTemplate.CanFocus)
            {
                _popTemplate = new FormPopUpTemplate();

                _popTemplate._SelectCard += Popup_ItemSelected;

                _popTemplate.LoadData(new List<List<string>>() { new List<string>() { "Custom", "Create custom step type" }, new List<string>() { "Import DLL" } });
                _popTemplate.Location = p;
                _popTemplate.Show();
            }
            else _popTemplate.Focus();
            _popTemplate.BringToFront();
        }
        private void Popup_ItemSelected(object sender, EventArgs e)
        {
            if (sender is FormPopUpTemplate template)
            {
                if (!string.IsNullOrEmpty(template._SelectedItem) && template._SelectedItem == "Custom")
                {
                    CreateStepType();
                }
            }
        }
        FormCustomStepPopup _frmCustom;
        private void CreateStepType()
        {
            FormBlur blur = new FormBlur();
            blur.Size = new Size(1920, 1030);
            blur.Location = this.Location;
            blur.StartPosition = FormStartPosition.Manual;
            blur.Owner = this;
            this.Focus();
            blur.Show();


            _frmCustom = new FormCustomStepPopup();
            _frmCustom.LoadData(_vm.Variables);
            _frmCustom.ShowDialog();
            _frmCustom.Dispose();
            // Cleanup
            blur.Close();
            blur.Dispose();



        }
        private void buttonCustom1__EventSelect(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_stepTypeSelectedName))
            {


                if (_frmCreateStep == null || (_frmCreateStep != null && (!_frmCreateStep.CanFocus || _frmCreateStep.CheckValue())))
                {


                    if (_vm.TableProcedures != null && _vm.TableProcedures.Count() > 0)
                    {
                        _vm = _frmCreateStep.SaveValue();
                        _vm.Variables = _frmCreateStep._variables;
                        ResetTableStep();
                    }
                    RowNumberI++;
                    if (_vm.TableProcedures == null) _vm.TableProcedures = new List<TableProcedureViewModel>();
                    TableProcedureViewModel newstep = getstepbyStepType(_stepTypeSelectedName);
                    newstep.NumberOder = _vm.TableProcedures.Count + 1;
                    _vm.TableProcedures.Add(newstep);
                    _vm.CurrentStep = newstep.NumberOder;

                    tblStep.AddNewStep("Step " + RowNumberI, newstep.NumberOder + ". ", newstep.NumberOder);
                    tblStep.SetActive(newstep.NumberOder);
                    loadStepContent(newstep.NumberOder);
                    loadStepType(newstep.StepType);
                    _stepClick = "Step" + RowNumberI;
                }


            }

        }
        private TableProcedureViewModel getstepbyStepType(string stepType)
        {
            TableProcedureViewModel result = new TableProcedureViewModel();
            result.StepType = stepType;
            result.LoopInput = 1;
            if (stepType == "Number" || stepType == "String" || stepType == "Boolean" || stepType == "PathFile" || stepType == "Add Parameter" || stepType == "Correction")
            {

            }
            else
            {
                var tb = _model.GetStepTypeBy(stepType);
                if (tb != null)
                {
                    var newPro = JsonConvert.DeserializeObject<TemplateViewModel>(tb.Content);
                    if (newPro != null && newPro.TableProcedures[0] != null)
                    {
                        int i = 1;
                        var newStep = newPro.TableProcedures[0];

                        foreach (var variable in newPro.Variables)
                        {
                            ProcedureVariableViewModel newv = new ProcedureVariableViewModel();
                            var strNewV = variable.Name + "";
                            int countName = _vm.Variables.Count(t => t.Name == variable.Name);
                            if (countName > 0)
                            {
                                var oldv = _vm.Variables.Where(t => t.Name == variable.Name).FirstOrDefault();
                                if (oldv.Unit != variable.Unit)
                                    while (_vm.Variables.Count(t => t.Name == strNewV) > 0)
                                    {
                                        strNewV = "NewName" + i;
                                        i++;
                                    }
                            }
                            newv.Name = strNewV;
                            newv.OldName = strNewV;
                            newv.Type = variable.Type;
                            newv.TypeInput = variable.TypeInput;
                            if (string.IsNullOrEmpty(newv.TypeInput)) newv.TypeInput = "Input";
                            newv.Value = variable.Value;
                            newv.Report = variable.Report;
                            newv.Required = variable.Required;
                            newv.Min = variable.Min;
                            newv.Max = variable.Max;
                            newv.Unit = variable.Unit;
                            newv.Title = variable.Title;
                            newv.Items = variable.Items;
                            _vm.Variables.Add(newv);
                            var item22 = newStep.Variables.Where(t => t.Name == newv.Name).FirstOrDefault();
                            if (item22 != null)
                            {
                                item22.Required = newv.Required;
                                item22.Report = newv.Report;
                            }
                            if (countName > 0)
                            {
                                if (newStep.Functions != null && newStep.Functions.Count > 0)
                                {
                                    foreach (var function in newStep.Functions)
                                    {
                                        if (function.FunctionVariables != null && function.FunctionVariables.Count > 0)
                                        {
                                            foreach (var v in function.FunctionVariables)
                                            {
                                                if (v.VariableName == variable.Name)
                                                {
                                                    v.VariableName = strNewV;
                                                    if (!string.IsNullOrEmpty(v.Value) && string.IsNullOrEmpty(newv.Value))
                                                    {
                                                        variable.Value = v.Value;
                                                        newv.Value = v.Value;
                                                    }

                                                }

                                            }
                                        }
                                    }
                                }
                                if (newStep.Variables != null && newStep.Variables.Count > 0)
                                {
                                    foreach (var item in newStep.Variables)
                                    {
                                        if (item.Name == variable.Name)
                                            item.Name = strNewV;
                                    }
                                }
                            }

                        }

                        return newStep;
                    }
                }
            }
            return result;
        }

        private void lblHugStep_Click(object sender, EventArgs e)
        {

        }
    }
}
