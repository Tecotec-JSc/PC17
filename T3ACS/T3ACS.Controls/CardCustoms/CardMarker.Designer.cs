namespace T3ACS.Controls
{
    partial class CardMarker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardMarker));
            lblMarkerTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            lblStatusMarker = new Label();
            lblPosition = new Label();
            lblValue = new Label();
            lblClose = new Label();
            SuspendLayout();
            // 
            // lblMarkerTitle
            // 
            lblMarkerTitle.AutoSize = true;
            lblMarkerTitle.Font = new Font("Segoe UI Semibold", 8.25F, FontStyle.Bold);
            lblMarkerTitle.Location = new Point(9, 9);
            lblMarkerTitle.Margin = new Padding(0);
            lblMarkerTitle.Name = "lblMarkerTitle";
            lblMarkerTitle.Size = new Size(50, 13);
            lblMarkerTitle.TabIndex = 0;
            lblMarkerTitle.Text = "Marker 1";
            lblMarkerTitle.Click += CardMarker_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 6.75F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(106, 106, 142);
            label1.Location = new Point(9, 33);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(38, 12);
            label1.TabIndex = 1;
            label1.Text = "Position:";
            label1.Click += CardMarker_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 6.75F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(106, 106, 142);
            label2.Location = new Point(9, 49);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(29, 12);
            label2.TabIndex = 1;
            label2.Text = "Value:";
            label2.Click += CardMarker_Click;
            // 
            // lblStatusMarker
            // 
            lblStatusMarker.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusMarker.ForeColor = Color.FromArgb(0, 166, 62);
            lblStatusMarker.Location = new Point(153, 10);
            lblStatusMarker.Margin = new Padding(0);
            lblStatusMarker.Name = "lblStatusMarker";
            lblStatusMarker.Size = new Size(44, 12);
            lblStatusMarker.TabIndex = 1;
            lblStatusMarker.Text = "Active";
            lblStatusMarker.TextAlign = ContentAlignment.TopRight;
            lblStatusMarker.Click += CardMarker_Click;
            // 
            // lblPosition
            // 
            lblPosition.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPosition.ForeColor = Color.FromArgb(5, 7, 72);
            lblPosition.Location = new Point(97, 33);
            lblPosition.Margin = new Padding(0);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(100, 12);
            lblPosition.TabIndex = 2;
            lblPosition.Text = "2.50 GHz";
            lblPosition.TextAlign = ContentAlignment.TopRight;
            lblPosition.Click += CardMarker_Click;
            // 
            // lblValue
            // 
            lblValue.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblValue.ForeColor = Color.FromArgb(5, 7, 72);
            lblValue.Location = new Point(97, 49);
            lblValue.Margin = new Padding(0);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(100, 12);
            lblValue.TabIndex = 2;
            lblValue.Text = "-15.0 dB";
            lblValue.TextAlign = ContentAlignment.TopRight;
            lblValue.Click += CardMarker_Click;
            // 
            // lblClose
            // 
            lblClose.Image = (Image)resources.GetObject("lblClose.Image");
            lblClose.Location = new Point(198, 26);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(20, 20);
            lblClose.TabIndex = 3;
            lblClose.Click += lblClose_Click;
            lblClose.MouseEnter += UserControl_MouseEnter;
            lblClose.MouseLeave += UserControl_MouseLeave;
            // 
            // CardMarker
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblClose);
            Controls.Add(lblValue);
            Controls.Add(lblPosition);
            Controls.Add(label2);
            Controls.Add(lblStatusMarker);
            Controls.Add(label1);
            Controls.Add(lblMarkerTitle);
            Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            ForeColor = Color.FromArgb(5, 7, 72);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CardMarker";
            Size = new Size(227, 74);
            Click += CardMarker_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMarkerTitle;
        private Label label1;
        private Label label2;
        private Label lblStatusMarker;
        private Label lblPosition;
        private Label lblValue;
        private Label lblClose;
    }
}
