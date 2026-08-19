namespace T3ACS.Controls.Table
{
    partial class RowNodata
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RowNodata));
            label1 = new Label();
            panelBorderRadiusCustom1 = new PanelBorderRadiusCustom();
            panelBorderRadiusCustom1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.FromArgb(125, 142, 164);
            label1.Location = new Point(380, 35);
            label1.Name = "label1";
            label1.Size = new Size(281, 19);
            label1.TabIndex = 0;
            label1.Text = "No rows added yet. Click \"Add Row\" to start.";
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColor = Color.White;
            panelBorderRadiusCustom1.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(label1);
            panelBorderRadiusCustom1.Dock = DockStyle.Fill;
            panelBorderRadiusCustom1.Location = new Point(0, 0);
            panelBorderRadiusCustom1.Margin = new Padding(0);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 5;
            panelBorderRadiusCustom1.RadiusBottomRight = 5;
            panelBorderRadiusCustom1.RadiusTopLeft = 0;
            panelBorderRadiusCustom1.RadiusTopRight = 0;
            panelBorderRadiusCustom1.Size = new Size(1021, 88);
            panelBorderRadiusCustom1.TabIndex = 1;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            // 
            // RowNodata
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelBorderRadiusCustom1);
            Font = new Font("Segoe UI", 10.5F);
            Margin = new Padding(3, 4, 3, 4);
            Name = "RowNodata";
            Size = new Size(1021, 88);
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelBorderRadiusCustom1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private PanelBorderRadiusCustom panelBorderRadiusCustom1;
    }
}
