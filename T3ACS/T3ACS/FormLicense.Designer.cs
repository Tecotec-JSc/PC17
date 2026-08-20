
using T3ACS.Controls;

namespace T3ACS
{
    partial class FormLicense
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLicense));
            pnlTop = new PanelBorderRadiusCustom();
            pnlBottom = new PanelBorderRadiusCustom();
            pnlBody = new Panel();
            txt5 = new TextBox();
            txt4 = new TextBox();
            txt3 = new TextBox();
            txt2 = new TextBox();
            txt1 = new TextBox();
            lblDash4 = new Label();
            lblDash3 = new Label();
            lblDash2 = new Label();
            lblDash1 = new Label();
            lblDescription = new Label();
            lblTitle = new Label();
            btnNext = new Button();
            btnSave = new Button();
            pnlBody.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTop
            // 
            pnlTop.BackColor = SystemColors.Window;
            pnlTop.BorderColor = Color.LightGray;
            pnlTop.BorderSize = 1;
            pnlTop.Dock = DockStyle.Top;
            pnlTop.Location = new Point(0, 0);
            pnlTop.Margin = new Padding(2);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new Padding(3);
            pnlTop.Size = new Size(540, 32);
            pnlTop.TabIndex = 1;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = SystemColors.Control;
            pnlBottom.BorderColor = Color.LightGray;
            pnlBottom.BorderSize = 1;
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Location = new Point(0, 208);
            pnlBottom.Margin = new Padding(2);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(3);
            pnlBottom.Size = new Size(540, 80);
            pnlBottom.TabIndex = 2;
            // 
            // pnlBody
            // 
            pnlBody.Controls.Add(txt5);
            pnlBody.Controls.Add(txt4);
            pnlBody.Controls.Add(txt3);
            pnlBody.Controls.Add(txt2);
            pnlBody.Controls.Add(txt1);
            pnlBody.Controls.Add(lblDash4);
            pnlBody.Controls.Add(lblDash3);
            pnlBody.Controls.Add(lblDash2);
            pnlBody.Controls.Add(lblDash1);
            pnlBody.Controls.Add(lblDescription);
            pnlBody.Controls.Add(lblTitle);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 32);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(540, 176);
            pnlBody.TabIndex = 3;
            // 
            // txt5
            // 
            txt5.Location = new Point(404, 120);
            txt5.Name = "txt5";
            txt5.Size = new Size(69, 26);
            txt5.TabIndex = 8;
            txt5.TextChanged += txt5_TextChanged;
            // 
            // txt4
            // 
            txt4.Location = new Point(309, 120);
            txt4.Name = "txt4";
            txt4.Size = new Size(69, 26);
            txt4.TabIndex = 8;
            txt4.TextChanged += txt4_TextChanged;
            // 
            // txt3
            // 
            txt3.Location = new Point(213, 120);
            txt3.Name = "txt3";
            txt3.Size = new Size(69, 26);
            txt3.TabIndex = 8;
            txt3.TextChanged += txt3_TextChanged;
            // 
            // txt2
            // 
            txt2.Location = new Point(117, 120);
            txt2.Name = "txt2";
            txt2.Size = new Size(69, 26);
            txt2.TabIndex = 8;
            txt2.TextChanged += txt2_TextChanged;
            // 
            // txt1
            // 
            txt1.Location = new Point(24, 120);
            txt1.Name = "txt1";
            txt1.Size = new Size(69, 26);
            txt1.TabIndex = 8;
            txt1.TextChanged += txt1_TextChanged;
            // 
            // lblDash4
            // 
            lblDash4.AutoSize = true;
            lblDash4.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDash4.Location = new Point(382, 118);
            lblDash4.Name = "lblDash4";
            lblDash4.Size = new Size(19, 26);
            lblDash4.TabIndex = 4;
            lblDash4.Text = "-";
            // 
            // lblDash3
            // 
            lblDash3.AutoSize = true;
            lblDash3.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDash3.Location = new Point(286, 118);
            lblDash3.Name = "lblDash3";
            lblDash3.Size = new Size(19, 26);
            lblDash3.TabIndex = 4;
            lblDash3.Text = "-";
            // 
            // lblDash2
            // 
            lblDash2.AutoSize = true;
            lblDash2.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDash2.Location = new Point(190, 118);
            lblDash2.Name = "lblDash2";
            lblDash2.Size = new Size(19, 26);
            lblDash2.TabIndex = 4;
            lblDash2.Text = "-";
            // 
            // lblDash1
            // 
            lblDash1.AutoSize = true;
            lblDash1.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDash1.Location = new Point(96, 118);
            lblDash1.Name = "lblDash1";
            lblDash1.Size = new Size(19, 26);
            lblDash1.TabIndex = 4;
            lblDash1.Text = "-";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Location = new Point(24, 48);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(391, 57);
            lblDescription.TabIndex = 2;
            lblDescription.Text = "Enter your license key below.\nThe key will unlock T3ACSSW on the operating system: Windows.\nThe software is licensed permanently.";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Variable Display", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(24, 8);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(135, 27);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Enter License";
            // 
            // btnNext
            // 
            btnNext.BackColor = SystemColors.Control;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Image = (Image)resources.GetObject("btnNext.Image");
            btnNext.Location = new Point(44, 231);
            btnNext.Margin = new Padding(0);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(241, 33);
            btnNext.TabIndex = 8;
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnSave
            // 
            btnSave.BackColor = SystemColors.Control;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.Location = new Point(289, 231);
            btnSave.Margin = new Padding(0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(243, 33);
            btnSave.TabIndex = 9;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // FormLicense
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(540, 288);
            Controls.Add(btnSave);
            Controls.Add(btnNext);
            Controls.Add(pnlBody);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTop);
            Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Enter License";
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PanelBorderRadiusCustom pnlTop;
        private PanelBorderRadiusCustom pnlBottom;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDash1;
        private System.Windows.Forms.Label lblDash4;
        private System.Windows.Forms.Label lblDash3;
        private System.Windows.Forms.Label lblDash2;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnSave;
        private TextBox txt1;
        private TextBox txt5;
        private TextBox txt4;
        private TextBox txt3;
        private TextBox txt2;
    }
}