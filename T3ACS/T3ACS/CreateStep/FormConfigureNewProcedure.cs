using Newtonsoft.Json;
using T3.Configuration;
using T3ACS.Model;
using T3ACS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace T3ACS
{
    public partial class FormConfigureNewProcedure : Form
    {
        IProcedureModel _model;
        int _procedureId;
        public FormConfigureNewProcedure()
        {

            InitializeComponent();
            _model = new ProcedureModel();
            RegisterClick(this);
            LoadComboDUT();
            panel2.HorizontalScroll.Enabled = false;
            panel2.HorizontalScroll.Visible = false;
            panel2.HorizontalScroll.Maximum = 0;
            // Chỉ cho scroll dọc
            panel2.AutoScrollMinSize = new Size(0, 569);
            tblMetaData.ResizeC();
        }
        //Update
        public void LoadData(int procedureId, string titleTemplate, string name, string id, string category, string duration, string dut, string des, string meetadata, string LinkModem, string LinkACU, List<ProcedureVariableViewModel> variables)
        {
            _procedureId = procedureId;
            lblTitleForm.Text = "Configure the procedure";
            lblDesTemplateName.Text = titleTemplate;
            txtProcedureName.Texts = name;
            txtId.Text = id;
            txtCategory.Texts = category;
            txtDuration.Texts = duration;

            rtbDescription.Texts = des;
            selectSearchDUT.SetValue(dut);
            if (!string.IsNullOrEmpty(meetadata))
            {
                var dataMeta = JsonConvert.DeserializeObject<Dictionary<string, string>>(meetadata);
                tblMetaData.LoadData(dataMeta);
            }
            else tblMetaData.ResizeC();
            tableVariable.LoadData(variables);
            ResizeTblFlow();
        }



        // Click title to move
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // Create
        public void SetData(TemplateProcedureViewModel data)
        {
            lblDesTemplateName.Text = data.Name;
            _procedureId = data.ProcedureId;
            var newId = _model.GetNewId();
            txtId.Text = newId;
        }
        public List<ProcedureVariableViewModel> _variables;
        private void LoadComboDUT()
        {
            IDUTModel model = new DUTModel();
            var dt = model.GetTenDUTs();
            if (dt != null && dt.Count > 0)
            {
                List<string> list = new List<string>();
                foreach (var item in dt)
                {
                    list.Add(item.DUTName + ";" + item.ModelDUT + ";" + item.Brand);
                }
                selectSearchDUT.SetData(list);
                // selectCustomAdd1.SetData(list);               
                selectSearchDevices.SetData(list);
            }
        }
        public int _NewId;
        public string _strName, _strId, _strVersion, _strDescription, _strCategory, _strDuration, _strDUT, _strMeta, _linkModem, _linkACU;

        private void btnChooseTemplate_Click(object sender, EventArgs e)
        {
            _strName = txtProcedureName.Texts;
            _strId = txtId.Texts;
      
            _strDescription = rtbDescription.Texts;
            _strCategory = txtCategory.Texts;
            _strDuration = txtDuration.Texts;

            if (string.IsNullOrEmpty(_strName) )
            {
                ShowNoti("Validate User Input", "You must enter a procedure name and version.", 2);
                return;
            }
            _strDUT = selectSearchDUT.SelectedValue;
            if (string.IsNullOrEmpty(_strDUT))
            {
                ShowNoti("Validate User Input", "You must select a DUT.", 2);
                return;
            }
            string error = "";
            //if (!MeasurementValidator.ValidateTitle("Procedure Name", _strName, 3, 250, null, out error))
            //{
            //    ShowNoti("Validate User Input", error, 2);
            //    return;
            //}

            if (!string.IsNullOrEmpty(_strCategory) && !MeasurementValidator.ValidateTitle("Category", _strCategory, 3, 25, null, out error))
            {
                ShowNoti("Validate User Input", error, 2);
                return;
            }
            _variables = tableVariable.GetVariables();
            var metaData = tblMetaData.GetValue();
            if (metaData != null)
                _strMeta = JsonConvert.SerializeObject(metaData);
            if ((_procedureId == 0))
            {
                _NewId = _model.InsertProcedure(_strName, _strId, _strDescription, _strVersion, _strCategory, _strDuration, _strDUT, metaData, _variables);
                if (_NewId > 0)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ShowNoti("Notification", "Error creating a new procedure.", 3);
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void RegisterClick(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (!(c is Button))
                {

                    if (!(c is Label && c.Name.IndexOf("lblbtn") != -1))
                    {
                        c.MouseDown += Control_MouseDown;

                        if (c.HasChildren)
                            RegisterClick(c);
                    }
                }

            }
        }
        void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(sender is TextBox || sender is RichTextBox))
            {
                this.ActiveControl = null; // BỎ FOCUS TEXTBOX
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblMetadata_Click(object sender, EventArgs e)
        {

        }
        private void ResizeTblFlow()
        {
            panelMetaData.Height = tblMetaData.Height + 41;
            panelVariable.Height = tableVariable.Height + 50;
            panelFlow.Height = panelVariable.Height + panelMetaData.Height;
        }

        private void btnAddMetaData_Click(object sender, EventArgs e)
        {
            tblMetaData.AddNewRow(false, "", "", true);
            tblMetaData.ResizeC();
            ResizeTblFlow();
        }

        private void btnDeleteMetaData_Click(object sender, EventArgs e)
        {
            tblMetaData.DeleteRowSelect();
            tblMetaData.ResizeC();
            ResizeTblFlow();
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


        private void FormConfigureNewProcedure_FormClosed(object sender, FormClosedEventArgs e)
        {
            selectSearchDUT.ClosePopUp();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableVariableControl1_Load(object sender, EventArgs e)
        {

        }

        private void tblMetaData__UpdateHeight(object sender, EventArgs e)
        {
            ResizeTblFlow();
        }

      

       

      

        private void btnCloseDefault_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
