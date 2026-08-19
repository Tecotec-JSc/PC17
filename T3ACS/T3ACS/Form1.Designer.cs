using T3ACS.Controls;

namespace T3ACS
{
    partial class Form1
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            toolTip1 = new ToolTip(components);
            toolTip2 = new ToolTip(components);
            toolTip3 = new ToolTip(components);
            label5 = new Label();
            label1 = new Label();
            label4 = new Label();
            lblCheckAll = new Label();
            panelBorderControl2 = new PanelBorderRadiusCustom();
            selectVariable1 = new SelectVariable();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(0, 32, 77);
            label5.Location = new Point(865, 249);
            label5.Name = "label5";
            label5.Size = new Size(58, 19);
            label5.TabIndex = 15;
            label5.Text = "Actions";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 32, 77);
            label1.Location = new Point(463, 249);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 14;
            label1.Text = "Value";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 32, 77);
            label4.Location = new Point(61, 249);
            label4.Name = "label4";
            label4.Size = new Size(38, 19);
            label4.TabIndex = 13;
            label4.Text = "Title";
            // 
            // lblCheckAll
            // 
            lblCheckAll.Image = (Image)resources.GetObject("lblCheckAll.Image");
            lblCheckAll.Location = new Point(1, 238);
            lblCheckAll.Name = "lblCheckAll";
            lblCheckAll.Size = new Size(43, 43);
            lblCheckAll.TabIndex = 12;
            // 
            // panelBorderControl2
            // 
            panelBorderControl2.BackColor = Color.FromArgb(243, 242, 241);
            panelBorderControl2.BorderColor = Color.DarkGray;
            panelBorderControl2.BorderSize = 1;
            panelBorderControl2.Dock = DockStyle.Top;
            panelBorderControl2.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl2.Location = new Point(0, 0);
            panelBorderControl2.Margin = new Padding(0);
            panelBorderControl2.Name = "panelBorderControl2";
            panelBorderControl2.Padding = new Padding(2);
            panelBorderControl2.Size = new Size(1118, 45);
            panelBorderControl2.TabIndex = 11;
            // 
            // selectVariable1
            // 
            selectVariable1._DataInputs = null;
            selectVariable1._SelectedValues = null;
            selectVariable1.BackColor = Color.White;
            selectVariable1.Font = new Font("Segoe UI", 10.5F);
            selectVariable1.Location = new Point(92, 60);
            selectVariable1.Margin = new Padding(3, 4, 3, 4);
            selectVariable1.Name = "selectVariable1";
            selectVariable1.Size = new Size(845, 68);
            selectVariable1.TabIndex = 16;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 519);
            Controls.Add(selectVariable1);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(lblCheckAll);
            Controls.Add(panelBorderControl2);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.ToolTip toolTip3;
        private Label label5;
        private Label label1;
        private Label label4;
        private Label lblCheckAll;
        private PanelBorderRadiusCustom panelBorderControl2;
        private SelectVariable selectVariable1;
    }
}

