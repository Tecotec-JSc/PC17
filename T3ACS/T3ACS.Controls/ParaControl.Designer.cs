namespace  T3ACS.Controls
{
    partial class ParaControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParaControl));
            label1 = new Label();
            lblDefaultTitle = new Label();
            lblTextName = new Label();
            lblTextValue = new Label();
            lblTextRank = new Label();
            btnEdit = new ButtonControl();
            btnRemove = new ButtonControl();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(20, 20);
            label1.TabIndex = 0;
            // 
            // lblDefaultTitle
            // 
            lblDefaultTitle.AutoSize = true;
            lblDefaultTitle.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDefaultTitle.Location = new Point(38, 13);
            lblDefaultTitle.Name = "lblDefaultTitle";
            lblDefaultTitle.Size = new Size(47, 19);
            lblDefaultTitle.TabIndex = 1;
            lblDefaultTitle.Text = "label2";
            // 
            // lblTextName
            // 
            lblTextName.AutoSize = true;
            lblTextName.Location = new Point(12, 45);
            lblTextName.Name = "lblTextName";
            lblTextName.Size = new Size(90, 19);
            lblTextName.TabIndex = 3;
            lblTextName.Text = "Name: Value1";
            // 
            // lblTextValue
            // 
            lblTextValue.AutoSize = true;
            lblTextValue.Location = new Point(12, 70);
            lblTextValue.Name = "lblTextValue";
            lblTextValue.Size = new Size(57, 19);
            lblTextValue.TabIndex = 3;
            lblTextValue.Text = "Value: 7";
            // 
            // lblTextRank
            // 
            lblTextRank.AutoSize = true;
            lblTextRank.Location = new Point(12, 95);
            lblTextRank.Name = "lblTextRank";
            lblTextRank.Size = new Size(54, 19);
            lblTextRank.TabIndex = 3;
            lblTextRank.Text = "Rank: 7";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.White;
            btnEdit.BorderColor = Color.FromArgb(227, 242, 253);
            btnEdit.BorderFocusColor = Color.FromArgb(3, 120, 212);
            btnEdit.BorderRadius = 5;
            btnEdit.BorderSize = 1;
            btnEdit.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEdit.HoverColors = Color.Gainsboro;
            btnEdit.Location = new Point(911, 12);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(49, 34);
            btnEdit.TabIndex = 4;
            btnEdit.Texts = "Edit";
            btnEdit.Click += btnEdit_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.White;
            btnRemove.BorderColor = Color.FromArgb(227, 242, 253);
            btnRemove.BorderFocusColor = Color.FromArgb(3, 120, 212);
            btnRemove.BorderRadius = 5;
            btnRemove.BorderSize = 1;
            btnRemove.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnRemove.HoverColors = Color.Gainsboro;
            btnRemove.Location = new Point(976, 12);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(80, 34);
            btnRemove.TabIndex = 4;
            btnRemove.Texts = "Remove";
            btnRemove.Click += btnRemove_Click;
            // 
            // ParaControl
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(btnRemove);
            Controls.Add(btnEdit);
            Controls.Add(lblTextRank);
            Controls.Add(lblTextValue);
            Controls.Add(lblTextName);
            Controls.Add(lblDefaultTitle);
            Controls.Add(label1);
            Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            Name = "ParaControl";
            Size = new Size(1072, 128);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblDefaultTitle;
        private Label lblTextName;
        private Label lblTextValue;
        private Label lblTextRank;
        private ButtonControl btnEdit;
        private ButtonControl btnRemove;
    }
}
