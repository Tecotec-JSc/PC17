
using T3ACS.Controls;

namespace T3ACS
{
    partial class FormBlank
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBlank));
            pnlBody = new Panel();
            lblTitle = new Label();
            pnlTitle = new Panel();
            lblClose = new Label();
            lblExtra = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            pnlBottom = new PanelBorderRadiusCustom();
            pnlTitle.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBody
            // 
            pnlBody.BackColor = Color.FromArgb(243, 245, 249);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Font = new Font("Segoe UI Variable Display", 10.5F);
            pnlBody.Location = new Point(0, 32);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(540, 437);
            pnlBody.TabIndex = 39;
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
            // pnlTitle
            // 
            pnlTitle.BackColor = SystemColors.Window;
            pnlTitle.Controls.Add(lblClose);
            pnlTitle.Controls.Add(lblExtra);
            pnlTitle.Controls.Add(lblTitle);
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Font = new Font("Segoe UI Variable Display", 10.5F);
            pnlTitle.Location = new Point(0, 0);
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Size = new Size(540, 32);
            pnlTitle.TabIndex = 37;
            pnlTitle.MouseDown += pnlTitle_MouseDown;
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
            // lblExtra
            // 
            lblExtra.Font = new Font("Segoe UI Variable Display", 10.5F);
            lblExtra.Image = (Image)resources.GetObject("lblExtra.Image");
            lblExtra.Location = new Point(1031, 3);
            lblExtra.Name = "lblExtra";
            lblExtra.Size = new Size(35, 24);
            lblExtra.TabIndex = 2;
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
            // pnlBottom
            // 
            pnlBottom.BackColor = SystemColors.Window;
            pnlBottom.BorderColor = Color.LightGray;
            pnlBottom.BorderSize = 1;
            pnlBottom.Dock = DockStyle.Bottom;
            pnlBottom.Font = new Font("Segoe UI Variable Display", 10.5F);
            pnlBottom.Location = new Point(0, 469);
            pnlBottom.Margin = new Padding(3, 4, 3, 4);
            pnlBottom.Name = "pnlBottom";
            pnlBottom.Padding = new Padding(3, 4, 3, 4);
            pnlBottom.Size = new Size(540, 60);
            pnlBottom.TabIndex = 38;
            // 
            // FormBlank
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 529);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(pnlBody);
            Controls.Add(pnlBottom);
            Controls.Add(pnlTitle);
            Font = new Font("Segoe UI Variable Display", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormBlank";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Blank";
            pnlTitle.ResumeLayout(false);
            pnlTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlBody;
        private PanelBorderRadiusCustom pnlBottom;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblExtra;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlTitle;
    }
}