namespace T3ACS.Controls
{
    partial class TableVariableSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableVariableSelect));
            panelTitleTop = new PanelBorderRadiusCustom();
            lblDefaultAction = new Label();
            lblDefaultReport = new Label();
            lblDefaultRequired = new Label();
            lblDefaultMin = new Label();
            lblDefaultMax = new Label();
            lblDefaultValue = new Label();
            lblDefaultTitle = new Label();
            lblDefaultName = new Label();
            panelContent = new flowPanelBorderRadius();
            panelTitleTop.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitleTop
            // 
            panelTitleTop.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelTitleTop.BackColor = Color.FromArgb(243, 242, 241);
            panelTitleTop.BackColorG = Color.White;
            panelTitleTop.BorderColor = Color.DarkGray;
            panelTitleTop.BorderSize = 1;
            panelTitleTop.Controls.Add(lblDefaultAction);
            panelTitleTop.Controls.Add(lblDefaultReport);
            panelTitleTop.Controls.Add(lblDefaultRequired);
            panelTitleTop.Controls.Add(lblDefaultMin);
            panelTitleTop.Controls.Add(lblDefaultMax);
            panelTitleTop.Controls.Add(lblDefaultValue);
            panelTitleTop.Controls.Add(lblDefaultTitle);
            panelTitleTop.Controls.Add(lblDefaultName);
            panelTitleTop.Location = new Point(1, 0);
            panelTitleTop.Margin = new Padding(0);
            panelTitleTop.Name = "panelTitleTop";
            panelTitleTop.RadiusBottomLeft = 0;
            panelTitleTop.RadiusBottomRight = 0;
            panelTitleTop.RadiusTopLeft = 5;
            panelTitleTop.RadiusTopRight = 5;
            panelTitleTop.Size = new Size(1021, 38);
            panelTitleTop.TabIndex = 0;
            panelTitleTop.VerticalPoints = (List<int>)resources.GetObject("panelTitleTop.VerticalPoints");
            // 
            // lblDefaultAction
            // 
            lblDefaultAction.AutoSize = true;
            lblDefaultAction.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultAction.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultAction.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultAction.Location = new Point(943, 9);
            lblDefaultAction.Name = "lblDefaultAction";
            lblDefaultAction.Size = new Size(52, 19);
            lblDefaultAction.TabIndex = 31;
            lblDefaultAction.Text = "Action";
            // 
            // lblDefaultReport
            // 
            lblDefaultReport.AutoSize = true;
            lblDefaultReport.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultReport.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultReport.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultReport.Location = new Point(831, 9);
            lblDefaultReport.Name = "lblDefaultReport";
            lblDefaultReport.Size = new Size(55, 19);
            lblDefaultReport.TabIndex = 32;
            lblDefaultReport.Text = "Report";
            // 
            // lblDefaultRequired
            // 
            lblDefaultRequired.AutoSize = true;
            lblDefaultRequired.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultRequired.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultRequired.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultRequired.Location = new Point(719, 9);
            lblDefaultRequired.Name = "lblDefaultRequired";
            lblDefaultRequired.Size = new Size(70, 19);
            lblDefaultRequired.TabIndex = 33;
            lblDefaultRequired.Text = "Required";
            // 
            // lblDefaultMin
            // 
            lblDefaultMin.AutoSize = true;
            lblDefaultMin.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultMin.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultMin.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultMin.Location = new Point(499, 9);
            lblDefaultMin.Name = "lblDefaultMin";
            lblDefaultMin.Size = new Size(34, 19);
            lblDefaultMin.TabIndex = 34;
            lblDefaultMin.Text = "Min";
            // 
            // lblDefaultMax
            // 
            lblDefaultMax.AutoSize = true;
            lblDefaultMax.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultMax.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultMax.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultMax.Location = new Point(613, 9);
            lblDefaultMax.Name = "lblDefaultMax";
            lblDefaultMax.Size = new Size(38, 19);
            lblDefaultMax.TabIndex = 35;
            lblDefaultMax.Text = "Max";
            // 
            // lblDefaultValue
            // 
            lblDefaultValue.AutoSize = true;
            lblDefaultValue.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultValue.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultValue.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultValue.Location = new Point(359, 9);
            lblDefaultValue.Name = "lblDefaultValue";
            lblDefaultValue.Size = new Size(45, 19);
            lblDefaultValue.TabIndex = 36;
            lblDefaultValue.Text = "Value";
            // 
            // lblDefaultTitle
            // 
            lblDefaultTitle.AutoSize = true;
            lblDefaultTitle.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultTitle.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultTitle.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultTitle.Location = new Point(216, 9);
            lblDefaultTitle.Name = "lblDefaultTitle";
            lblDefaultTitle.Size = new Size(49, 19);
            lblDefaultTitle.TabIndex = 37;
            lblDefaultTitle.Text = "Name";
            // 
            // lblDefaultName
            // 
            lblDefaultName.AutoSize = true;
            lblDefaultName.BackColor = Color.FromArgb(243, 242, 241);
            lblDefaultName.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultName.ForeColor = Color.FromArgb(0, 32, 77);
            lblDefaultName.Location = new Point(51, 9);
            lblDefaultName.Name = "lblDefaultName";
            lblDefaultName.Size = new Size(23, 19);
            lblDefaultName.TabIndex = 38;
            lblDefaultName.Text = "ID";
            // 
            // panelContent
            // 
            panelContent.BorderColor = Color.DarkGray;
            panelContent.BorderSize = 1;
            panelContent.Location = new Point(1, 37);
            panelContent.Margin = new Padding(0);
            panelContent.Name = "panelContent";
            panelContent.RadiusBottomLeft = 5;
            panelContent.RadiusBottomRight = 5;
            panelContent.RadiusTopLeft = 0;
            panelContent.RadiusTopRight = 0;
            panelContent.Size = new Size(1021, 88);
            panelContent.TabIndex = 1;
            panelContent.VerticalPoints = (List<int>)resources.GetObject("panelContent.VerticalPoints");
            // 
            // TableVariableSelect
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelContent);
            Controls.Add(panelTitleTop);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            Margin = new Padding(0);
            Name = "TableVariableSelect";
            Size = new Size(1022, 126);
            panelTitleTop.ResumeLayout(false);
            panelTitleTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PanelBorderRadiusCustom panelTitleTop;
        private Label lblDefaultAction;
        private Label lblDefaultReport;
        private Label lblDefaultRequired;
        private Label lblDefaultMin;
        private Label lblDefaultMax;
        private Label lblDefaultValue;
        private Label lblDefaultTitle;
        private Label lblDefaultName;
        private flowPanelBorderRadius panelContent;
    }
}
