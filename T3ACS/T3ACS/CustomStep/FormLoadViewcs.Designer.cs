namespace T3ACS
{
    partial class FormLoadViewcs
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
            rdoDefault = new RadioButton();
            rdoViewCustom = new RadioButton();
            panel1 = new Panel();
            panelViewContent = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // rdoDefault
            // 
            rdoDefault.AutoSize = true;
            rdoDefault.Checked = true;
            rdoDefault.Location = new Point(9, 7);
            rdoDefault.Name = "rdoDefault";
            rdoDefault.Size = new Size(104, 23);
            rdoDefault.TabIndex = 0;
            rdoDefault.TabStop = true;
            rdoDefault.Text = "View Default";
            rdoDefault.UseVisualStyleBackColor = true;
            // 
            // rdoViewCustom
            // 
            rdoViewCustom.AutoSize = true;
            rdoViewCustom.Location = new Point(139, 7);
            rdoViewCustom.Name = "rdoViewCustom";
            rdoViewCustom.Size = new Size(108, 23);
            rdoViewCustom.TabIndex = 1;
            rdoViewCustom.TabStop = true;
            rdoViewCustom.Text = "View Custom";
            rdoViewCustom.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Controls.Add(rdoViewCustom);
            panel1.Controls.Add(rdoDefault);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1034, 37);
            panel1.TabIndex = 2;
            // 
            // panelViewContent
            // 
            panelViewContent.Dock = DockStyle.Fill;
            panelViewContent.Location = new Point(0, 37);
            panelViewContent.Name = "panelViewContent";
            panelViewContent.Size = new Size(1034, 315);
            panelViewContent.TabIndex = 3;
            // 
            // FormLoadViewcs
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 352);
            Controls.Add(panelViewContent);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormLoadViewcs";
            Text = "FormLoadViewcs";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RadioButton rdoDefault;
        private RadioButton rdoViewCustom;
        private Panel panel1;
        private Panel panelViewContent;
    }
}