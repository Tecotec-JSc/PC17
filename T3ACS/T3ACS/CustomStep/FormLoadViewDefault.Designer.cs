namespace T3ACS.CustomStep
{
    partial class FormLoadViewDefault
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoadViewDefault));
            btnAddVariable = new Button();
            panel1 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label1 = new Label();
            panel1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddVariable
            // 
            btnAddVariable.BackColor = Color.White;
            btnAddVariable.FlatAppearance.BorderSize = 0;
            btnAddVariable.FlatAppearance.MouseDownBackColor = Color.White;
            btnAddVariable.FlatAppearance.MouseOverBackColor = Color.White;
            btnAddVariable.FlatStyle = FlatStyle.Flat;
            btnAddVariable.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnAddVariable.Image = (Image)resources.GetObject("btnAddVariable.Image");
            btnAddVariable.Location = new Point(7, 3);
            btnAddVariable.Margin = new Padding(0);
            btnAddVariable.Name = "btnAddVariable";
            btnAddVariable.Size = new Size(137, 35);
            btnAddVariable.TabIndex = 58;
            btnAddVariable.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnAddVariable);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1034, 43);
            panel1.TabIndex = 59;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(label1);
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 43);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1034, 309);
            flowLayoutPanel1.TabIndex = 60;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            label1.Location = new Point(12, 4);
            label1.Margin = new Padding(12, 4, 0, 0);
            label1.Name = "label1";
            label1.Size = new Size(64, 19);
            label1.TabIndex = 0;
            label1.Text = "PreView";
            // 
            // FormLoadViewDefault
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1034, 352);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormLoadViewDefault";
            Text = "FormLoadViewDefault";
            panel1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button btnAddVariable;
        private Panel panel1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label1;
    }
}