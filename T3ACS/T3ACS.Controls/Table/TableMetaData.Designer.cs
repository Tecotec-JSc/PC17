using T3ACS.Controls.PanelCustoms;

namespace T3ACS.Controls
{
    partial class TableMetaData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableMetaData));
            panelTableBody = new FlowLayoutPanel();
            panelControl1 = new PanelCustomBorder();
            label5 = new Label();
            label1 = new Label();
            label4 = new Label();
            lblbtnCheckAll = new Label();
            SuspendLayout();
            // 
            // panelTableBody
            // 
            panelTableBody.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelTableBody.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTableBody.BackColor = Color.White;
            panelTableBody.FlowDirection = FlowDirection.TopDown;
            panelTableBody.Font = new Font("Segoe UI Variable Text", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelTableBody.ForeColor = Color.FromArgb(0, 32, 77);
            panelTableBody.Location = new Point(0, 42);
            panelTableBody.Margin = new Padding(0);
            panelTableBody.Name = "panelTableBody";
            panelTableBody.Size = new Size(1040, 163);
            panelTableBody.TabIndex = 21;
            panelTableBody.WrapContents = false;
            // 
            // panelControl1
            // 
            panelControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelControl1.BackColor = Color.FromArgb(243, 242, 241);
            panelControl1.BorderColor = Color.DarkGray;
            panelControl1.BorderSize = 1;
            panelControl1.Location = new Point(0, 0);
            panelControl1.Margin = new Padding(0);
            panelControl1.Name = "panelControl1";
            panelControl1.Padding = new Padding(2);
            panelControl1.Size = new Size(1040, 42);
            panelControl1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(243, 242, 241);
            label5.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(0, 32, 77);
            label5.Location = new Point(868, 11);
            label5.Name = "label5";
            label5.Size = new Size(58, 19);
            label5.TabIndex = 31;
            label5.Text = "Actions";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(243, 242, 241);
            label1.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 32, 77);
            label1.Location = new Point(494, 11);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 30;
            label1.Text = "Value";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.FromArgb(243, 242, 241);
            label4.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(0, 32, 77);
            label4.Location = new Point(68, 11);
            label4.Name = "label4";
            label4.Size = new Size(38, 19);
            label4.TabIndex = 29;
            label4.Text = "Title";
            // 
            // lblbtnCheckAll
            // 
            lblbtnCheckAll.BackColor = Color.FromArgb(243, 242, 241);
            lblbtnCheckAll.Cursor = Cursors.Hand;
            lblbtnCheckAll.Image = (Image)resources.GetObject("lblbtnCheckAll.Image");
            lblbtnCheckAll.Location = new Point(6, 4);
            lblbtnCheckAll.Name = "lblbtnCheckAll";
            lblbtnCheckAll.Size = new Size(41, 36);
            lblbtnCheckAll.TabIndex = 28;
            lblbtnCheckAll.Click += lblbtnCheckAll_Click;
            // 
            // TableMetaData
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(lblbtnCheckAll);
            Controls.Add(panelControl1);
            Controls.Add(panelTableBody);
            Name = "TableMetaData";
            Size = new Size(1040, 205);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private FlowLayoutPanel panelTableBody;
        private PanelCustomBorder panelControl1;
        private Label label5;
        private Label label1;
        private Label label4;
        private Label lblbtnCheckAll;
    }
}
