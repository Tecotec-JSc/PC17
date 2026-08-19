using Newtonsoft.Json;
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
using T3ACS.Controls;
using T3ACS.Controls.Card;
using T3ACS.Controls.Table;
using T3ACS.Model;
using T3ACS.ViewModel;

namespace T3ACS.StepDefault
{
    public partial class FormEvaluateParameter : Form
    {
        private Point stickyControlOriginalLocation;
        public List<AssembyViewModel> _Assemblys;

        public FormEvaluateParameter()
        {
            InitializeComponent();
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
           // this.panelForm.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelForm_MouseWheel);
        }
        public List<ProcedureDetaiVariableViewModel> _Variable;
        public List<ProcedureVariableViewModel> _Data;
        public void LoadData(TableProcedureViewModel step, List<ProcedureVariableViewModel> variables)
        {
            _Maskdone = step.MaskDoneValue;
            rtbNote.Texts = step.Comment;
            MaskDone();

            var json = JsonConvert.SerializeObject(step.Variables);
            _Variable = JsonConvert.DeserializeObject<List<ProcedureDetaiVariableViewModel>>(json);
            if (string.IsNullOrEmpty(step.Comment)) rtbNote.Texts = step.Comment;
            var lstVariIdStep = step.Variables.Select(i => i.ProcedureVariableId).ToList();
            _Data = variables.Where(t => lstVariIdStep.Contains(t.ProcedureVariableId)).ToList();
            if (_Data != null && _Data.Count > 0)
            {
                foreach (var item in _Data)
                {
                    var itemv = _Variable.Where(t => t.Name == item.Name).FirstOrDefault();
                    item.Value = itemv.Value;
                    item.TypeInput = itemv.TypeInput;
                    item.Report = itemv.Report;
                    item.Title = itemv.Title;
                    item.Required = itemv.Required;
                }
            }
            panelStickBottom.Location = new Point(12, 723);
            tableDefaultrun1.LoadData(_Data);
            tableDefaultrun1.ResizeC();
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

            return tableDefaultrun1.ValidateInputs(out mess);
        }
        public void SaveValue()
        {
            var lst = tableDefaultrun1.GetVariables();
            _Variable = new List<ProcedureDetaiVariableViewModel>();
            foreach (var v in lst)
            {
                ProcedureDetaiVariableViewModel item = new ProcedureDetaiVariableViewModel();

                var seachId = _Data.Where(t => t.Title == v.Title).FirstOrDefault();
                item.ProcedureVariableId = seachId.ProcedureVariableId;
                item.Name = seachId.Name;
                item.Value = v.Value;
                item.Title = v.Title;
                seachId.Rank = v.Rank;
                item.Report = v.Report;
                item.Required = v.Required;
                _Variable.Add(item);
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
        public event EventHandler _StopProcedure;
        private void btnQuit_Click(object sender, EventArgs e)
        {
            _StopProcedure?.Invoke(null, EventArgs.Empty);
        }
    }
}
