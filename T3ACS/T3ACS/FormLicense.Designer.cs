
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
            panelControl1 = new PanelBorderRadiusCustom();
            panelControlbottom1 = new PanelBorderRadiusCustom();
            panel1 = new Panel();
            txt5 = new TextBox();
            txt4 = new TextBox();
            txt3 = new TextBox();
            txt2 = new TextBox();
            txt1 = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnNext = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelControl1
            // 
            panelControl1.BackColor = SystemColors.Window;
            panelControl1.BorderColor = Color.LightGray;
            panelControl1.BorderSize = 1;
            panelControl1.Dock = DockStyle.Top;
            panelControl1.Location = new Point(0, 0);
            panelControl1.Margin = new Padding(2);
            panelControl1.Name = "panelControl1";
            panelControl1.Padding = new Padding(3);
            panelControl1.Size = new Size(540, 32);
            panelControl1.TabIndex = 1;
            // 
            // panelControlbottom1
            // 
            panelControlbottom1.BackColor = SystemColors.Control;
            panelControlbottom1.BorderColor = Color.LightGray;
            panelControlbottom1.BorderSize = 1;
            panelControlbottom1.Dock = DockStyle.Bottom;
            panelControlbottom1.Location = new Point(0, 208);
            panelControlbottom1.Margin = new Padding(2);
            panelControlbottom1.Name = "panelControlbottom1";
            panelControlbottom1.Padding = new Padding(3);
            panelControlbottom1.Size = new Size(540, 80);
            panelControlbottom1.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(txt5);
            panel1.Controls.Add(txt4);
            panel1.Controls.Add(txt3);
            panel1.Controls.Add(txt2);
            panel1.Controls.Add(txt1);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(540, 176);
            panel1.TabIndex = 3;
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
            txt1.TextChanged += txt1_TextChanged_1;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(382, 118);
            label6.Name = "label6";
            label6.Size = new Size(19, 26);
            label6.TabIndex = 4;
            label6.Text = "-";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(286, 118);
            label5.Name = "label5";
            label5.Size = new Size(19, 26);
            label5.TabIndex = 4;
            label5.Text = "-";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(190, 118);
            label4.Name = "label4";
            label4.Size = new Size(19, 26);
            label4.TabIndex = 4;
            label4.Text = "-";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(96, 118);
            label3.Name = "label3";
            label3.Size = new Size(19, 26);
            label3.TabIndex = 4;
            label3.Text = "-";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 48);
            label2.Name = "label2";
            label2.Size = new Size(391, 57);
            label2.TabIndex = 2;
            label2.Text = "Enter your license key below.\nThe key will unlock T3ACSSW on the operating system: Windows.\nThe software is licensed permanently.";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(24, 8);
            label1.Name = "label1";
            label1.Size = new Size(135, 27);
            label1.TabIndex = 1;
            label1.Text = "Enter License";
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
            // button1
            // 
            button1.BackColor = SystemColors.Control;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(289, 231);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(243, 33);
            button1.TabIndex = 9;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // FormLicense
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(540, 288);
            Controls.Add(button1);
            Controls.Add(btnNext);
            Controls.Add(panel1);
            Controls.Add(panelControlbottom1);
            Controls.Add(panelControl1);
            Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormLicense";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Enter License";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PanelBorderRadiusCustom panelControl1;
        private PanelBorderRadiusCustom panelControlbottom1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button button1;
        private TextBox txt1;
        private TextBox txt5;
        private TextBox txt4;
        private TextBox txt3;
        private TextBox txt2;
    }
}