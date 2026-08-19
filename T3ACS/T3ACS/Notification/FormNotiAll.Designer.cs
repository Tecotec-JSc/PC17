using T3ACS.Controls;

namespace T3ACS
{
    partial class FormNotiAll
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
            lblImage = new Label();
            lblTitle = new Label();
            lblContent = new Label();
            buttonControl1 = new ButtonControl();
            SuspendLayout();
            // 
            // lblImage
            // 
            lblImage.Image = Properties.Resources.pngSuccess;
            lblImage.Location = new Point(24, 24);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(32, 32);
            lblImage.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(72, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(71, 21);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Success";
            // 
            // lblContent
            // 
            lblContent.Location = new Point(72, 57);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(381, 56);
            lblContent.TabIndex = 2;
            lblContent.Text = "label2";
            // 
            // buttonControl1
            // 
            buttonControl1.BackColor = Color.White;
            buttonControl1.BackColors = Color.White;
            buttonControl1.BorderColor = Color.FromArgb(227, 242, 253);
            buttonControl1.BorderFocusColor = Color.FromArgb(3, 120, 212);
            buttonControl1.BorderRadius = 5;
            buttonControl1.BorderSize = 1;
            buttonControl1.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonControl1.ForeColors = Color.FromArgb(0, 32, 77);
            buttonControl1.HoverColors = Color.DarkGray;
            buttonControl1.Location = new Point(318, 128);
            buttonControl1.Name = "buttonControl1";
            buttonControl1.Size = new Size(135, 36);
            buttonControl1.TabIndex = 4;
            buttonControl1.Texts = "lblbtn1";
            buttonControl1.Click += btnOK_Load;
            // 
            // FormNotiAll
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 176);
            Controls.Add(buttonControl1);
            Controls.Add(lblContent);
            Controls.Add(lblTitle);
            Controls.Add(lblImage);
            Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormNotiAll";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Notification";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblImage;
        private Label lblTitle;
        private Label lblContent;
        private ButtonControl buttonControl1;
    }
}