namespace T3ACS
{
    partial class FormCustomStepPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomStepPopup));
            panelContent = new Panel();
            panelTitle = new Panel();
            lblClose = new Label();
            lblTitleForm = new Label();
            btnChooseTemplate = new Button();
            btnCancel = new Button();
            panelTitle.SuspendLayout();
            SuspendLayout();
            // 
            // panelContent
            // 
            panelContent.Location = new Point(1, 63);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1078, 587);
            panelContent.TabIndex = 0;
            panelContent.Paint += panelContent_Paint;
            // 
            // panelTitle
            // 
            panelTitle.Controls.Add(lblClose);
            panelTitle.Controls.Add(lblTitleForm);
            panelTitle.Location = new Point(5, 3);
            panelTitle.Name = "panelTitle";
            panelTitle.Size = new Size(1070, 58);
            panelTitle.TabIndex = 0;
            panelTitle.MouseDown += panelTitle_MouseDown;
            // 
            // lblClose
            // 
            lblClose.Cursor = Cursors.Hand;
            lblClose.Font = new Font("Segoe UI Variable Display", 10.5F);
            lblClose.Image = (Image)resources.GetObject("lblClose.Image");
            lblClose.Location = new Point(1028, 14);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(35, 29);
            lblClose.TabIndex = 5;
            lblClose.Click += lblClose_Click;
            // 
            // lblTitleForm
            // 
            lblTitleForm.AutoSize = true;
            lblTitleForm.BackColor = Color.Transparent;
            lblTitleForm.Font = new Font("Segoe UI Variable Text", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleForm.ForeColor = Color.FromArgb(0, 32, 77);
            lblTitleForm.Location = new Point(16, 16);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(345, 27);
            lblTitleForm.TabIndex = 1;
            lblTitleForm.Text = "Configure Step Template - Customs";
            lblTitleForm.MouseDown += panelTitle_MouseDown;
            // 
            // btnChooseTemplate
            // 
            btnChooseTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnChooseTemplate.BackColor = Color.FromArgb(249, 250, 251);
            btnChooseTemplate.Cursor = Cursors.Hand;
            btnChooseTemplate.FlatAppearance.BorderSize = 0;
            btnChooseTemplate.FlatAppearance.MouseDownBackColor = Color.FromArgb(249, 250, 251);
            btnChooseTemplate.FlatAppearance.MouseOverBackColor = Color.FromArgb(249, 250, 251);
            btnChooseTemplate.FlatStyle = FlatStyle.Flat;
            btnChooseTemplate.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnChooseTemplate.Image = (Image)resources.GetObject("btnChooseTemplate.Image");
            btnChooseTemplate.Location = new Point(964, 663);
            btnChooseTemplate.Margin = new Padding(0);
            btnChooseTemplate.Name = "btnChooseTemplate";
            btnChooseTemplate.Size = new Size(92, 38);
            btnChooseTemplate.TabIndex = 56;
            btnChooseTemplate.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.BackColor = Color.White;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.White;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            btnCancel.Location = new Point(852, 663);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(92, 38);
            btnCancel.TabIndex = 57;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FormCustomStepPopup
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1080, 720);
            Controls.Add(btnChooseTemplate);
            Controls.Add(btnCancel);
            Controls.Add(panelTitle);
            Controls.Add(panelContent);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1080, 720);
            MinimumSize = new Size(1080, 720);
            Name = "FormCustomStepPopup";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCustomStepPopup";
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContent;
        private Panel panelTitle;
        private Label lblTitleForm;
        private Label lblClose;
        private Button btnChooseTemplate;
        private Button btnCancel;
    }
}