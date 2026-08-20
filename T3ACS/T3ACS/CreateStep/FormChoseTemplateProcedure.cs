using T3.Configuration;
using T3ACS.Controls;
using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS
{

    public partial class FormChoseTemplateProcedure : Form
    {
        IMain _imain;
        public FormChoseTemplateProcedure(IMain iman)
        {
            InitializeComponent();
            _imain = iman;
            GetTemplates();
            SearchTemplate("");

        }
        private void changeFontColor(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is Label)
                {

                }


            }
        }
        private void GetTemplates()
        {
            IProcedureModel model = new ProcedureModel();
            _lstData = model.GetTemplates();
        }
        private void SearchTemplate(string strSearch)
        {
            lstShow = new List<TemplateProcedureViewModel>();
            if (!string.IsNullOrEmpty(strSearch))
            {
                if (_lstData.Count(t => t.Name.Contains(strSearch) || t.Description.Contains(strSearch)) > 0)
                    lstShow = _lstData.Where(t => t.Name.Contains(strSearch) || t.Description.Contains(strSearch)).ToList();

            }
            else lstShow = _lstData;
            panelTemp.Controls.Clear();
            int starty = 0;
            CardSelect card0 = new CardSelect();
            card0.Name = "card0";
            card0.SetValue("Blank Template", "Start with an empty procedure");
            card0.TitleColor = Color.FromArgb(0, 32, 77);
            card0.ContentColor = Color.FromArgb(0, 32, 77);
            card0.Size = new Size(1516, 82);
            card0.Location = new Point(23, starty);
            card0._EventSelect += ClickCard;
            panelTemp.Controls.Add(card0);
            starty += 90;
            if (lstShow.Count > 0)
            {
                foreach (var item in lstShow)
                {
                    CardSelect card = new CardSelect();
                    card.TitleColor = Color.FromArgb(0, 32, 77);
                    card.ContentColor = Color.FromArgb(0, 32, 77);
                    card.Name = "card" + item.ProcedureId;
                    card.SetValue(item.Name, item.ShortDescription);
                    card.Size = new Size(1516, 82);
                    card.Location = new Point(23, starty);
                    card._EventSelect += ClickCard;
                    panelTemp.Controls.Add(card);
                    starty += 90;
                }
            }
            RegisterClick(this);
        }
        private void ClickCard(object sender, EventArgs e)
        {
            var cardClick = sender as CardSelect;
            if (cardClick != null)
                foreach (var item in panelTemp.Controls)
                {
                    if (item is CardSelect card)
                    {
                        if (card.SelectedV && card.Name != cardClick.Name)
                        {
                            card.DeSelected();
                        }
                    }

                }
            var newId = int.Parse(cardClick.Name.Replace("card", ""));
            if (procedureId != newId)
            {
                procedureId = newId;
                if (procedureId == 0)
                {
                    lblDetails.Text = "Blank Template";
                    lblDescripDetail.Text = "Start with an empty procedure";
                    lblTextCategory.Text = "";
                    lblTextStep.Text = "0 steps";
                    lblTextDuration.Text = "0.0 min";
                }
                else
                {
                    try
                    {
                        var item = _lstData.Where(t => t.ProcedureId == procedureId).FirstOrDefault();
                        lblDetails.Text = item.Name;
                        lblDescripDetail.Text = item.Description;
                        lblTextCategory.Text = item.Category;
                        lblTextStep.Text = item.CountSteps + " steps";
                        lblTextDuration.Text = "0.0 min";
                    }
                    catch
                    {

                    }


                }
            }
        }

        List<TemplateProcedureViewModel> lstShow;
        List<TemplateProcedureViewModel> _lstData;

        string controlnow = "";
        int procedureId = -1;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnChooseTemplate_Click(object sender, EventArgs e)
        {
            if (procedureId == -1)
            {
                ShowNoti("Notification", "Please choose a template.", 2);
            }
            else
            {
                IProcedureModel model = new ProcedureModel();
                FormConfigureNewProcedure frm = new FormConfigureNewProcedure();
                var item = _lstData.Where(t => t.ProcedureId == procedureId).FirstOrDefault();
                TemplateViewModel _vm = new TemplateViewModel();
                if (item == null)
                {
                    item = new TemplateProcedureViewModel()
                    {
                        Name = "Blank Template",
                        Description = "Start with an empty procedure",
                        ShortDescription = "Start with an empty procedure",
                    };
                    frm.SetData(item);
                }
                else
                {


                    _vm = model.GetProcedureById(procedureId);
                    frm.SetData(item);
                    frm.LoadData(0, "Create procedure", _vm.Subject, _vm.Id, _vm.Category, _vm.Duration, _vm.DUTName, _vm.Description, _vm.MetaData, _vm.LinkModem, _vm.LinkACU, _vm.Variables);
                }
                FormBlur blur = new FormBlur();
                blur.Size = new Size(1920, 1030);
                blur.Location = this.Location;
                blur.StartPosition = FormStartPosition.Manual;
                blur.Owner = this;
                blur.Show();
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    if (procedureId > 0)
                    {
                        var newv = model.GetProcedureById(frm._NewId);
                        _vm.ProcedureId = frm._NewId;
                        _vm.Subject = newv.Subject;
                        _vm.Id = newv.Id;
                        _vm.Version = newv.Version;
                        _vm.Category = newv.Category;
                        _vm.Duration = newv.Duration;
                        _vm.DUTName = newv.DUTName;
                        _vm.Description = newv.Description;
                        _vm.MetaData = newv.MetaData;
                        model.UpdateProcedure(_vm, out string mess);
                    }

                    _imain.EditProcedureId(frm._NewId);

                }
                frm.Dispose();
                // Cleanup
                blur.Close();
                blur.Dispose();

            }
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
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            _imain.ClearFormMain();
        }

        private void txtSearchTemplate_EventSearch(object sender, EventArgs e)
        {
            SearchTemplate(txtSearchTemplate.Text);
        }
        private void RegisterClick(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (!(c is Button))
                {
                    c.MouseDown += Control_MouseDown;

                    if (c.HasChildren)
                        RegisterClick(c);
                }


            }
        }
        void Control_MouseDown(object sender, MouseEventArgs e)
        {
            if (!(sender is TextBox))
            {
                this.ActiveControl = null; // BỎ FOCUS TEXTBOX
            }
        }
    }
}
