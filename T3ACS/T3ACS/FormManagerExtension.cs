using Newtonsoft.Json;
using T3ACS.Model;
using T3ACS.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace T3ACS
{
    public partial class FormManagerExtension : Form
    {
        IPackageModel _model;
        public FormManagerExtension()
        {
            InitializeComponent();
            _model = new PackageModel();
            LoadDataEx();
        }
        private void LoadDataEx()
        {
            var dt = _model.Gets();
            dtGrid.DataSource = dt;
            dtGrid.Refresh();
        }
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void FormManagerExtension_Load(object sender, EventArgs e)
        {

        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            List<int> lstId = new List<int>();
            var dt = (List<RowTableExtensionViewModel>)dtGrid.DataSource;
            if (dt != null && dt.Count > 0 && dt.Count(t => t.Action == true) > 0)
            {
                lstId = dt.Where(t => t.Action == true).Select(t => t.Id).ToList();
            }
            if (lstId != null && lstId.Count > 0)
            {
                if (cboAction.Text == "Delete")
                {
                    foreach (var id in lstId)
                    {
                        if (_model.CheckDelete(id))
                        {
                            if (!_model.Delete(id))
                            {
                                ShowMess("Nofication", "Failed to delete package.", 3);                              
                                LoadDataEx();
                                return;
                            }
                        }
                        else
                        {
                            ShowMess("Nofication", "This package is in use. It cannot be deleted.", 2);                        
                            LoadDataEx();
                            return;
                        }

                    }
                    ShowMess("Nofication", "Package deleted successfully.", 1);                    
                    LoadDataEx();
                }
            }
            else
            {
                ShowMess("Nofication", "You must select a package.", 2);             
            }
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
            this.Focus();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "(*.xml) | *.xml";
            //   open.initialdirectory = appdomain.currentdomain.basedirectory;
            if (open.ShowDialog() == DialogResult.OK)
            {
                var filename = open.FileName;
                XmlSerializer serializer = new XmlSerializer(typeof(FileExtensionInputViewModel));
                FileExtensionInputViewModel vm;
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    vm =(FileExtensionInputViewModel)serializer.Deserialize(fs);
                }
                //var str = File.ReadAllText(filename);
                //var vm = JsonConvert.DeserializeObject<PackageViewModel>(str);
                //CreateFunction cf = new CreateFunction();
                //var replayvm = cf.GetProcedureTestSpectrum3();
                //var p1 = vm.Procedures[1].Subject;
                //vm.Procedures[1] = replayvm;
                //var filePath = AppDomain.CurrentDomain.BaseDirectory + "ExtensionProcedureSpectrumF.xml";
                //FileXML.SaveToXml(vm, filePath);
                IPackageModel model = new PackageModel();
                if (model.CheckIsExist(vm.Name,vm.Version))
                {
                    var strnoti = "Package " + vm.Name + " with version "+vm.Version+" already exists.";
                    ShowMess("Nofication", strnoti, 2);
                 
                }
                else
                {
                    var newid = model.InsertPackage(vm, filename);
                    if (newid > 0)
                    {
                        ShowMess("Nofication", "Package import successfully.", 1);
                       
                        LoadDataEx();
                    }
                    else
                    {
                        ShowMess("Nofication", "Package import Error.", 3);
               
                    }
                }

            }
        }


   
    }
}
