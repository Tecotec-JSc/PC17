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
    public partial class FormEvaluateDUTInformation : Form
    {
        private Point stickyControlOriginalLocation;
        public List<AssembyViewModel> _Assemblys;
        public event EventHandler _StopProcedure;
        public FormEvaluateDUTInformation()
        {
            InitializeComponent();
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
            // this.panelForm.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelForm_MouseWheel);
        }
        public List<ProcedureDetaiVariableViewModel> _Variable;
        public List<ProcedureVariableViewModel> _Data;
        public void LoadData(TableProcedureViewModel step, List<ProcedureVariableViewModel> variables, int dutId)
        {
            _Maskdone = step.MaskDoneValue;
            if (!string.IsNullOrEmpty(step.Description))
                rtbNote.Texts = step.Comment;
            MaskDone();
            var json = JsonConvert.SerializeObject(step.Variables);
            _Variable = JsonConvert.DeserializeObject<List<ProcedureDetaiVariableViewModel>>(json);
            if (string.IsNullOrEmpty(step.Comment)) rtbNote.Texts = step.Comment;
            var lstVariIdStep = step.Variables.Select(i => i.ProcedureVariableId).ToList();
            _Data = variables.Where(t => lstVariIdStep.Contains(t.ProcedureVariableId)).ToList();
            foreach (var item in _Variable)
            {   var itemv = _Data.Where(t => t.Name == item.Name).FirstOrDefault();
                itemv.Value = item.Value;
                itemv.TypeInput = item.TypeInput;
                itemv.Report = item.Report;
                itemv.Title = item.Title;
                itemv.Required = item.Required;
            }
            //  panelStickBottom.Location = new Point(12, 723);
            tableDefaultrun1.LoadData(_Data);
            tableDefaultrun1.ResizeC();
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

            return tableDefaultrun1.ValidateInputs(out mess);
        }
        public void SaveValue()
        {
            var lst = tableDefaultrun1.GetVariables();
            int i = 0;
            foreach (var v in lst)
            {

                _Variable[i].Value = v.Value;
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
    }
}
