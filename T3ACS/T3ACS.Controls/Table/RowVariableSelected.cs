using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SQLite.SQLite3;

namespace T3ACS.Controls.Table
{
    public partial class RowVariableSelected : UserControl
    {
        public RowVariableSelected()
        {
            InitializeComponent();
            panelRowSelected.VerticalPoints.Add(168);
            panelRowSelected.VerticalPoints.Add(314);
            panelRowSelected.VerticalPoints.Add(463);
            panelRowSelected.VerticalPoints.Add(579);
            panelRowSelected.VerticalPoints.Add(697);
            panelRowSelected.VerticalPoints.Add(807);
            panelRowSelected.VerticalPoints.Add(918);
        }
        public void SetBorder(int topleft, int topright, int bottomleft, int bottomright)
        {
            panelRowSelected.RadiusTopLeft = Top;
            panelRowSelected.RadiusTopRight = topright;
            panelRowSelected.RadiusBottomLeft = bottomleft;
            panelRowSelected.RadiusBottomRight = bottomright;
        }
        public int _IdVariable;
        public bool _Edit;
        public string _Type, _Unit, _TypeInput, _StrError;
        public event EventHandler _SaveClick;
        public event EventHandler _UpdateHeight;
        public event EventHandler _RemoveRow;
        public void LoadData(int id, string name, string title, string value, string unit, string min, string max, string type, string typeInput, bool required, bool report, bool edit)
        {
            _IdVariable = id;
            _Type = type;
            lblSizeSName.Text = name;
            txtSizeSTitle.Text = title;
            lblSizeSTitle.Text = title;
            txtSizeSValue.Text = value;
            lblSizeSValue.Text = value;
            lblSizeSMin.Text = min;
            lblSizeSMax.Text = max;
            if (required)
                lblSizeSRequired.Image = Properties.Resources.IconCheckbox;
            else lblSizeSRequired.Image = Properties.Resources.IconCheckboxNo;
            _Edit = edit;
            EditAction(edit);
        }
        private void EditAction(bool edit)
        {
            txtSizeSTitle.Visible = edit;
            txtSizeSValue.Visible = edit;
            lblSizeSTitle.Visible = !edit;
            lblSizeSValue.Visible = !edit;
            btnEdit.Visible = !edit;
            btnSave.Visible = edit;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            var vals = CheckSaveData(out string error);
            {
                _StrError = error;
                if (_SaveClick != null)
                    _SaveClick.Invoke(this, e);
            }
            if (vals)
            {
                SaveData();
                _Edit = false;
                EditAction(false);
                if (_UpdateHeight != null)
                    _UpdateHeight.Invoke(sender, e);
            }
        }
        private void SaveData()
        {
            lblSizeSTitle.Text = txtSizeSTitle.Text;
            lblSizeSValue.Text = txtSizeSValue.Text;
        }
        private bool CheckSaveData(out string strError)
        {
            strError = "";
            var result = true;

            var strTitle = txtSizeSTitle.Text;
            if (string.IsNullOrEmpty(strTitle) || strTitle.Length < 3)
            {
                result = false;
                strError = "The title must be at least 3 characters.";
                return result;
            }
            var strValue = txtSizeSValue.Text;
            var strMin = lblSizeSMin.Text;
            var strMax = lblSizeSMax.Text;
            result = ValidateValue(strTitle, strValue, strMin, strMax, _Type, out strError);
            return result;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (_RemoveRow != null)
                _RemoveRow.Invoke(this, e);
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            _Edit = true;
            EditAction(true);
        }
        public bool ValidateValue(string title, string input, string strmin, string strmax, string type, out string mess1)
        {
            try
            {

                bool check = true;
                double? valuecheck = null;
                double? min = null;
                double? max = null;
                StringBuilder str = new StringBuilder();
                //Integer Double String Boolean
                if (type == "Interger")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
                        try
                        {
                            valuecheck = int.Parse(input);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be a integer");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmin))
                    {
                        try
                        {
                            min = int.Parse(strmin);
                        }
                        catch
                        {
                            str.AppendLine(title + " min  must be a integer");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmax))
                    {
                        try
                        {
                            max = int.Parse(strmax);
                        }
                        catch
                        {
                            str.AppendLine(title + " max must be a integer");
                            check = false;
                        }
                    }
                    if (min != null && max != null)
                    {
                        if (min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
                        }
                    }
                    if (valuecheck != null && min != null && valuecheck < min)
                    {
                        str.AppendLine(title + " value must be no less than Min");
                        check = false;
                    }
                    if (valuecheck != null && max != null && valuecheck > max)
                    {
                        str.AppendLine(title + " value must be no greater than Min");
                        check = false;
                    }

                }
                else if (type == "Double")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
                        try
                        {
                            valuecheck = double.Parse(input, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmin))
                    {
                        try
                        {
                            min = double.Parse(strmin, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " min  must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmax))
                    {
                        try
                        {
                            max = double.Parse(strmax, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " max must be a number");
                            check = false;
                        }
                    }
                    if (min != null && max != null)
                    {
                        if (min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
                        }
                    }
                    if (valuecheck != null && min != null && valuecheck < min)
                    {
                        str.AppendLine(title + " value must be no less than Min");
                        check = false;
                    }
                    if (valuecheck != null && max != null && valuecheck > max)
                    {
                        str.AppendLine(title + " value must be no greater than Max");
                        check = false;
                    }
                }
                else if (type == "Boolean")
                {
                    if (!string.IsNullOrEmpty(input))
                    {
                        bool valuep = false;
                        if (!bool.TryParse(input, out valuep))
                        {
                            str.AppendLine(title + " value must be true or false.");
                        }
                    }
                }
                else if (type == "Float")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
                        try
                        {
                            valuecheck = float.Parse(input, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmin))
                    {
                        try
                        {
                            min = float.Parse(strmin, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " min  must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmax))
                    {
                        try
                        {
                            max = float.Parse(strmax, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " max must be a number");
                            check = false;
                        }
                    }
                    if (min != null && max != null)
                    {
                        if (min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
                        }
                    }
                    if (valuecheck != null && min != null && valuecheck < min)
                    {
                        str.AppendLine(title + " value must be no less than Min");
                        check = false;
                    }
                    if (valuecheck != null && max != null && valuecheck > max)
                    {
                        str.AppendLine(title + " value must be no greater than Max");
                        check = false;
                    }
                }
                else if (type == "Ushort")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
                        try
                        {
                            valuecheck = ushort.Parse(input);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmin))
                    {
                        try
                        {
                            min = ushort.Parse(strmin);
                        }
                        catch
                        {
                            str.AppendLine(title + " min  must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmax))
                    {
                        try
                        {
                            max = ushort.Parse(strmax);
                        }
                        catch
                        {
                            str.AppendLine(title + " max must be a number");
                            check = false;
                        }
                    }
                    if (min != null && max != null)
                    {
                        if (min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
                        }
                    }
                    if (valuecheck != null && min != null && valuecheck < min)
                    {
                        str.AppendLine(title + " value must be no less than Min");
                        check = false;
                    }
                    if (valuecheck != null && max != null && valuecheck > max)
                    {
                        str.AppendLine(title + " value must be no greater than Max");
                        check = false;
                    }
                }
                mess1 = str.ToString();
                return check;
            }
            catch
            {
                mess1 = "Error.";
                return false;
            }
        }
        public ProcedureDetailFunctionVariable GetData()
        {
            ProcedureDetailFunctionVariable result = new ProcedureDetailFunctionVariable();
            result.VariableId = _IdVariable;
            result.VariableName = lblSizeSName.Text;
            result.Title = lblSizeSTitle.Text;
            result.Value = lblSizeSValue.Text;
            return result;
        }

        private void panelRowSelected_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
