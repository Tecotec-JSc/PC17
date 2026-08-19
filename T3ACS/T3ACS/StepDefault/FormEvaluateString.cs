using Newtonsoft.Json;
using T3.Configuration;
using T3ACS.Controls;
using T3ACS.Controls.Card;
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
    public partial class FormEvaluateString : Form
    {
        IMain _imain;
        private Point stickyControlOriginalLocation;
        public FormEvaluateString(IMain imain)
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
                    string str = item.Value;

                    var vardiable12 = variables.Where(t => t.Name == item.Name).FirstOrDefault();
                    if (!string.IsNullOrEmpty(vardiable12.Value)) {
                        str = vardiable12.Value;


                    } 
                    carSelect.SetValue(item.Title, str);
                    carSelect.Margin = new Padding(1, 7, 1, 7);
                    panelString.Controls.Add(carSelect);
                    heightNow += carSelect.Height;
                    i++;
                }
                if (heightNow > 546)
                {
                    panelString.Height = heightNow;
                    panelHold.Location = new Point(panelStickBottom.Location.X, panelStickBottom.Location.Y + (heightNow - 546));
                }
            }
            panelStickBottom.Location = new Point(12, 723);

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
            foreach (Control c in panelString.Controls)
            {
                if (c is CardInput card)
                {                    
                    if (string.IsNullOrEmpty(card.Texts))
                    {
                        mess = "Please fill in all required fields before saving.";
                        return false;
                    }
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
                    _Variable[i].Value = card.Texts;
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
