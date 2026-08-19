using T3ACS.Controls;
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
    public partial class FormCustomContent : Form
    {
        public FormCustomContent()
        {
            InitializeComponent();
            //selectVariable1.SetData(new List<string>() { "variable1", "variable2", "variable3", "variable4", "variable5", "variable6", "variable7", "variable8", "variable9", "variable10", "variable11", "variable12", "variable13", "variable14", "variable15", "variable16", "variable17", "variable18", "variable19", "variable20", "variable21", "variable22", "variable23", "variable24", "variable25", "variable26", "variable27", "variable28", "variable29" }, new List<string>() { "variable1", "variable2", "variable3", "variable4", "variable5", "variable6", "variable7", "variable8", "variable9", "variable10", "variable11", "variable12", "variable13", "variable14", "variable15", "variable16", "variable17", "variable18", "variable19" });
            //tableVariableSelect1.ShowDataSelect();
            _functions = new List<ProcedureDetailFunctionViewModel>();
            _functions.Add(new ProcedureDetailFunctionViewModel()
            {
                Type="LoadView",
                NumberOrder=1
                
            });
            loadTAB();

        }
        FormFunction _functionShow,_functionDrive,_functionPrepare,_functionRun,_functionStop,_functionSave;
        private void loadTAB()
        {
            tabTitleDrive.Visible = false;
            tabTitlePrepare.Visible = false;
            tabTitleRun.Visible = false;
            tabTitleStop.Visible = false;
            tabTitleSave.Visible = false;
            _functionShow = new FormFunction();
            _functionShow.LoadData(_DataSelect);
            _functionShow.TopLevel = false;
            _functionShow.Dock = DockStyle.Fill;
            panelFunctionContent.Controls.Add(_functionShow);
            panelFunctionContent.Height = _functionShow.Height;
            _functionShow.Show();
        }
        TableProcedureViewModel _step;
        private void lblCheck_Click(object sender, EventArgs e)
        {
            _step.Required = !_step.Required;
            loadImageRequired();
        }
        private void loadImageRequired()
        {
            if (_step.Required) lblCheck.Image = Properties.Resources.Radio_Button;
            else lblCheck.Image = Properties.Resources.rdonocheck;
        }
        private void panelBottom_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;

            using (Pen pen = new Pen(Color.DarkGray, 1))
            {
                e.Graphics.DrawLine(
                    pen,
                    0,
                    p.Height - 1,
                    p.Width,
                    p.Height - 1
                );
            }
        }

        private void FormCustomContent_Click(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }

        private void FormCustomContent_Shown(object sender, EventArgs e)
        {
            this.ActiveControl = null;
        }
        PopupAddVariable frm;
        private void button1_Click(object sender, EventArgs e)
        {
            frm = new PopupAddVariable();
            frm.Deactivate += ClosePopUp;
            var p = this.PointToScreen(new Point(302, 105));
            frm.Location = p;
            if (!frm.CanFocus)
                frm.Show();
            else frm.Focus();
            frm.BringToFront();
        }
        private void ClosePopUp(object sender, EventArgs e)
        {
            frm.Close();
        }
        public List<ProcedureVariableViewModel> _Data;
        public List<ProcedureVariableViewModel> _DataSelect;
        public List<string> _Names;
        public List<string> _NamesSelect;
        public List<ProcedureDetailFunctionViewModel> _functions;
        public void LoadData(List<ProcedureVariableViewModel> list)
        {
            _Data = list;
            if (_Data != null)
            {
                _Names = _Data.Select(t => t.Name).ToList();
            }
            selectVariable1.SetData(_Names, _NamesSelect);
        }
    }
}
