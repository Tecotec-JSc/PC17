namespace T3ACS.Controls.SelectCustoms
{
    partial class ItemSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemSelect));
            panelBorderRadiusCustom1 = new PanelBorderRadiusCustom();
            label1 = new Label();
            panelBorderRadiusCustom1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColor = Color.White;
            panelBorderRadiusCustom1.BackColorG = Color.White;
            panelBorderRadiusCustom1.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(label1);
            panelBorderRadiusCustom1.Cursor = Cursors.Hand;
            panelBorderRadiusCustom1.Dock = DockStyle.Fill;
            panelBorderRadiusCustom1.ForeColor = Color.FromArgb(3, 5, 51);
            panelBorderRadiusCustom1.Location = new Point(0, 0);
            panelBorderRadiusCustom1.Margin = new Padding(0);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 0;
            panelBorderRadiusCustom1.RadiusBottomRight = 0;
            panelBorderRadiusCustom1.RadiusTopLeft = 0;
            panelBorderRadiusCustom1.RadiusTopRight = 0;
            panelBorderRadiusCustom1.Size = new Size(495, 38);
            panelBorderRadiusCustom1.TabIndex = 0;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            panelBorderRadiusCustom1.Click += ItemSelect_Click;
            panelBorderRadiusCustom1.MouseEnter += ItemSelect_MouseEnter;
            panelBorderRadiusCustom1.MouseLeave += ItemSelect_MouseLeave;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 10);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.Click += ItemSelect_Click;
            label1.MouseEnter += ItemSelect_MouseEnter;
            label1.MouseLeave += ItemSelect_MouseLeave;
            // 
            // ItemSelect
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelBorderRadiusCustom1);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(3, 5, 51);
            Margin = new Padding(0);
            Name = "ItemSelect";
            Size = new Size(495, 38);
            Click += ItemSelect_Click;
            MouseEnter += ItemSelect_MouseEnter;
            MouseLeave += ItemSelect_MouseLeave;
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelBorderRadiusCustom1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private Label label1;
    }
}
