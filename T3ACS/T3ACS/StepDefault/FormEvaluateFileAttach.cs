using Newtonsoft.Json;
using T3.Configuration;
using T3ACS.Controls;
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
    public partial class FormEvaluateFileAttach : Form
    {
        IMain _imain;
        private Point stickyControlOriginalLocation;
        public FormEvaluateFileAttach(IMain imain)
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
        public List<ProcedureDetailValueViewModel> _Data;
        public void LoadData(TableProcedureViewModel step)
        {
            if (step.MaskDoneValue.HasValue)
            {
                btnPass.SetValue(step.MaskDoneValue.Value);
                btnFailed.SetValue(!step.MaskDoneValue.Value);
            }
            if (string.IsNullOrEmpty(step.Comment)) rtbNote.Texts = step.Comment;
            _Data = step.ProcedureDetailValue2s;
            if (_Data != null && _Data.Count > 0)
            {
                var heightNow = 0;
                foreach (var item in _Data)
                {
                    Label lblitem = new Label();
                    lblitem.Text = item.Title;
                    lblitem.Name = "lblVariable" + item.NumberOder;
                    lblitem.Padding = new Padding(3, 7, 3, 7);
                    lblitem.AutoSize = false;
                    lblitem.Width = panelString.Width - 10;
                    lblitem.Height = 33;
                    panelString.Controls.Add(lblitem);
                    RJSelectFileControl txtitem = new RJSelectFileControl();                 
                    txtitem.Width = panelString.Width - 3;
                    txtitem.Name = "txfVariable" + item.NumberOder;
                    txtitem.Padding = new Padding(3, 7, 3, 7);
                    if (!string.IsNullOrEmpty(item.Value)) txtitem.SetValue(item.Value);
                    panelString.Controls.Add(txtitem);
                    //CardSelectBoolean carSelect = new CardSelectBoolean();
                    //carSelect.Name = "variable" + item.NumberOder;
                    //bool? valueInput = null;
                    //if (!string.IsNullOrEmpty(item.Value))
                    //{
                    //    valueInput = bool.Parse(item.Value);
                    //}
                    //carSelect.SetValue(item.Title, valueInput);
                    //carSelect.Margin = new Padding(1, 7, 1, 7);
                    //panelString.Controls.Add(carSelect);
                    //heightNow += carSelect.Height;
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
                if (c is RJSelectFileControl)
                {
                    RJSelectFileControl item= c as RJSelectFileControl;
                    if (string.IsNullOrEmpty(item._fileInput))
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
                if (c is RJSelectFileControl)
                {
                    RJSelectFileControl item = c as RJSelectFileControl;
                    _Data[i].Value = item._fileInput;
                    i++;
                }

            }
        }
        public string GetNote()
        {
            return rtbNote.Texts;
        }
    }
}
