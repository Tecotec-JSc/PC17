
using T3ACS.Controls;

namespace T3ACS
{
    partial class FormSimulation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSimulation));
            panel1 = new Panel();
            btnSImulation = new Button();
            label1 = new Label();
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
            panel1.Controls.Add(btnSImulation);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Segoe UI Variable Display", 10.5F);
            panel1.Location = new Point(0, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(540, 130);
            panel1.TabIndex = 39;
            // 
            // btnSImulation
            // 
            btnSImulation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSImulation.BackColor = Color.Transparent;
            btnSImulation.FlatAppearance.BorderSize = 0;
            btnSImulation.FlatStyle = FlatStyle.Flat;
            btnSImulation.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnSImulation.Image = Properties.Resources.Base_ControlNoActive;
            btnSImulation.Location = new Point(454, 20);
            btnSImulation.Margin = new Padding(0);
            btnSImulation.Name = "btnSImulation";
            btnSImulation.Size = new Size(67, 33);
            btnSImulation.TabIndex = 42;
            btnSImulation.UseVisualStyleBackColor = false;
            btnSImulation.Click += btnSImulation_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label1.Location = new Point(29, 27);
            label1.Name = "label1";
            label1.Size = new Size(124, 19);
            label1.TabIndex = 2;
            label1.Text = "Simulation Status";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 6);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(79, 19);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Simulation";
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
            btnSave.Location = new Point(409, 176);
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
            btnCancel.Location = new Point(295, 176);
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
            panelControlbottom1.Location = new Point(0, 162);
            panelControlbottom1.Margin = new Padding(3, 4, 3, 4);
            panelControlbottom1.Name = "panelControlbottom1";
            panelControlbottom1.Padding = new Padding(3, 4, 3, 4);
            panelControlbottom1.Size = new Size(540, 60);
            panelControlbottom1.TabIndex = 38;
            // 
            // FormSimulation
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(540, 222);
            Controls.Add(btnSave);
            Controls.Add(btnCancel);
            Controls.Add(panel1);
            Controls.Add(panelControlbottom1);
            Controls.Add(panel2);
            Font = new Font("Segoe UI Variable Display", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormSimulation";
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
        private PanelBorderRadiusCustom panelControlbottom1;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private Label label1;
        private Button btnSImulation;
    }
}