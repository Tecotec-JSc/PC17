using T3ACS.Controls;

namespace T3ACS
{
    partial class FormNotificationWarning
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
            label1 = new Label();
            lblHugeTitle = new Label();
            lblTextContent = new Label();
            buttonControl1 = new ButtonControl();
            buttonControl2 = new ButtonControl();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Image = Properties.Resources.iconwarning;
            label1.Location = new Point(32, 27);
            label1.Name = "label1";
            label1.Size = new Size(37, 40);
            label1.TabIndex = 0;
            // 
            // lblHugeTitle
            // 
            lblHugeTitle.AutoSize = true;
            lblHugeTitle.Font = new Font("Segoe UI Variable Text Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHugeTitle.Location = new Point(84, 32);
            lblHugeTitle.Name = "lblHugeTitle";
            lblHugeTitle.Size = new Size(135, 21);
            lblHugeTitle.TabIndex = 1;
            lblHugeTitle.Text = "Discard changes?";
            // 
            // lblTextContent
            // 
            lblTextContent.Location = new Point(86, 62);
            lblTextContent.Name = "lblTextContent";
            lblTextContent.Size = new Size(392, 66);
            lblTextContent.TabIndex = 2;
            lblTextContent.Text = "You have unsaved changes. Are you sure you want to cancel? All changes will be lost.";
            // 
            // buttonControl1
            // 
            buttonControl1.BackColor = Color.White;
            buttonControl1.BackColors = Color.White;
            buttonControl1.BorderColor = Color.DarkGray;
            buttonControl1.BorderFocusColor = Color.FromArgb(3, 120, 212);
            buttonControl1.BorderRadius = 5;
            buttonControl1.BorderSize = 1;
            buttonControl1.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonControl1.ForeColors = Color.FromArgb(0, 32, 77);
            buttonControl1.HoverColors = Color.DarkGray;
            buttonControl1.Location = new Point(184, 150);
            buttonControl1.Name = "buttonControl1";
            buttonControl1.Size = new Size(143, 41);
            buttonControl1.TabIndex = 3;
            buttonControl1.Texts = "Continue Editing";
            buttonControl1.Load += buttonControl1_Load;
            // 
            // buttonControl2
            // 
            buttonControl2.BackColor = Color.Red;
            buttonControl2.BackColors = Color.White;
            buttonControl2.BorderColor = Color.Red;
            buttonControl2.BorderFocusColor = Color.FromArgb(3, 120, 212);
            buttonControl2.BorderRadius = 5;
            buttonControl2.BorderSize = 1;
            buttonControl2.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold);
            buttonControl2.ForeColors = Color.FromArgb(0, 32, 77);
            buttonControl2.HoverColors = Color.DarkGray;
            buttonControl2.Location = new Point(343, 150);
            buttonControl2.Name = "buttonControl2";
            buttonControl2.Size = new Size(135, 41);
            buttonControl2.TabIndex = 4;
            buttonControl2.Texts = "Discard Changes";
            buttonControl2.Load += buttonControl2_Load;
            // 
            // FormNotificationWarning
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(520, 214);
            Controls.Add(buttonControl2);
            Controls.Add(buttonControl1);
            Controls.Add(lblTextContent);
            Controls.Add(lblHugeTitle);
            Controls.Add(label1);
            Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(520, 214);
            MinimumSize = new Size(520, 214);
            Name = "FormNotificationWarning";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormNotificationWarning";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblHugeTitle;
        private Label lblTextContent;
        private ButtonControl buttonControl1;
        private ButtonControl buttonControl2;
    }
}