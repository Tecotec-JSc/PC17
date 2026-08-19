namespace T3ACS.Controls.SelectCustoms
{
    partial class FormPopUpMultiAdd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPopUpMultiAdd));
            panelTitle = new PanelBorderRadiusCustom();
            acsTextSearch1 = new ACSTextSearch();
            panelBottom = new PanelBorderRadiusCustom();
            lblAddDUT = new Label();
            label1 = new Label();
            flowPanelBorderRadius1 = new flowPanelBorderRadius();
            panel1 = new Panel();
            panelTitle.SuspendLayout();
            panelBottom.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.White;
            panelTitle.BackColorG = Color.Empty;
            panelTitle.BorderColor = Color.DarkGray;
            panelTitle.BorderSize = 1;
            panelTitle.Controls.Add(acsTextSearch1);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.ForeColor = Color.FromArgb(3, 5, 51);
            panelTitle.Location = new Point(0, 0);
            panelTitle.Margin = new Padding(0);
            panelTitle.Name = "panelTitle";
            panelTitle.RadiusBottomLeft = 0;
            panelTitle.RadiusBottomRight = 0;
            panelTitle.RadiusTopLeft = 5;
            panelTitle.RadiusTopRight = 5;
            panelTitle.Size = new Size(627, 53);
            panelTitle.TabIndex = 0;
            panelTitle.VerticalPoints = (List<int>)resources.GetObject("panelTitle.VerticalPoints");
            // 
            // acsTextSearch1
            // 
            acsTextSearch1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            acsTextSearch1.BackColor = Color.White;
            acsTextSearch1.BackColorG = Color.Transparent;
            acsTextSearch1.BorderColorG = Color.DarkGray;
            acsTextSearch1.BorderSize = 1;
            acsTextSearch1.Font = new Font("Segoe UI", 10.5F);
            acsTextSearch1.FontG = new Font("Segoe UI", 10.5F);
            acsTextSearch1.ForeColor = Color.FromArgb(3, 5, 51);
            acsTextSearch1.ForeColorG = Color.FromArgb(3, 5, 51);
            acsTextSearch1.Location = new Point(12, 11);
            acsTextSearch1.Name = "acsTextSearch1";
            acsTextSearch1.PlaceholderColor = Color.FromArgb(153, 166, 184);
            acsTextSearch1.RadiusBottomLeft = 5;
            acsTextSearch1.RadiusBottomRight = 5;
            acsTextSearch1.RadiusTopLeft = 5;
            acsTextSearch1.RadiusTopRight = 5;
            acsTextSearch1.Size = new Size(603, 36);
            acsTextSearch1.TabIndex = 0;
            acsTextSearch1.Texts = "";
            acsTextSearch1._TextChanged += acsTextSearch1__TextChanged;
            // 
            // panelBottom
            // 
            panelBottom.BackColor = Color.White;
            panelBottom.BackColorG = Color.Empty;
            panelBottom.BorderColor = Color.DarkGray;
            panelBottom.BorderSize = 1;
            panelBottom.Controls.Add(lblAddDUT);
            panelBottom.Controls.Add(label1);
            panelBottom.Cursor = Cursors.Hand;
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 307);
            panelBottom.Margin = new Padding(0);
            panelBottom.Name = "panelBottom";
            panelBottom.RadiusBottomLeft = 5;
            panelBottom.RadiusBottomRight = 5;
            panelBottom.RadiusTopLeft = 0;
            panelBottom.RadiusTopRight = 0;
            panelBottom.Size = new Size(627, 37);
            panelBottom.TabIndex = 1;
            panelBottom.VerticalPoints = (List<int>)resources.GetObject("panelBottom.VerticalPoints");
            panelBottom.Click += lblAddDUT_Click;
            panelBottom.MouseEnter += panelBottom_Enter;
            panelBottom.MouseLeave += panelBottom_Leave;
            // 
            // lblAddDUT
            // 
            lblAddDUT.AutoSize = true;
            lblAddDUT.ForeColor = Color.FromArgb(0, 184, 230);
            lblAddDUT.Location = new Point(37, 9);
            lblAddDUT.Name = "lblAddDUT";
            lblAddDUT.Size = new Size(105, 19);
            lblAddDUT.TabIndex = 1;
            lblAddDUT.Text = "Add New DUT...";
            lblAddDUT.Click += lblAddDUT_Click;
            lblAddDUT.MouseEnter += panelBottom_Enter;
            lblAddDUT.MouseLeave += panelBottom_Leave;
            // 
            // label1
            // 
            label1.Cursor = Cursors.Hand;
            label1.ForeColor = Color.CornflowerBlue;
            label1.Image = (Image)resources.GetObject("label1.Image");
            label1.Location = new Point(12, 10);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(16, 16);
            label1.TabIndex = 0;
            label1.Click += lblAddDUT_Click;
            label1.MouseEnter += panelBottom_Enter;
            label1.MouseLeave += panelBottom_Leave;
            // 
            // flowPanelBorderRadius1
            // 
            flowPanelBorderRadius1.BackColor = Color.White;
            flowPanelBorderRadius1.BorderColor = Color.DarkGray;
            flowPanelBorderRadius1.BorderSize = 1;
            flowPanelBorderRadius1.FlowDirection = FlowDirection.TopDown;
            flowPanelBorderRadius1.ForeColor = Color.FromArgb(3, 5, 51);
            flowPanelBorderRadius1.Location = new Point(0, 0);
            flowPanelBorderRadius1.Margin = new Padding(0);
            flowPanelBorderRadius1.Name = "flowPanelBorderRadius1";
            flowPanelBorderRadius1.RadiusBottomLeft = 0;
            flowPanelBorderRadius1.RadiusBottomRight = 0;
            flowPanelBorderRadius1.RadiusTopLeft = 0;
            flowPanelBorderRadius1.RadiusTopRight = 0;
            flowPanelBorderRadius1.Size = new Size(627, 254);
            flowPanelBorderRadius1.TabIndex = 2;
            flowPanelBorderRadius1.VerticalPoints = (List<int>)resources.GetObject("flowPanelBorderRadius1.VerticalPoints");
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(flowPanelBorderRadius1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 53);
            panel1.Name = "panel1";
            panel1.Size = new Size(627, 254);
            panel1.TabIndex = 3;
            // 
            // FormPopUpMultiAdd
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(6, 16, 20);
            ClientSize = new Size(627, 344);
            Controls.Add(panel1);
            Controls.Add(panelBottom);
            Controls.Add(panelTitle);
            Font = new Font("Segoe UI", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormPopUpMultiAdd";
            StartPosition = FormStartPosition.Manual;
            Text = "FormPopUpMultiAdd";
            Shown += FormPopUpMultiAdd_Shown;
            panelTitle.ResumeLayout(false);
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PanelBorderRadiusCustom panelTitle;
        private PanelBorderRadiusCustom panelBottom;
        private flowPanelBorderRadius flowPanelBorderRadius1;
        private Label label1;
        private Label lblAddDUT;
        private Panel panel1;
        private ACSTextSearch acsTextSearch1;
    }
}