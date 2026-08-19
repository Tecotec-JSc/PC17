using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using T3ACS.Controls;
using T3ACS.Controls.Buttons;
using T3ACS.Controls.Card;
using T3ACS.Controls.Table;
using T3ACS.Model;
using T3ACS.ViewModel;

namespace T3ACS.StepDefault
{
    public partial class FormEvaluateReview : Form
    {
        private Point stickyControlOriginalLocation;
        public List<AssembyViewModel> _Assemblys;
        public event EventHandler _StopProcedure;
        public FormEvaluateReview()
        {
            InitializeComponent();
            LoadButtonBot();        
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
            lblStep.Text = "Step " + vm.TableProcedures.Count;
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
                    lblTitleStep.Size = new Size(flowStepContent.Width - 169, 22);
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
                    ButtonCustom btn = new ButtonCustom();
                    btn.Name = "btnStep" + step.NumberOder;
                    btn._EventSelect += Btn__EventSelect;
                    if (step.MaskDoneValue == true)
                    {
                        btn.Texts = "Pass";
                        btn.TextLocation = new Point(38, 6);
                        btn.iConLocation = new Point(14, 8);
                        btn.ImageAd = Properties.Resources.iconPass;
                        btn.BackColorG = Color.FromArgb(15, 123, 15);
                        btn.BorderColorG = Color.FromArgb(15, 123, 15);
                        btn.ForeColorG = Color.White;
                        btn.Size = new Size(93, 36);
                    }
                    else
                    {
                        btn.Texts = "Failed";
                        btn.TextLocation = new Point(38, 6);
                        btn.iConLocation = new Point(14, 8);
                        btn.ImageAd = Properties.Resources.iconFailt;
                        btn.BackColorG = Color.FromArgb(196, 43, 28);
                        btn.BorderColorG = Color.FromArgb(196, 43, 28); 
                        btn.ForeColorG = Color.White;
                        btn.Size = new Size(93, 36);
                    }
                    flowStepContent.Controls.Add(btn);
                    TableReviewRun tbl = new TableReviewRun();
                    tbl.LoadData(vselect);
                    tbl.Margin = new Padding(16, 10, 0, 0);
                    tbl.ResizeC();
                    flowStepContent.Controls.Add(tbl);
                    height += tbl.Height + 10;
                }
                flowStepContent.Height = height + 5;
            }
            ResizePanel();
        }

        private void Btn__EventSelect(object? sender, EventArgs e)
        {
            if(sender is ButtonCustom btn)
            {
                var name =btn.Name;
               if(int.TryParse(name.Replace("btnStep",""),out int numberstep)){
                    var step = _vm.TableProcedures[numberstep-1];
                    if(!step.MaskDone) step.MaskDone = true;
                    if (step.MaskDoneValue == true)
                    {
                        step.MaskDoneValue = false;
                        btn.Texts = "Failed";                      
                        btn.ImageAd = Properties.Resources.iconFailt;
                        btn.BackColorG = Color.FromArgb(196, 43, 28);
                        btn.BorderColorG = Color.FromArgb(196, 43, 28);
                    }
                    else 
                    { 
                        step.MaskDoneValue = true;
                        btn.Texts = "Pass";                     
                        btn.ImageAd = Properties.Resources.iconPass;
                        btn.BackColorG = Color.FromArgb(15, 123, 15);
                        btn.BorderColorG = Color.FromArgb(15, 123, 15);
                    }
                }
            }
        }
       
        private void ResizePanel()
        {
            if (flowStepContent.Height > 231)
            {
                foreach (Control item in panelReview.Controls)
                {
                    if (!(item is TableReviewRun)) item.Width -= 18;
                }
            }
        }

        private void panelForm_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            panelStickBottom.Location = new Point(stickyControlOriginalLocation.X, stickyControlOriginalLocation.Y + this.AutoScrollPosition.Y);
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

        }

        private void btnQuit_btnClick(object sender, EventArgs e)
        {
            _StopProcedure?.Invoke(null, EventArgs.Empty);
        }

        private void tableDefaultrun1_Click(object sender, EventArgs e)
        {

        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            _StopProcedure?.Invoke(null, EventArgs.Empty);
        }

        private void btnFailed_Click_1(object sender, EventArgs e)
        {
            _Maskdone = false;
            MaskDone();
        }
    }
}
