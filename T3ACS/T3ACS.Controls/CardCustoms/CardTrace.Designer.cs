namespace T3ACS.Controls.CardCustoms
{
    partial class CardTrace
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
            lblIconStatus = new Label();
            lblTraceId = new Label();
            lblStatusMarker = new Label();
            lblMarkerTitle = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            lblChannelId = new Label();
            lblStatus = new Label();
            SuspendLayout();
            // 
            // lblIconStatus
            // 
            lblIconStatus.Image = Properties.Resources.iconActive;
            lblIconStatus.Location = new Point(9, 7);
            lblIconStatus.Name = "lblIconStatus";
            lblIconStatus.Size = new Size(20, 20);
            lblIconStatus.TabIndex = 10;
            // 
            // lblTraceId
            // 
            lblTraceId.Font = new Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTraceId.ForeColor = Color.FromArgb(5, 7, 72);
            lblTraceId.Location = new Point(123, 27);
            lblTraceId.Margin = new Padding(0);
            lblTraceId.Name = "lblTraceId";
            lblTraceId.Size = new Size(89, 15);
            lblTraceId.TabIndex = 9;
            lblTraceId.Text = "2.50 GHz";
            lblTraceId.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStatusMarker
            // 
            lblStatusMarker.Font = new Font("Segoe UI", 6.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatusMarker.ForeColor = Color.FromArgb(0, 166, 62);
            lblStatusMarker.Location = new Point(168, 11);
            lblStatusMarker.Margin = new Padding(0);
            lblStatusMarker.Name = "lblStatusMarker";
            lblStatusMarker.Size = new Size(44, 12);
            lblStatusMarker.TabIndex = 6;
            lblStatusMarker.Text = "Running";
            lblStatusMarker.TextAlign = ContentAlignment.TopRight;
            // 
            // lblMarkerTitle
            // 
            lblMarkerTitle.Font = new Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMarkerTitle.ForeColor = Color.FromArgb(5, 7, 72);
            lblMarkerTitle.Location = new Point(29, 10);
            lblMarkerTitle.Margin = new Padding(0);
            lblMarkerTitle.Name = "lblMarkerTitle";
            lblMarkerTitle.Size = new Size(20, 15);
            lblMarkerTitle.TabIndex = 4;
            lblMarkerTitle.Text = "S11";
            lblMarkerTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(5, 7, 72);
            label1.Location = new Point(10, 27);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(50, 15);
            label1.TabIndex = 4;
            label1.Text = "Trace ID:";
            label1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(5, 7, 72);
            label2.Location = new Point(10, 43);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 4;
            label2.Text = "Channel:";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(5, 7, 72);
            label3.Location = new Point(10, 59);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(80, 15);
            label3.TabIndex = 4;
            label3.Text = "Status:";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblChannelId
            // 
            lblChannelId.Font = new Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblChannelId.ForeColor = Color.FromArgb(5, 7, 72);
            lblChannelId.Location = new Point(123, 46);
            lblChannelId.Margin = new Padding(0);
            lblChannelId.Name = "lblChannelId";
            lblChannelId.Size = new Size(89, 15);
            lblChannelId.TabIndex = 9;
            lblChannelId.Text = "2.50 GHz";
            lblChannelId.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblStatus
            // 
            lblStatus.Font = new Font("Segoe UI", 7.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStatus.ForeColor = Color.FromArgb(5, 7, 72);
            lblStatus.Location = new Point(123, 62);
            lblStatus.Margin = new Padding(0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(89, 15);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "2.50 GHz";
            lblStatus.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CardTrace
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblIconStatus);
            Controls.Add(lblStatus);
            Controls.Add(lblChannelId);
            Controls.Add(lblTraceId);
            Controls.Add(lblStatusMarker);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblMarkerTitle);
            Name = "CardTrace";
            Size = new Size(228, 82);
            DoubleClick += CardTrace_DoubleClick;
            ResumeLayout(false);
        }

        #endregion

        private Label lblIconStatus;
        private Label lblTraceId;
        private Label lblStatusMarker;
        private Label lblMarkerTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label lblChannelId;
        private Label lblStatus;
    }
}
