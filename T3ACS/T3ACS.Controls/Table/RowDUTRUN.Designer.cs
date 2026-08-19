using System.Drawing;
using System.Windows.Forms;

namespace T3ACS.Controls
{
    partial class RowDUTRUN
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
            txtValue = new RJTextBox();
            lblReport = new Label();
            lblRequired = new Label();
            lblType = new Label();
            lblUnit = new Label();
            lblTitle = new Label();
            lblNo = new Label();
            lblName = new Label();
            lblMin = new Label();
            lblMax = new Label();
            lblTypeImport = new Label();
            SuspendLayout();
            // 
            // txtValue
            // 
            txtValue.BackColor = Color.FromArgb(6, 16, 20);
            txtValue.BorderColor = Color.FromArgb(14, 82, 98);
            txtValue.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtValue.BorderRadius = 5;
            txtValue.BorderSize = 1;
            txtValue.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtValue.Location = new Point(285, 5);
            txtValue.Margin = new Padding(4);
            txtValue.Multiline = false;
            txtValue.Name = "txtValue";
            txtValue.Padding = new Padding(10, 7, 10, 7);
            txtValue.PasswordChar = false;
            txtValue.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtValue.PlaceholderText = "";
            txtValue.ReadOnly = false;
            txtValue.Size = new Size(90, 40);
            txtValue.TabIndex = 0;
            txtValue.UnderlinedStyle = false;
            // 
            // lblReport
            // 
            lblReport.BackColor = Color.Transparent;
            lblReport.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblReport.ForeColor = Color.FromArgb(153, 166, 184);
            lblReport.Location = new Point(910, 15);
            lblReport.Name = "lblReport";
            lblReport.Size = new Size(90, 23);
            lblReport.TabIndex = 10;
            lblReport.Text = "Report";
            lblReport.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRequired
            // 
            lblRequired.BackColor = Color.Transparent;
            lblRequired.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRequired.ForeColor = Color.FromArgb(153, 166, 184);
            lblRequired.Location = new Point(820, 15);
            lblRequired.Name = "lblRequired";
            lblRequired.Size = new Size(90, 23);
            lblRequired.TabIndex = 9;
            lblRequired.Text = "Required";
            lblRequired.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblType
            // 
            lblType.BackColor = Color.Transparent;
            lblType.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblType.ForeColor = Color.FromArgb(153, 166, 184);
            lblType.Location = new Point(620, 15);
            lblType.Name = "lblType";
            lblType.Size = new Size(90, 23);
            lblType.TabIndex = 7;
            lblType.Text = "Type";
            lblType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUnit
            // 
            lblUnit.BackColor = Color.Transparent;
            lblUnit.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblUnit.ForeColor = Color.FromArgb(153, 166, 184);
            lblUnit.Location = new Point(390, 15);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(90, 23);
            lblUnit.TabIndex = 4;
            lblUnit.Text = "Unit";
            lblUnit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(153, 166, 184);
            lblTitle.Location = new Point(175, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(112, 23);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.Visible = false;
            // 
            // lblNo
            // 
            lblNo.BackColor = Color.Transparent;
            lblNo.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNo.ForeColor = Color.White;
            lblNo.Location = new Point(15, 15);
            lblNo.Name = "lblNo";
            lblNo.Size = new Size(45, 23);
            lblNo.TabIndex = 0;
            lblNo.Text = "1";
            lblNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            lblName.BackColor = Color.Transparent;
            lblName.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(153, 166, 184);
            lblName.Location = new Point(65, 15);
            lblName.Name = "lblName";
            lblName.Size = new Size(200, 23);
            lblName.TabIndex = 1;
            lblName.Text = "Name";
            lblName.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMin
            // 
            lblMin.BackColor = Color.Transparent;
            lblMin.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMin.ForeColor = Color.FromArgb(153, 166, 184);
            lblMin.Location = new Point(480, 15);
            lblMin.Name = "lblMin";
            lblMin.Size = new Size(120, 23);
            lblMin.TabIndex = 5;
            lblMin.Text = "Min";
            lblMin.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMax
            // 
            lblMax.BackColor = Color.Transparent;
            lblMax.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMax.ForeColor = Color.FromArgb(153, 166, 184);
            lblMax.Location = new Point(550, 15);
            lblMax.Name = "lblMax";
            lblMax.Size = new Size(68, 23);
            lblMax.TabIndex = 6;
            lblMax.Text = "Max";
            lblMax.TextAlign = ContentAlignment.MiddleLeft;
            lblMax.Visible = false;
            // 
            // lblTypeImport
            // 
            lblTypeImport.BackColor = Color.Transparent;
            lblTypeImport.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTypeImport.ForeColor = Color.FromArgb(153, 166, 184);
            lblTypeImport.Location = new Point(710, 15);
            lblTypeImport.Name = "lblTypeImport";
            lblTypeImport.Size = new Size(112, 23);
            lblTypeImport.TabIndex = 8;
            lblTypeImport.Text = "Type Import";
            lblTypeImport.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RowDUTRUN
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 16, 20);
            Controls.Add(lblReport);
            Controls.Add(lblRequired);
            Controls.Add(lblTypeImport);
            Controls.Add(lblType);
            Controls.Add(lblMax);
            Controls.Add(lblMin);
            Controls.Add(lblUnit);
            Controls.Add(txtValue);
            Controls.Add(lblTitle);
            Controls.Add(lblName);
            Controls.Add(lblNo);
            Font = new Font("Segoe UI Variable Display Semib", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(0);
            Name = "RowDUTRUN";
            Size = new Size(1072, 50);
            ResumeLayout(false);
        }

        #endregion

        private RJTextBox txtValue;
        private System.Windows.Forms.Label lblNo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblUnit;
        private System.Windows.Forms.Label lblMin;
        private System.Windows.Forms.Label lblMax;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblTypeImport;
        private System.Windows.Forms.Label lblRequired;
        private System.Windows.Forms.Label lblReport;
    }
}
