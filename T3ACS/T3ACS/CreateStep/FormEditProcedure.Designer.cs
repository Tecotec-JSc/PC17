using System.Windows.Forms;
using T3ACS.Controls;
using T3ACS.Controls.Buttons;
using T3ACS.Controls.PanelCustoms;

namespace T3ACS
{
    partial class FormEditProcedure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditProcedure));
            lblHugStep = new Label();
            panelContent = new PanelBorderRadiusCustom();
            lblTitleProcedure = new Label();
            lblDefaultDescription = new Label();
            lblVisibal = new Label();
            panelBorderControl3 = new PanelBorderRadiusCustom();
            label1 = new Label();
            panelCenterContent = new Panel();
            panelBorderControl4 = new PanelBorderRadiusCustom();
            panelBorderControl5 = new PanelBorderRadiusCustom();
            panelRightContent = new Panel();
            panelCustomBorder1 = new PanelCustomBorder();
            buttonCustom1 = new ButtonCustom();
            rjTextSeach1 = new RJTextSeach();
            lblTextRepeatCountDT = new Label();
            lblTextDesDT = new Label();
            lblTextStepNameDT = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panelBorderControl6 = new PanelBorderRadiusCustom();
            panelStepType = new FlowLayoutPanel();
            label2 = new Label();
            tblStep = new TableStepControl();
            flowLayoutPanel1 = new FlowLayoutPanel();
            lblIdProcedure = new Label();
            lblVersionProcedure = new Label();
            btnCreateProcedure = new Button();
            button2 = new Button();
            btnMoreTemplate = new Label();
            ButtonCustom1 = new ButtonCustom();
            panelBorderRadiusCustom1 = new PanelBorderRadiusCustom();
            panelLeft = new PanelBorderRadiusCustom();
            btnAction = new ButtonCustom();
            panelBorderRadiusCustom2 = new PanelBorderRadiusCustom();
            ButtonCustom2 = new ButtonCustom();
            panelRightContent.SuspendLayout();
            panelCustomBorder1.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            panelBorderRadiusCustom1.SuspendLayout();
            panelLeft.SuspendLayout();
            panelBorderRadiusCustom2.SuspendLayout();
            SuspendLayout();
            // 
            // lblHugStep
            // 
            lblHugStep.BackColor = Color.White;
            lblHugStep.Font = new Font("Segoe UI Variable Text Semibold", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHugStep.Location = new Point(10, 6);
            lblHugStep.Margin = new Padding(0);
            lblHugStep.Name = "lblHugStep";
            lblHugStep.Size = new Size(100, 28);
            lblHugStep.TabIndex = 2;
            lblHugStep.Text = "STEP";
            lblHugStep.TextAlign = ContentAlignment.MiddleLeft;
            lblHugStep.Click += lblHugStep_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.BorderColor = Color.DarkGray;
            panelContent.BorderSize = 1;
            panelContent.Dock = DockStyle.Top;
            panelContent.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelContent.Location = new Point(0, 0);
            panelContent.Margin = new Padding(0);
            panelContent.Name = "panelContent";
            panelContent.Padding = new Padding(2);
            panelContent.Size = new Size(1920, 67);
            panelContent.TabIndex = 3;
            // 
            // lblTitleProcedure
            // 
            lblTitleProcedure.AutoSize = true;
            lblTitleProcedure.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleProcedure.Location = new Point(3, 0);
            lblTitleProcedure.Name = "lblTitleProcedure";
            lblTitleProcedure.Size = new Size(51, 21);
            lblTitleProcedure.TabIndex = 4;
            lblTitleProcedure.Text = "label1";
            // 
            // lblDefaultDescription
            // 
            lblDefaultDescription.Location = new Point(27, 37);
            lblDefaultDescription.Name = "lblDefaultDescription";
            lblDefaultDescription.Size = new Size(1440, 22);
            lblDefaultDescription.TabIndex = 5;
            lblDefaultDescription.Text = "label2";
            // 
            // lblVisibal
            // 
            lblVisibal.Location = new Point(8, 979);
            lblVisibal.Name = "lblVisibal";
            lblVisibal.Size = new Size(1, 1);
            lblVisibal.TabIndex = 53;
            lblVisibal.Visible = false;
            lblVisibal.TextChanged += lblVisibal_TextChanged;
            // 
            // panelBorderControl3
            // 
            panelBorderControl3.BackColor = SystemColors.Window;
            panelBorderControl3.BorderColor = Color.DarkGray;
            panelBorderControl3.BorderSize = 1;
            panelBorderControl3.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl3.Location = new Point(354, 66);
            panelBorderControl3.Margin = new Padding(0);
            panelBorderControl3.Name = "panelBorderControl3";
            panelBorderControl3.Padding = new Padding(2);
            panelBorderControl3.Size = new Size(1130, 41);
            panelBorderControl3.TabIndex = 54;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI Variable Display Semib", 15F, FontStyle.Bold);
            label1.Location = new Point(372, 72);
            label1.Name = "label1";
            label1.Size = new Size(182, 27);
            label1.TabIndex = 56;
            label1.Text = "CONFIGURATIONS";
            // 
            // panelCenterContent
            // 
            panelCenterContent.Location = new Point(358, 110);
            panelCenterContent.Name = "panelCenterContent";
            panelCenterContent.Size = new Size(1120, 873);
            panelCenterContent.TabIndex = 57;
            // 
            // panelBorderControl4
            // 
            panelBorderControl4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelBorderControl4.BackColor = SystemColors.Window;
            panelBorderControl4.BorderColor = Color.DarkGray;
            panelBorderControl4.BorderSize = 1;
            panelBorderControl4.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl4.Location = new Point(1483, 66);
            panelBorderControl4.Margin = new Padding(0);
            panelBorderControl4.Name = "panelBorderControl4";
            panelBorderControl4.Padding = new Padding(2);
            panelBorderControl4.Size = new Size(438, 41);
            panelBorderControl4.TabIndex = 58;
            // 
            // panelBorderControl5
            // 
            panelBorderControl5.BackColor = SystemColors.Window;
            panelBorderControl5.BorderColor = Color.DarkGray;
            panelBorderControl5.BorderSize = 1;
            panelBorderControl5.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl5.Location = new Point(1483, 128);
            panelBorderControl5.Margin = new Padding(0);
            panelBorderControl5.Name = "panelBorderControl5";
            panelBorderControl5.Padding = new Padding(2);
            panelBorderControl5.Size = new Size(439, 903);
            panelBorderControl5.TabIndex = 59;
            // 
            // panelRightContent
            // 
            panelRightContent.Controls.Add(panelCustomBorder1);
            panelRightContent.Controls.Add(rjTextSeach1);
            panelRightContent.Controls.Add(lblTextRepeatCountDT);
            panelRightContent.Controls.Add(lblTextDesDT);
            panelRightContent.Controls.Add(lblTextStepNameDT);
            panelRightContent.Controls.Add(label6);
            panelRightContent.Controls.Add(label5);
            panelRightContent.Controls.Add(label4);
            panelRightContent.Controls.Add(label3);
            panelRightContent.Controls.Add(panelBorderControl6);
            panelRightContent.Controls.Add(panelStepType);
            panelRightContent.Location = new Point(1484, 128);
            panelRightContent.Name = "panelRightContent";
            panelRightContent.Size = new Size(437, 854);
            panelRightContent.TabIndex = 0;
            // 
            // panelCustomBorder1
            // 
            panelCustomBorder1.BorderBottom = true;
            panelCustomBorder1.BorderColor = Color.FromArgb(204, 215, 230);
            panelCustomBorder1.BorderLeft = false;
            panelCustomBorder1.BorderRight = false;
            panelCustomBorder1.BorderSize = 1;
            panelCustomBorder1.BorderTop = true;
            panelCustomBorder1.Controls.Add(buttonCustom1);
            panelCustomBorder1.Location = new Point(-1, 542);
            panelCustomBorder1.Name = "panelCustomBorder1";
            panelCustomBorder1.Size = new Size(447, 60);
            panelCustomBorder1.TabIndex = 7;
            // 
            // buttonCustom1
            // 
            buttonCustom1.BackColor = Color.White;
            buttonCustom1.BackColorG = Color.White;
            buttonCustom1.BorderColorG = Color.FromArgb(204, 215, 230);
            buttonCustom1.BorderSize = 1;
            buttonCustom1.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCustom1.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            buttonCustom1.ForeColor = Color.FromArgb(0, 32, 77);
            buttonCustom1.ForeColorG = Color.FromArgb(0, 32, 77);
            buttonCustom1.HoverG = false;
            buttonCustom1.ImageAd = (Image)resources.GetObject("buttonCustom1.ImageAd");
            buttonCustom1.Location = new Point(263, 15);
            buttonCustom1.Margin = new Padding(0);
            buttonCustom1.Name = "buttonCustom1";
            buttonCustom1.RadiusBottomLeft = 5;
            buttonCustom1.RadiusBottomRight = 5;
            buttonCustom1.RadiusTopLeft = 5;
            buttonCustom1.RadiusTopRight = 5;
            buttonCustom1.Size = new Size(156, 30);
            buttonCustom1.TabIndex = 0;
            buttonCustom1.TextAlign = ContentAlignment.MiddleLeft;
            buttonCustom1.Texts = "Add to Procedure";
            buttonCustom1._EventSelect += buttonCustom1__EventSelect;
            // 
            // rjTextSeach1
            // 
            rjTextSeach1.BorderColor = Color.FromArgb(204, 215, 230);
            rjTextSeach1.BorderFocusColor = Color.FromArgb(3, 120, 212);
            rjTextSeach1.BorderRadius = 5;
            rjTextSeach1.BorderSize = 1;
            rjTextSeach1.Font = new Font("Segoe UI Variable Display", 10.5F);
            rjTextSeach1.Location = new Point(16, 12);
            rjTextSeach1.Margin = new Padding(3, 4, 3, 4);
            rjTextSeach1.Multiline = false;
            rjTextSeach1.Name = "rjTextSeach1";
            rjTextSeach1.PasswordChar = false;
            rjTextSeach1.PlaceholderColor = Color.FromArgb(151, 164, 182);
            rjTextSeach1.PlaceholderText = "Search step";
            rjTextSeach1.Size = new Size(417, 30);
            rjTextSeach1.TabIndex = 6;
            rjTextSeach1.UnderlinedStyle = false;
            rjTextSeach1._TextChanged += rjTextSeach1__TextChanged;
            // 
            // lblTextRepeatCountDT
            // 
            lblTextRepeatCountDT.AutoSize = true;
            lblTextRepeatCountDT.Location = new Point(118, 731);
            lblTextRepeatCountDT.Name = "lblTextRepeatCountDT";
            lblTextRepeatCountDT.Size = new Size(45, 19);
            lblTextRepeatCountDT.TabIndex = 5;
            lblTextRepeatCountDT.Text = "label7";
            // 
            // lblTextDesDT
            // 
            lblTextDesDT.Location = new Point(102, 689);
            lblTextDesDT.Name = "lblTextDesDT";
            lblTextDesDT.Size = new Size(333, 42);
            lblTextDesDT.TabIndex = 5;
            lblTextDesDT.Text = "label7";
            // 
            // lblTextStepNameDT
            // 
            lblTextStepNameDT.AutoSize = true;
            lblTextStepNameDT.Location = new Point(102, 657);
            lblTextStepNameDT.Name = "lblTextStepNameDT";
            lblTextStepNameDT.Size = new Size(45, 19);
            lblTextStepNameDT.TabIndex = 5;
            lblTextStepNameDT.Text = "label7";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(17, 731);
            label6.Name = "label6";
            label6.Size = new Size(95, 19);
            label6.TabIndex = 4;
            label6.Text = "Repeat count:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(17, 689);
            label5.Name = "label5";
            label5.Size = new Size(88, 19);
            label5.TabIndex = 4;
            label5.Text = "Description: ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(18, 657);
            label4.Name = "label4";
            label4.Size = new Size(78, 19);
            label4.TabIndex = 4;
            label4.Text = "Step name:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Variable Text Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(17, 609);
            label3.Name = "label3";
            label3.Size = new Size(150, 21);
            label3.TabIndex = 3;
            label3.Text = "TEMPLATE DETAILS";
            // 
            // panelBorderControl6
            // 
            panelBorderControl6.BackColor = SystemColors.Window;
            panelBorderControl6.BorderColor = Color.DarkGray;
            panelBorderControl6.BorderSize = 1;
            panelBorderControl6.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl6.Location = new Point(-1, 600);
            panelBorderControl6.Margin = new Padding(0);
            panelBorderControl6.Name = "panelBorderControl6";
            panelBorderControl6.Padding = new Padding(2);
            panelBorderControl6.Size = new Size(447, 37);
            panelBorderControl6.TabIndex = 2;
            // 
            // panelStepType
            // 
            panelStepType.AutoScroll = true;
            panelStepType.FlowDirection = FlowDirection.TopDown;
            panelStepType.Location = new Point(8, 56);
            panelStepType.Name = "panelStepType";
            panelStepType.Size = new Size(431, 483);
            panelStepType.TabIndex = 1;
            panelStepType.WrapContents = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI Variable Display Semib", 15F, FontStyle.Bold);
            label2.Location = new Point(1492, 72);
            label2.Name = "label2";
            label2.Size = new Size(152, 27);
            label2.TabIndex = 56;
            label2.Text = "Template Steps";
            // 
            // tblStep
            // 
            tblStep.AutoScroll = true;
            tblStep.Dock = DockStyle.Fill;
            tblStep.Location = new Point(1, 1);
            tblStep.Margin = new Padding(3, 4, 3, 4);
            tblStep.Name = "tblStep";
            tblStep.Size = new Size(354, 803);
            tblStep.TabIndex = 0;
            tblStep._ClickControl += tblStep__ClickControl;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(lblTitleProcedure);
            flowLayoutPanel1.Controls.Add(lblIdProcedure);
            flowLayoutPanel1.Controls.Add(lblVersionProcedure);
            flowLayoutPanel1.Location = new Point(24, 16);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1440, 27);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // lblIdProcedure
            // 
            lblIdProcedure.AutoSize = true;
            lblIdProcedure.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblIdProcedure.Location = new Point(77, 0);
            lblIdProcedure.Margin = new Padding(20, 0, 7, 0);
            lblIdProcedure.Name = "lblIdProcedure";
            lblIdProcedure.Size = new Size(51, 21);
            lblIdProcedure.TabIndex = 5;
            lblIdProcedure.Text = "label1";
            // 
            // lblVersionProcedure
            // 
            lblVersionProcedure.AutoSize = true;
            lblVersionProcedure.Font = new Font("Segoe UI Variable Display Semib", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblVersionProcedure.Location = new Point(155, 0);
            lblVersionProcedure.Margin = new Padding(20, 0, 7, 0);
            lblVersionProcedure.Name = "lblVersionProcedure";
            lblVersionProcedure.Size = new Size(51, 21);
            lblVersionProcedure.TabIndex = 6;
            lblVersionProcedure.Text = "label1";
            // 
            // btnCreateProcedure
            // 
            btnCreateProcedure.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateProcedure.BackColor = Color.White;
            btnCreateProcedure.FlatAppearance.BorderSize = 0;
            btnCreateProcedure.FlatAppearance.MouseDownBackColor = Color.White;
            btnCreateProcedure.FlatAppearance.MouseOverBackColor = Color.White;
            btnCreateProcedure.FlatStyle = FlatStyle.Flat;
            btnCreateProcedure.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnCreateProcedure.Image = (Image)resources.GetObject("btnCreateProcedure.Image");
            btnCreateProcedure.ImageAlign = ContentAlignment.MiddleLeft;
            btnCreateProcedure.Location = new Point(1722, 18);
            btnCreateProcedure.Margin = new Padding(0);
            btnCreateProcedure.Name = "btnCreateProcedure";
            btnCreateProcedure.Size = new Size(140, 32);
            btnCreateProcedure.TabIndex = 47;
            btnCreateProcedure.UseVisualStyleBackColor = false;
            btnCreateProcedure.Click += btnCreateProcedure_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.BackColor = Color.White;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.White;
            button2.FlatAppearance.MouseOverBackColor = Color.White;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Variable Display", 10.5F);
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.ImageAlign = ContentAlignment.MiddleRight;
            button2.Location = new Point(1861, 18);
            button2.Margin = new Padding(0);
            button2.Name = "button2";
            button2.Size = new Size(40, 32);
            button2.TabIndex = 47;
            button2.TextImageRelation = TextImageRelation.ImageAboveText;
            button2.UseVisualStyleBackColor = false;
            // 
            // btnMoreTemplate
            // 
            btnMoreTemplate.Cursor = Cursors.Hand;
            btnMoreTemplate.Image = (Image)resources.GetObject("btnMoreTemplate.Image");
            btnMoreTemplate.Location = new Point(1876, 72);
            btnMoreTemplate.Name = "btnMoreTemplate";
            btnMoreTemplate.Size = new Size(32, 32);
            btnMoreTemplate.TabIndex = 0;
            btnMoreTemplate.Click += btnMoreTemplate_Click;
            // 
            // ButtonCustom1
            // 
            ButtonCustom1.BackColor = Color.White;
            ButtonCustom1.BackColorG = Color.White;
            ButtonCustom1.BorderColorG = Color.DarkGray;
            ButtonCustom1.BorderSize = 1;
            ButtonCustom1.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonCustom1.FontG = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ButtonCustom1.ForeColor = Color.FromArgb(0, 32, 77);
            ButtonCustom1.ForeColorG = Color.FromArgb(0, 32, 77);
            ButtonCustom1.HoverG = false;
            ButtonCustom1.HoverColor = Color.Empty;
            ButtonCustom1.iConLocation = new Point(11, 5);
            ButtonCustom1.ImageAd = (Image)resources.GetObject("ButtonCustom1.ImageAd");
            ButtonCustom1.Location = new Point(1490, 18);
            ButtonCustom1.Name = "ButtonCustom1";
            ButtonCustom1.RadiusBottomLeft = 5;
            ButtonCustom1.RadiusBottomRight = 5;
            ButtonCustom1.RadiusTopLeft = 5;
            ButtonCustom1.RadiusTopRight = 5;
            ButtonCustom1.Size = new Size(116, 32);
            ButtonCustom1.TabIndex = 60;
            ButtonCustom1.TextAlign = ContentAlignment.MiddleLeft;
            ButtonCustom1.TextLocation = new Point(35, 4);
            ButtonCustom1.Texts = "Settings";
            ButtonCustom1.TextSizes = new Size(66, 22);
            ButtonCustom1._EventSelect += btnSetting_Click;
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColorG = Color.White;
            panelBorderRadiusCustom1.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(lblHugStep);
            panelBorderRadiusCustom1.Location = new Point(0, 66);
            panelBorderRadiusCustom1.Margin = new Padding(0);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 0;
            panelBorderRadiusCustom1.RadiusBottomRight = 0;
            panelBorderRadiusCustom1.RadiusTopLeft = 0;
            panelBorderRadiusCustom1.RadiusTopRight = 0;
            panelBorderRadiusCustom1.Size = new Size(356, 41);
            panelBorderRadiusCustom1.TabIndex = 61;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            // 
            // panelLeft
            // 
            panelLeft.BackColorG = Color.White;
            panelLeft.BorderColor = Color.DarkGray;
            panelLeft.BorderSize = 1;
            panelLeft.Controls.Add(tblStep);
            panelLeft.Location = new Point(0, 106);
            panelLeft.Name = "panelLeft";
            panelLeft.Padding = new Padding(1);
            panelLeft.RadiusBottomLeft = 0;
            panelLeft.RadiusBottomRight = 0;
            panelLeft.RadiusTopLeft = 0;
            panelLeft.RadiusTopRight = 0;
            panelLeft.Size = new Size(356, 805);
            panelLeft.TabIndex = 3;
            panelLeft.VerticalPoints = (List<int>)resources.GetObject("panelLeft.VerticalPoints");
            // 
            // btnAction
            // 
            btnAction.BackColor = Color.White;
            btnAction.BackColorG = Color.FromArgb(11, 123, 105);
            btnAction.BorderColorG = Color.FromArgb(11, 123, 105);
            btnAction.BorderSize = 1;
            btnAction.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAction.FontG = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAction.ForeColor = Color.FromArgb(0, 32, 77);
            btnAction.ForeColorG = Color.White;
            btnAction.HoverG = false;
            btnAction.HoverColor = Color.Empty;
            btnAction.iConLocation = new Point(207, 7);
            btnAction.ImageAd = (Image)resources.GetObject("btnAction.ImageAd");
            btnAction.Location = new Point(12, 17);
            btnAction.Name = "btnAction";
            btnAction.RadiusBottomLeft = 5;
            btnAction.RadiusBottomRight = 5;
            btnAction.RadiusTopLeft = 5;
            btnAction.RadiusTopRight = 5;
            btnAction.Size = new Size(331, 35);
            btnAction.TabIndex = 62;
            btnAction.TextAlign = ContentAlignment.MiddleLeft;
            btnAction.TextLocation = new Point(110, 6);
            btnAction.Texts = "More actions";
            btnAction.TextSizes = new Size(100, 16);
            btnAction._EventSelect += btnDeleteMetaData_Click;
            // 
            // panelBorderRadiusCustom2
            // 
            panelBorderRadiusCustom2.BackColorG = Color.White;
            panelBorderRadiusCustom2.BorderColor = Color.FromArgb(14, 82, 98);
            panelBorderRadiusCustom2.BorderSize = 1;
            panelBorderRadiusCustom2.Controls.Add(btnAction);
            panelBorderRadiusCustom2.Location = new Point(0, 910);
            panelBorderRadiusCustom2.Name = "panelBorderRadiusCustom2";
            panelBorderRadiusCustom2.RadiusBottomLeft = 0;
            panelBorderRadiusCustom2.RadiusBottomRight = 0;
            panelBorderRadiusCustom2.RadiusTopLeft = 0;
            panelBorderRadiusCustom2.RadiusTopRight = 0;
            panelBorderRadiusCustom2.Size = new Size(356, 77);
            panelBorderRadiusCustom2.TabIndex = 62;
            panelBorderRadiusCustom2.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom2.VerticalPoints");
            // 
            // ButtonCustom2
            // 
            ButtonCustom2.BackColor = Color.White;
            ButtonCustom2.BackColorG = Color.White;
            ButtonCustom2.BorderColorG = Color.DarkGray;
            ButtonCustom2.BorderSize = 1;
            ButtonCustom2.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonCustom2.FontG = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            ButtonCustom2.ForeColor = Color.FromArgb(0, 32, 77);
            ButtonCustom2.ForeColorG = Color.FromArgb(0, 32, 77);
            ButtonCustom2.HoverG = false;
            ButtonCustom2.HoverColor = Color.Empty;
            ButtonCustom2.iConLocation = new Point(11, 5);
            ButtonCustom2.ImageAd = null;
            ButtonCustom2.Location = new Point(1623, 18);
            ButtonCustom2.Name = "ButtonCustom2";
            ButtonCustom2.RadiusBottomLeft = 5;
            ButtonCustom2.RadiusBottomRight = 5;
            ButtonCustom2.RadiusTopLeft = 5;
            ButtonCustom2.RadiusTopRight = 5;
            ButtonCustom2.Size = new Size(96, 32);
            ButtonCustom2.TabIndex = 63;
            ButtonCustom2.TextAlign = ContentAlignment.MiddleLeft;
            ButtonCustom2.TextLocation = new Point(25, 4);
            ButtonCustom2.Texts = "Cancel";
            ButtonCustom2.TextSizes = new Size(59, 22);
            ButtonCustom2._EventSelect += btnCancel_Click;
            // 
            // FormEditProcedure
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1920, 983);
            Controls.Add(ButtonCustom2);
            Controls.Add(panelBorderRadiusCustom2);
            Controls.Add(panelLeft);
            Controls.Add(panelBorderRadiusCustom1);
            Controls.Add(ButtonCustom1);
            Controls.Add(btnMoreTemplate);
            Controls.Add(button2);
            Controls.Add(btnCreateProcedure);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(label2);
            Controls.Add(panelRightContent);
            Controls.Add(panelBorderControl5);
            Controls.Add(panelBorderControl4);
            Controls.Add(label1);
            Controls.Add(lblVisibal);
            Controls.Add(lblDefaultDescription);
            Controls.Add(panelContent);
            Controls.Add(panelCenterContent);
            Controls.Add(panelBorderControl3);
            Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormEditProcedure";
            Text = "Edit Procedure";
            panelRightContent.ResumeLayout(false);
            panelRightContent.PerformLayout();
            panelCustomBorder1.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelBorderRadiusCustom2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label lblHugStep;
        private PanelBorderRadiusCustom panelContent;
        private Label lblTitleProcedure;
        private Label lblDefaultDescription;

        private Label lblVisibal;
        private PanelBorderRadiusCustom panelBorderControl3;
        private Label label1;
        private Panel panelCenterContent;
        private PanelBorderRadiusCustom panelBorderControl4;
        private PanelBorderRadiusCustom panelBorderControl5;
        private Panel panelRightContent;
        private Label label2;
        private FlowLayoutPanel panelStepType;
        private PanelBorderRadiusCustom panelBorderControl6;
        private Label label4;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label lblTextRepeatCountDT;
        private Label lblTextDesDT;
        private Label lblTextStepNameDT;
        private TableStepControl tblStep;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label lblIdProcedure;
        private Label lblVersionProcedure;
        private Button button2;
        private Button btnCreateProcedure;
        private RJTextSeach rjTextSeach1;
        private Label btnMoreTemplate;
        private PanelCustomBorder panelCustomBorder1;
        private ButtonCustom buttonCustom1;
        private ButtonCustom ButtonCustom1;
        private ButtonActionControl buttonActionControl1;
        private PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private PanelBorderRadiusCustom panelLeft;
        private ButtonCustom btnAction;
        private PanelBorderRadiusCustom panelBorderRadiusCustom2;
        private ButtonCustom ButtonCustom2;
    }
}