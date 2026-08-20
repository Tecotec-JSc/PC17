
using T3ACS.Controls;

namespace T3ACS
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            pnlInput = new System.Windows.Forms.Panel();
            lblPassword = new System.Windows.Forms.Label();
            lblUserName = new System.Windows.Forms.Label();
            txtPassword = new RJTextBox32();
            txtUserName = new RJTextBox32();
            lblTitle = new System.Windows.Forms.Label();
            btnLogin = new System.Windows.Forms.Button();
            btnNext = new System.Windows.Forms.Button();
            btnClose = new System.Windows.Forms.Button();
            pnlBottom = new PanelBorderRadiusCustom();
            pnlTop = new PanelBorderRadiusCustom();
            pnlInput.SuspendLayout();
            SuspendLayout();
            // 
            // pnlInput
            // 
            pnlInput.Controls.Add(lblPassword);
            pnlInput.Controls.Add(lblUserName);
            pnlInput.Controls.Add(txtPassword);
            pnlInput.Controls.Add(txtUserName);
            pnlInput.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlInput.Location = new System.Drawing.Point(0, 32);
            pnlInput.Name = "pnlInput";
            pnlInput.Size = new System.Drawing.Size(540, 176);
            pnlInput.TabIndex = 3;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblPassword.Location = new System.Drawing.Point(22, 117);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new System.Drawing.Size(72, 19);
            lblPassword.TabIndex = 5;
            lblPassword.Text = "Password";
            // 
            // lblUserName
            // 
            lblUserName.AutoSize = true;
            lblUserName.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblUserName.Location = new System.Drawing.Point(22, 50);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new System.Drawing.Size(76, 19);
            lblUserName.TabIndex = 4;
            lblUserName.Text = "Username";
            // 
            // txtPassword
            // 
            txtPassword.BackColor = System.Drawing.SystemColors.Window;
            txtPassword.BorderColor = System.Drawing.Color.LightGray;
            txtPassword.BorderFocusColor = System.Drawing.Color.HotPink;
            txtPassword.BorderSize = 1;
            txtPassword.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtPassword.Location = new System.Drawing.Point(124, 115);
            txtPassword.Margin = new System.Windows.Forms.Padding(2);
    
            txtPassword.Multiline = false;
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new System.Windows.Forms.Padding(3);
            txtPassword.PasswordChar = true;
            txtPassword.ReadOnly = false;
            txtPassword.Size = new System.Drawing.Size(386, 28);
            txtPassword.TabIndex = 4;
            txtPassword.Texts = "";
            txtPassword.UnderlinedStyle = true;
            txtPassword.KeyDown += txtPassword_KeyDown;
            txtPassword.KeyPress += txtPassword_KeyPress;
            // 
            // txtUserName
            // 
            txtUserName.BackColor = System.Drawing.SystemColors.Window;
            txtUserName.BorderColor = System.Drawing.Color.LightGray;
            txtUserName.BorderFocusColor = System.Drawing.Color.HotPink;
            txtUserName.BorderSize = 1;
            txtUserName.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            txtUserName.Location = new System.Drawing.Point(124, 44);
            txtUserName.Margin = new System.Windows.Forms.Padding(2);
   
            txtUserName.Multiline = false;
            txtUserName.Name = "txtUserName";
            txtUserName.Padding = new System.Windows.Forms.Padding(3);
            txtUserName.PasswordChar = false;
            txtUserName.ReadOnly = false;
            txtUserName.Size = new System.Drawing.Size(390, 28);
            txtUserName.TabIndex = 3;
            txtUserName.Texts = "";
            txtUserName.UnderlinedStyle = true;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI Variable Display", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTitle.Location = new System.Drawing.Point(21, 2);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(63, 27);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Login";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = System.Drawing.SystemColors.Control;
            btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLogin.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLogin.Image = (System.Drawing.Image)resources.GetObject("btnLogin.Image");
            btnLogin.Location = new System.Drawing.Point(271, 231);
            btnLogin.Margin = new System.Windows.Forms.Padding(0);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new System.Drawing.Size(243, 33);
            btnLogin.TabIndex = 6;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = System.Drawing.SystemColors.Control;
            btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNext.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            btnNext.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Control;
            btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNext.Image = (System.Drawing.Image)resources.GetObject("btnNext.Image");
            btnNext.Location = new System.Drawing.Point(26, 231);
            btnNext.Margin = new System.Windows.Forms.Padding(0);
            btnNext.Name = "btnNext";
            btnNext.Size = new System.Drawing.Size(241, 33);
            btnNext.TabIndex = 5;
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnClose
            // 
            btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnClose.Image = (System.Drawing.Image)resources.GetObject("btnClose.Image");
            btnClose.Location = new System.Drawing.Point(495, -1);
            btnClose.Margin = new System.Windows.Forms.Padding(0);
            btnClose.Name = "btnClose";
            btnClose.Size = new System.Drawing.Size(44, 32);
            btnClose.TabIndex = 44;
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // pnlBottom
            // 
            pnlBottom.BackColor = System.Drawing.SystemColors.Control;
            pnlBottom.BorderColor = System.Drawing.Color.LightGray;

            pnlBottom.BorderSize = 1;
            pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            pnlBottom.Location = new System.Drawing.Point(0, 208);
            pnlBottom.Margin = new System.Windows.Forms.Padding(2);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new System.Windows.Forms.Padding(3);
            pnlBottom.Size = new System.Drawing.Size(540, 80);
            pnlBottom.TabIndex = 2;
            // 
            // pnlTop
            // 
            pnlTop.BackColor = System.Drawing.SystemColors.Window;
            pnlTop.BorderColor = System.Drawing.Color.LightGray;
     
            pnlTop.BorderSize = 1;
            pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTop.Location = new System.Drawing.Point(0, 0);
            pnlTop.Margin = new System.Windows.Forms.Padding(2);
            pnlTop.Name = "pnlTop";
            pnlTop.Padding = new System.Windows.Forms.Padding(3);
            pnlTop.Size = new System.Drawing.Size(540, 32);
            pnlTop.TabIndex = 1;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(540, 288);
            Controls.Add(btnClose);
            Controls.Add(btnLogin);
            Controls.Add(btnNext);
            Controls.Add(pnlInput);
            Controls.Add(pnlBottom);
            Controls.Add(lblTitle);
            Controls.Add(pnlTop);
            Font = new System.Drawing.Font("Segoe UI Variable Display", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "FormLogin";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Enter License";
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PanelBorderRadiusCustom pnlTop;
        private PanelBorderRadiusCustom pnlBottom;
        private System.Windows.Forms.Panel pnlInput;
        private System.Windows.Forms.Label lblTitle;
        private RJTextBox32 txtUserName;
        private RJTextBox32 txtPassword;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Button btnClose;
    }
}