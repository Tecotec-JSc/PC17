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
using T3ACS.Controls.Table;
using T3ACS.Model;
using VSat.FormulaEvaluator;
using VSat.Spectrum;

namespace T3ACS.CreateStep
{
    public partial class FormCreateCalculate : Form
    {
        public FormCreateCalculate()
        {
            InitializeComponent();
        }
        public List<ProcedureVariableViewModel> _variableProcedure;
        public List<ProcedureVariableViewModel> _variableStep;

        public List<string> _listv;
        public List<string> _listvSelect;
        public string _filedll;
        public string _fileCalib;
        public bool formReady;
        public void LoadData(List<ProcedureVariableViewModel> varisAll, TableProcedureViewModel step)
        {
            _filedll = step.PathDll;
            _fileCalib = step.PathSource;
            if (!string.IsNullOrEmpty(_filedll))
            {
                selectedFileDll.Texts = _filedll;
            }
            if (!string.IsNullOrEmpty(_fileCalib))
            {
                selectedFileCalibration.Texts = _fileCalib;
            }
            if (varisAll == null) varisAll = new List<ProcedureVariableViewModel>();
            _variableProcedure = varisAll.ToList();
            _variableStep = new List<ProcedureVariableViewModel>();
            if (step.Variables != null && step.Variables.Count > 0)
            {
                step.Variables= step.Variables.OrderBy(t=>t.NumberOrder).ToList();
                foreach (var va in step.Variables)
                {
                    var item = varisAll.Where(t => t.Name == va.Name).FirstOrDefault(); ;
                    item.Value = va.Value;
                    item.TypeInput = va.TypeInput;
                    item.Title = va.Title;
                    item.Report = va.Report;
                    _variableStep.Add(item);

                }
            }



            tableDefault.LoadData(_variableStep);
            tableDefault.ResizeC();
            formReady = true;
        }
        public bool CheckSave(out string mess)
        {
            if (string.IsNullOrEmpty(_filedll))
            {
                mess = "Select a library file to save the data.";
                return false;
            }
            if (string.IsNullOrEmpty(_fileCalib))
            {
                mess = "Select a calibration file to save the data.";
                return false;
            }
            if (tableDefault.CheckSave(out mess))
            {
                var result = tableDefault.GetVariables();
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
            _result = tableDefault.GetVariables();
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
        private void tableVariableControl1__ShowError(object sender, EventArgs e)
        {
            ShowMess("Notification", tableDefault._StrError, 2);
        }
        private void LoadVariable()
        {
            if (!string.IsNullOrEmpty(_filedll) && !string.IsNullOrEmpty(_fileCalib))
            {
                try
                {
                    // Load cached user data from the txt file in the DLL directory
                    var cachedFromFile = LoadVariablesFromDllConfigFile();

                    // Fall back to grid data if no txt file found
                    var cacheSource = cachedFromFile.Count > 0
                        ? cachedFromFile
                        : GetVariablesFromGrid();

                    var cachedInputs = cacheSource
                        .Where(v => v.TypeImport.Equals("Input", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    var cachedOutputs = cacheSource
                        .Where(v => !v.TypeImport.Equals("Input", StringComparison.OrdinalIgnoreCase))
                        .ToList();

                    var variables = File.Exists(_fileCalib)
                        ? Evaluator.GetVariables(_fileCalib)
                        : Evaluator.GetVariables();
                    var viewModels = new List<ProcedureVariableViewModel>();

                    int inputIdx = 0;
                    int outputIdx = 0;

                    foreach (object[] varInfo in variables)
                    {
                        string name = varInfo[0]?.ToString() ?? "";
                        string typeImport = varInfo[1]?.ToString() ?? "Input";
                        string unit = varInfo[2]?.ToString() ?? "";
                        double? parsedMin = varInfo.Length > 3 ? (double?)varInfo[3] : null;
                        double? parsedMax = varInfo.Length > 4 ? (double?)varInfo[4] : null;

                        bool isInput = typeImport.Equals("Input", StringComparison.OrdinalIgnoreCase);
                        DynamicVariable cached = null;

                        if (isInput)
                        {
                            cached = cachedInputs.FirstOrDefault(v => v.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                            if (cached == null)
                                cached = cachedInputs.FirstOrDefault(v => v.Title.Equals(name, StringComparison.OrdinalIgnoreCase));
                            if (cached == null && inputIdx < cachedInputs.Count)
                            {
                                cached = cachedInputs[inputIdx];
                            }
                            inputIdx++;
                        }
                        else
                        {
                            cached = cachedOutputs.FirstOrDefault(v => v.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                            if (cached == null)
                                cached = cachedOutputs.FirstOrDefault(v => v.Title.Equals(name, StringComparison.OrdinalIgnoreCase));
                            if (cached == null && outputIdx < cachedOutputs.Count)
                            {
                                cached = cachedOutputs[outputIdx];
                            }
                            outputIdx++;
                        }

                        if (cached != null)
                        {
                            viewModels.Add(new ProcedureVariableViewModel
                            {
                                Name = cached.Name,
                                Title = cached.Title ?? "N/A",
                                Value = cached.Value ?? (isInput ? "0" : ""),
                                Unit = string.IsNullOrEmpty(unit) ? (cached.Unit ?? "N/A") : unit,
                                Min = cached.Min?.ToString() ?? parsedMin?.ToString() ?? "0",
                                Max = cached.Max?.ToString() ?? parsedMax?.ToString() ?? "0",
                                Type = cached.Type ?? "Double",
                                TypeInput = cached.TypeImport ?? typeImport,
                                Required = cached.Required,
                                Report = cached.Report
                            });
                        }
                        else
                        {
                            string valDefault = isInput ? "0" : "";
                            viewModels.Add(new ProcedureVariableViewModel
                            {
                                Name = name,
                                Title = "N/A",
                                Value = valDefault,
                                Unit = unit,
                                Min = parsedMin?.ToString() ?? "N/A",
                                Max = parsedMax?.ToString() ?? "N/A",
                                Type = "Double",
                                TypeInput = typeImport,
                                Required = true,
                                Report = false
                            });
                        }
                    }

                    tableDefault.LoadData(viewModels);


                }
                catch (Exception ex)
                {
                    // Error reading formula file
                }
            }
        }
        private List<DynamicVariable> GetVariablesFromGrid()
        {
            var list = new List<DynamicVariable>();
            //var variables = tableDUT.GetVariables();
            //foreach (var item in variables)
            //{
            //    double? minVal = null;
            //    if (double.TryParse(item.Min, out double min)) minVal = min;
            //    double? maxVal = null;
            //    if (double.TryParse(item.Max, out double max)) maxVal = max;

            //    list.Add(new DynamicVariable
            //    {
            //        Name = item.Name,
            //        Title = item.Title,
            //        Value = item.Value,
            //        Unit = item.Unit,
            //        Min = minVal,
            //        Max = maxVal,
            //        Type = item.Type,
            //        TypeImport = item.TypeInput,
            //        Required = item.Required,
            //        Report = item.Report
            //    });
            //}
            return list;
        }
        private List<DynamicVariable> LoadVariablesFromDllConfigFile()
        {
            try
            {
                string txtPath = GetDllConfigFilePath();
                if (string.IsNullOrEmpty(txtPath) || !File.Exists(txtPath))
                    return new List<DynamicVariable>();

                string json = File.ReadAllText(txtPath);
                var config = System.Text.Json.JsonSerializer.Deserialize<DynamicFormulaConfig>(json);
                return config?.Variables ?? new List<DynamicVariable>();
            }
            catch
            {
                return new List<DynamicVariable>();
            }
        }
        private string GetDllConfigFilePath()
        {
            if (string.IsNullOrEmpty(_filedll)) return "";
            string dllDir = Path.GetDirectoryName(_filedll) ?? "";
            string dllName = Path.GetFileNameWithoutExtension(_filedll);
            return Path.Combine(dllDir, dllName + "_config.txt");
        }
        private void selectedFileCalibration__selectChange(object sender, EventArgs e)
        {
            _fileCalib = selectedFileCalibration.Texts;
            LoadVariable();
        }

        private void selectedFileDll__selectChange(object sender, EventArgs e)
        {
            _filedll = selectedFileDll.Texts;
            LoadVariable();
        }

        private void tableDefault__ShowError(object sender, EventArgs e)
        {
            ShowMess("Notification", tableDefault._StrError, 2);
        }
    }
}
