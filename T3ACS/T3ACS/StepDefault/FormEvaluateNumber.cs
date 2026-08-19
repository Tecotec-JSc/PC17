using Newtonsoft.Json;
using T3.Configuration;
using T3ACS.Controls;
using T3ACS.Controls.Card;
using T3ACS.Model;
using T3ACS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class FormEvaluateNumber : Form
    {
        IMain _imain;
        private Point stickyControlOriginalLocation;
        public FormEvaluateNumber(IMain imain)
        {
            InitializeComponent();
            stickyControlOriginalLocation = new Point(12, 723);
            LoadButtonBot();
            panelForm.AutoScroll = true;
            panelForm.HorizontalScroll.Enabled = false;
            panelForm.HorizontalScroll.Visible = false;
            panelForm.AutoScrollMinSize = new Size(0, 804);
            //this.AutoScroll = true;
            //_imain=imain;
            //// ❌ Không cho scroll ngang
            //this.HorizontalScroll.Enabled = false;
            //this.HorizontalScroll.Visible = false;

            //// Ngưỡng xuất hiện scroll Y
            //this.AutoScrollMinSize = new Size(0, 804);
            //this.Scroll += FormEvaluate_Scroll;
            this.panelForm.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelForm_MouseWheel);
            //  this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.FormEvaluate_Scroll);
        }
        private void panelForm_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            panelStickBottom.Location = new Point(stickyControlOriginalLocation.X, stickyControlOriginalLocation.Y + this.AutoScrollPosition.Y);
        }
        public List<ProcedureVariableViewModel> _Data;
        public List<ProcedureDetaiVariableViewModel> _Variable;
        public void LoadData(TableProcedureViewModel step, List<ProcedureVariableViewModel> variables)
        {
            _Maskdone = step.MaskDone;
            MaskDone();
            var json = JsonConvert.SerializeObject(step.Variables);
            _Variable = JsonConvert.DeserializeObject<List<ProcedureDetaiVariableViewModel>>(json);
            if (string.IsNullOrEmpty(step.Comment)) rtbNote.Texts = step.Comment;
            var lstVariIdStep = step.Variables.Select(i => i.ProcedureVariableId).ToList();

            _Data = variables.Where(t => lstVariIdStep.Contains(t.ProcedureVariableId)).ToList();
            if (_Data != null && _Data.Count > 0)
            {
                var heightNow = 0;
                int i = 0;
                foreach (var item in _Data)
                {
                    CardInput carSelect = new CardInput();
                    carSelect.Name = "variable" + item.ProcedureVariableId;                   
                    double valueInput = 0;
                    string strValue = "";
                    if (item.Unit.ToUpper().Contains("HZ"))
                    {
                   
                        var vardiable12 = variables.Where(t => t.Name == item.Name).FirstOrDefault();
                        if (!string.IsNullOrEmpty(step.Variables[i].Value))
                        {
                            valueInput = double.Parse(vardiable12.Value, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else if (!string.IsNullOrEmpty(item.Value))
                        {
                            valueInput = double.Parse(item.Value, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        strValue= FormatFrequency(valueInput);                       
                    }
                    else
                    {
                        
                        var vardiable12 = variables.Where(t => t.Name == item.Name).FirstOrDefault();
                        if (!string.IsNullOrEmpty(step.Variables[i].Value))
                        {
                            valueInput = double.Parse(step.Variables[i].Value, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        else if (!string.IsNullOrEmpty(item.Value))
                        {
                            valueInput = double.Parse(item.Value, System.Globalization.CultureInfo.InvariantCulture);
                        }

                         strValue = valueInput + " " + item.Unit;
                    }
                    if (item.Title == "Bien8")
                    {
                        var a = 1;
                    }
                    carSelect.SetValue(item.Title, strValue);
                    carSelect.Margin = new Padding(1, 7, 1, 7);
                    heightNow += carSelect.Height+15;
                    if (heightNow > 546) panelString.Height = heightNow;
                    panelString.Controls.Add(carSelect);
              
                    i++;
                }
                if (heightNow > 546)
                {                   
                    panelHold.Location = new Point(panelStickBottom.Location.X, panelStickBottom.Location.Y + (heightNow - 546));
                }
            }
            panelStickBottom.Location = new Point(12, 723);

        }
        private string FormatFrequency(double hz)
        {
            if (hz >= 1e9) return (hz / 1e9).ToString("0.######", System.Globalization.CultureInfo.InvariantCulture) + " GHz";
            if (hz >= 1e6) return (hz / 1e6).ToString("0.######", System.Globalization.CultureInfo.InvariantCulture) + " MHz";
            if (hz >= 1e3) return (hz / 1e3).ToString("0.######", System.Globalization.CultureInfo.InvariantCulture) + " kHz";
            return hz.ToString("0.######", System.Globalization.CultureInfo.InvariantCulture) + " Hz";
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
            int i = 0;
            foreach (Control c in panelString.Controls)
            {

                if (c is CardInput card)
                {
                    if (string.IsNullOrEmpty(card.Texts))
                    {
                        mess = "Please fill in all required fields before saving.";
                        return false;
                    }
                    if (_Data != null && _Data.Count > i)
                    {
                        var item = _Data[i];
                        if (!string.IsNullOrEmpty(item.Unit))
                        {
                            if (item.Unit.ToUpper().Contains("HZ"))
                            {
                                double? min = null;
                                double? max = null;
                                if (!string.IsNullOrEmpty(item.Min)) min = double.Parse(item.Min, System.Globalization.CultureInfo.InvariantCulture);
                                if (!string.IsNullOrEmpty(item.Max)) max = double.Parse(item.Max, System.Globalization.CultureInfo.InvariantCulture);
                                if (!MeasurementValidator.ValidateFrequency(item.Title, card.Texts, min, max, out mess, out double vacheck))
                                {
                                    return false;
                                }
                            }
                            else 
                            {
                                double? min = null;
                                double? max = null;
                                if (!string.IsNullOrEmpty(item.Min)) min = double.Parse(item.Min, System.Globalization.CultureInfo.InvariantCulture);
                                if (!string.IsNullOrEmpty(item.Max)) max = double.Parse(item.Max, System.Globalization.CultureInfo.InvariantCulture);
                                if (!MeasurementValidator.ValidateUnit(item.Title, card.Texts, item.Unit, min, max, out mess, out double vacheck))
                                {
                                    return false;
                                }
                            }                           
                        }
                        else
                        if (!MeasurementValidator.CheckValue(item.Title, card.Texts, item.Min, item.Max, item.Type, out mess))
                        {
                            return false;
                        }
                    }
                    i++;
                }
            }
            return true;
        }
        public void SaveValue()
        {
            int i = 0;
            foreach (Control c in panelString.Controls)
            {
                if (c is CardInput card)
                {
                    if (_Data != null && _Data.Count > i)
                    {
                        var item = _Data[i];
                        if (!string.IsNullOrEmpty(item.Unit))
                        {
                            if (item.Unit.ToUpper().Contains("HZ"))
                            {
                                double? min = null;
                                double? max = null;
                                if (!string.IsNullOrEmpty(item.Min)) min = double.Parse(item.Min, System.Globalization.CultureInfo.InvariantCulture);
                                if (!string.IsNullOrEmpty(item.Max)) max = double.Parse(item.Max, System.Globalization.CultureInfo.InvariantCulture);
                                MeasurementValidator.ValidateFrequency(item.Title, card.Texts, min, max, out string mess, out double vacheck);
                                _Variable[i].Value = vacheck.ToString(System.Globalization.CultureInfo.InvariantCulture);
                            }
                            else
                            {
                                double? min = null;
                                double? max = null;
                                if (!string.IsNullOrEmpty(item.Min)) min = double.Parse(item.Min, System.Globalization.CultureInfo.InvariantCulture);
                                if (!string.IsNullOrEmpty(item.Max)) max = double.Parse(item.Max, System.Globalization.CultureInfo.InvariantCulture);
                                MeasurementValidator.ValidateUnit(item.Title, card.Texts, item.Unit, min, max, out string mess, out double vacheck);
                                _Variable[i].Value = vacheck.ToString(System.Globalization.CultureInfo.InvariantCulture);
                            }
                        }
                        else _Variable[i].Value = card.Texts;
                    }
                    i++;
                }

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
    }
}
