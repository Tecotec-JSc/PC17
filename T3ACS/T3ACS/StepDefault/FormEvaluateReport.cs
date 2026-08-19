using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
    public partial class FormEvaluateReport : Form
    {
        private Point stickyControlOriginalLocation;
        public List<AssembyViewModel> _Assemblys;

        public FormEvaluateReport()
        {
            InitializeComponent();
            LoadButtonBot();
            panelForm.AutoScroll = true;
            panelForm.HorizontalScroll.Enabled = false;
            panelForm.HorizontalScroll.Visible = false;
            panelForm.AutoScrollMinSize = new Size(0, 804);

            this.panelForm.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelForm_MouseWheel);
        }
        public TemplateViewModel _vm;
        public event EventHandler _exprort;
        public void LoadData(TemplateViewModel vm)
        {
            _vm = vm;
            txtReportName.Texts = vm.ReportName;
            txtOutputPath.Texts = vm.ReportOutputPath;
            txtReportDate.Texts = vm.ReportDate;
            chkPDFReport.Checked = vm.ExportPDF;
        }
        public bool CheckSave(out string mess)
        {
            mess = "";
            var rpName = txtReportName.Texts;
            var rpPath = txtOutputPath.Texts;
            var rpDate = txtReportDate.Texts;
            if (string.IsNullOrEmpty(rpName))
            {
                mess = "You must enter a report name.";
                return false;
            }
            if (string.IsNullOrEmpty(rpPath))
            {
                mess = "You must enter a report path.";
                return false;
            }
            if (!string.IsNullOrEmpty(rpDate))
            {
                if (!DateTime.TryParseExact(rpDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _))
                {
                    mess = "You must enter the report date in the format dd/MM/yyyy.";
                    return false;
                }
            }
            return true;
        }

        public bool SaveData()
        {
            var rpName = txtReportName.Texts;
            var rpPath = txtOutputPath.Texts;
            var rpDate = txtReportDate.Texts;
            _vm.ReportName = rpName;
            _vm.ReportDate = rpDate;
            _vm.ReportOutputPath = rpPath;
            _vm.ExportPDF = chkPDFReport.Checked;
            return true;
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
            btnExport._ImageDefault = Image.FromFile(pathApp + "btnExport.png");
            btnExport._ImageSelect = Image.FromFile(pathApp + "btnExport.png");
            btnExport._ImageDisable = Image.FromFile(pathApp + "btnExport.png");
            btnExport.SetEnalbe(true);

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

        private void btnExport__ClickControl(object sender, EventArgs e)
        {
            if (CheckSave(out string mess))
            {
                SaveData();
                _exprort?.Invoke(null, EventArgs.Empty);
            }
            else ShowMess("Notification", mess, 2);
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

        private void ButtonCustom1__EventSelect(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Select a folder";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string path = dialog.SelectedPath;
                    txtOutputPath.Texts = path;
                }
            }
        }
    }
}
