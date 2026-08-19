using Newtonsoft.Json;
using System.Data;
using T3.Configuration;
using T3ACS.Controls.Card;
using T3ACS.Model;

namespace T3ACS
{
    public partial class FormEvaluateBoolean : Form
    {
        IMain _imain;
        private Point stickyControlOriginalLocation;

        public FormEvaluateBoolean(IMain imain)
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
            _Maskdone = step.MaskDoneValue;
            MaskDone();
            var json = JsonConvert.SerializeObject(step.Variables);
            _Variable = JsonConvert.DeserializeObject<List<ProcedureDetaiVariableViewModel>>(json);
            rtbNote.Texts = step.Comment;


            var lstVariIdStep = step.Variables.Select(i => i.ProcedureVariableId).ToList();

            _Data = variables.Where(t => lstVariIdStep.Contains(t.ProcedureVariableId)).ToList();
            if (_Data != null && _Data.Count > 0)
            {
                var heightNow = 0;
                int i = 0;
                foreach (var item in _Data)
                {
                    CardSelectBoolean carSelect = new CardSelectBoolean();
                    carSelect.Name = "variable" + item.ProcedureVariableId;
                    bool? valueInput = null;
                    var vardiable12 = variables.Where(t => t.Name == item.Name).FirstOrDefault();
                    if (!string.IsNullOrEmpty(vardiable12.Value))
                    {
                        valueInput = bool.Parse(vardiable12.Value);
                    }
                    else if (!string.IsNullOrEmpty(item.Value))
                    {
                        valueInput = bool.Parse(item.Value);
                    }
                    carSelect.SetValue(item.Title, valueInput);
                    carSelect.Margin = new Padding(1, 7, 1, 7);
                    panelBoolean.Controls.Add(carSelect);
                    heightNow += carSelect.Height;
                }
                if (heightNow > 546)
                {
                    panelBoolean.Height = heightNow;
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
            foreach (CardSelectBoolean item in panelBoolean.Controls)
            {
                if (!item._Value.HasValue)
                {
                    mess = item.GetText() + " must be selected.";
                    return false;
                }
            }
            return true;
        }
        public void SaveValue()
        {
            int i = 0;
            foreach (CardSelectBoolean item in panelBoolean.Controls)
            {
                _Variable[i].Value = item._Value.ToString();
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
            _Maskdone = false;
            MaskDone();
        }
    }
}
