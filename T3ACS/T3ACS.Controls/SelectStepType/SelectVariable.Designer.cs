namespace T3ACS.Controls
{
    partial class SelectVariable
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
            lblText = new Label();
            label1 = new Label();
            panel1 = new Panel();
            panelSelected = new FlowLayoutPanel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblText
            // 
            lblText.AutoSize = true;
            lblText.BackColor = Color.White;
            lblText.Font = new Font("Segoe UI", 10.5F);
            lblText.ForeColor = Color.FromArgb(0, 32, 77);
            lblText.Location = new Point(15, 11);
            lblText.Name = "lblText";
            lblText.Size = new Size(44, 19);
            lblText.TabIndex = 1;
            lblText.Text = "Select";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.BackColor = Color.White;
            label1.Image = Properties.Resources.ArrowDown;
            label1.Location = new Point(810, 5);
            label1.Name = "label1";
            label1.Size = new Size(31, 29);
            label1.TabIndex = 2;
            label1.Click += OpenPopup;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblText);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(845, 40);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // panelSelected
            // 
            panelSelected.Dock = DockStyle.Top;
            panelSelected.Location = new Point(0, 40);
            panelSelected.Margin = new Padding(0);
            panelSelected.Name = "panelSelected";
            panelSelected.Size = new Size(845, 26);
            panelSelected.TabIndex = 4;
            // 
            // SelectVariable
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelSelected);
            Controls.Add(panel1);
            Font = new Font("Segoe UI", 10.5F);
            Margin = new Padding(0);
            Name = "SelectVariable";
            Size = new Size(845, 68);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label lblText;
        private Label label1;
        private Panel panel1;
        private FlowLayoutPanel panelSelected;
    }
}
