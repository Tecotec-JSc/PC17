namespace T3ACS.Controls
{
    partial class RowReviewRun
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
        /// Required method for Designer modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RowReviewRun));
            panelBorderRadiusCustom1 = new PanelBorderRadiusCustom();
            lblRange = new Label();
            lblUnit = new Label();
            lblValue = new Label();
            lblTitle = new Label();
            lblNo = new Label();
            panelBorderRadiusCustom1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColor = Color.White;
            panelBorderRadiusCustom1.BackColorG = Color.White;
            panelBorderRadiusCustom1.BorderColor = Color.White;
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(lblRange);
            panelBorderRadiusCustom1.Controls.Add(lblUnit);
            panelBorderRadiusCustom1.Controls.Add(lblValue);
            panelBorderRadiusCustom1.Controls.Add(lblTitle);
            panelBorderRadiusCustom1.Controls.Add(lblNo);
            panelBorderRadiusCustom1.Dock = DockStyle.Fill;
            panelBorderRadiusCustom1.Location = new Point(0, 0);
            panelBorderRadiusCustom1.Margin = new Padding(0);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 0;
            panelBorderRadiusCustom1.RadiusBottomRight = 0;
            panelBorderRadiusCustom1.RadiusTopLeft = 0;
            panelBorderRadiusCustom1.RadiusTopRight = 0;
            panelBorderRadiusCustom1.Size = new Size(1026, 50);
            panelBorderRadiusCustom1.TabIndex = 0;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            // 
            // lblRange
            // 
            lblRange.BackColor = Color.Transparent;
            lblRange.Font = new Font("Segoe UI Variable Display", 10.5F);
            lblRange.ForeColor = Color.Black;
            lblRange.Location = new Point(720, 14);
            lblRange.Name = "lblRange";
            lblRange.Size = new Size(250, 22);
            lblRange.TabIndex = 49;
            lblRange.Text = "Range";
            lblRange.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUnit
            // 
            lblUnit.BackColor = Color.Transparent;
            lblUnit.Font = new Font("Segoe UI Variable Display", 10.5F);
            lblUnit.ForeColor = Color.Black;
            lblUnit.Location = new Point(500, 14);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(200, 22);
            lblUnit.TabIndex = 48;
            lblUnit.Text = "Unit";
            lblUnit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblValue
            // 
            lblValue.BackColor = Color.Transparent;
            lblValue.Font = new Font("Segoe UI Variable Display", 10.5F);
            lblValue.ForeColor = Color.Black;
            lblValue.Location = new Point(285, 14);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(200, 22);
            lblValue.TabIndex = 47;
            lblValue.Text = "Value";
            lblValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.Transparent;
            lblTitle.Font = new Font("Segoe UI Variable Display", 10.5F);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(65, 14);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(200, 22);
            lblTitle.TabIndex = 46;
            lblTitle.Text = "Title";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblNo
            // 
            lblNo.BackColor = Color.Transparent;
            lblNo.Font = new Font("Segoe UI Variable Display", 10.5F);
            lblNo.ForeColor = Color.Black;
            lblNo.Location = new Point(15, 14);
            lblNo.Name = "lblNo";
            lblNo.Size = new Size(40, 22);
            lblNo.TabIndex = 44;
            lblNo.Text = "1";
            lblNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // RowReviewRun
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelBorderRadiusCustom1);
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(0);
            Name = "RowReviewRun";
            Size = new Size(1026, 50);
            panelBorderRadiusCustom1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private Label lblNo;
        private Label lblTitle;
        private Label lblValue;
        private Label lblUnit;
        private Label lblRange;
    }
}
