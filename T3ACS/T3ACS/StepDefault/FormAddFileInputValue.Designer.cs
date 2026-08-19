using T3ACS.Controls;

namespace T3ACS
{
    partial class FormAddFileInputValue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddFileInputValue));
            panelControlAll1 = new PanelControlAll();
            panel1 = new Panel();
            lblbtnClose = new Label();
            lblHugeTitle = new Label();
            panelControlAll2 = new PanelControlAll();
            panelBorderControl1 = new PanelBorderRadiusCustom();
            lblDefaultName = new Label();
            label3 = new Label();
            txtName = new RJTextBox();
            lblDefaultValue = new Label();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            label4 = new Label();
            txtTitle = new RJTextBox();
            rjSelectFileControl1 = new RJSelectFileControl();
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
            panelControlAll1.Size = new Size(610, 81);
            panelControlAll1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblbtnClose);
            panel1.Controls.Add(lblHugeTitle);
            panel1.Location = new Point(3, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(605, 77);
            panel1.TabIndex = 1;
            panel1.MouseDown += panel1_MouseDown;
            // 
            // lblbtnClose
            // 
            lblbtnClose.Image = (Image)resources.GetObject("lblbtnClose.Image");
            lblbtnClose.Location = new Point(563, 16);
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
            lblHugeTitle.Size = new Size(130, 21);
            lblHugeTitle.TabIndex = 2;
            lblHugeTitle.Text = "Add String Input";
            // 
            // panelControlAll2
            // 
            panelControlAll2.BackColor = SystemColors.Window;
            panelControlAll2.BorderColor = Color.LightGray;
            panelControlAll2.BorderFocusColor = Color.HotPink;
            panelControlAll2.BorderSize = 1;
            panelControlAll2.Dock = DockStyle.Bottom;
            panelControlAll2.Location = new Point(0, 317);
            panelControlAll2.Margin = new Padding(2, 3, 2, 3);
            panelControlAll2.Name = "panelControlAll2";
            panelControlAll2.Padding = new Padding(2, 3, 2, 3);
            panelControlAll2.Size = new Size(610, 90);
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
            panelBorderControl1.Size = new Size(610, 244);
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
            txtName.Size = new Size(573, 40);
            txtName.TabIndex = 3;
            txtName.UnderlinedStyle = false;
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
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button1.BackColor = Color.White;
            button1.FlatAppearance.BorderColor = Color.White;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.White;
            button1.FlatAppearance.MouseOverBackColor = Color.White;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(356, 342);
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
            button2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.White;
            button2.FlatAppearance.MouseOverBackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Variable Display Semib", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(472, 342);
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
            txtTitle.Size = new Size(573, 40);
            txtTitle.TabIndex = 3;
            txtTitle.UnderlinedStyle = false;
            // 
            // rjSelectFileControl1
            // 
            rjSelectFileControl1.Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rjSelectFileControl1.ForeColor = Color.FromArgb(0, 32, 77);
            rjSelectFileControl1.Location = new Point(24, 261);
            rjSelectFileControl1.Margin = new Padding(3, 4, 3, 4);
            rjSelectFileControl1.Name = "rjSelectFileControl1";
            rjSelectFileControl1.Size = new Size(573, 49);
            rjSelectFileControl1.TabIndex = 3;
            // 
            // FormAddFileInputValue
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(610, 407);
            Controls.Add(rjSelectFileControl1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtTitle);
            Controls.Add(txtName);
            Controls.Add(label4);
            Controls.Add(label3);
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
            Name = "FormAddFileInputValue";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAddFileInputValue";
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
        private Label lblDefaultValue;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label label4;
        private RJTextBox txtTitle;
        private RJSelectFileControl rjSelectFileControl1;
    }
}