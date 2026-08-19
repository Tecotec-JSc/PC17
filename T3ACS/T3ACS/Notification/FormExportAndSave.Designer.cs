using T3ACS.Controls;

namespace T3ACS
{
    partial class FormExportAndSave
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormExportAndSave));
            lblImage = new Label();
            lblTitle = new Label();
            btnSaveAndQuit = new ButtonControl();
            label1 = new Label();
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
            lblTitle.Size = new Size(106, 21);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Finish to end";
            // 
            // btnSaveAndQuit
            // 
            btnSaveAndQuit.BackColor = Color.White;
            btnSaveAndQuit.BackColors = Color.White;
            btnSaveAndQuit.BorderColor = Color.FromArgb(227, 242, 253);
            btnSaveAndQuit.BorderFocusColor = Color.FromArgb(3, 120, 212);
            btnSaveAndQuit.BorderRadius = 5;
            btnSaveAndQuit.BorderSize = 1;
            btnSaveAndQuit.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSaveAndQuit.ForeColors = Color.FromArgb(0, 32, 77);
            btnSaveAndQuit.HoverColors = Color.DarkGray;
            btnSaveAndQuit.Location = new Point(154, 128);
            btnSaveAndQuit.Name = "btnSaveAndQuit";
            btnSaveAndQuit.Size = new Size(135, 36);
            btnSaveAndQuit.TabIndex = 4;
            btnSaveAndQuit.Texts = "Save And Quit";
            btnSaveAndQuit.Click += btnSaveAndQuit_Click;
            // 
            // label1
            // 
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(441, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 26);
            label1.TabIndex = 6;
            label1.Click += label1_Click;
            // 
            // FormExportAndSave
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(477, 176);
            Controls.Add(label1);
            Controls.Add(btnSaveAndQuit);
            Controls.Add(lblTitle);
            Controls.Add(lblImage);
            Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormExportAndSave";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormExportAndSave";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblImage;
        private Label lblTitle;
        private ButtonControl btnSaveAndQuit;
        private Label label1;
    }
}