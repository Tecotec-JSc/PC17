using T3ACS.Controls;

namespace T3ACS
{
    partial class FormOKCancelAll
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
            lblContent = new Label();
            lblTitle = new Label();
            lblImage = new Label();
            btnOK = new ButtonControl();
            btnCancel = new ButtonControl();
            SuspendLayout();
            // 
            // lblContent
            // 
            lblContent.Location = new Point(72, 50);
            lblContent.Name = "lblContent";
            lblContent.Size = new Size(381, 56);
            lblContent.TabIndex = 6;
            lblContent.Text = "label2";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(72, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(71, 21);
            lblTitle.TabIndex = 5;
            lblTitle.Text = "Success";
            // 
            // lblImage
            // 
            lblImage.Image = Properties.Resources.pngSave;
            lblImage.Location = new Point(24, 17);
            lblImage.Name = "lblImage";
            lblImage.Size = new Size(32, 32);
            lblImage.TabIndex = 4;
            // 
            // btnOK
            // 
            btnOK.BackColor = Color.White;
            btnOK.BackColors = Color.White;
            btnOK.BorderColor = Color.FromArgb(227, 242, 253);
            btnOK.BorderFocusColor = Color.FromArgb(3, 120, 212);
            btnOK.BorderRadius = 5;
            btnOK.BorderSize = 1;
            btnOK.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnOK.ForeColors = Color.FromArgb(0, 32, 77);
            btnOK.HoverColors = Color.DarkGray;
            btnOK.Location = new Point(318, 123);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(135, 36);
            btnOK.TabIndex = 9;
            btnOK.Texts = "lblbtn1";
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.BackColors = Color.White;
            btnCancel.BorderColor = Color.FromArgb(227, 242, 253);
            btnCancel.BorderFocusColor = Color.FromArgb(3, 120, 212);
            btnCancel.BorderRadius = 5;
            btnCancel.BorderSize = 1;
            btnCancel.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColors = Color.FromArgb(0, 32, 77);
            btnCancel.HoverColors = Color.DarkGray;
            btnCancel.Location = new Point(166, 122);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(135, 36);
            btnCancel.TabIndex = 10;
            btnCancel.Texts = "lblbtn1";
            btnCancel.Click += btnCancel_Click;
            // 
            // FormOKCancelAll
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(477, 176);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(lblContent);
            Controls.Add(lblTitle);
            Controls.Add(lblImage);
            Font = new Font("Segoe UI Variable Display", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormOKCancelAll";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblContent;
        private Label lblTitle;
        private Label lblImage;
        private ButtonControl btnOK;
        private ButtonControl btnCancel;
    }
}
