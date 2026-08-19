using Newtonsoft.Json;
using System.Globalization;
using T3.Configuration;
using T3ACS.Controls;
using T3ACS.Controls.Card;
using T3ACS.Model;
using T3ACS.Service;
using T3ACS.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3ACS.Model.ViewModel;


namespace T3ACS
{
    public partial class FormEvaluateCorrection : Form
    {
        private Point stickyControlOriginalLocation;
        public List<AssembyViewModel> _Assemblys;
        public List<ProcedureVariableViewModel> _variables;
        public Form _frmEvaluate;

        // Đi qua Service chuẩn để gọi thiết bị (dùng chung cơ chế in-process T3Call),
        // thay cho việc tự cài lại reflection trong form (đúng phân lớp UI -> Service).
        private readonly IFormService _deviceService = new FormService();
        public FormEvaluateCorrection()
        {
            InitializeComponent();
            SetStypeForTable();

            stickyControlOriginalLocation = new Point(15, 790);
            LoadButtonBot();
            //panelForm.AutoScroll = true;
            //panelForm.HorizontalScroll.Enabled = false;
            //panelForm.HorizontalScroll.Visible = false;
            //panelForm.AutoScrollMinSize = new Size(0, 804);
            //this.AutoScroll = true;
            //_imain=imain;
            //// ❌ Không cho scroll ngang
            //this.HorizontalScroll.Enabled = false;
            //this.HorizontalScroll.Visible = false;

            //// Ngưỡng xuất hiện scroll Y
            //this.AutoScrollMinSize = new Size(0, 804);
            //this.Scroll += FormEvaluate_Scroll;
            //  this.panelForm.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelForm_MouseWheel);
            //  this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FormEvaluate_Scroll);



        }

        private void SetStypeForTable()
        {



        }

        public void LoadData(TableProcedureViewModel currentStep, List<ProcedureVariableViewModel> varis)
        {






        }

        private void panelForm_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            panelStickBottom.Location = new Point(stickyControlOriginalLocation.X, stickyControlOriginalLocation.Y + this.AutoScrollPosition.Y);
        }
        /// <summary>
        /// Gọi hàm trong DLL thiết bị thông qua Service chuẩn.
        /// Mảng <paramref name="vars"/> được cập nhật tại chỗ qua tham số ref/out của hàm được gọi,
        /// nên trả về chính mảng này để nơi gọi đọc kết quả (giữ nguyên hành vi cũ).
        /// </summary>
        /// <param name="pathDll">Đường dẫn tới file DLL thiết bị.</param>
        /// <param name="assembly">Tên assembly (namespace) chứa class.</param>
        /// <param name="assemblyType">Tên class trong assembly.</param>
        /// <param name="function">Tên hàm cần gọi.</param>
        /// <param name="vars">Danh sách tham số truyền vào, đồng thời nhận kết quả trả về.</param>
        /// <returns>Mảng tham số đã được cập nhật, hoặc null nếu gọi thất bại.</returns>
        public object CallFunction(string pathDll, string assembly, string assemblyType, string function, object[] vars)
        {
            try
            {
                // Service đã xử lý chuẩn hoá đường dẫn và cache assembly/type qua T3Call.
                _deviceService.CallFunction(pathDll, assembly, assemblyType, function, vars);
                return vars;
            }
            catch (Exception ex)
            {
                Logger.Log("FormEvaluateCorrection.CallFunction error: " + ex);
                return null;
            }
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
                    case "Float":
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
                    case "Integer":
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
                    case "Double":
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
                    case "String":
                        if (obj == null || string.IsNullOrEmpty(obj.Value))
                            result[index] = item.Value;
                        else result[index] = obj.Value;
                        break;
                    case "Boolean":
                        if (string.IsNullOrEmpty(item.Value)) result[index] = false;
                        else
                        {
                            if (obj == null || string.IsNullOrEmpty(obj.Value))
                                result[index] = bool.Parse(item.Value);
                            else result[index] = bool.Parse(obj.Value);
                        }


                        break;
                    case "PathFile":
                        if (obj == null)
                            result[index] = item.Value;
                        else result[index] = obj.Value;
                        break;
                }
                index++;
            }
            return result;
        }

        public List<ProcedureDetaiVariableViewModel> _Data;
        public string Marker;
        public string ReadingValue;
        public string CorrectionValue;
        public string ReportValue;
        int numberOder;
        public void LoadData(TableProcedureViewModel currentStep)
        {
            _Data = currentStep.Variables;
            rtbNote.Texts = currentStep.Description;
            numberOder = currentStep.NumberOder;
            if (_Data == null || _Data.Count < 4) return;
            _Data = _Data.OrderBy(t => t.NumberOrder).ToList();


            var pathCorrection = _Data[1].Value;
            var pathdll = _Data[0].Value;
            if (File.Exists(pathCorrection) && File.Exists(pathdll))
            {
                string correctionValue = "";
                string ReportValue = "";
                string mess = "";
                var result = (object[])CallFunction(pathdll, "CorrectionDB", "Correction", "CorrectionFunction", new object[] { pathCorrection, _Data[2].Value, _Data[3].Value, correctionValue, ReportValue, mess });  
                if (result != null && result.Count() > 0)
                {
                    DataTable table = new DataTable();
                    table.Columns.Add("No", typeof(int));
                    table.Columns.Add("MarkerID", typeof(string));
                    table.Columns.Add("ReadingValue", typeof(string));
                    table.Columns.Add("CorrectionValue", typeof(string));
                    table.Columns.Add("ReportValue", typeof(string));
                    table.Columns.Add("Uncertainty", typeof(string));
                    table.Columns.Add("Result", typeof(string));
                    Marker = _Data[2].Value;
                    ReadingValue = _Data[3].Value;
                    var colmarker = Marker.Split(",");
                    var colReading = ReadingValue.Split(",");
                    CorrectionValue = ((string)result[3]);
                    ReportValue = ((string)result[4]);
                    var colCorrrection = CorrectionValue.Split(",");
                    var colReportValue = ReportValue.Split(",");
                    var index = 0;
                    try
                    {
                        foreach (var col in colmarker)
                        {
                            table.Rows.Add(index + 1, FormatFrequency(double.Parse(colmarker[index], CultureInfo.InvariantCulture)), colReading[index], colCorrrection[index], colReportValue[index], "N/A", "N/A");
                            index++;
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    dataGridView1.DataSource = table;
                    dataGridView1.Refresh();
                }
            }
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
            mess = "";
            //if(string.IsNullOrEmpty(CorrectionValue))
            //{
            //    mess=
            //}
            return true;
        }
        public List<ProcedureVariableViewModel> _newV;
        private string FormatFrequency(double hz)
        {
            if (hz >= 1e9)
            {
                double val = Math.Truncate((hz / 1e9) * 1000000) / 1000000;
                return val.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture) + " GHz";
            }
            if (hz >= 1e6)
            {
                double val = Math.Truncate((hz / 1e6) * 1000000) / 1000000;
                return val.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture) + " MHz";
            }
            if (hz >= 1e3)
            {
                double val = Math.Truncate((hz / 1e3) * 1000000) / 1000000;
                return val.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture) + " kHz";
            }
            double valHz = Math.Truncate(hz * 1000000) / 1000000;
            return valHz.ToString("0.000000", System.Globalization.CultureInfo.InvariantCulture) + " Hz";
        }
        public void SaveValue()
        {
            if (_Data.Count < 6)
            {
                _newV = new List<ProcedureVariableViewModel>();
                _newV.Add(new ProcedureVariableViewModel()
                {
                    Name = "CorrectionStep" + numberOder,
                    Type = "String",
                    Value = CorrectionValue
                });
                _newV.Add(new ProcedureVariableViewModel()
                {
                    Name = "ReportStep" + numberOder,
                    Type = "String",
                    Value = ReportValue
                });
                _Data.Add(new ProcedureDetaiVariableViewModel()
                {
                    Name = "CorrectionStep" + numberOder,
                    Value = CorrectionValue,
                    NumberOrder = 5

                });
                _Data.Add(new ProcedureDetaiVariableViewModel()
                {
                    Name = "ReportStep" + numberOder,
                    Value = ReportValue,
                    NumberOrder = 6
                });
            }
            else
            {
                _newV = new List<ProcedureVariableViewModel>();
                _Data[4].Value = CorrectionValue;
                _Data[5].Value = CorrectionValue;
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
            _Maskdone = false;
            MaskDone();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void selectedFile1_Load(object sender, EventArgs e)
        {

        }
        public event EventHandler _StopProcedure;
        private void btnQuit_Click(object sender, EventArgs e)
        {
            _StopProcedure?.Invoke(null, EventArgs.Empty);
        }
    }
}
