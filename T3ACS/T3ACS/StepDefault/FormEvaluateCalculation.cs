using Newtonsoft.Json;
using System.Data;
using T3ACS.Model;
using T3ACS.ViewModel;
using VSat.FormulaEvaluator;

namespace T3ACS.StepDefault
{
    public partial class FormEvaluateCalculation : Form
    {
        private Point stickyControlOriginalLocation;
        public List<AssembyViewModel> _Assemblys;
        public event EventHandler _StopProcedure;
        public int _statusStep;
        public FormEvaluateCalculation()
        {
            InitializeComponent();
            LoadButtonBot();

            // Ngưỡng xuất hiện scroll Y
            this.AutoScrollMinSize = new Size(0, 804);
            this.Scroll += FormEvaluate_Scroll;
           this.panelForm.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelForm_MouseWheel);
        }
        public List<ProcedureDetaiVariableViewModel> _Variable;

        public List<ProcedureVariableViewModel> _VariableOutput;
        public List<ProcedureVariableViewModel> _VariableInput;
        public List<ProcedureVariableViewModel> _Data;
        public void LoadData(TableProcedureViewModel step, List<ProcedureVariableViewModel> variables)
        {
            _statusStep = step.Status;
            _Maskdone = step.MaskDoneValue;
            txtPathDll.Texts = step.PathDll;
            txtPathCalibration.Texts = step.PathSource;
            if (!string.IsNullOrEmpty(step.Description))
                rtbNote.Texts = step.Comment;
            MaskDone();
            var json = JsonConvert.SerializeObject(step.Variables);
            _Variable = JsonConvert.DeserializeObject<List<ProcedureDetaiVariableViewModel>>(json);
            if (string.IsNullOrEmpty(step.Comment)) rtbNote.Texts = step.Comment;
            var lstVariIdStep = step.Variables.Select(i => i.ProcedureVariableId).ToList();
            _Data = variables.Where(t => lstVariIdStep.Contains(t.ProcedureVariableId)).ToList();
            _VariableInput = new List<ProcedureVariableViewModel>();
            _VariableOutput = new List<ProcedureVariableViewModel>();
            int i = 0;
            if (step.Variables != null && step.Variables.Count > 0)
            {
                step.Variables = step.Variables.OrderBy(t => t.NumberOrder).ToList();
                foreach (var itemv in step.Variables)
                {
                    var item = _Data.Where(t => t.Name == itemv.Name).FirstOrDefault();
                    item.Value = itemv.Value;
                    item.Title= itemv.Title;
                    item.TypeInput = itemv.TypeInput;
                    item.Report = itemv.Report;
                    item.Required = itemv.Required;
                    if (item.TypeInput == "Input" || item.TypeInput == "ListInput") _VariableInput.Add(item);
                    else _VariableOutput.Add(item);

                }
                i++;
            }
         
            //  panelStickBottom.Location = new Point(12, 723);
            tbnInput.LoadData(_VariableInput);
            tbnInput.ResizeC();
            tbnOutPut.LoadData(_VariableOutput);
            tbnOutPut.ResizeC();
            //DUTModel model = new DUTModel();
            //var vm = model.GetByID(dutId);
            //if (vm != null)
            //{
            //    if (vm.Options != null && vm.Options.Count > 0)
            //    {
            //        tabledutrun1.LoadData(vm.Options);
            //        tabledutrun1.ResizeC();
            //    }
            //}
        }

        private void panelForm_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            panelStickBottom.Location = new Point(stickyControlOriginalLocation.X, stickyControlOriginalLocation.Y + this.AutoScrollPosition.Y);
        }


        public void LoadFormEvalute(Form form)
        {
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            panelString.Controls.Clear();
            panelString.Controls.Add(form);
            form.Visible = true;
            form.Show();
        }


        public void LoadButtonBot()
        {
            var pathApp = AppDomain.CurrentDomain.BaseDirectory + "Image\\btn\\";
            //btnPass
            btnPass._ImageDefault = Image.FromFile(pathApp + "PassDefault.png");
            btnPass._ImageSelect = Image.FromFile(pathApp + "PassActive.png");
            btnPass._ImageDisable = Image.FromFile(pathApp + "PassDisable.png");

            btnPass.SetEnalbe(true);
            //btnFailed
            btnFailed._ImageDefault = Image.FromFile(pathApp + "FailedDefault.png");
            btnFailed._ImageSelect = Image.FromFile(pathApp + "FailedActive.png");
            btnFailed._ImageDisable = Image.FromFile(pathApp + "FailedDisable.png");

            btnFailed.SetEnalbe(true);
            //btnExport
            btnExport._ImageDefault = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport._ImageSelect = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport._ImageDisable = Image.FromFile(pathApp + "btnExportDisable.png");
            btnExport.Cursor = Cursors.No;
            btnExport.SetEnalbe(false);

            //btnExport
            btnQuit.Texts = "Quit";
            btnQuit.BorderColor = Color.FromArgb(0, 112, 203);
            btnQuit.ForeColor = Color.FromArgb(0, 112, 203);

        }
        private void FormEvaluate_Scroll(object sender, ScrollEventArgs e)
        {
            // Điều chỉnh vị trí của stickyButton theo vị trí cuộn.
            panelStickBottom.Location = new Point(stickyControlOriginalLocation.X, stickyControlOriginalLocation.Y + this.AutoScrollPosition.Y);
        }

        public bool CheckSave(out string mess)
        {
            if (!tbnInput.ValidateInputs(out mess))
            {
                return false;
            }
            return true;
        }
        public void SaveValue()
        {
            var lstInput = tbnInput.GetVariables();
            int i = 0;
            foreach (var v in lstInput)
            {
                var item = _VariableInput[i];
               _Variable.Where(t=>t.Name==item.Name).FirstOrDefault().Value=v.Value;
                i++;
            }
            var lstOutput = tbnOutPut.GetVariables();
             i = 0;
            foreach (var v in lstOutput)
            {
                var item = _VariableOutput[i];
                _Variable.Where(t => t.Name == item.Name).FirstOrDefault().Value = v.Value;
                i++;
            }
        }
        public string GetNote()
        {
            return rtbNote.Texts;
        }
        public bool? _Maskdone;
        private void MaskDone()
        {
            if (_Maskdone.HasValue)
            {
                btnPass.SetValue(_Maskdone.Value);
                btnFailed.SetValue(!_Maskdone.Value);
            }
        }
        private void btnPass_Click(object sender, EventArgs e)
        {
            _Maskdone = true;
            MaskDone();
        }

        private void btnFailed_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_btnClick(object sender, EventArgs e)
        {
            _StopProcedure?.Invoke(null, EventArgs.Empty);
        }

        private void tableDefaultrun1_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            _StopProcedure?.Invoke(null, EventArgs.Empty);
        }

        private void btnFailed_Click_1(object sender, EventArgs e)
        {
            _Maskdone = false;
            MaskDone();
        }

        private void ButtonCustom1__EventSelect(object sender, EventArgs e)
        {
            var filedll= txtPathDll.Texts;
            var fileCabli = txtPathCalibration.Texts;
            if (!File.Exists(filedll)) ShowMess("Notification", "File dll is not exist.", 2);
            if (!File.Exists(fileCabli)) ShowMess("Notification", "File calibration is not exist.", 2);

            try
            {
                if (CheckSave(out string mess))
                    Calculate();
                else ShowMess("Notification", mess, 2);
            }
            catch (Exception ex) 
            {
                ShowMess("Notification", ex.Message, 2);
            }
    
        }

        #region calculate
        private Dictionary<string, double> _inputValues = new(StringComparer.OrdinalIgnoreCase);
        private Dictionary<string, double> _outputValues = new(StringComparer.OrdinalIgnoreCase);
        private void Calculate()
        {
            _inputValues.Clear();
    
            // Số biến ứng với số biến trong file tính toán và đúng thứ tự
            var inputVars = tbnInput.GetVariables();
            // Số biến ứng với số biến trong file tính toán và đúng thứ tự
            var outpuVars = tbnOutPut.GetVariables();

            var _FormulaFilePath = txtPathCalibration.Texts;
            List<object> inputNames = File.Exists(_FormulaFilePath)
                ? Evaluator.GetInputVariables(_FormulaFilePath)
                : Evaluator.GetInputVariables();

            for (int i = 0; i < Math.Min(inputNames.Count, inputVars.Count); i++)
            {
                string name = inputNames[i]?.ToString() ?? "";

                if (string.IsNullOrWhiteSpace(name))
                    continue;

                string valStr = inputVars[i].Value?.Trim() ?? "0";

                double.TryParse(
                    valStr,
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double val);

                _inputValues[name] = val;
            }

            List<object> results;
            if (File.Exists(_FormulaFilePath))
            {
                results = Evaluator.Calculate(_FormulaFilePath, _inputValues);
            }
            else
            {
                results = Evaluator.Calculate(_inputValues);
            }

            _outputValues.Clear();

            // Map output variables sequentially to results           
            for (int j = 0; j < _VariableOutput.Count && j < results.Count; j++)
            {
                string outName = _VariableOutput[j].Name;
                double.TryParse(results[j]?.ToString() ?? "0",
                    System.Globalization.NumberStyles.Any,
                    System.Globalization.CultureInfo.InvariantCulture,
                    out double outVal);
                _outputValues[outName] = outVal;
                // Ghi số theo InvariantCulture để nhất quán với lúc đọc (parse) ở trên.
                _VariableOutput[j].Value = outVal.ToString(System.Globalization.CultureInfo.InvariantCulture);
            }
            tbnOutPut.LoadData(_VariableOutput);
        }
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
        #endregion
    }
}
