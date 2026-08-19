namespace T3ACS.StepDefault
{
    partial class FormURLConfiguration
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
            lblFormTitle = new Label();
            btnAddUrl = new Controls.ButtonControl();
            flowLayoutPanelCards = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // lblFormTitle
            // 
            lblFormTitle.AutoSize = true;
            lblFormTitle.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFormTitle.ForeColor = Color.White;
            lblFormTitle.Location = new Point(15, 18);
            lblFormTitle.Name = "lblFormTitle";
            lblFormTitle.Size = new Size(126, 19);
            lblFormTitle.TabIndex = 0;
            lblFormTitle.Text = "URL Configuration";
            // 
            // btnAddUrl
            // 
            btnAddUrl.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddUrl.BackColor = Color.FromArgb(0, 162, 194);
            btnAddUrl.BackColors = Color.FromArgb(0, 162, 194);
            btnAddUrl.BorderColor = Color.FromArgb(0, 162, 194);
            btnAddUrl.BorderFocusColor = Color.FromArgb(0, 180, 216);
            btnAddUrl.BorderRadius = 5;
            btnAddUrl.BorderSize = 1;
            btnAddUrl.Font = new Font("Segoe UI Variable Text Semiligh", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddUrl.ForeColors = Color.White;
            btnAddUrl.HoverColors = Color.FromArgb(0, 180, 216);
            btnAddUrl.Location = new Point(782, 12);
            btnAddUrl.Name = "btnAddUrl";
            btnAddUrl.Size = new Size(117, 34);
            btnAddUrl.TabIndex = 1;
            btnAddUrl.Texts = "+ Add URL";
            btnAddUrl.Click += btnAddUrl_Click;
            // 
            // flowLayoutPanelCards
            // 
            flowLayoutPanelCards.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanelCards.AutoScroll = true;
            flowLayoutPanelCards.BackColor = Color.FromArgb(6, 16, 20);
            flowLayoutPanelCards.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelCards.Location = new Point(15, 60);
            flowLayoutPanelCards.Name = "flowLayoutPanelCards";
            flowLayoutPanelCards.Size = new Size(884, 495);
            flowLayoutPanelCards.TabIndex = 2;
            flowLayoutPanelCards.WrapContents = false;
            flowLayoutPanelCards.SizeChanged += flowLayoutPanelCards_SizeChanged;
            // 
            // FormURLConfiguration
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(15, 32, 39);
            ClientSize = new Size(914, 570);
            Controls.Add(flowLayoutPanelCards);
            Controls.Add(btnAddUrl);
            Controls.Add(lblFormTitle);
            Font = new Font("Segoe UI", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormURLConfiguration";
            Text = "URL Configuration";
        
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblFormTitle;
        private T3ACS.Controls.ButtonControl btnAddUrl;
        private FlowLayoutPanel flowLayoutPanelCards;
    }
}