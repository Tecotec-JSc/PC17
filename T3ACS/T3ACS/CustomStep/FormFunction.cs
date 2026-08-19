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
    public partial class FormFunction : Form
    {
        public FormFunction()
        {
            InitializeComponent();
        }
        public List<ProcedureVariableViewModel> _Data;
        public void LoadData(List<ProcedureVariableViewModel> values)
        {
            _Data=values;
            tableVariableSelect1.LoadData(null);
        }
        private void tableVariableSelect1__ShowError(object sender, EventArgs e)
        {
            ShowNoti("Validate User Input", tableVariableSelect1._StrError, 2);
        }
        /// <summary>
        /// 1: success, 2 warning, 3 Error
        /// </summary>
        /// <param name="title"></param>
        /// <param name="strmess"></param>
        /// <param name="status"></param>
        private void ShowNoti(string title, string strmess, int status)
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
            this.Focus();
        }
        private void tableVariableSelect1__UpdateHeight(object sender, EventArgs e)
        {
            this.Height = tableVariableSelect1.Height + 220;
        }

    }
}
