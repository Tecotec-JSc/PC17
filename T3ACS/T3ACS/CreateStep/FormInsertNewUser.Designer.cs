
using T3ACS.Controls;

namespace T3ACS
{
    partial class FormInsertNewUser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInsertNewUser));
            panel1 = new Panel();
            cboPermission = new ComboBox();
            txtPassword = new TextControl();
            txtFullName = new TextControl();
            txtUserName = new TextControl();
            label11 = new Label();
            label8 = new Label();
            label5 = new Label();
            label4 = new Label();
            lblTitle = new Label();
            panel2 = new Panel();
            lblClose = new Label();
            label2 = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            panelControlbottom1 = new PanelBorderRadiusCustom();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(243, 245, 249);
            panel1.Controls.Add(cboPermission);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(txtFullName);
            panel1.Controls.Add(txtUserName);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Segoe UI Variable Display", 10.5F);
            panel1.Location = new Point(0, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(540, 437);
            panel1.TabIndex = 39;
            // 
            // cboPermission
            // 
            cboPermission.FormattingEnabled = true;
            cboPermission.Items.AddRange(new object[] { "Admin", "Operator", "Reviewer", "QA" });
            cboPermission.Location = new Point(19, 301);
            cboPermission.Name = "cboPermission";
            cboPermission.Size = new Size(505, 27);
            cboPermission.TabIndex = 7;
            cboPermission.Text = "Admin";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = SystemColors.Window;
            txtPassword.BorderColor = Color.LightGray;
            txtPassword.BorderFocusColor = Color.HotPink;
            txtPassword.BorderSize = 1;
            txtPassword.Font = new Font("Segoe UI Variable Display", 10.5F);
            txtPassword.Location = new Point(16, 207);
            txtPassword.Margin = new Padding(2);
            txtPassword.MaxLeng = 32767;
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(3);
            txtPassword.PasswordChar = false;
            txtPassword.ReadOnly = false;
            txtPassword.Size = new Size(508, 26);
            txtPassword.TabIndex = 6;
            txtPassword.Texts = "";
            txtPassword.UnderlinedStyle = true;
            // 
            // txtFullName
            // 
            txtFullName.BackColor = SystemColors.Window;
            txtFullName.BorderColor = Color.LightGray;
            txtFullName.BorderFocusColor = Color.HotPink;
            txtFullName.BorderSize = 1;
            txtFullName.Font = new Font("Segoe UI Variable Display", 10.5F);
            txtFullName.Location = new Point(16, 120);
            txtFullName.Margin = new Padding(2);
            txtFullName.MaxLeng = 32767;
            txtFullName.Multiline = false;
            txtFullName.Name = "txtFullName";
            txtFullName.Padding = new Padding(3);
            txtFullName.PasswordChar = false;
            txtFullName.ReadOnly = false;
            txtFullName.Size = new Size(508, 26);
            txtFullName.TabIndex = 6;
            txtFullName.Texts = "";
            txtFullName.UnderlinedStyle = true;
            // 
            // txtUserName
            // 
            txtUserName.BackColor = SystemColors.Window;
            txtUserName.BorderColor = Color.LightGray;
            txtUserName.BorderFocusColor = Color.HotPink;
            txtUserName.BorderSize = 1;
            txtUserName.Font = new Font("Segoe UI Variable Display", 10.5F);
            txtUserName.Location = new Point(16, 36);
            txtUserName.Margin = new Padding(2);
            txtUserName.MaxLeng = 32767;
            txtUserName.Multiline = false;
            txtUserName.Name = "txtUserName";
            txtUserName.Padding = new Padding(3);
            txtUserName.PasswordChar = false;
            txtUserName.ReadOnly = false;
            txtUserName.Size = new Size(508, 26);
            txtUserName.TabIndex = 6;
            txtUserName.Texts = "";
            txtUserName.UnderlinedStyle = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label11.Location = new Point(16, 273);
            label11.Name = "label11";
            label11.Size = new Size(88, 19);
            label11.TabIndex = 5;
            label11.Text = "Permissions";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label8.Location = new Point(16, 179);
            label8.Name = "label8";
            label8.Size = new Size(72, 19);
            label8.TabIndex = 5;
            label8.Text = "Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label5.Location = new Point(16, 92);
            label5.Name = "label5";
            label5.Size = new Size(74, 19);
            label5.TabIndex = 5;
            label5.Text = "Full Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label4.Location = new Point(16, 8);
            label4.Name = "label4";
            label4.Size = new Size(82, 19);
            label4.TabIndex = 5;
            label4.Text = "User Name";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(80, 19);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "New Users";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.Window;
            panel2.Controls.Add(lblClose);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(lblTitle);
            panel2.Dock = DockStyle.Top;
            panel2.Font = new Font("Segoe UI Variable Display", 10.5F);
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(540, 32);
            panel2.TabIndex = 37;
            panel2.MouseDown += panel2_MouseDown;
            // 
            // lblClose
            // 
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Segoe UI Variable Display", 10.5F);
            lblClose.Image = (Image)resources.GetObject("lblClose.Image");
            lblClose.Location = new Point(502, 2);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(35, 29);
            lblClose.TabIndex = 3;
            lblClose.Click += lblClose_Click;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Variable Display", 10.5F);
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(1031, 3);
            label2.Name = "label2";
            label2.Size = new Size(35, 24);
            label2.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSave.BackColor = Color.White;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnSave.Image = (Image)resources.GetObject("btnSave.Image");
            btnSave.Location = new Point(409, 483);
            btnSave.Margin = new Padding(0);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(95, 33);
            btnSave.TabIndex = 40;
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            btnCancel.Location = new Point(295, 483);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(95, 33);
            btnCancel.TabIndex = 41;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panelControlbottom1
            // 
            panelControlbottom1.BackColor = SystemColors.Window;
            panelControlbottom1.BorderColor = Color.LightGray;
            panelControlbottom1.BorderSize = 1;
            panelControlbottom1.Dock = DockStyle.Bottom;
            panelControlbottom1.Font = new Font("Segoe UI Variable Display", 10.5F);
            panelControlbottom1.Location = new Point(0, 469);
            panelControlbottom1.Margin = new Padding(3, 4, 3, 4);
            panelControlbottom1.Name = "panelControlbottom1";
            panelControlbottom1.Padding = new Padding(3, 4, 3, 4);
            panelControlbottom1.Size = new Size(540, 60);
            panelControlbottom1.TabIndex = 38;
            // 
            // FormInsertNewUser
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 529);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(panel1);
            Controls.Add(panelControlbottom1);
            Controls.Add(panel2);
            Font = new Font("Segoe UI Variable Display", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormInsertNewUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "New User";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel panel1;
        private TextControl txtPassword;
        private TextControl txtFullName;
        private TextControl txtUserName;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private PanelBorderRadiusCustom panelControlbottom1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cboPermission;
    }
}