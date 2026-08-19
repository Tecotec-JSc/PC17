namespace T3ACS.Controls
{
    partial class RowDefaultVariable
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RowDefaultVariable));
            panelBorderControl1 = new PanelBorderRadiusCustom();
            txtTbVName = new RJTextBox();
            txtTbVTitle = new RJTextBox();
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
            lblChkReport = new Label();
            lblNo = new Label();
            selectValue = new SelectCustomD();
            SuspendLayout();
            // 
            // panelBorderControl1
            // 
            panelBorderControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBorderControl1.BackColor = SystemColors.Window;
            panelBorderControl1.BorderColor = Color.DarkGray;

            panelBorderControl1.BorderSize = 1;
            panelBorderControl1.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl1.Location = new Point(0, 0);
            panelBorderControl1.Margin = new Padding(0);
            panelBorderControl1.Name = "panelBorderControl1";
            panelBorderControl1.Padding = new Padding(2);
            panelBorderControl1.Size = new Size(1056, 51);
            panelBorderControl1.TabIndex = 0;
            // 
            // txtTbVName
            // 
            txtTbVName.BackColor = Color.White;
            txtTbVName.BorderColor = Color.DarkGray;
            txtTbVName.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtTbVName.BorderRadius = 5;
            txtTbVName.BorderSize = 1;
            txtTbVName.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTbVName.Location = new Point(42, 5);
            txtTbVName.Margin = new Padding(4);
            txtTbVName.Multiline = false;
            txtTbVName.Name = "txtTbVName";
            txtTbVName.Padding = new Padding(10, 7, 10, 7);
            txtTbVName.PasswordChar = false;
            txtTbVName.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtTbVName.PlaceholderText = "";
            txtTbVName.ReadOnly = false;
            txtTbVName.Size = new Size(100, 40);
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
            txtTbVTitle.Location = new Point(144, 5);
            txtTbVTitle.Margin = new Padding(4);
            txtTbVTitle.Multiline = false;
            txtTbVTitle.Name = "txtTbVTitle";
            txtTbVTitle.Padding = new Padding(10, 7, 10, 7);
            txtTbVTitle.PasswordChar = false;
            txtTbVTitle.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtTbVTitle.PlaceholderText = "";
            txtTbVTitle.ReadOnly = false;
            txtTbVTitle.Size = new Size(191, 40);
            txtTbVTitle.TabIndex = 26;
            txtTbVTitle.UnderlinedStyle = false;
            // 
            // lblbtnSave
            // 
            lblbtnSave.BackColor = Color.White;
            lblbtnSave.Cursor = Cursors.Hand;
            lblbtnSave.Image = (Image)resources.GetObject("lblbtnSave.Image");
            lblbtnSave.Location = new Point(1004, 8);
            lblbtnSave.Name = "lblbtnSave";
            lblbtnSave.Size = new Size(27, 28);
            lblbtnSave.TabIndex = 28;
            lblbtnSave.Click += lblbtnSave_Click;
            // 
            // lblbtnEdit
            // 
            lblbtnEdit.BackColor = Color.White;
            lblbtnEdit.Cursor = Cursors.Hand;
            lblbtnEdit.Image = (Image)resources.GetObject("lblbtnEdit.Image");
            lblbtnEdit.Location = new Point(1004, 8);
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
            txtTbVValue.Location = new Point(341, 5);
            txtTbVValue.Margin = new Padding(4);
            txtTbVValue.Multiline = false;
            txtTbVValue.Name = "txtTbVValue";
            txtTbVValue.Padding = new Padding(10, 7, 10, 7);
            txtTbVValue.PasswordChar = false;
            txtTbVValue.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtTbVValue.PlaceholderText = "";
            txtTbVValue.ReadOnly = false;
            txtTbVValue.Size = new Size(98, 40);
            txtTbVValue.TabIndex = 26;
            txtTbVValue.UnderlinedStyle = false;
            // 
            // lblDefaultName
            // 
            lblDefaultName.BackColor = Color.Transparent;
            lblDefaultName.Font = new Font("Segoe UI", 10.5F);
            lblDefaultName.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultName.Location = new Point(42, 14);
            lblDefaultName.Name = "lblDefaultName";
            lblDefaultName.Size = new Size(100, 22);
            lblDefaultName.TabIndex = 30;
            lblDefaultName.Text = "Name";
            // 
            // lblDefaultTitle
            // 
            lblDefaultTitle.BackColor = Color.Transparent;
            lblDefaultTitle.Font = new Font("Segoe UI", 10.5F);
            lblDefaultTitle.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultTitle.Location = new Point(144, 14);
            lblDefaultTitle.Name = "lblDefaultTitle";
            lblDefaultTitle.Size = new Size(191, 22);
            lblDefaultTitle.TabIndex = 30;
            lblDefaultTitle.Text = "Title";
            // 
            // lblDefaultValue
            // 
            lblDefaultValue.Font = new Font("Segoe UI", 10.5F);
            lblDefaultValue.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultValue.Location = new Point(341, 14);
            lblDefaultValue.Name = "lblDefaultValue";
            lblDefaultValue.Size = new Size(98, 22);
            lblDefaultValue.TabIndex = 30;
            lblDefaultValue.Text = "Title";
            // 
            // lblDefaultUnit
            // 
            lblDefaultUnit.BackColor = Color.Transparent;
            lblDefaultUnit.Font = new Font("Segoe UI", 10.5F);
            lblDefaultUnit.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultUnit.Location = new Point(445, 14);
            lblDefaultUnit.Name = "lblDefaultUnit";
            lblDefaultUnit.Size = new Size(71, 22);
            lblDefaultUnit.TabIndex = 30;
            lblDefaultUnit.Text = "Unit";
            // 
            // lblDefaultMin
            // 
            lblDefaultMin.BackColor = Color.Transparent;
            lblDefaultMin.Font = new Font("Segoe UI", 10.5F);
            lblDefaultMin.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultMin.Location = new Point(522, 14);
            lblDefaultMin.Name = "lblDefaultMin";
            lblDefaultMin.Size = new Size(45, 22);
            lblDefaultMin.TabIndex = 30;
            lblDefaultMin.Text = "Min";
            // 
            // lblDefaultMax
            // 
            lblDefaultMax.BackColor = Color.Transparent;
            lblDefaultMax.Font = new Font("Segoe UI", 10.5F);
            lblDefaultMax.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultMax.Location = new Point(572, 14);
            lblDefaultMax.Name = "lblDefaultMax";
            lblDefaultMax.Size = new Size(71, 22);
            lblDefaultMax.TabIndex = 30;
            lblDefaultMax.Text = "Max";
            // 
            // lblType
            // 
            lblType.BackColor = Color.Transparent;
            lblType.Font = new Font("Segoe UI", 10.5F);
            lblType.ForeColor = Color.FromArgb(102, 121, 148);
            lblType.Location = new Point(649, 14);
            lblType.Name = "lblType";
            lblType.Size = new Size(106, 22);
            lblType.TabIndex = 30;
            lblType.Text = "Type";
            // 
            // lblTypeInput
            // 
            lblTypeInput.BackColor = Color.Transparent;
            lblTypeInput.Font = new Font("Segoe UI", 10.5F);
            lblTypeInput.ForeColor = Color.FromArgb(102, 121, 148);
            lblTypeInput.Location = new Point(754, 14);
            lblTypeInput.Name = "lblTypeInput";
            lblTypeInput.Size = new Size(100, 22);
            lblTypeInput.TabIndex = 30;
            lblTypeInput.Text = "TypeInput";
            // 
            // lblDefaultRequired
            // 
            lblDefaultRequired.BackColor = Color.Transparent;
            lblDefaultRequired.Font = new Font("Segoe UI", 10.5F);
            lblDefaultRequired.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultRequired.Location = new Point(860, 14);
            lblDefaultRequired.Name = "lblDefaultRequired";
            lblDefaultRequired.Size = new Size(57, 22);
            lblDefaultRequired.TabIndex = 30;
            lblDefaultRequired.Text = "Required";
            // 
            // lblDefaultReport
            // 
            lblDefaultReport.BackColor = Color.Transparent;
            lblDefaultReport.Font = new Font("Segoe UI", 10.5F);
            lblDefaultReport.ForeColor = Color.FromArgb(102, 121, 148);
            lblDefaultReport.Location = new Point(937, 14);
            lblDefaultReport.Name = "lblDefaultReport";
            lblDefaultReport.Size = new Size(55, 22);
            lblDefaultReport.TabIndex = 30;
            lblDefaultReport.Text = "Report";
            // 
            // lblChkReport
            // 
            lblChkReport.BackColor = Color.White;
            lblChkReport.Cursor = Cursors.Hand;
            lblChkReport.Image = Properties.Resources.NotChecked;
            lblChkReport.Location = new Point(937, 5);
            lblChkReport.Name = "lblChkReport";
            lblChkReport.Size = new Size(36, 40);
            lblChkReport.TabIndex = 25;
            lblChkReport.Click += lblChkReport_Click;
            // 
            // lblNo
            // 
            lblNo.BackColor = Color.Transparent;
            lblNo.Font = new Font("Segoe UI", 10.5F);
            lblNo.ForeColor = Color.FromArgb(102, 121, 148);
            lblNo.Location = new Point(4, 14);
            lblNo.Name = "lblNo";
            lblNo.Size = new Size(32, 22);
            lblNo.TabIndex = 30;
            lblNo.Text = "No1";
            // 
            // selectValue
            // 
            selectValue.ArrowColor = Color.FromArgb(0, 32, 77);
            selectValue.BackColor = Color.White;
            selectValue.BorderColor = Color.DarkGray;
            selectValue.BorderSize = 1;
            selectValue.Font = new Font("Segoe UI", 10.5F);
            selectValue.ForeColor = Color.FromArgb(0, 32, 77);
            selectValue.Location = new Point(342, 5);
            selectValue.Margin = new Padding(0);
            selectValue.Name = "selectValue";
            selectValue.RadiusBottomLeft = 5;
            selectValue.RadiusBottomRight = 5;
            selectValue.RadiusTopLeft = 5;
            selectValue.RadiusTopRight = 5;
            selectValue.SelectedIndex = -1;
            selectValue.ShowArrow = true;
            selectValue.Size = new Size(97, 41);
            selectValue.TabIndex = 35;
            selectValue.Texts = "label1";
            // 
            // RowDefaultVariable
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(selectValue);
            Controls.Add(lblDefaultReport);
            Controls.Add(lblDefaultRequired);
            Controls.Add(lblTypeInput);
            Controls.Add(lblType);
            Controls.Add(lblDefaultMax);
            Controls.Add(lblDefaultMin);
            Controls.Add(lblNo);
            Controls.Add(lblDefaultUnit);
            Controls.Add(lblDefaultValue);
            Controls.Add(lblDefaultTitle);
            Controls.Add(lblDefaultName);
            Controls.Add(lblbtnEdit);
            Controls.Add(lblbtnSave);
            Controls.Add(txtTbVValue);
            Controls.Add(txtTbVTitle);
            Controls.Add(txtTbVName);
            Controls.Add(lblChkReport);
            Controls.Add(panelBorderControl1);
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(0);
            Name = "RowDefaultVariable";
            Size = new Size(1056, 51);
            Load += RowDefaultVariable_Load;
            ResumeLayout(false);
        }

        #endregion

        private PanelBorderRadiusCustom panelBorderControl1;
        private RJTextBox txtTbVName;
        private RJTextBox txtTbVTitle;
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
        private Label lblChkReport;
        private Label lblNo;
        private SelectCustomD selectValue;
    }
}
