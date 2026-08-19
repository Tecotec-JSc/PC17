using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS.Controls
{
    public partial class RowMetaData : UserControl
    {
        public RowMetaData()
        {
            InitializeComponent();
        }
        public event EventHandler _UpdateHeight;
        public bool Editor;
        public bool _Checked;
        public void LoadData(bool checkv, string title, string description, bool edit)
        {
            _Checked = checkv;
            if (checkv) lblCheckItem.Image = Properties.Resources.Checked;
            else lblCheckItem.Image = Properties.Resources.NotChecked;
            lblDefaultTitle.Text = title;
            lblDefaultValue.Text = description;
            txtTitle.Text = title;
            txtValue.Text = description;
            Editor = edit;
            if (edit)
            {
                txtTitle.Visible = true;
                txtValue.Visible = true;
                lblDefaultTitle.Visible = false;
                lblDefaultValue.Visible = false;
                lblbtnEdit.Visible = false;
                lblbtnSave.Visible = true;
            }
            else
            {
                txtValue.Visible = false;
                txtTitle.Visible = false;
                lblDefaultTitle.Visible = true;
                lblDefaultValue.Visible = true;
                lblbtnEdit.Visible = true;
                lblbtnSave.Visible = false;
            }
        }

        private void lblbtnSave_Click(object sender, EventArgs e)
        {
            lblDefaultTitle.Text = txtTitle.Text;
            lblDefaultValue.Text = txtValue.Text;
            Editor = false;
            txtValue.Visible = false;
            txtTitle.Visible = false;
            lblDefaultTitle.Visible = true;
            lblDefaultValue.Visible = true;
            lblbtnEdit.Visible = true;
            lblbtnSave.Visible = false;
        }


        private void lblbtnEdit_Click(object sender, EventArgs e)
        {
            Editor = true;
            txtTitle.Visible = true;
            txtValue.Visible = true;
            lblDefaultTitle.Visible = false;
            lblDefaultValue.Visible = false;
            lblbtnEdit.Visible = false;
            lblbtnSave.Visible = true;
        }

        private void lblCheckItem_Click(object sender, EventArgs e)
        {
            if (_Checked) _Checked = false;
            else _Checked = true;
            ResetImageCheck();
        }
        public void ResetImageCheck()
        {
            if (_Checked)
            {
                lblCheckItem.Image = Properties.Resources.Checked;

            }
            else lblCheckItem.Image = Properties.Resources.NotChecked;
        }
        public List<string> GetData()
        {
            List<string> result = new List<string>();
            var title = lblDefaultTitle.Text;
            var value = lblDefaultValue.Text;
            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(value))
            {
                result.Add(title);
                result.Add(value);
            }
            return result;
        }
        private void UpdateControlHeight()
        {
            lblDefaultTitle.Width = 370;
            Size textSize = TextRenderer.MeasureText(
    lblDefaultTitle.Text,
            lblDefaultTitle.Font,
    new Size(lblDefaultTitle.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );

            lblDefaultTitle.Height = textSize.Height;
            var maxheight1 = 29 + lblDefaultTitle.Height;
            lblDefaultValue.Width = 370;
            Size textSize2 = TextRenderer.MeasureText(
    lblDefaultValue.Text,
            lblDefaultValue.Font,
    new Size(lblDefaultValue.Width, int.MaxValue),
            TextFormatFlags.WordBreak
            );

            lblDefaultValue.Height = textSize2.Height;
            var maxheight2 = 29 + lblDefaultValue.Height;
            var Height = Math.Max(maxheight2, maxheight1);
            if (Height < 51) Height = 51;
            this.Height = Height;
        }
        private void lblDefaultTitle_TextChanged(object sender, EventArgs e)
        {
            UpdateControlHeight();
            if (_UpdateHeight != null)
                _UpdateHeight.Invoke(sender, e);
        }               

        private void lblDefaultValue_TextChanged(object sender, EventArgs e)
        {
            UpdateControlHeight();
            if (_UpdateHeight != null)
                _UpdateHeight.Invoke(sender, e);
        }
    }
}
