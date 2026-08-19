using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3ACS.Controls;
using T3ACS.Controls.SelectCustoms;
using T3ACS.Model;

namespace T3ACS.CreateStep
{
    public partial class FormCreateReport : Form
    {
        public FormCreateReport()
        {
            InitializeComponent();
        }
        public TemplateViewModel _vm;

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

        private void label8_Click(object sender, EventArgs e)
        {
            chkPDFReport.Checked = !chkPDFReport.Checked;
        }
    }
}
