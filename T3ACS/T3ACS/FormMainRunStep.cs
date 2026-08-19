using System.Diagnostics;
using System.Reflection;
using T3.Configuration;
using T3ACS.Model;
using T3ACS.Service;
using T3ACS.ViewModel;
namespace T3ACS
{
    public partial class FormMain :Form, IMain
    {
        public FormMain()
        {
            InitializeComponent();
          //  SetupForm();
        }
        #region properties

        List<ToolsViewModel> _tools;   
        FormBlur blur;
        bool showFrmBlue, Action = false;
        FormTableInspections _frmProcedure;
        FormCreateProcedure _frmCreateProcedure;
        FormEditProcedure _frmEditProcedure;
        FormRunMain _frmRunProcedure;
        List<Form> lstForms;
        IFormMainService _service;
        #endregion


        private void SetupForm()
        {
            _service = new FormMainService();           
           // menuSw.Renderer = new ToolStripProfessionalRenderer(new MyColorTable());
            showFrmBlue = false;
            lstForms = new List<Form>();
            var area = Screen.PrimaryScreen.WorkingArea;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = area.Location;
            this.Size = area.Size;
            LoadTools();
        }
        #region Extension
        public void LoadTools()
        {
            _tools = _service.GetTools();
            if (_tools != null && _tools.Count > 0)
            {
                foreach (var item in _tools)
                {
                    ToolStripMenuItem newItem = new ToolStripMenuItem(item.Name);
                    manuTool.DropDown.Items.Add(newItem);
                    newItem.Click += (s, ev) => CallTool(item.Id);
                }
            }
            menuSw.Refresh();
        }
        private void CallTool(int toolId)
        {
            if (_tools != null && _tools.Count(t => t.Id == toolId) > 0)
            {
                try
                {
                    var obj = _service.CallTool(toolId, out string mess);
                    try
                    {
                        if(obj==null)
                        {
                            ShowMess("Notification", mess, 2);
                            return;
                        }
                        Form frm = (Form)obj;
                        if(frm==null)
                        {
                            ShowMess("Notification", "Can't open this tool", 2);
                            return;
                        }
                        frm.TopLevel = true;
                        frm.ShowDialog();
                    }
                    catch (Exception ex)
                    {
                        ShowMess("Notification", ex.Message, 2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
        #endregion

        #region click function
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private void MenuUserCreate_Click(object sender, EventArgs e)
        {
            FormInsertNewUser frmUser = new FormInsertNewUser(0);
            ShowFormDialog(frmUser);
        }
  


        private void MenuUserLstUser_Click(object sender, EventArgs e)
        {
            FormUsers frmUser = new FormUsers();
            ShowFormDialog(frmUser);
        }
        private void btnMinimun_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void runWorkInspectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void managementToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ShowManagerProcedure(true);
        }

        private void ShowManagerProcedure(bool value)
        {
            _frmProcedure = new FormTableInspections(this, value);
            ShowFormDialog(_frmProcedure);
        }

        #region IMain;
        // async void (khớp interface IMain trả về void). await để form dựng xong nội dung
        // rồi mới thêm vào panel và Show() -> không còn nháy trống.
        public async void RunProcedureId(int id)
        {
            if (_frmProcedure != null && _frmProcedure.CanFocus)
            {
                _frmProcedure.Close();
            }
            this.Focus();
            ClearFormMain();
            _frmRunProcedure = new FormRunMain();
            _frmRunProcedure.TopLevel = false;
            await _frmRunProcedure.RunProcedureId(id);
            _frmRunProcedure._SendAction += _SendAction;
            panelMain.Controls.Add(_frmRunProcedure);
            lstForms.Add(_frmCreateProcedure);
            _frmRunProcedure.Show();
        }



        public void EditProcedureId(int id)
        {
            if (_frmProcedure != null && _frmProcedure.CanFocus)
            {
                _frmProcedure.Close();
            }
            this.Focus();
            ClearFormMain();
            _frmEditProcedure = new FormEditProcedure();
            _frmEditProcedure._SendAction += _SendAction;
            _frmEditProcedure.TopLevel = false;
            _frmEditProcedure.LoadProcedure(id);
            panelMain.Controls.Add(_frmEditProcedure);
            _frmEditProcedure.Show();
        }

        private void _SendAction(object? sender, EventArgs e)
        {
           if (sender != null&&sender is string str)
            {
                if(!string.IsNullOrEmpty(str)) { 
                   switch(str)
                    {
                        case "ClearFormMain":
                            ClearFormMain(); 
                            break;
                    }
                }
            }
        }

        public void CreateProcedure()
        {
            if (_frmProcedure != null && _frmProcedure.CanFocus)
            {
                _frmProcedure.Close();
            }
            this.Focus();
            panelMain.Controls.Clear();
            _frmCreateProcedure = new FormCreateProcedure(this);
            _frmCreateProcedure.TopLevel = false;
            _frmCreateProcedure.Addbtn();
            panelMain.Controls.Add(_frmCreateProcedure);
            _frmCreateProcedure.Show();
            lstForms.Add(_frmCreateProcedure);
        }
        public void ClearFormMain()
        {
            if (lstForms != null && lstForms.Count > 0)
            {
                foreach (Form item in lstForms)
                {
                    if (item != null)
                        item.Dispose();
                }
                lstForms.Clear();
            }

            panelMain.Controls.Clear();

        }
        #endregion

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetupForm();
        }

        private void FormMain_Click(object sender, EventArgs e)
        {

        }
        private void managerExtensionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormManagerExtension frm = new FormManagerExtension();
            ShowFormDialog(frm);
            LoadTools();
        }
        private void lblSwName_Click(object sender, EventArgs e)
        {
        }
     

        private void testToolStripMenuItem2_Click(object sender, EventArgs e)
        {
         FormTest1 formTest1 = new FormTest1();
            formTest1.Show();
        }
        private void test2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCreateStepType frm = new FormCreateStepType();
            frm.ShowDialog();
        }
        private void test3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTest1 frm = new FormTest1();
            frm.ShowDialog();
        }
        private void testFormURLToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuSw_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddDUT frm = new FormAddDUT(0);
            frm.ShowDialog();
        }
        private void managementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDUTManager frm = new FormDUTManager(this);
            ShowFormDialog(frm);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout();
            ShowFormDialog(frm);
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string filePath = AppDomain.CurrentDomain.BaseDirectory + "Satellite Simulator.PDF";
            if (File.Exists(filePath))
            {
                Process.Start("explorer.exe", filePath);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ShowManagerProcedure(false);
        }
        private void ShowMess(string title, string strmess, int status)
        {
            FormNotiAll frmNoti = new FormNotiAll();
            frmNoti.LoadData(title, strmess, status);
            ShowFormDialog(frmNoti);
        }
        private void ShowFormDialog(Form form)
        {
            FormBlur blur = new FormBlur();
            blur.Size = new Size(1920, 1030);
            blur.Location = this.Location;
            blur.StartPosition = FormStartPosition.Manual;
            blur.Owner = this;
            blur.Show();
            form.ShowDialog();
            form.Dispose();
            // Cleanup
            blur.Close();
            blur.Dispose();
        }

    }
}
