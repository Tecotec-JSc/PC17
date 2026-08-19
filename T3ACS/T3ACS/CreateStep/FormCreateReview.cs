using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3ACS.Controls;
using T3ACS.Controls.SelectCustoms;
using T3ACS.Controls.Table;
using T3ACS.Model;

namespace T3ACS.CreateStep
{
    public partial class FormCreateReview : Form
    {
        public FormCreateReview()
        {
            InitializeComponent();
        }
        public TemplateViewModel _vm;
        public void LoadData(TemplateViewModel vm)
        {
            _vm = vm;
            lblProcedureCategory.Text = vm.Category;
            lblProcedureName.Text = vm.Subject;
            lblProcedureId.Text = vm.Id;
            lblProcedureDUT.Text = vm.DUTName;
            lblProcedureDevice.Text = vm.DevicesName;
            lblStep.Text="Step "+ vm.TableProcedures.Count;
            lblProcedureDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
            int stepNumber = vm.CurrentStep;
            var varis = vm.Variables;
            var font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            flowStepContent.Controls.Clear();
            if (stepNumber > 1 && vm.TableProcedures != null && vm.TableProcedures.Count > 1)
            {
                var height = 0;
                for (int i = 0; i < stepNumber - 1; i++)
                {
                    var step = vm.TableProcedures[i];
                    var lblTitleStep = new Label();
                    lblTitleStep.Text = "Step " + step.NumberOder + ": " + step.Title;
                    lblTitleStep.Font = font;
                    lblTitleStep.Margin = new Padding(16, 10, 0, 0);
                    lblTitleStep.AutoSize = false;
                    lblTitleStep.Size = new Size(flowStepContent.Width - 100, 22);
                    flowStepContent.Controls.Add(lblTitleStep);
                    height += lblTitleStep.Height + 10;
                    var vselect = new List<ProcedureVariableViewModel>();
                    if (step.Variables != null && step.Variables.Count > 0)
                    {
                        var lstVaris = step.Variables.Where(t => t.Report).ToList();

                        if (lstVaris.Count > 0)
                        {
                            foreach (var item in lstVaris)
                            {
                                var newItem = varis.Where(t => t.Name == item.Name).FirstOrDefault();
                                newItem.Value = item.Value;
                                newItem.Report = item.Report;
                                newItem.Title = item.Title;
                                newItem.TypeInput = item.TypeInput;
                                newItem.Required = item.Required;
                                vselect.Add(newItem);
                            }
                        }
                    }

                    TableReview tbl = new TableReview();
                    tbl.LoadData(vselect);
                    tbl.Margin = new Padding(16, 10, 0, 0);
                    tbl.ResizeC();
                    flowStepContent.Controls.Add(tbl);
                    height += tbl.Height + 10;
                }
                flowStepContent.Height = height+5;
            }
            ResizePanel();
        }
        private void ResizePanel()
        {
            if (flowStepContent.Height > 231)
            {
                foreach(Control item in panelReview.Controls)
                {
                    if (!(item is TableReview)) item.Width -= 18;
                }
            }
        }

        public void SaveData(out string mess)
        {
            mess = "";
            int stepNumber = _vm.CurrentStep;
            if (stepNumber > 1 && _vm.TableProcedures != null && _vm.TableProcedures.Count > 1)
            {
                int i = 0;
                foreach (Control control in flowStepContent.Controls)
                {
                    if (control is TableReview tblStep)
                    {
                        var lstc = tblStep.GetVariables();
                        if (lstc != null && lstc.Count > 0)
                        {
                            var step = _vm.TableProcedures[i];
                            foreach(var item in step.Variables)
                            {
                                if(lstc.Count(t=>t.Name==item.Name) > 0)
                                {
                                    var item2 = lstc.Where(t => t.Name == item.Name).FirstOrDefault();
                                    item.Report = item2.Report;
                                }
                            }                            
                        }
                        i++;
                    }
                }
            }
        }

        //public bool CheckSave(out string mess)
        //{
        //  return false;
        //}
        public List<ProcedureVariableViewModel> _result;


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
        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
