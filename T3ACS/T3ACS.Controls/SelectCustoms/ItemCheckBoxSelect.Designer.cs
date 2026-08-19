namespace T3ACS.Controls.SelectCustoms
{
    partial class ItemCheckBoxSelect
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemCheckBoxSelect));
            panelBorderRadiusCustom1 = new PanelBorderRadiusCustom();
            checkBoxCustom1 = new CheckBoxCustom();
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
            panelBorderRadiusCustom1.Controls.Add(checkBoxCustom1);
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
            panelBorderRadiusCustom1.MouseEnter += ItemCheckBoxSelect_MouseEnter;
            panelBorderRadiusCustom1.MouseLeave += ItemCheckBoxSelect_MouseLeave;
            // 
            // checkBoxCustom1
            // 
            checkBoxCustom1.BoxBackCheckColor = Color.FromArgb(191, 216, 230);
            checkBoxCustom1.BoxBackColor = Color.White;
            checkBoxCustom1.BoxBorderColor = Color.DarkGray;
            checkBoxCustom1.BoxSize = 20;
            checkBoxCustom1.CheckColor = Color.FromArgb(0, 82, 130);
            checkBoxCustom1.Location = new Point(10, 8);
            checkBoxCustom1.Name = "checkBoxCustom1";
            checkBoxCustom1.Size = new Size(22, 22);
            checkBoxCustom1.TabIndex = 1;
            checkBoxCustom1.UseVisualStyleBackColor = true;
            checkBoxCustom1.CheckedChanged += checkBoxCustom1_CheckedChanged;
            checkBoxCustom1.Click += checkBoxCustom1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 9);
            label1.Name = "label1";
            label1.Size = new Size(45, 19);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.MouseEnter += ItemCheckBoxSelect_MouseEnter;
            label1.MouseLeave += ItemCheckBoxSelect_MouseLeave;
            // 
            // ItemCheckBoxSelect
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panelBorderRadiusCustom1);
            Cursor = Cursors.Hand;
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(3, 5, 51);
            Margin = new Padding(0);
            Name = "ItemCheckBoxSelect";
            Size = new Size(495, 38);
            MouseEnter += ItemCheckBoxSelect_MouseEnter;
            MouseLeave += ItemCheckBoxSelect_MouseLeave;
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelBorderRadiusCustom1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private Label label1;
        private CheckBoxCustom checkBoxCustom1;
    }
}
