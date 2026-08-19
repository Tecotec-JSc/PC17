using T3ACS.Controls;
using T3ACS.Controls.PanelCustoms;

namespace T3ACS
{
    partial class FormCustomContent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCustomContent));
            lblName = new Label();
            label4 = new Label();
            rjTextBox321 = new RJTextBox32();
            label2 = new Label();
            lblCheck = new Label();
            label1 = new Label();
            selectControl1 = new SelectControl();
            label3 = new Label();
            btnAddMedia = new Button();
            txaDescription = new RJEditor();
            flowLayoutPanel1 = new FlowLayoutPanel();
            selectVariable1 = new SelectVariable();
            panelBorder1 = new PanelBorderRadiusCustom();
            switchOnoff6 = new SwitchOnOFF();
            switchOnoff5 = new SwitchOnOFF();
            switchOnoff4 = new SwitchOnOFF();
            switchOnoff3 = new SwitchOnOFF();
            switchOnoff2 = new SwitchOnOFF();
            switchOnoff1 = new SwitchOnOFF();
            label5 = new Label();
            flowpanelTabTitle = new FlowLayoutPanel();
            tabTitleViewRun = new TabTitle();
            tabTitlePrepare = new TabTitle();
            tabTitleDrive = new TabTitle();
            tabTitleRun = new TabTitle();
            tabTitleStop = new TabTitle();
            tabTitleSave = new TabTitle();
            Next = new TabTitle();
            panelFunctionContent = new Panel();
            button1 = new Button();
            tabTitleViewSetup = new TabTitle();
            flowLayoutPanel1.SuspendLayout();
            panelBorder1.SuspendLayout();
            flowpanelTabTitle.SuspendLayout();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(0, 32, 77);
            lblName.Location = new Point(24, 16);
            lblName.Margin = new Padding(0);
            lblName.Name = "lblName";
            lblName.Size = new Size(134, 19);
            lblName.TabIndex = 1;
            lblName.Text = "Step template name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.5F);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(157, 16);
            label4.Name = "label4";
            label4.Size = new Size(15, 19);
            label4.TabIndex = 4;
            label4.Text = "*";
            // 
            // rjTextBox321
            // 
            rjTextBox321.BackColor = Color.White;
            rjTextBox321.BorderColor = Color.DarkGray;
            rjTextBox321.BorderFocusColor = Color.FromArgb(3, 120, 212);
            rjTextBox321.BorderRadius = 5;
            rjTextBox321.BorderSize = 1;
            rjTextBox321.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rjTextBox321.Location = new Point(24, 44);
            rjTextBox321.Margin = new Padding(4);
            rjTextBox321.Multiline = false;
            rjTextBox321.Name = "rjTextBox321";
            rjTextBox321.Padding = new Padding(10, 7, 10, 7);
            rjTextBox321.PasswordChar = false;
            rjTextBox321.PlaceholderColor = Color.FromArgb(153, 166, 184);
            rjTextBox321.PlaceholderText = "";
            rjTextBox321.ReadOnly = false;
            rjTextBox321.Size = new Size(803, 32);
            rjTextBox321.TabIndex = 5;
            rjTextBox321.UnderlinedStyle = false;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Cursor = Cursors.Hand;
            label2.Location = new Point(902, 51);
            label2.Name = "label2";
            label2.Size = new Size(145, 19);
            label2.TabIndex = 7;
            label2.Text = " Require previous step";
            label2.Click += lblCheck_Click;
            // 
            // lblCheck
            // 
            lblCheck.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCheck.Cursor = Cursors.Hand;
            lblCheck.Image = Properties.Resources.rdonocheck;
            lblCheck.Location = new Point(871, 47);
            lblCheck.Name = "lblCheck";
            lblCheck.Size = new Size(27, 28);
            lblCheck.TabIndex = 6;
            lblCheck.Click += lblCheck_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 32, 77);
            label1.Location = new Point(24, 93);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(68, 19);
            label1.TabIndex = 1;
            label1.Text = "Step type";
            // 
            // selectControl1
            // 
            selectControl1.Location = new Point(24, 122);
            selectControl1.Name = "selectControl1";
            selectControl1.Size = new Size(401, 34);
            selectControl1.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(0, 32, 77);
            label3.Location = new Point(24, 175);
            label3.Margin = new Padding(0);
            label3.Name = "label3";
            label3.Size = new Size(81, 19);
            label3.TabIndex = 1;
            label3.Text = "Description";
            // 
            // btnAddMedia
            // 
            btnAddMedia.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddMedia.BackColor = Color.White;
            btnAddMedia.FlatAppearance.BorderSize = 0;
            btnAddMedia.FlatAppearance.MouseDownBackColor = Color.White;
            btnAddMedia.FlatAppearance.MouseOverBackColor = Color.White;
            btnAddMedia.FlatStyle = FlatStyle.Flat;
            btnAddMedia.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnAddMedia.Image = (Image)resources.GetObject("btnAddMedia.Image");
            btnAddMedia.Location = new Point(930, 174);
            btnAddMedia.Margin = new Padding(0);
            btnAddMedia.Name = "btnAddMedia";
            btnAddMedia.Size = new Size(121, 36);
            btnAddMedia.TabIndex = 46;
            btnAddMedia.UseVisualStyleBackColor = false;
            // 
            // txaDescription
            // 
            txaDescription.BackColor = Color.White;
            txaDescription.BorderColor = Color.DarkGray;
            txaDescription.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txaDescription.BorderRadius = 5;
            txaDescription.BorderSize = 1;
            txaDescription.Location = new Point(24, 213);
            txaDescription.Name = "txaDescription";
            txaDescription.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txaDescription.PlaceholderText = "Description";
            txaDescription.Size = new Size(1024, 100);
            txaDescription.TabIndex = 48;
            txaDescription.Texts = "";
            txaDescription.UnderlinedStyle = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(selectVariable1);
            flowLayoutPanel1.Controls.Add(panelBorder1);
            flowLayoutPanel1.Controls.Add(flowpanelTabTitle);
            flowLayoutPanel1.Controls.Add(panelFunctionContent);
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(18, 341);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1042, 601);
            flowLayoutPanel1.TabIndex = 50;
            flowLayoutPanel1.WrapContents = false;
            // 
            // selectVariable1
            // 
            selectVariable1._DataInputs = null;
            selectVariable1._SelectedValues = null;
            selectVariable1.BackColor = Color.White;
            selectVariable1.Font = new Font("Segoe UI", 10.5F);
            selectVariable1.Location = new Point(3, 4);
            selectVariable1.Margin = new Padding(3, 4, 3, 4);
            selectVariable1.Name = "selectVariable1";
            selectVariable1.Size = new Size(1030, 123);
            selectVariable1.TabIndex = 49;
            // 
            // panelBorder1
            // 
            panelBorder1.BorderColor = Color.DarkGray;
            panelBorder1.RadiusTopLeft = 10;
            panelBorder1.RadiusBottomRight = 10;
            panelBorder1.BorderSize = 1;
            panelBorder1.Controls.Add(switchOnoff6);
            panelBorder1.Controls.Add(switchOnoff5);
            panelBorder1.Controls.Add(switchOnoff4);
            panelBorder1.Controls.Add(switchOnoff3);
            panelBorder1.Controls.Add(switchOnoff2);
            panelBorder1.Controls.Add(switchOnoff1);
            panelBorder1.Controls.Add(label5);
            panelBorder1.Location = new Point(7, 131);
            panelBorder1.Margin = new Padding(7, 0, 5, 0);
            panelBorder1.Name = "panelBorder1";
            panelBorder1.Size = new Size(1030, 89);
            panelBorder1.TabIndex = 50;
            // 
            // switchOnoff6
            // 
            switchOnoff6.Font = new Font("Segoe UI", 10.5F);
            switchOnoff6.ForeColor = Color.FromArgb(0, 32, 77);
            switchOnoff6.Location = new Point(17, 50);
            switchOnoff6.Margin = new Padding(3, 4, 3, 4);
            switchOnoff6.Name = "switchOnoff6";
            switchOnoff6.Size = new Size(101, 22);
            switchOnoff6.TabIndex = 5;
            switchOnoff6.TextS = "Prepare";
            // 
            // switchOnoff5
            // 
            switchOnoff5.Font = new Font("Segoe UI", 10.5F);
            switchOnoff5.ForeColor = Color.FromArgb(0, 32, 77);
            switchOnoff5.Location = new Point(534, 50);
            switchOnoff5.Margin = new Padding(3, 4, 3, 4);
            switchOnoff5.Name = "switchOnoff5";
            switchOnoff5.Size = new Size(82, 22);
            switchOnoff5.TabIndex = 4;
            switchOnoff5.TextS = "Next";
            // 
            // switchOnoff4
            // 
            switchOnoff4.Font = new Font("Segoe UI", 10.5F);
            switchOnoff4.ForeColor = Color.FromArgb(0, 32, 77);
            switchOnoff4.Location = new Point(433, 50);
            switchOnoff4.Margin = new Padding(3, 4, 3, 4);
            switchOnoff4.Name = "switchOnoff4";
            switchOnoff4.Size = new Size(82, 22);
            switchOnoff4.TabIndex = 4;
            switchOnoff4.TextS = "Save";
            // 
            // switchOnoff3
            // 
            switchOnoff3.Font = new Font("Segoe UI", 10.5F);
            switchOnoff3.ForeColor = Color.FromArgb(0, 32, 77);
            switchOnoff3.Location = new Point(334, 50);
            switchOnoff3.Margin = new Padding(3, 4, 3, 4);
            switchOnoff3.Name = "switchOnoff3";
            switchOnoff3.Size = new Size(82, 22);
            switchOnoff3.TabIndex = 4;
            switchOnoff3.TextS = "Stop";
            // 
            // switchOnoff2
            // 
            switchOnoff2.Font = new Font("Segoe UI", 10.5F);
            switchOnoff2.ForeColor = Color.FromArgb(0, 32, 77);
            switchOnoff2.Location = new Point(236, 50);
            switchOnoff2.Margin = new Padding(3, 4, 3, 4);
            switchOnoff2.Name = "switchOnoff2";
            switchOnoff2.Size = new Size(78, 22);
            switchOnoff2.TabIndex = 3;
            switchOnoff2.TextS = "Run";
            // 
            // switchOnoff1
            // 
            switchOnoff1.Font = new Font("Segoe UI", 10.5F);
            switchOnoff1.ForeColor = Color.FromArgb(0, 32, 77);
            switchOnoff1.Location = new Point(132, 50);
            switchOnoff1.Margin = new Padding(3, 4, 3, 4);
            switchOnoff1.Name = "switchOnoff1";
            switchOnoff1.Size = new Size(86, 22);
            switchOnoff1.TabIndex = 2;
            switchOnoff1.TextS = "Drive";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(0, 32, 77);
            label5.Location = new Point(17, 17);
            label5.Margin = new Padding(0);
            label5.Name = "label5";
            label5.Size = new Size(128, 19);
            label5.TabIndex = 1;
            label5.Text = "Enable Step Phases";
            // 
            // flowpanelTabTitle
            // 
            flowpanelTabTitle.Controls.Add(tabTitleViewSetup);
            flowpanelTabTitle.Controls.Add(tabTitleViewRun);
            flowpanelTabTitle.Controls.Add(tabTitlePrepare);
            flowpanelTabTitle.Controls.Add(tabTitleDrive);
            flowpanelTabTitle.Controls.Add(tabTitleRun);
            flowpanelTabTitle.Controls.Add(tabTitleStop);
            flowpanelTabTitle.Controls.Add(tabTitleSave);
            flowpanelTabTitle.Controls.Add(Next);
            flowpanelTabTitle.Location = new Point(7, 220);
            flowpanelTabTitle.Margin = new Padding(7, 0, 0, 0);
            flowpanelTabTitle.Name = "flowpanelTabTitle";
            flowpanelTabTitle.Size = new Size(1027, 39);
            flowpanelTabTitle.TabIndex = 51;
            flowpanelTabTitle.Paint += panelBottom_Paint;
            // 
            // tabTitleViewRun
            // 
            tabTitleViewRun.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabTitleViewRun.ForeColor = Color.FromArgb(0, 32, 77);
            tabTitleViewRun.Location = new Point(100, 0);
            tabTitleViewRun.Margin = new Padding(0, 0, 0, 2);
            tabTitleViewRun.Name = "tabTitleViewRun";
            tabTitleViewRun.SelectedTab = false;
            tabTitleViewRun.Size = new Size(89, 38);
            tabTitleViewRun.TabIndex = 0;
            tabTitleViewRun.TextS = "View Run";
            // 
            // tabTitlePrepare
            // 
            tabTitlePrepare.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabTitlePrepare.ForeColor = Color.FromArgb(0, 32, 77);
            tabTitlePrepare.Location = new Point(189, 0);
            tabTitlePrepare.Margin = new Padding(0);
            tabTitlePrepare.Name = "tabTitlePrepare";
            tabTitlePrepare.SelectedTab = false;
            tabTitlePrepare.Size = new Size(76, 38);
            tabTitlePrepare.TabIndex = 1;
            tabTitlePrepare.TextS = "Prepare";
            // 
            // tabTitleDrive
            // 
            tabTitleDrive.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabTitleDrive.ForeColor = Color.FromArgb(0, 32, 77);
            tabTitleDrive.Location = new Point(265, 0);
            tabTitleDrive.Margin = new Padding(0);
            tabTitleDrive.Name = "tabTitleDrive";
            tabTitleDrive.SelectedTab = false;
            tabTitleDrive.Size = new Size(62, 38);
            tabTitleDrive.TabIndex = 2;
            tabTitleDrive.TextS = "Drive";
            // 
            // tabTitleRun
            // 
            tabTitleRun.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabTitleRun.ForeColor = Color.FromArgb(0, 32, 77);
            tabTitleRun.Location = new Point(327, 0);
            tabTitleRun.Margin = new Padding(0);
            tabTitleRun.Name = "tabTitleRun";
            tabTitleRun.SelectedTab = false;
            tabTitleRun.Size = new Size(54, 38);
            tabTitleRun.TabIndex = 2;
            tabTitleRun.TextS = "Run";
            // 
            // tabTitleStop
            // 
            tabTitleStop.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabTitleStop.ForeColor = Color.FromArgb(0, 32, 77);
            tabTitleStop.Location = new Point(381, 0);
            tabTitleStop.Margin = new Padding(0);
            tabTitleStop.Name = "tabTitleStop";
            tabTitleStop.SelectedTab = false;
            tabTitleStop.Size = new Size(58, 38);
            tabTitleStop.TabIndex = 2;
            tabTitleStop.TextS = "Stop";
            // 
            // tabTitleSave
            // 
            tabTitleSave.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabTitleSave.ForeColor = Color.FromArgb(0, 32, 77);
            tabTitleSave.Location = new Point(439, 0);
            tabTitleSave.Margin = new Padding(0);
            tabTitleSave.Name = "tabTitleSave";
            tabTitleSave.SelectedTab = false;
            tabTitleSave.Size = new Size(58, 38);
            tabTitleSave.TabIndex = 2;
            tabTitleSave.TextS = "Save";
            // 
            // Next
            // 
            Next.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Next.ForeColor = Color.FromArgb(0, 32, 77);
            Next.Location = new Point(497, 0);
            Next.Margin = new Padding(0);
            Next.Name = "Next";
            Next.SelectedTab = false;
            Next.Size = new Size(59, 38);
            Next.TabIndex = 3;
            Next.TextS = "Next";
            // 
            // panelFunctionContent
            // 
            panelFunctionContent.Location = new Point(6, 259);
            panelFunctionContent.Margin = new Padding(6, 0, 3, 0);
            panelFunctionContent.Name = "panelFunctionContent";
            panelFunctionContent.Size = new Size(1034, 342);
            panelFunctionContent.TabIndex = 52;
            // 
            // button1
            // 
            button1.Location = new Point(302, 95);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 51;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabTitleViewSetup
            // 
            tabTitleViewSetup.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabTitleViewSetup.ForeColor = Color.FromArgb(0, 32, 77);
            tabTitleViewSetup.Location = new Point(0, 0);
            tabTitleViewSetup.Margin = new Padding(0, 0, 0, 2);
            tabTitleViewSetup.Name = "tabTitleViewSetup";
            tabTitleViewSetup.SelectedTab = true;
            tabTitleViewSetup.Size = new Size(100, 38);
            tabTitleViewSetup.TabIndex = 4;
            tabTitleViewSetup.TextS = "View Setup";
            // 
            // FormCustomContent
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.White;
            ClientSize = new Size(1078, 987);
            Controls.Add(button1);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(txaDescription);
            Controls.Add(btnAddMedia);
            Controls.Add(selectControl1);
            Controls.Add(label2);
            Controls.Add(lblCheck);
            Controls.Add(rjTextBox321);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(lblName);
            Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormCustomContent";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormCustomContent";
            Shown += FormCustomContent_Shown;
            Click += FormCustomContent_Click;
            flowLayoutPanel1.ResumeLayout(false);
            panelBorder1.ResumeLayout(false);
            panelBorder1.PerformLayout();
            flowpanelTabTitle.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label label4;
        private RJTextBox32 rjTextBox321;
        private Label label2;
        private Label lblCheck;
        private Label label1;
        private SelectControl selectControl1;
        private Label label3;
        private Button btnAddMedia;
        private RJEditor txaDescription;
        private FlowLayoutPanel flowLayoutPanel1;
        private SelectVariable selectVariable1;
        private PanelBorderRadiusCustom panelBorder1;
        private Label label5;
        private SwitchOnOFF switchOnoff1;
        private SwitchOnOFF switchOnoff2;
        private SwitchOnOFF switchOnoff4;
        private SwitchOnOFF switchOnoff3;
        private SwitchOnOFF switchOnoff5;
        private FlowLayoutPanel flowpanelTabTitle;
        private TabTitle tabTitleViewRun;
        private TabTitle tabTitlePrepare;
        private SwitchOnOFF switchOnoff6;
        private TabTitle tabTitleDrive;
        private TabTitle tabTitleRun;
        private TabTitle tabTitleStop;
        private TabTitle tabTitleSave;
        private TabTitle Next;
        private Button button1;
        private Panel panelFunctionContent;
        private TabTitle tabTitleViewSetup;
    }
}