using T3ACS.Controls;

namespace T3ACS
{
    partial class FormAddNumberInputValue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddNumberInputValue));
            panelControlAll1 = new PanelControlAll();
            panel1 = new Panel();
            lblbtnClose = new Label();
            lblHugeTitle = new Label();
            panelControlAll2 = new PanelControlAll();
            panelBorderControl1 = new PanelBorderRadiusCustom();
            lblDefaultName = new Label();
            label3 = new Label();
            txtName = new RJTextBox();
            lblDefaultUnit = new Label();
            lblDefaultValue = new Label();
            lblDefaultMin = new Label();
            txtUnit = new RJTextBox();
            txtValue = new RJTextBox();
            txtMin = new RJTextBox();
            lblDefaultMax = new Label();
            txtMax = new RJTextBox();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            label4 = new Label();
            txtTitle = new RJTextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelControlAll1
            // 
            panelControlAll1.BackColor = SystemColors.Window;
            panelControlAll1.BorderColor = Color.LightGray;
            panelControlAll1.BorderFocusColor = Color.HotPink;
            panelControlAll1.BorderSize = 1;
            panelControlAll1.Dock = DockStyle.Top;
            panelControlAll1.Location = new Point(0, 0);
            panelControlAll1.Margin = new Padding(2, 3, 2, 3);
            panelControlAll1.Name = "panelControlAll1";
            panelControlAll1.Padding = new Padding(2, 3, 2, 3);
            panelControlAll1.Size = new Size(500, 81);
            panelControlAll1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblbtnClose);
            panel1.Controls.Add(lblHugeTitle);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(494, 77);
            panel1.TabIndex = 1;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // lblbtnClose
            // 
            lblbtnClose.Image = (Image)resources.GetObject("lblbtnClose.Image");
            lblbtnClose.Location = new Point(444, 24);
            lblbtnClose.Name = "lblbtnClose";
            lblbtnClose.Size = new Size(32, 32);
            lblbtnClose.TabIndex = 2;
            lblbtnClose.Click += lblbtnClose_Click;
            // 
            // lblHugeTitle
            // 
            lblHugeTitle.AutoSize = true;
            lblHugeTitle.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHugeTitle.Location = new Point(12, 27);
            lblHugeTitle.Name = "lblHugeTitle";
            lblHugeTitle.Size = new Size(147, 21);
            lblHugeTitle.TabIndex = 2;
            lblHugeTitle.Text = "Add Number Input";
            // 
            // panelControlAll2
            // 
            panelControlAll2.BackColor = SystemColors.Window;
            panelControlAll2.BorderColor = Color.LightGray;
            panelControlAll2.BorderFocusColor = Color.HotPink;
            panelControlAll2.BorderSize = 1;
            panelControlAll2.Dock = DockStyle.Bottom;
            panelControlAll2.Location = new Point(0, 521);
            panelControlAll2.Margin = new Padding(2, 3, 2, 3);
            panelControlAll2.Name = "panelControlAll2";
            panelControlAll2.Padding = new Padding(2, 3, 2, 3);
            panelControlAll2.Size = new Size(500, 114);
            panelControlAll2.TabIndex = 2;
            // 
            // panelBorderControl1
            // 
            panelBorderControl1.BackColor = SystemColors.Window;
            panelBorderControl1.BorderColor = Color.DarkGray;
            panelBorderControl1.BorderSize = 1;
            panelBorderControl1.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl1.Location = new Point(0, 74);
            panelBorderControl1.Margin = new Padding(0);
            panelBorderControl1.Name = "panelBorderControl1";
            panelBorderControl1.Padding = new Padding(2);
            panelBorderControl1.Size = new Size(500, 468);
            panelBorderControl1.TabIndex = 3;
            // 
            // lblDefaultName
            // 
            lblDefaultName.AutoSize = true;
            lblDefaultName.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultName.Location = new Point(24, 84);
            lblDefaultName.Name = "lblDefaultName";
            lblDefaultName.Size = new Size(112, 19);
            lblDefaultName.TabIndex = 3;
            lblDefaultName.Text = "Parameter Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Red;
            label3.Location = new Point(132, 84);
            label3.Name = "label3";
            label3.Size = new Size(15, 19);
            label3.TabIndex = 3;
            label3.Text = "*";
            label3.Click += label3_Click;
            // 
            // txtName
            // 
            txtName.BackColor = SystemColors.Window;
            txtName.BorderColor = Color.DarkGray;
            txtName.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtName.BorderRadius = 5;
            txtName.BorderSize = 1;
            txtName.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(24, 109);
            txtName.Margin = new Padding(4);
            txtName.Multiline = false;
            txtName.Name = "txtName";
            txtName.Padding = new Padding(10, 7, 10, 7);
            txtName.PasswordChar = false;
            txtName.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtName.PlaceholderText = "";
            txtName.ReadOnly = false;
            txtName.Size = new Size(452, 40);
            txtName.TabIndex = 3;
            txtName.UnderlinedStyle = false;
            // 
            // lblDefaultUnit
            // 
            lblDefaultUnit.AutoSize = true;
            lblDefaultUnit.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultUnit.Location = new Point(24, 467);
            lblDefaultUnit.Name = "lblDefaultUnit";
            lblDefaultUnit.Size = new Size(36, 19);
            lblDefaultUnit.TabIndex = 3;
            lblDefaultUnit.Text = "Unit";
            // 
            // lblDefaultValue
            // 
            lblDefaultValue.AutoSize = true;
            lblDefaultValue.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultValue.Location = new Point(24, 229);
            lblDefaultValue.Name = "lblDefaultValue";
            lblDefaultValue.Size = new Size(43, 19);
            lblDefaultValue.TabIndex = 3;
            lblDefaultValue.Text = "Value";
            // 
            // lblDefaultMin
            // 
            lblDefaultMin.AutoSize = true;
            lblDefaultMin.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultMin.Location = new Point(24, 311);
            lblDefaultMin.Name = "lblDefaultMin";
            lblDefaultMin.Size = new Size(34, 19);
            lblDefaultMin.TabIndex = 3;
            lblDefaultMin.Text = "Min";
            // 
            // txtUnit
            // 
            txtUnit.BackColor = SystemColors.Window;
            txtUnit.BorderColor = Color.DarkGray;
            txtUnit.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtUnit.BorderRadius = 5;
            txtUnit.BorderSize = 1;
            txtUnit.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtUnit.Location = new Point(24, 495);
            txtUnit.Margin = new Padding(4);
            txtUnit.Multiline = false;
            txtUnit.Name = "txtUnit";
            txtUnit.Padding = new Padding(10, 7, 10, 7);
            txtUnit.PasswordChar = false;
            txtUnit.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtUnit.PlaceholderText = "";
            txtUnit.ReadOnly = false;
            txtUnit.Size = new Size(452, 40);
            txtUnit.TabIndex = 3;
            txtUnit.UnderlinedStyle = false;
            // 
            // txtValue
            // 
            txtValue.BackColor = SystemColors.Window;
            txtValue.BorderColor = Color.DarkGray;
            txtValue.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtValue.BorderRadius = 5;
            txtValue.BorderSize = 1;
            txtValue.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtValue.Location = new Point(24, 255);
            txtValue.Margin = new Padding(4);
            txtValue.Multiline = false;
            txtValue.Name = "txtValue";
            txtValue.Padding = new Padding(10, 7, 10, 7);
            txtValue.PasswordChar = false;
            txtValue.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtValue.PlaceholderText = "";
            txtValue.ReadOnly = false;
            txtValue.Size = new Size(452, 40);
            txtValue.TabIndex = 3;
            txtValue.UnderlinedStyle = false;
            // 
            // txtMin
            // 
            txtMin.BackColor = SystemColors.Window;
            txtMin.BorderColor = Color.DarkGray;
            txtMin.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtMin.BorderRadius = 5;
            txtMin.BorderSize = 1;
            txtMin.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMin.Location = new Point(24, 337);
            txtMin.Margin = new Padding(4);
            txtMin.Multiline = false;
            txtMin.Name = "txtMin";
            txtMin.Padding = new Padding(10, 7, 10, 7);
            txtMin.PasswordChar = false;
            txtMin.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtMin.PlaceholderText = "";
            txtMin.ReadOnly = false;
            txtMin.Size = new Size(452, 40);
            txtMin.TabIndex = 3;
            txtMin.UnderlinedStyle = false;
            // 
            // lblDefaultMax
            // 
            lblDefaultMax.AutoSize = true;
            lblDefaultMax.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultMax.Location = new Point(24, 387);
            lblDefaultMax.Name = "lblDefaultMax";
            lblDefaultMax.Size = new Size(36, 19);
            lblDefaultMax.TabIndex = 3;
            lblDefaultMax.Text = "Max";
            // 
            // txtMax
            // 
            txtMax.BackColor = SystemColors.Window;
            txtMax.BorderColor = Color.DarkGray;
            txtMax.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtMax.BorderRadius = 5;
            txtMax.BorderSize = 1;
            txtMax.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMax.Location = new Point(24, 413);
            txtMax.Margin = new Padding(4);
            txtMax.Multiline = false;
            txtMax.Name = "txtMax";
            txtMax.Padding = new Padding(10, 7, 10, 7);
            txtMax.PasswordChar = false;
            txtMax.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtMax.PlaceholderText = "";
            txtMax.ReadOnly = false;
            txtMax.Size = new Size(452, 40);
            txtMax.TabIndex = 3;
            txtMax.UnderlinedStyle = false;
            // 
            // button1
            // 
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(232, 570);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(96, 40);
            button1.TabIndex = 53;
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.White;
            button2.FlatAppearance.MouseOverBackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(350, 570);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(126, 40);
            button2.TabIndex = 53;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(24, 156);
            label2.Name = "label2";
            label2.Size = new Size(37, 19);
            label2.TabIndex = 3;
            label2.Text = "Title";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(56, 154);
            label4.Name = "label4";
            label4.Size = new Size(15, 19);
            label4.TabIndex = 3;
            label4.Text = "*";
            label4.Click += label3_Click;
            // 
            // txtTitle
            // 
            txtTitle.BackColor = SystemColors.Window;
            txtTitle.BorderColor = Color.DarkGray;
            txtTitle.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtTitle.BorderRadius = 5;
            txtTitle.BorderSize = 1;
            txtTitle.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTitle.Location = new Point(24, 183);
            txtTitle.Margin = new Padding(4);
            txtTitle.Multiline = false;
            txtTitle.Name = "txtTitle";
            txtTitle.Padding = new Padding(10, 7, 10, 7);
            txtTitle.PasswordChar = false;
            txtTitle.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtTitle.PlaceholderText = "";
            txtTitle.ReadOnly = false;
            txtTitle.Size = new Size(452, 40);
            txtTitle.TabIndex = 3;
            txtTitle.UnderlinedStyle = false;
            // 
            // FormAddNumberInputValue
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 635);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtUnit);
            Controls.Add(txtMax);
            Controls.Add(txtMin);
            Controls.Add(txtValue);
            Controls.Add(lblDefaultUnit);
            Controls.Add(txtTitle);
            Controls.Add(txtName);
            Controls.Add(lblDefaultMax);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(lblDefaultMin);
            Controls.Add(label2);
            Controls.Add(lblDefaultValue);
            Controls.Add(lblDefaultName);
            Controls.Add(panelBorderControl1);
            Controls.Add(panelControlAll2);
            Controls.Add(panel1);
            Controls.Add(panelControlAll1);
            Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            MaximumSize = new Size(500, 635);
            MinimumSize = new Size(500, 635);
            Name = "FormAddNumberInputValue";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAddNumberInputValue";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PanelControlAll panelControlAll1;
        private Panel panel1;
        private Label lblbtnClose;
        private Label lblHugeTitle;
        private PanelControlAll panelControlAll2;
        private PanelBorderRadiusCustom panelBorderControl1;
        private Label lblDefaultName;
        private Label label3;
        private RJTextBox txtName;
        private Label lblDefaultUnit;
        private Label lblDefaultValue;
        private RJTextBox txtUnit;
        private Label lblDefaultMin;
        private RJTextBox txtValue;
        private RJTextBox txtMin;
        private Label lblDefaultMax;
        private RJTextBox txtMax;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label label4;
        private RJTextBox txtTitle;
    }
}