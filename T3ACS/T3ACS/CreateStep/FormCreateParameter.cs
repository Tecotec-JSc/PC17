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
using T3ACS.Model;

namespace T3ACS.CreateStep
{
    public partial class FormCreateParameter : Form
    {
        public FormCreateParameter()
        {
            InitializeComponent();
        }
        public List<ProcedureVariableViewModel> _variable;
        public List<string> _listv;
        public List<string> _listvSelect;
        public void LoadData(List<ProcedureVariableViewModel> varis, List<ProcedureDetaiVariableViewModel> varisInStep)
        {
            if (varis == null) varis = new List<ProcedureVariableViewModel>();
            _variable = varis.ToList();

            List<ProcedureVariableViewModel> vselect = new List<ProcedureVariableViewModel>();
            if (varisInStep != null && varisInStep.Count > 0)
            {
                foreach (var item in varisInStep)
                {
                    var newItem= _variable.Where(t => t.Name == item.Name).FirstOrDefault();
                    newItem.Value = item.Value;
                    newItem.Report= item.Report;
                    newItem.Title= item.Title;
                    newItem.Required = item.Required;
                    newItem.TypeInput= item.TypeInput;
                    vselect.Add(newItem);
                }
            }
            if (_variable.Count > 0)
            {
                _listv = _variable.Select(t => t.Name).ToList();
                if (vselect.Count > 0)
                    _listvSelect = vselect.Select(t => t.Name).ToList();
                else _listvSelect = new List<string>();
            }
            else
            {
                _listv = new List<string>();
                _listvSelect = new List<string>();
            }
            selectParameter1._datas = _listv;
            selectParameter1._SelectedValues = _listvSelect;
            tableVariableControl1.LoadData(vselect);
            tableVariableControl1.ResizeC();
        }



        private void tabledut1__EventChange(object sender, EventArgs e)
        {
            var count = tableVariableControl1.CountRowSelected();
            btnIconDelete.Texts = "Delete (" + count + ")";
        }
        public bool CheckSave(out string mess)
        {
            if (tableVariableControl1.CheckSave(out mess))
            {

                var result = tableVariableControl1.GetVariables();
                foreach (var v in result)
                {
                    if (_variable.Count(t => t.Name == v.Name) > 0)
                    {
                        var oldv = _variable.Where(t => t.Name == v.Name).FirstOrDefault();
                        if (oldv.Type != v.Type)
                        {
                            mess = "Parameter " + v.Name + " cannot be changed to this type.It must be of type " + oldv.Type + ".";
                            return false;
                        }
                    }
                }
                return true;
            }
            else return false;
        }
        public List<ProcedureVariableViewModel> _result;
        public bool SaveValue()
        {
            _result = tableVariableControl1.GetVariables();
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

        private void tableVariableControl1__ShowError(object sender, EventArgs e)
        {
            ShowMess("Notification", tableVariableControl1._StrError, 2);
        }

        private void tableVariableControl1__ChangeNumberRow(object sender, EventArgs e)
        {
            var count = tableVariableControl1.CountRowSelected();
            btnIconDelete.Texts = "Delete (" + count + ")";
         
        }

        private void selectParameter1__eventAddnew(object sender, EventArgs e)
        {
            tableVariableControl1.AddNewRow(false, 0, "", "","", "", "", "", "", "Double", "Input", true, true, true);
            tableVariableControl1.ResizeC();
        }

        private void selectParameter1__eventDeselect(object sender, EventArgs e)
        {
            if (sender is string strv)
            {
                var selectitem = _variable.Where(t => t.Name == strv).FirstOrDefault();

                tableVariableControl1.DeleteRowWithName(strv);
              
                ChangeData();
                tableVariableControl1.ResizeC();
            }
        }
        private void ChangeData()
        {
            var rows = tableVariableControl1.GetVariables();
            _listvSelect = new List<string>();
            if (rows != null && rows.Count > 0)
            {
                foreach (var row in rows)
                {
                    _listvSelect.Add(row.Name);
                }
            }
            selectParameter1._SelectedValues = _listvSelect;
        }

        private void selectParameter1__EventSelect(object sender, EventArgs e)
        {
            if (sender is string strv)
            {
                var selectitem = _variable.Where(t => t.Name == strv).FirstOrDefault();
                if (selectitem != null)
                {
                    tableVariableControl1.AddNewRow(false, selectitem.ProcedureVariableId, selectitem.Name, selectitem.Title, selectitem.Value,selectitem.Items, selectitem.Unit, selectitem.Min, selectitem.Max, selectitem.Type, selectitem.TypeInput, selectitem.Required, selectitem.Report, false);
                    tableVariableControl1.ResizeC();
                }


              
            }
        }

    }
}
