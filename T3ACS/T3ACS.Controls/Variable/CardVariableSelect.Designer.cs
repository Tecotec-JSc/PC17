namespace T3ACS.Controls.Variable
{
    partial class CardVariableSelect
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
            panelCustomBorder1 = new PanelCustoms.PanelCustomBorder();
            lblDes = new Label();
            lblName = new Label();
            panelCustomBorder1.SuspendLayout();
            SuspendLayout();
            // 
            // panelCustomBorder1
            // 
            panelCustomBorder1.BorderBottom = true;
            panelCustomBorder1.BorderColor = Color.DarkGray;
            panelCustomBorder1.BorderLeft = true;
            panelCustomBorder1.BorderRight = false;
            panelCustomBorder1.BorderSize = 1;
            panelCustomBorder1.BorderTop = true;
            panelCustomBorder1.Controls.Add(lblDes);
            panelCustomBorder1.Controls.Add(lblName);
            panelCustomBorder1.Cursor = Cursors.Hand;
            panelCustomBorder1.Dock = DockStyle.Fill;
            panelCustomBorder1.Location = new Point(0, 0);
            panelCustomBorder1.Name = "panelCustomBorder1";
            panelCustomBorder1.Size = new Size(297, 59);
            panelCustomBorder1.TabIndex = 0;
            panelCustomBorder1.Click += panelCustomBorder1_Click;
            panelCustomBorder1.Enter += CardLable_Enter;
            panelCustomBorder1.Leave += CardLable_Leave;
            panelCustomBorder1.MouseEnter += CardLable_Enter;
            panelCustomBorder1.MouseLeave += CardLable_Leave;
            // 
            // lblDes
            // 
            lblDes.AutoSize = true;
            lblDes.Font = new Font("Segoe UI", 8.25F);
            lblDes.ForeColor = Color.FromArgb(102, 121, 148);
            lblDes.Location = new Point(16, 31);
            lblDes.Name = "lblDes";
            lblDes.Size = new Size(38, 13);
            lblDes.TabIndex = 1;
            lblDes.Text = "label2";
            lblDes.Click += panelCustomBorder1_Click;
            lblDes.Enter += CardLable_Enter;
            lblDes.Leave += CardLable_Leave;
            lblDes.MouseEnter += CardLable_Enter;
            lblDes.MouseLeave += CardLable_Leave;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI Semibold", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.Location = new Point(16, 10);
            lblName.Name = "lblName";
            lblName.Size = new Size(41, 17);
            lblName.TabIndex = 0;
            lblName.Text = "label1";
            lblName.Click += panelCustomBorder1_Click;
            lblName.Enter += CardLable_Enter;
            lblName.Leave += CardLable_Leave;
            lblName.MouseEnter += CardLable_Enter;
            lblName.MouseLeave += CardLable_Leave;
            // 
            // CardVariableSelect
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelCustomBorder1);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CardVariableSelect";
            Size = new Size(297, 59);
            panelCustomBorder1.ResumeLayout(false);
            panelCustomBorder1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PanelCustoms.PanelCustomBorder panelCustomBorder1;
        private Label lblName;
        private Label lblDes;
    }
}
