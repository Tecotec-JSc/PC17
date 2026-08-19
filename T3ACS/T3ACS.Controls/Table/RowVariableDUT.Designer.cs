using T3ACS.Controls.PanelCustoms;

namespace T3ACS.Controls
{
    partial class RowVariableDUT
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RowVariableDUT));
            panelBorderControl1 = new PanelCustomBorder();
            lblCheckItem = new Label();
            txtTbVName = new RJTextBox();
            txtTbVTitle = new RJTextBox();
            txtTbVUnit = new RJTextBox();
            txtTbVMin = new RJTextBox();
            txtTbVMax = new RJTextBox();
            lblbtnSave = new Label();
            lblbtnEdit = new Label();
            txtTbVValue = new RJTextBox();
            lblDefaultName = new Label();
            lblDefaultTitle = new Label();
            lblDefaultValue = new Label();
            lblDefaultUnit = new Label();
            lblDefaultMin = new Label();
            lblDefaultMax = new Label();
            lblType = new Label();
            lblTypeInput = new Label();
            lblDefaultRequired = new Label();
            lblDefaultReport = new Label();
            cboType = new SelectControl();
            cboTypeInput = new SelectControl();
            lblChkRequired = new Label();
            lblChkReport = new Label();
            lblDelete = new Label();
            SuspendLayout();
            // 
            // panelBorderControl1
            // 
            panelBorderControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBorderControl1.BackColor = SystemColors.Window;
            panelBorderControl1.BorderColor = Color.DarkGray;     
            panelBorderControl1.BorderSize = 1;
            panelBorderControl1.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl1.Location = new Point(0, -1);
            panelBorderControl1.Margin = new Padding(0);
            panelBorderControl1.Name = "panelBorderControl1";
            panelBorderControl1.Padding = new Padding(2);
            panelBorderControl1.Size = new Size(1026, 52);
            panelBorderControl1.TabIndex = 0;
            // 
            // lblCheckItem
            // 
            lblCheckItem.BackColor = Color.White;
            lblCheckItem.Cursor = Cursors.Hand;
            lblCheckItem.Image = Properties.Resources.NotChecked;
            lblCheckItem.Location = new Point(7, 5);
            lblCheckItem.Name = "lblCheckItem";
            lblCheckItem.Size = new Size(36, 40);
            lblCheckItem.TabIndex = 25;
            lblCheckItem.Click += lblCheckItem_Click_1;
            // 
            // txtTbVName
            // 
            txtTbVName.BackColor = Color.White;
            txtTbVName.BorderColor = Color.DarkGray;
            txtTbVName.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtTbVName.BorderRadius = 5;
            txtTbVName.BorderSize = 1;
            txtTbVName.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTbVName.Location = new Point(47, 5);
            txtTbVName.Margin = new Padding(4);
            txtTbVName.Multiline = false;
            txtTbVName.Name = "txtTbVName";
            txtTbVName.Padding = new Padding(10, 7, 10, 7);
            txtTbVName.PasswordChar = false;
            txtTbVName.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtTbVName.PlaceholderText = "";
            txtTbVName.ReadOnly = false;
            txtTbVName.Size = new Size(80, 40);
            txtTbVName.TabIndex = 26;
            txtTbVName.UnderlinedStyle = false;
            // 
            // txtTbVTitle
            // 
            txtTbVTitle.BackColor = Color.White;
            txtTbVTitle.BorderColor = Color.DarkGray;
            txtTbVTitle.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtTbVTitle.BorderRadius = 5;
            txtTbVTitle.BorderSize = 1;
            txtTbVTitle.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTbVTitle.Location = new Point(135, 5);
            txtTbVTitle.Margin = new Padding(4);
            txtTbVTitle.Multiline = false;
            txtTbVTitle.Name = "txtTbVTitle";
            txtTbVTitle.Padding = new Padding(10, 7, 10, 7);
            txtTbVTitle.PasswordChar = false;
            txtTbVTitle.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtTbVTitle.PlaceholderText = "";
            txtTbVTitle.ReadOnly = false;
            txtTbVTitle.Size = new Size(96, 40);
            txtTbVTitle.TabIndex = 26;
            txtTbVTitle.UnderlinedStyle = false;
            // 
            // txtTbVUnit
            // 
            txtTbVUnit.BackColor = Color.White;
            txtTbVUnit.BorderColor = Color.DarkGray;
            txtTbVUnit.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtTbVUnit.BorderRadius = 5;
            txtTbVUnit.BorderSize = 1;
            txtTbVUnit.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTbVUnit.Location = new Point(327, 5);
            txtTbVUnit.Margin = new Padding(4);
            txtTbVUnit.Multiline = false;
            txtTbVUnit.Name = "txtTbVUnit";
            txtTbVUnit.Padding = new Padding(10, 7, 10, 7);
            txtTbVUnit.PasswordChar = false;
            txtTbVUnit.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtTbVUnit.PlaceholderText = "";
            txtTbVUnit.ReadOnly = false;
            txtTbVUnit.Size = new Size(70, 40);
            txtTbVUnit.TabIndex = 26;
            txtTbVUnit.UnderlinedStyle = false;
            // 
            // txtTbVMin
            // 
            txtTbVMin.BackColor = Color.White;
            txtTbVMin.BorderColor = Color.DarkGray;
            txtTbVMin.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtTbVMin.BorderRadius = 5;
            txtTbVMin.BorderSize = 1;
            txtTbVMin.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTbVMin.Location = new Point(405, 5);
            txtTbVMin.Margin = new Padding(4);
            txtTbVMin.Multiline = false;
            txtTbVMin.Name = "txtTbVMin";
            txtTbVMin.Padding = new Padding(10, 7, 10, 7);
            txtTbVMin.PasswordChar = false;
            txtTbVMin.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtTbVMin.PlaceholderText = "";
            txtTbVMin.ReadOnly = false;
            txtTbVMin.Size = new Size(60, 40);
            txtTbVMin.TabIndex = 26;
            txtTbVMin.UnderlinedStyle = false;
            // 
            // txtTbVMax
            // 
            txtTbVMax.BackColor = Color.White;
            txtTbVMax.BorderColor = Color.DarkGray;
            txtTbVMax.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtTbVMax.BorderRadius = 5;
            txtTbVMax.BorderSize = 1;
            txtTbVMax.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTbVMax.Location = new Point(473, 5);
            txtTbVMax.Margin = new Padding(4);
            txtTbVMax.Multiline = false;
            txtTbVMax.Name = "txtTbVMax";
            txtTbVMax.Padding = new Padding(10, 7, 10, 7);
            txtTbVMax.PasswordChar = false;
            txtTbVMax.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtTbVMax.PlaceholderText = "";
            txtTbVMax.ReadOnly = false;
            txtTbVMax.Size = new Size(60, 40);
            txtTbVMax.TabIndex = 26;
            txtTbVMax.UnderlinedStyle = false;
            // 
            // lblbtnSave
            // 
            lblbtnSave.BackColor = Color.White;
            lblbtnSave.Cursor = Cursors.Hand;
            lblbtnSave.Image = (Image)resources.GetObject("lblbtnSave.Image");
            lblbtnSave.Location = new Point(962, 5);
            lblbtnSave.Name = "lblbtnSave";
            lblbtnSave.Size = new Size(42, 42);
            lblbtnSave.TabIndex = 28;
            lblbtnSave.Click += lblbtnSave_Click;
            // 
            // lblbtnEdit
            // 
            lblbtnEdit.BackColor = Color.White;
            lblbtnEdit.Cursor = Cursors.Hand;
            lblbtnEdit.Image = (Image)resources.GetObject("lblbtnEdit.Image");
            lblbtnEdit.Location = new Point(961, 8);
            lblbtnEdit.Name = "lblbtnEdit";
            lblbtnEdit.Size = new Size(27, 28);
            lblbtnEdit.TabIndex = 29;
            lblbtnEdit.Click += lblbtnEdit_Click;
            // 
            // txtTbVValue
            // 
            txtTbVValue.BackColor = Color.White;
            txtTbVValue.BorderColor = Color.DarkGray;
            txtTbVValue.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtTbVValue.BorderRadius = 5;
            txtTbVValue.BorderSize = 1;
            txtTbVValue.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTbVValue.Location = new Point(239, 5);
            txtTbVValue.Margin = new Padding(4);
            txtTbVValue.Multiline = false;
            txtTbVValue.Name = "txtTbVValue";
            txtTbVValue.Padding = new Padding(10, 7, 10, 7);
            txtTbVValue.PasswordChar = false;
            txtTbVValue.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtTbVValue.PlaceholderText = "";
            txtTbVValue.ReadOnly = false;
            txtTbVValue.Size = new Size(80, 40);
            txtTbVValue.TabIndex = 26;
            txtTbVValue.UnderlinedStyle = false;
            // 
            // lblDefaultName
            // 
            lblDefaultName.Font = new Font("Segoe UI", 10.5F);
            lblDefaultName.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultName.Location = new Point(47, 14);
            lblDefaultName.Name = "lblDefaultName";
            lblDefaultName.Size = new Size(80, 22);
            lblDefaultName.TabIndex = 30;
            lblDefaultName.Text = "Title";
            // 
            // lblDefaultTitle
            // 
            lblDefaultTitle.Font = new Font("Segoe UI", 10.5F);
            lblDefaultTitle.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultTitle.Location = new Point(135, 14);
            lblDefaultTitle.Name = "lblDefaultTitle";
            lblDefaultTitle.Size = new Size(96, 22);
            lblDefaultTitle.TabIndex = 30;
            lblDefaultTitle.Text = "Title";
            // 
            // lblDefaultValue
            // 
            lblDefaultValue.Font = new Font("Segoe UI", 10.5F);
            lblDefaultValue.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultValue.Location = new Point(239, 14);
            lblDefaultValue.Name = "lblDefaultValue";
            lblDefaultValue.Size = new Size(80, 22);
            lblDefaultValue.TabIndex = 30;
            lblDefaultValue.Text = "Title";
            // 
            // lblDefaultUnit
            // 
            lblDefaultUnit.Font = new Font("Segoe UI", 10.5F);
            lblDefaultUnit.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultUnit.Location = new Point(327, 14);
            lblDefaultUnit.Name = "lblDefaultUnit";
            lblDefaultUnit.Size = new Size(70, 22);
            lblDefaultUnit.TabIndex = 30;
            lblDefaultUnit.Text = "Title";
            // 
            // lblDefaultMin
            // 
            lblDefaultMin.Font = new Font("Segoe UI", 10.5F);
            lblDefaultMin.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultMin.Location = new Point(405, 14);
            lblDefaultMin.Name = "lblDefaultMin";
            lblDefaultMin.Size = new Size(60, 22);
            lblDefaultMin.TabIndex = 30;
            lblDefaultMin.Text = "Title";
            // 
            // lblDefaultMax
            // 
            lblDefaultMax.Font = new Font("Segoe UI", 10.5F);
            lblDefaultMax.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultMax.Location = new Point(473, 14);
            lblDefaultMax.Name = "lblDefaultMax";
            lblDefaultMax.Size = new Size(60, 22);
            lblDefaultMax.TabIndex = 30;
            lblDefaultMax.Text = "Title";
            // 
            // lblType
            // 
            lblType.Font = new Font("Segoe UI", 10.5F);
            lblType.ForeColor = Color.FromArgb(102, 121, 148);
            lblType.Location = new Point(541, 14);
            lblType.Name = "lblType";
            lblType.Size = new Size(80, 22);
            lblType.TabIndex = 30;
            lblType.Text = "Title";
            // 
            // lblTypeInput
            // 
            lblTypeInput.Font = new Font("Segoe UI", 10.5F);
            lblTypeInput.ForeColor = Color.FromArgb(102, 121, 148);
            lblTypeInput.Location = new Point(657, 14);
            lblTypeInput.Name = "lblTypeInput";
            lblTypeInput.Size = new Size(107, 22);
            lblTypeInput.TabIndex = 30;
            lblTypeInput.Text = "Title";
            // 
            // lblDefaultRequired
            // 
            lblDefaultRequired.Font = new Font("Segoe UI", 10.5F);
            lblDefaultRequired.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultRequired.Location = new Point(775, 14);
            lblDefaultRequired.Name = "lblDefaultRequired";
            lblDefaultRequired.Size = new Size(95, 22);
            lblDefaultRequired.TabIndex = 30;
            lblDefaultRequired.Text = "Title";
            // 
            // lblDefaultReport
            // 
            lblDefaultReport.Font = new Font("Segoe UI", 10.5F);
            lblDefaultReport.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultReport.Location = new Point(879, 14);
            lblDefaultReport.Name = "lblDefaultReport";
            lblDefaultReport.Size = new Size(77, 22);
            lblDefaultReport.TabIndex = 30;
            lblDefaultReport.Text = "Title";
            // 
            // cboType
            // 
            cboType.BackColorG = Color.White;
            cboType.BorderColorG = Color.DarkGray;
            cboType.BorderSize = 1;
            cboType.Location = new Point(541, 7);
            cboType.Name = "cboType";
            cboType.RadiusBottomLeft = 5;
            cboType.RadiusBottomRight = 5;
            cboType.RadiusTopLeft = 5;
            cboType.RadiusTopRight = 5;
            cboType.Size = new Size(110, 40);
            cboType.TabIndex = 34;
            cboType.Texts = "Select";
            // 
            // cboTypeInput
            // 
            cboTypeInput.BackColorG = Color.White;
            cboTypeInput.BorderColorG = Color.DarkGray;
            cboTypeInput.BorderSize = 1;
            cboTypeInput.Location = new Point(657, 7);
            cboTypeInput.Name = "cboTypeInput";
            cboTypeInput.RadiusBottomLeft = 5;
            cboTypeInput.RadiusBottomRight = 5;
            cboTypeInput.RadiusTopLeft = 5;
            cboTypeInput.RadiusTopRight = 5;
            cboTypeInput.Size = new Size(112, 40);
            cboTypeInput.TabIndex = 35;
            cboTypeInput.Texts = "Select";
            // 
            // lblChkRequired
            // 
            lblChkRequired.BackColor = Color.White;
            lblChkRequired.Cursor = Cursors.Hand;
            lblChkRequired.Image = Properties.Resources.NotChecked;
            lblChkRequired.Location = new Point(777, 7);
            lblChkRequired.Name = "lblChkRequired";
            lblChkRequired.Size = new Size(36, 40);
            lblChkRequired.TabIndex = 25;
            lblChkRequired.Click += lblChkRequired_Click;
            // 
            // lblChkReport
            // 
            lblChkReport.BackColor = Color.White;
            lblChkReport.Cursor = Cursors.Hand;
            lblChkReport.Image = Properties.Resources.NotChecked;
            lblChkReport.Location = new Point(881, 5);
            lblChkReport.Name = "lblChkReport";
            lblChkReport.Size = new Size(36, 40);
            lblChkReport.TabIndex = 25;
            lblChkReport.Click += lblChkReport_Click;
            // 
            // lblDelete
            // 
            lblDelete.BackColor = Color.White;
            lblDelete.Cursor = Cursors.Hand;
            lblDelete.Image = (Image)resources.GetObject("lblDelete.Image");
            lblDelete.Location = new Point(995, 8);
            lblDelete.Name = "lblDelete";
            lblDelete.Size = new Size(27, 28);
            lblDelete.TabIndex = 29;
            lblDelete.Click += lblDelete_Click;
            // 
            // RowVariableDUT
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(cboTypeInput);
            Controls.Add(cboType);
            Controls.Add(lblDefaultReport);
            Controls.Add(lblDefaultRequired);
            Controls.Add(lblTypeInput);
            Controls.Add(lblType);
            Controls.Add(lblDefaultMax);
            Controls.Add(lblDefaultMin);
            Controls.Add(lblDefaultUnit);
            Controls.Add(lblDefaultValue);
            Controls.Add(lblDefaultTitle);
            Controls.Add(lblDefaultName);
            Controls.Add(lblDelete);
            Controls.Add(lblbtnEdit);
            Controls.Add(lblbtnSave);
            Controls.Add(txtTbVMax);
            Controls.Add(txtTbVMin);
            Controls.Add(txtTbVUnit);
            Controls.Add(txtTbVValue);
            Controls.Add(txtTbVTitle);
            Controls.Add(txtTbVName);
            Controls.Add(lblChkRequired);
            Controls.Add(lblChkReport);
            Controls.Add(lblCheckItem);
            Controls.Add(panelBorderControl1);
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(0);
            Name = "RowVariableDUT";
            Size = new Size(1026, 51);
            Load += RowVariableDUT_Load;
            ResumeLayout(false);
        }

        #endregion

        private PanelCustomBorder panelBorderControl1;
        private Label lblCheckItem;
        private RJTextBox txtTbVName;
        private RJTextBox txtTbVTitle;
        private RJTextBox txtTbVUnit;
        private RJTextBox txtTbVMin;
        private RJTextBox txtTbVMax;
        private RJTextBox txtTbVTypeImport;
        private RJTextBox txtTbVRequired;
        private RJTextBox txtTbVReport;
        private Label lblbtnSave;
        private Label lblbtnEdit;
        private RJTextBox txtTbVValue;
        private Label lblDefaultName;
        private Label lblDefaultTitle;
        private Label lblDefaultValue;
        private Label lblDefaultUnit;
        private Label lblDefaultMin;
        private Label lblDefaultMax;
        private Label lblType;
        private Label lblTypeInput;
        private Label lblDefaultRequired;
        private Label lblDefaultReport;
        private SelectControl cboType;
        private SelectControl cboTypeInput;
        private Label lblChkRequired;
        private Label lblChkReport;
        private Label lblDelete;
    }
}
