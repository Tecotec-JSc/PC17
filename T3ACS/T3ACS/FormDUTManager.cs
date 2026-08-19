using Newtonsoft.Json;
using T3.Configuration;
using T3ACS.Data;
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
using System.Reflection.Metadata;

namespace T3ACS
{
    public partial class FormDUTManager : BaseForm
    {
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Region = new Region(
                SetupForm.CreateRoundRect(this.ClientRectangle, 5));
        }

        private void loadData(string txtSearch)
        {
            var dt = _model.Gets(txtSearch);
            dataGridView1.DataSource = dt;
            dataGridView1.Refresh();
            if (dt != null && dt.Count > 14)
            {
                dataGridView1.Height = dt.Count * 36 + 2;
            }
            else
            {
                dataGridView1.Height = 508;
            }

        }

















        DUTModel _model;
        IMain _imain;
        int _dutId;
        public FormDUTManager(IMain imain)
        {
            InitializeComponent();
            _imain = imain;
            _model = new DUTModel();
            loadData("");
            //LoadDataTable();
            //LoadComboDUT();
            //LoadComboDUTHistory();
            //SettupGridHistory();
            //LoadDataResultTable();
            ;
        }
        private void SettupGridHistory()
        {
            //DataGridViewProgressColumn column = new DataGridViewProgressColumn();
            //dataGridView2.Columns.Add(column);
            //column.HeaderText = "Progress";
            //column.DataPropertyName = "PROGRESS";
            //column.Width = 200;
            //column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

        }
        // Click title to move
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        //End click title to move
        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadHistory(int dutId)
        {

        }

        private void LoadComboDUT()
        {

        }
        private void LoadComboDUTHistory()
        {

        }
        private void btnFilterProcedureList_Click(object sender, EventArgs e)
        {

        }
        private void btnPass2_Click(object sender, EventArgs e)
        {
            if (Main.Permission == "User")
            {
                ShowMess("Notification", "You do not have access.", 2);
                return;
            }

            FormBlur blur = new FormBlur();
            blur.Size = new Size(1920, 1030);
            blur.Location = this.Location;
            blur.StartPosition = FormStartPosition.Manual;
            blur.Owner = this;
            blur.Show();
            FormAddDUT frmadd = new FormAddDUT(0);
            frmadd.ShowDialog();       
            blur.Close();
            blur.Dispose();
            this.Focus();
            loadData("");
        }
        private void settupTab(bool viewProcedure)
        {

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
        private void tabProcedureList_Click(object sender, EventArgs e)
        {
            settupTab(true);
        }
        private void tabHistory_Click(object sender, EventArgs e)
        {
            settupTab(false);
        }
        private void btnAction_Click(object sender, EventArgs e)
        {
            List<int> lstId = new List<int>();
            var dt = (List<TableDUTViewModel>)dataGridView1.DataSource;
            if (dt != null && dt.Count > 0 && dt.Count(t => t.Action == true) > 0)
            {
                lstId = dt.Where(t => t.Action == true).Select(t => t.Id).ToList();
            }
            if (lstId != null && lstId.Count > 0)
            {
                if (cboAction.Texts == "Edit DUT")
                {
                    if (lstId.Count > 1)
                    {
                        ShowMess("Notification","You need to select only one device to edit.",2);
                    
                    }
                    else
                    {
                        FormAddDUT frmInsert = new FormAddDUT(lstId[0]);
                        if (frmInsert.ShowDialog() == DialogResult.OK)
                        {
                            loadData("");
                        }
                    }
                }

                else if (cboAction.Texts == "Duplicate DUT")
                {
                    if (_model.Duplicate(lstId))
                    {
                        ShowMess("Notification", "Duplicate devices successfully.", 2);
                  
                        loadData("");
                    }
                    else
                    {
                        ShowMess("Notification", "Error to duplicate devices.", 2);               
                        loadData("");
                    }
                    //if (lstId.Clstount > 1)
                    //{
                    //    FormNotification frmnoti = new FormNotification("You need select only one procedure to edit.");
                    //    frmnoti.ShowDialog();
                    //}
                    //else
                    //{
                    //    _imain.EditProcedureId(lstId[0]);
                    //    this.Close();
                    //}
                }
                else if (cboAction.Texts == "Delete DUT")
                {
                    FormOKCancelAll frmok = new FormOKCancelAll();
                    frmok.LoadData("Delete DUT", "Click OK to confirm DUT deletation! Device will be deleted permanently!", "Delete", "Cancel", 1);
                    if (frmok.ShowDialog() == DialogResult.OK)
                    {
                        foreach (var id in lstId)
                        {
                            if (_model.checkDelete(id))
                            {
                                if (!_model.Delete(id))
                                {
                                    ShowMess("Notification", "Error to detele DUT.", 2);
                                   
                                    loadData("");
                                    return;
                                }
                            }
                            else
                            {
                                ShowMess("Notification", "DUT has been used. Do not delete.", 2);                            
                                loadData("");
                                return;
                            }

                        }
                        ShowMess("Notification", "Delete DUT successfully.", 2);                    
                        loadData("");
                    }
                }
            }
            else
            {
                ShowMess("Notification", "You need to select a DUT.", 2);
             
            }
        }
        private void Duplicate(int procedureId)
        {


        }

        private void Delete(int procedureId)
        {



        }
        private void btnFilterHistory_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            //if (Main.Permission == "User")
            //{
            //    showNoti("You do not have access.");

            //    return;
            //}
            //OpenFileDialog open = new OpenFileDialog();
            //open.Filter = "(*.seq) | *.seq";
            //open.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory + "TemplateProcedure\\";
            //if (open.ShowDialog() == DialogResult.OK)
            //{
            //    var fileName = open.FileName;
            //    var str = File.ReadAllText(fileName);
            //    var vm = JsonConvert.DeserializeObject<TemplateViewModel>(str);
            //    ProcedureModel model = new ProcedureModel();
            //    var currentFolder = fileName.Substring(0, fileName.LastIndexOf("\\"));
            //    var namenewFile = fileName.Substring(fileName.LastIndexOf("\\") + 1);
            //    var newpath = currentFolder + "\\" + namenewFile.Replace(" ", "_").Replace(".", "_");
            //    vm.Id = model.GetNewId();
            //    vm = changeFileToImport(vm, newpath);
            //    var newId = model.InsertProcedure(vm);
            //    if (newId > 0)
            //    {
            //        showNoti("Import procedure successfully.");

            //        LoadDataTable(0);
            //    }
            //}
        }
        //private TemplateViewModel changeFileToImport(TemplateViewModel vm, string currentFolder)
        //{
        //    InsertFileFromDescription(vm.Description, currentFolder);
        //    foreach (var step in vm.TableProcedures)
        //    {
        //        if (!string.IsNullOrEmpty(step.Description))
        //            InsertFileFromDescription(vm.Description, currentFolder);
        //        if (!string.IsNullOrEmpty(step.PathDll) && step.PathDll.IndexOf("\\") == 0)
        //        {
        //            step.PathDll = currentFolder + step.PathDll;
        //        }
        //        if (!string.IsNullOrEmpty(step.PathSource) && step.PathSource.IndexOf("\\") == 0)
        //        {
        //            step.PathSource = currentFolder + step.PathSource;
        //        }
        //        if (!string.IsNullOrEmpty(step.PathDllMagnetic) && step.PathDllMagnetic.IndexOf("\\") == 0)
        //        {
        //            step.PathDllMagnetic = currentFolder + step.PathDllMagnetic;
        //        }
        //        if (!string.IsNullOrEmpty(step.FileMagnetic) && step.FileMagnetic.IndexOf("\\") == 0)
        //        {
        //            step.FileMagnetic = currentFolder + step.FileMagnetic;
        //        }
        //        if (!string.IsNullOrEmpty(step.PathDllPressure) && step.PathDllPressure.IndexOf("\\") == 0)
        //        {
        //            step.PathDllPressure = currentFolder + step.PathDllPressure;
        //        }
        //        if (!string.IsNullOrEmpty(step.FilePressure) && step.FilePressure.IndexOf("\\") == 0)
        //        {
        //            step.FilePressure = currentFolder + step.FilePressure;
        //        }
        //    }
        //    return vm;
        //}
        private void InsertFileFromDescription(string des, string currentFolder)
        {
            //List<string> lstDes = splitDescription(des);
            //if (lstDes != null && lstDes.Count > 0)
            //{
            //    if (lstDes != null && lstDes.Count > 0)
            //    {
            //        foreach (var strdes in lstDes)
            //        {
            //            if (strdes.IndexOf("<linkimg>") != -1)
            //            {
            //                var str1 = strdes.Substring(strdes.IndexOf("path=\"") + 6);
            //                var shortpathFile = str1.Substring(0, str1.IndexOf("\""));
            //                var olFile = currentFolder + "\\" + shortpathFile;
            //                var newFile = AppDomain.CurrentDomain.BaseDirectory + shortpathFile;
            //                try
            //                {
            //                    File.Copy(olFile, newFile, true);
            //                }
            //                catch (Exception ex)
            //                {

            //                }

            //            }
            //        }
            //    }



            //}


        }
        private void btnExport_Click(object sender, EventArgs e)
        {

            if (Main.Permission == "User")
            {
                showNoti("notification", "You do not have access.", 2);

                return;
            }
            List<int> lstId = new List<int>();
            var dt = (List<TableInspectionViewModel>)dataGridView1.DataSource;
            if (dt != null && dt.Count > 0 && dt.Count(t => t.Action == true) > 0)
            {
                lstId = dt.Where(t => t.Action == true).Select(t => t.ProcedureId).ToList();
            }
            if (lstId != null && lstId.Count > 0)
            {


                SaveFileDialog exportInspection = new SaveFileDialog();
                exportInspection.Title = "Inspection Export";
                exportInspection.Filter = "(*.xml) | *.xml";
                var newpatha = AppDomain.CurrentDomain.BaseDirectory + "TemplateInspectionExport\\";
                if (!Directory.Exists(newpatha)) Directory.CreateDirectory(newpatha);
                exportInspection.InitialDirectory = newpatha;
                ProcedureModel model = new ProcedureModel();
                var vm = model.GetProcedureById(lstId[0]);
                if (exportInspection.ShowDialog() == DialogResult.OK)
                {
                    var filePath = exportInspection.FileName;
                    var fileName = filePath.Substring(filePath.LastIndexOf("\\") + 1);
                    var shortName = fileName.Substring(0, fileName.LastIndexOf("."));
                    FileExtensionInputViewModel fileE = new FileExtensionInputViewModel();
                    fileE.Category = "RFTestSet";
                    fileE.Name = shortName;
                    fileE.Type = (int)EnumTypeExtension.Procedure;
                    //vm.Procedures = GetProcedureTestSpectrum();
                    fileE.Version = "1.0.0";
                    fileE.TypeFrame = 1;
                    // vm.Model = "DS520A";       
                    //var filePath = AppDomain.CurrentDomain.BaseDirectory + "ExtensionSpectrumProcedure.xml";
                    fileE.Procedures = new List<TemplateViewModel>();
                    foreach (var p in lstId)
                    {
                        fileE.Procedures.Add(model.GetProcedureById(p));
                    }

                    FileXML.SaveToXml(fileE, filePath);
                    showNoti("Notification", "File " + fileName + " was exported successfully.", 1);
                }


            }
            else
            {
                showNoti("Notification", "You need to select procedures to export.", 2);

            }



        }
        //private bool exportInspectionToFile(string newPathFile, TemplateViewModel vm)
        //{
        //    var check = true;

        //    var patha = newPathFile.Substring(0, newPathFile.LastIndexOf("\\"));
        //    var namenewFile = newPathFile.Substring(newPathFile.LastIndexOf("\\") + 1);
        //    var newpath = patha + "\\" + namenewFile.Replace(" ", "_").Replace(".", "_");
        //    if (!Directory.Exists(newpath)) Directory.CreateDirectory(newpath);
        //    List<FileExportViewModel> lstFileExport = new List<FileExportViewModel>();
        //    // copy file image in description.
        //    List<string> lstDes1 = splitDescription(vm.Description);
        //    if (lstDes1 != null && lstDes1.Count > 0)
        //    {
        //        for (int i = 0; i < lstDes1.Count; i++)
        //        {
        //            var stritem = lstDes1[i];
        //            if (stritem.IndexOf("<linkimg>") != -1)
        //            {
        //                var str1 = stritem.Substring(stritem.IndexOf("path=\"") + 6);
        //                var shortpathFile = str1.Substring(0, str1.IndexOf("\""));
        //                var oldFile = AppDomain.CurrentDomain.BaseDirectory + shortpathFile;
        //                var newpathimage = newpath + "\\Image";
        //                if (!Directory.Exists(newpathimage)) Directory.CreateDirectory(newpathimage);
        //                var newFile = newpath + "\\" + shortpathFile;
        //                try
        //                {
        //                    File.Copy(oldFile, newFile, true);
        //                }
        //                catch (Exception ex)
        //                {

        //                }


        //            }
        //        }
        //    }

        //    if (vm.TableProcedures != null && vm.TableProcedures.Count > 0)
        //    {
        //        foreach (var step in vm.TableProcedures)
        //        {
        //            // copy file image in description.
        //            List<string> lstDes = splitDescription(step.Description);
        //            if (lstDes != null && lstDes.Count > 0)
        //            {
        //                for (int i = 0; i < lstDes.Count; i++)
        //                {
        //                    var stritem = lstDes[i];
        //                    if (stritem.IndexOf("<linkimg>") != -1)
        //                    {
        //                        var str1 = stritem.Substring(stritem.IndexOf("path=\"") + 6);
        //                        var shortpathFile = str1.Substring(0, str1.IndexOf("\""));
        //                        var oldFile = AppDomain.CurrentDomain.BaseDirectory + shortpathFile;
        //                        var newpathimage = newpath + "\\Image";
        //                        if (!Directory.Exists(newpathimage)) Directory.CreateDirectory(newpathimage);
        //                        var newFile = newpath + "\\" + shortpathFile;
        //                        try
        //                        {
        //                            File.Copy(oldFile, newFile, true);
        //                        }
        //                        catch (Exception ex)
        //                        {

        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    string content2 = JsonConvert.SerializeObject(vm);
        //    File.WriteAllText(newPathFile, content2);
        //    return check;
        //}
        //private List<string> splitDescription(string des)
        //{
        //    List<string> result = new List<string>();
        //    string needsplit = des;
        //    var a = needsplit.IndexOf("<linkimg>");
        //    var b = needsplit.IndexOf("</linkimg>");
        //    if (needsplit.IndexOf("<linkimg>") != -1 && needsplit.IndexOf("</linkimg>") != -1)
        //    {
        //        while (needsplit.IndexOf("<linkimg>") != -1 && needsplit.IndexOf("</linkimg>") != -1)
        //        {
        //            if (needsplit.IndexOf("<linkimg>") > 0)
        //            {
        //                result.Add(needsplit.Substring(0, needsplit.IndexOf("<linkimg>")));
        //                needsplit = needsplit.Substring(needsplit.IndexOf("<linkimg>"));
        //            }
        //            result.Add(needsplit.Substring(0, needsplit.IndexOf("</linkimg>") + 11));
        //            if (needsplit.Length > needsplit.IndexOf("</linkimg>") + 11)
        //            {
        //                needsplit = needsplit.Substring(needsplit.IndexOf("</linkimg>") + 11);
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
        //    }
        //    else result.Add(des);
        //    return result;
        //}
        //private string changePathFile(List<FileExportViewModel> lstFileExport, string newshortPath, int stepNumber, string pathsourcea, out List<FileExportViewModel> lstToReturn)
        //{
        //    string result = "";
        //    if (lstFileExport.Count(t => t.OldPath == pathsourcea) == 0)
        //    {
        //        FileExportViewModel newFileVm = new FileExportViewModel();
        //        newFileVm.OldPath = pathsourcea;
        //        var fileName = pathsourcea.Substring(pathsourcea.LastIndexOf("\\") + 1);
        //        var newpathFull = newshortPath + "\\Step" + stepNumber;
        //        if (!Directory.Exists(newpathFull)) Directory.CreateDirectory(newpathFull);
        //        string newFullFile = newpathFull + "\\" + fileName;
        //        File.Copy(pathsourcea, newFullFile, true);
        //        newFileVm.NewPath = newFullFile;
        //        lstFileExport.Add(newFileVm);
        //        result = "\\Step" + stepNumber + "\\" + fileName;
        //    }
        //    else
        //    {
        //        var fileVm = lstFileExport.Where(t => t.OldPath == pathsourcea).FirstOrDefault();
        //        result = fileVm.NewPath;
        //    }
        //    lstToReturn = lstFileExport;
        //    return result;
        //}
        //private bool changePathFileImage(string newshortPath, string pathsourcea)
        //{
        //    try
        //    {
        //        if (!File.Exists(newshortPath)) File.Copy(pathsourcea, newshortPath, true);
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }

        //}
        private void btnActionHistory_Click(object sender, EventArgs e)
        {
            //List<int> lstId = new List<int>();
            //var dt = (List<TableResultInspectionViewModel>)dataGridView2.DataSource;
            //if (dt != null && dt.Count > 0 && dt.Count(t => t.Action == true) > 0)
            //{
            //    lstId = dt.Where(t => t.Action == true).Select(t => t.ResultProcedureId).ToList();
            //}
            //if (lstId != null && lstId.Count > 0)
            //{
            //    if (cboActionHistory.Text == "View log")
            //    {
            //        if (lstId.Count > 1)
            //        {
            //            showNoti("Notification", "You need select only one result history to view log.",2);

            //        }
            //        else
            //        {
            //            var log = _model.GetLogBy(lstId[0]);
            //            FormLogResult frmlogResult = new FormLogResult();
            //            frmlogResult.SetValue(log);
            //            frmlogResult.ShowDialog();
            //        }
            //    }
            //    else if (cboActionHistory.Text == "View report")
            //    {
            //        if (lstId.Count > 1)
            //        {
            //            showNoti("Notification", "You need select only one result history to view report.", 2);

            //        }
            //        else
            //        {
            //            var vm = _model.GetResultProcedureById(lstId[0]);
            //            if (vm.Type == (int)EnumStepType.ReportSelect)
            //            {
            //                if (vm.Description != null)
            //                {

            //                    var template = JsonConvert.DeserializeObject<DataTable>(vm.Description);
            //                    var fileTemplate = AppDomain.CurrentDomain.BaseDirectory + "Template001.xlsx";
            //                    if (!File.Exists(fileTemplate))
            //                    {
            //                        showNoti("File Template001.xlsx is not exist.");
            //                        return;
            //                    }
            //                    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //                    saveFileDialog.Title = "Export excel";
            //                    saveFileDialog.Filter = "(*.xlsx) | *.xlsx";
            //                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //                    {
            //                        var newPath = saveFileDialog.FileName;
            //                        ExcelModel model = new ExcelModel();
            //                        try
            //                        {
            //                            model.DrawTemplate001(fileTemplate, template, newPath);
            //                            showNoti("Export excel file successful.");

            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            showNoti(ex.Message);

            //                        }
            //                    }
            //                    //FormExportReport frmexportx = new FormExportReport(template);
            //                    //frmexportx.ShowDialog();
            //                }
            //            }
            //            else if (vm.Type == (int)EnumStepType.Tranceiver)
            //            {
            //                if (vm.Description != null)
            //                {
            //                    SaveFileDialog saveFileDialog = new SaveFileDialog();
            //                    saveFileDialog.Title = "Export file wav";
            //                    saveFileDialog.Filter = "(*.wav) | *.wav";
            //                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //                    {
            //                        try
            //                        {
            //                            File.Copy(vm.Description, saveFileDialog.FileName, true);
            //                            showNoti("Export data successfully.");

            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            showNoti(ex.Message);

            //                        }

            //                    }
            //                }
            //            }
            //            else
            //            {
            //                try
            //                {
            //                    var template = JsonConvert.DeserializeObject<TemplateViewModel>(vm.Description);
            //                    FormChooseTemplateExport frmExport = new FormChooseTemplateExport(template);
            //                    if (frmExport.ShowDialog() == DialogResult.OK)
            //                    {
            //                        SaveFileDialog savef = new SaveFileDialog();
            //                        savef.Filter = "(*.xlsx) | *.xlsx";
            //                        var path = frmExport._FileTemplate;
            //                        if (savef.ShowDialog() == DialogResult.OK)
            //                        {
            //                            var newFileName = savef.FileName;
            //                            if (string.IsNullOrEmpty(path))
            //                                path = AppDomain.CurrentDomain.BaseDirectory + "DefaultTemplate.xlsx";
            //                            if (newFileName.Trim().ToUpper() == path.Trim().ToUpper())
            //                            {
            //                                showNoti(newFileName + " is already template file. You must chose another path to export report.");

            //                                return;
            //                            }

            //                            ExcelModel model = new ExcelModel();
            //                            try
            //                            {
            //                                model.DrawTemplateT3ACS1(template, path, newFileName);
            //                            }
            //                            catch (Exception ex)
            //                            {
            //                                showNoti(ex.Message);

            //                            }

            //                        }
            //                    }
            //                }
            //                catch
            //                {

            //                }






            //            }


            //        }
            //    }
            //    else if (cboActionHistory.Text == "View attach file")
            //    {
            //        if (lstId.Count > 1)
            //        {
            //            showNoti("You need select only one result history to view attach file.");

            //        }
            //        else
            //        {
            //            FileModel model = new FileModel();
            //            var lst = model.GetsByResultProcedureId(lstId[0]);

            //            FormAttachList frm = new FormAttachList();
            //            frm.LoadView(lst);
            //            frm.ShowDialog();




            //        }
            //    }
            //}
            //else
            //{
            //    showNoti("You need select one result history.");

            //}
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {


        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var check = checkBox1.Checked;
            List<TableInspectionViewModel> data = (List<TableInspectionViewModel>)dataGridView1.DataSource;
            if (data != null && data.Count > 0)
            {
                foreach (var item in data)
                {
                    item.Action = check;
                }
            }
            dataGridView1.DataSource = data;
            dataGridView1.Refresh();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //var rowindexp = e.RowIndex;
            //var datap = (List<TableInspectionViewModel>)dataGridView1.DataSource;
            //datap[rowindexp].Action = !datap[rowindexp].Action;


            var rowindexp = e.RowIndex;
            var datap = (List<TableDUTViewModel>)dataGridView1.DataSource;
            List<TableDUTViewModel> lstToreturn = new List<TableDUTViewModel>();
            if (datap != null && datap.Count > 0)
            {
                datap[rowindexp].Action = !datap[rowindexp].Action;
                foreach (var item in datap)
                {
                    lstToreturn.Add(item);
                }
                dataGridView1.DataSource = lstToreturn;
            }
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void showNoti(string mess, string content, int type)
        {
            FormBlur blur = new FormBlur();
            blur.Size = new Size(1920, 1030);
            blur.Location = this.Location;
            blur.StartPosition = FormStartPosition.Manual;
            blur.Owner = this;
            blur.Show();
            FormNotiAll formNotiAll = new FormNotiAll();
            formNotiAll.LoadData(mess, content, type);
            formNotiAll.ShowDialog();
            formNotiAll.Dispose();
            blur.Close();
            blur.Dispose();





        }

        private void cboActionHistory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnCloseDefault_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabHistory_Load(object sender, EventArgs e)
        {

        }

        private void btnIconAddNew_Load(object sender, EventArgs e)
        {

        }
    }
}
