using T3ACS.Controls;

namespace T3ACS
{
    partial class FormCreateStepContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCreateStepContent));
            label1 = new Label();
            lblCheck = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAddMedia = new Button();
            txtStepName = new RJTextBox32();
            txtStepType = new RJTextBox32();
            label4 = new Label();
            txtRepeatCount = new RJTextBox32();
            label5 = new Label();
            panelBorderRadiusCustom1 = new PanelBorderRadiusCustom();
            txaDescription = new RJEditor();
            panelContentStep = new PanelBorderRadiusCustom();
            panelBorderRadiusCustom1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(250, 250, 250);
            label1.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 10);
            label1.Name = "label1";
            label1.Size = new Size(74, 19);
            label1.TabIndex = 0;
            label1.Text = "Step name";
            // 
            // lblCheck
            // 
            lblCheck.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCheck.BackColor = Color.FromArgb(250, 250, 250);
            lblCheck.Image = Properties.Resources.rdonocheck;
            lblCheck.Location = new Point(911, 42);
            lblCheck.Name = "lblCheck";
            lblCheck.Size = new Size(27, 28);
            lblCheck.TabIndex = 2;
            lblCheck.Click += lblCheck_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(250, 250, 250);
            label2.Location = new Point(942, 46);
            label2.Name = "label2";
            label2.Size = new Size(142, 19);
            label2.TabIndex = 3;
            label2.Text = " Require previous step";
            label2.Click += lblCheck_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.FromArgb(250, 250, 250);
            label3.Font = new Font("Segoe UI Variable Display Semib", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(5, 171);
            label3.Name = "label3";
            label3.Size = new Size(90, 20);
            label3.TabIndex = 0;
            label3.Text = "Description";
            // 
            // btnAddMedia
            // 
            btnAddMedia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddMedia.BackColor = Color.White;
            btnAddMedia.FlatAppearance.BorderSize = 0;
            btnAddMedia.FlatAppearance.MouseDownBackColor = Color.White;
            btnAddMedia.FlatAppearance.MouseOverBackColor = Color.White;
            btnAddMedia.FlatStyle = FlatStyle.Flat;
            btnAddMedia.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnAddMedia.Image = (Image)resources.GetObject("btnAddMedia.Image");
            btnAddMedia.Location = new Point(958, 155);
            btnAddMedia.Margin = new Padding(0);
            btnAddMedia.Name = "btnAddMedia";
            btnAddMedia.Size = new Size(118, 35);
            btnAddMedia.TabIndex = 45;
            btnAddMedia.UseVisualStyleBackColor = false;
            btnAddMedia.Click += btnAddMedia_Click;
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
            txtStepName.PlaceholderText = "Name";
            txtStepName.ReadOnly = false;
            txtStepName.Size = new Size(888, 32);
            txtStepName.TabIndex = 49;
            txtStepName.Texts = "";
            txtStepName.UnderlinedStyle = false;
            txtStepName._TextChanged += txtStepName__TextChanged_1;
            // 
            // txtStepType
            // 
            txtStepType.BackColor = Color.White;
            txtStepType.BorderColor = Color.DarkGray;
            txtStepType.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtStepType.BorderRadius = 5;
            txtStepType.BorderSize = 1;
            txtStepType.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStepType.Location = new Point(12, 116);
            txtStepType.Margin = new Padding(4);
            txtStepType.Multiline = false;
            txtStepType.Name = "txtStepType";
            txtStepType.Padding = new Padding(10, 7, 10, 7);
            txtStepType.PasswordChar = false;
            txtStepType.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtStepType.PlaceholderText = "";
            txtStepType.ReadOnly = true;
            txtStepType.Size = new Size(451, 32);
            txtStepType.TabIndex = 51;
            txtStepType.Texts = "";
            txtStepType.UnderlinedStyle = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(250, 250, 250);
            label4.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(7, 83);
            label4.Name = "label4";
            label4.Size = new Size(67, 19);
            label4.TabIndex = 50;
            label4.Text = "Step type";
            // 
            // txtRepeatCount
            // 
            txtRepeatCount.BackColor = Color.White;
            txtRepeatCount.BorderColor = Color.DarkGray;
            txtRepeatCount.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtRepeatCount.BorderRadius = 5;
            txtRepeatCount.BorderSize = 1;
            txtRepeatCount.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtRepeatCount.Location = new Point(576, 119);
            txtRepeatCount.Margin = new Padding(4);
            txtRepeatCount.Multiline = false;
            txtRepeatCount.Name = "txtRepeatCount";
            txtRepeatCount.Padding = new Padding(10, 7, 10, 7);
            txtRepeatCount.PasswordChar = false;
            txtRepeatCount.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtRepeatCount.PlaceholderText = "";
            txtRepeatCount.ReadOnly = false;
            txtRepeatCount.Size = new Size(508, 32);
            txtRepeatCount.TabIndex = 53;
            txtRepeatCount.Texts = "";
            txtRepeatCount.UnderlinedStyle = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(250, 250, 250);
            label5.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(576, 83);
            label5.Name = "label5";
            label5.Size = new Size(91, 19);
            label5.TabIndex = 52;
            label5.Text = "Repeat count";
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColor = Color.White;
            panelBorderRadiusCustom1.BackColorG = Color.FromArgb(250, 250, 250);
            panelBorderRadiusCustom1.BorderColor = Color.FromArgb(250, 250, 250);
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(txaDescription);
            panelBorderRadiusCustom1.Controls.Add(txtRepeatCount);
            panelBorderRadiusCustom1.Controls.Add(txtStepName);
            panelBorderRadiusCustom1.Controls.Add(label1);
            panelBorderRadiusCustom1.Controls.Add(label5);
            panelBorderRadiusCustom1.Controls.Add(btnAddMedia);
            panelBorderRadiusCustom1.Controls.Add(label3);
            panelBorderRadiusCustom1.Controls.Add(label2);
            panelBorderRadiusCustom1.Controls.Add(txtStepType);
            panelBorderRadiusCustom1.Controls.Add(label4);
            panelBorderRadiusCustom1.Controls.Add(lblCheck);
            panelBorderRadiusCustom1.Location = new Point(12, 12);
            panelBorderRadiusCustom1.Margin = new Padding(0);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 5;
            panelBorderRadiusCustom1.RadiusBottomRight = 5;
            panelBorderRadiusCustom1.RadiusTopLeft = 5;
            panelBorderRadiusCustom1.RadiusTopRight = 5;
            panelBorderRadiusCustom1.Size = new Size(1096, 314);
            panelBorderRadiusCustom1.TabIndex = 55;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            // 
            // txaDescription
            // 
            txaDescription.BackColor = Color.White;
            txaDescription.BorderColor = Color.DarkGray;
            txaDescription.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txaDescription.BorderRadius = 5;
            txaDescription.BorderSize = 1;
            txaDescription.Location = new Point(12, 202);
            txaDescription.Margin = new Padding(0);
            txaDescription.Name = "txaDescription";
            txaDescription.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txaDescription.PlaceholderText = "";
            txaDescription.RadiusBottomLeft = 5;
            txaDescription.RadiusBottomRight = 5;
            txaDescription.RadiusTopLeft = 5;
            txaDescription.RadiusTopRight = 5;
            txaDescription.ReadOnly = false;
            txaDescription.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil Segoe UI Variable Display;}}\r\n{\\*\\generator Riched20 10.0.26100}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs21\\par\r\n}\r\n";
            txaDescription.Size = new Size(1072, 100);
            txaDescription.TabIndex = 54;
            txaDescription.Texts = "";
            txaDescription.UnderlinedStyle = false;
            // 
            // panelContentStep
            // 
            panelContentStep.BackColorG = Color.Empty;
            panelContentStep.BorderColor = Color.DarkGray;
            panelContentStep.BorderSize = 1;
            panelContentStep.Location = new Point(12, 334);
            panelContentStep.Margin = new Padding(0);
            panelContentStep.Name = "panelContentStep";
            panelContentStep.Padding = new Padding(2);
            panelContentStep.RadiusBottomLeft = 5;
            panelContentStep.RadiusBottomRight = 5;
            panelContentStep.RadiusTopLeft = 5;
            panelContentStep.RadiusTopRight = 5;
            panelContentStep.Size = new Size(1096, 517);
            panelContentStep.TabIndex = 54;
            panelContentStep.VerticalPoints = (List<int>)resources.GetObject("panelContentStep.VerticalPoints");
            // 
            // FormCreateStepContent
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1120, 858);
            Controls.Add(panelContentStep);
            Controls.Add(panelBorderRadiusCustom1);
            Font = new Font("Segoe UI Variable Display", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormCreateStepContent";
            Text = "FormCreateStepContent";
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelBorderRadiusCustom1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label lblCheck;
        private Label label2;
        private Label label3;
        private Button btnAddMedia;
        private RJTextBox32 txtStepName;
        private RJTextBox32 txtStepType;
        private Label label4;
        private RJTextBox32 txtRepeatCount;
        private Label label5;
        private PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private RJEditor txaDescription;
        private PanelBorderRadiusCustom panelContentStep;
    }
}