
namespace T3ACS
{
    partial class FormTableInfo
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblStepNumber = new Label();
            lblCheck = new Label();
            lblRequiresPrev = new Label();
            txtStepName = new Controls.RJTextBox32();
            lblDescriptionCaption = new Label();
            txaDescription = new Controls.RJEditor();
            SuspendLayout();
            // 
            // lblStepNumber
            // 
            lblStepNumber.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStepNumber.Location = new Point(12, 11);
            lblStepNumber.Margin = new Padding(0);
            lblStepNumber.Name = "lblStepNumber";
            lblStepNumber.Size = new Size(97, 21);
            lblStepNumber.TabIndex = 0;
            lblStepNumber.Text = "Step 1";
            lblStepNumber.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCheck
            // 
            lblCheck.Image = Properties.Resources.rdonocheck;
            lblCheck.Location = new Point(217, 12);
            lblCheck.Name = "lblCheck";
            lblCheck.Size = new Size(20, 20);
            lblCheck.TabIndex = 3;
            // 
            // lblRequiresPrev
            // 
            lblRequiresPrev.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRequiresPrev.Location = new Point(245, 12);
            lblRequiresPrev.Margin = new Padding(0);
            lblRequiresPrev.Name = "lblRequiresPrev";
            lblRequiresPrev.Size = new Size(171, 21);
            lblRequiresPrev.TabIndex = 0;
            lblRequiresPrev.Text = "REQUIRES PREVIOUS STEP";
            lblRequiresPrev.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txtStepName
            // 
            txtStepName.BackColor = Color.White;
            txtStepName.BorderColor = Color.DarkGray;
            txtStepName.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtStepName.BorderRadius = 5;
            txtStepName.BorderSize = 1;
            txtStepName.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStepName.Location = new Point(12, 40);
            txtStepName.Margin = new Padding(0);
            txtStepName.Multiline = false;
            txtStepName.Name = "txtStepName";
            txtStepName.Padding = new Padding(10, 7, 10, 7);
            txtStepName.PasswordChar = false;
            txtStepName.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtStepName.PlaceholderText = "";
            txtStepName.ReadOnly = true;
            txtStepName.Size = new Size(396, 32);
            txtStepName.TabIndex = 4;
            txtStepName.Texts = "";
            txtStepName.UnderlinedStyle = false;
            // 
            // lblDescriptionCaption
            // 
            lblDescriptionCaption.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescriptionCaption.Location = new Point(12, 89);
            lblDescriptionCaption.Margin = new Padding(0);
            lblDescriptionCaption.Name = "lblDescriptionCaption";
            lblDescriptionCaption.Size = new Size(97, 21);
            lblDescriptionCaption.TabIndex = 0;
            lblDescriptionCaption.Text = "Description";
            lblDescriptionCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // txaDescription
            // 
            txaDescription.AutoScroll = true;
            txaDescription.BackColor = Color.White;
            txaDescription.BorderColor = Color.DarkGray;
            txaDescription.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txaDescription.BorderRadius = 5;
            txaDescription.BorderSize = 1;
            txaDescription.Location = new Point(12, 129);
            txaDescription.Name = "txaDescription";
            txaDescription.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txaDescription.PlaceholderText = "";
            txaDescription.RadiusBottomLeft = 5;
            txaDescription.RadiusBottomRight = 5;
            txaDescription.RadiusTopLeft = 5;
            txaDescription.RadiusTopRight = 5;
            txaDescription.ReadOnly = false;
            txaDescription.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI Variable Display;}}\r\n{\\*\\generator Riched20 10.0.26100}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs21\\par\r\n}\r\n";
            txaDescription.Size = new Size(396, 634);
            txaDescription.TabIndex = 5;
            txaDescription.Texts = "";
            txaDescription.UnderlinedStyle = false;
            // 
            // FormTableInfo
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(420, 775);
            Controls.Add(txaDescription);
            Controls.Add(txtStepName);
            Controls.Add(lblCheck);
            Controls.Add(lblRequiresPrev);
            Controls.Add(lblDescriptionCaption);
            Controls.Add(lblStepNumber);
            Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormTableInfo";
            Text = "FormTableInfo";
            ResumeLayout(false);
        }

        #endregion

        private Label lblStepNumber;
        private Label lblCheck;
        private Label lblRequiresPrev;
        private Controls.RJTextBox32 txtStepName;
        private Label lblDescriptionCaption;
        private Controls.RJEditor txaDescription;
    }
}