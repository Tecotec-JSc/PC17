using T3.Configuration;
using T3ACS.Controls;

namespace T3ACS
{
    partial class FormConfigureNewProcedure
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfigureNewProcedure));
            btnChooseTemplate = new Button();
            btnCancel = new Button();
            panel2 = new Panel();
            panelBorderRadiusCustom3 = new PanelBorderRadiusCustom();
            txtDuration = new RJTextBox32();
            txtCategory = new RJTextBox32();
            txtId = new RJTextBox32();
            txtProcedureName = new RJTextBox32();
            rtbDescription = new RJEditor();
            selectSearchDevices = new SelectControl();
            selectSearchDUT = new SelectControl();
            label2 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label1 = new Label();
            lblTitleContent = new Label();
            lblId = new Label();
            lblDescription = new Label();
            label8 = new Label();
            lblDut = new Label();
            lblName = new Label();
            panelFlow = new FlowLayoutPanel();
            panelMetaData = new PanelBorderRadiusCustom();
            btnIconAddMedia = new Controls.Buttons.ButtonCustom();
            btnIconDelete = new Controls.Buttons.ButtonCustom();
            lblMetadata = new Label();
            tblMetaData = new TableMetaData();
            panelVariable = new PanelBorderRadiusCustom();
            tableVariable = new Controls.Table.TableReview();
            label9 = new Label();
            lblDesTemplateName = new Label();
            lblTitleForm = new Label();
            panelBorderRadiusCustom1 = new PanelBorderRadiusCustom();
            panelBorderRadiusCustom2 = new PanelBorderRadiusCustom();
            btnCloseDefault = new Button();
            panelBorderRadiusCustom5 = new PanelBorderRadiusCustom();
            panel2.SuspendLayout();
            panelBorderRadiusCustom3.SuspendLayout();
            panelFlow.SuspendLayout();
            panelMetaData.SuspendLayout();
            panelVariable.SuspendLayout();
            panelBorderRadiusCustom1.SuspendLayout();
            panelBorderRadiusCustom2.SuspendLayout();
            panelBorderRadiusCustom5.SuspendLayout();
            SuspendLayout();
            // 
            // btnChooseTemplate
            // 
            btnChooseTemplate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnChooseTemplate.BackColor = Color.FromArgb(249, 250, 251);
            btnChooseTemplate.FlatAppearance.BorderSize = 0;
            btnChooseTemplate.FlatAppearance.MouseDownBackColor = Color.FromArgb(249, 250, 251);
            btnChooseTemplate.FlatAppearance.MouseOverBackColor = Color.FromArgb(249, 250, 251);
            btnChooseTemplate.FlatStyle = FlatStyle.Flat;
            btnChooseTemplate.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnChooseTemplate.Image = (Image)resources.GetObject("btnChooseTemplate.Image");
            btnChooseTemplate.Location = new Point(951, 19);
            btnChooseTemplate.Margin = new Padding(0);
            btnChooseTemplate.Name = "btnChooseTemplate";
            btnChooseTemplate.Size = new Size(92, 38);
            btnChooseTemplate.TabIndex = 54;
            btnChooseTemplate.UseVisualStyleBackColor = false;
            btnChooseTemplate.Click += btnChooseTemplate_Click;
            // 
            // btnCancel
            // 
            btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnCancel.BackColor = Color.White;
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatAppearance.MouseDownBackColor = Color.White;
            btnCancel.FlatAppearance.MouseOverBackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI Variable Display", 10.5F);
            btnCancel.Image = (Image)resources.GetObject("btnCancel.Image");
            btnCancel.Location = new Point(16, 19);
            btnCancel.Margin = new Padding(0);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(92, 38);
            btnCancel.TabIndex = 55;
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.AutoScroll = true;
            panel2.BackColor = Color.White;
            panel2.Controls.Add(panelBorderRadiusCustom3);
            panel2.Controls.Add(panelFlow);
            panel2.Location = new Point(1, 1);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1076, 566);
            panel2.TabIndex = 5;
            panel2.Paint += panel2_Paint;
            // 
            // panelBorderRadiusCustom3
            // 
            panelBorderRadiusCustom3.BackColor = Color.FromArgb(250, 250, 250);
            panelBorderRadiusCustom3.BackColorG = Color.White;
            panelBorderRadiusCustom3.BorderColor = Color.FromArgb(250, 250, 250);
            panelBorderRadiusCustom3.BorderSize = 0;
            panelBorderRadiusCustom3.Controls.Add(txtDuration);
            panelBorderRadiusCustom3.Controls.Add(txtCategory);
            panelBorderRadiusCustom3.Controls.Add(txtId);
            panelBorderRadiusCustom3.Controls.Add(txtProcedureName);
            panelBorderRadiusCustom3.Controls.Add(rtbDescription);
            panelBorderRadiusCustom3.Controls.Add(selectSearchDevices);
            panelBorderRadiusCustom3.Controls.Add(selectSearchDUT);
            panelBorderRadiusCustom3.Controls.Add(label2);
            panelBorderRadiusCustom3.Controls.Add(label7);
            panelBorderRadiusCustom3.Controls.Add(label6);
            panelBorderRadiusCustom3.Controls.Add(label5);
            panelBorderRadiusCustom3.Controls.Add(label4);
            panelBorderRadiusCustom3.Controls.Add(label1);
            panelBorderRadiusCustom3.Controls.Add(lblTitleContent);
            panelBorderRadiusCustom3.Controls.Add(lblId);
            panelBorderRadiusCustom3.Controls.Add(lblDescription);
            panelBorderRadiusCustom3.Controls.Add(label8);
            panelBorderRadiusCustom3.Controls.Add(lblDut);
            panelBorderRadiusCustom3.Controls.Add(lblName);
            panelBorderRadiusCustom3.Location = new Point(12, 12);
            panelBorderRadiusCustom3.Name = "panelBorderRadiusCustom3";
            panelBorderRadiusCustom3.RadiusBottomLeft = 5;
            panelBorderRadiusCustom3.RadiusBottomRight = 5;
            panelBorderRadiusCustom3.RadiusTopLeft = 5;
            panelBorderRadiusCustom3.RadiusTopRight = 5;
            panelBorderRadiusCustom3.Size = new Size(1040, 546);
            panelBorderRadiusCustom3.TabIndex = 56;
            panelBorderRadiusCustom3.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom3.VerticalPoints");
            // 
            // txtDuration
            // 
            txtDuration.BackColor = Color.FromArgb(232, 232, 232);
            txtDuration.BorderColor = Color.DarkGray;
            txtDuration.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtDuration.BorderRadius = 5;
            txtDuration.BorderSize = 1;
            txtDuration.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtDuration.Location = new Point(528, 238);
            txtDuration.Margin = new Padding(0);
            txtDuration.Multiline = false;
            txtDuration.Name = "txtDuration";
            txtDuration.Padding = new Padding(10, 7, 10, 7);
            txtDuration.PasswordChar = false;
            txtDuration.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtDuration.PlaceholderText = "";
            txtDuration.ReadOnly = true;
            txtDuration.Size = new Size(501, 32);
            txtDuration.TabIndex = 78;
            txtDuration.Texts = "";
            txtDuration.UnderlinedStyle = false;
            // 
            // txtCategory
            // 
            txtCategory.BackColor = Color.White;
            txtCategory.BorderColor = Color.DarkGray;
            txtCategory.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtCategory.BorderRadius = 5;
            txtCategory.BorderSize = 1;
            txtCategory.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCategory.Location = new Point(13, 238);
            txtCategory.Margin = new Padding(0);
            txtCategory.Multiline = false;
            txtCategory.Name = "txtCategory";
            txtCategory.Padding = new Padding(10, 7, 10, 7);
            txtCategory.PasswordChar = false;
            txtCategory.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtCategory.PlaceholderText = "";
            txtCategory.ReadOnly = false;
            txtCategory.Size = new Size(503, 32);
            txtCategory.TabIndex = 76;
            txtCategory.Texts = "";
            txtCategory.UnderlinedStyle = false;
            // 
            // txtId
            // 
            txtId.BackColor = Color.White;
            txtId.BorderColor = Color.DarkGray;
            txtId.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtId.BorderRadius = 5;
            txtId.BorderSize = 1;
            txtId.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtId.Location = new Point(13, 154);
            txtId.Margin = new Padding(0);
            txtId.Multiline = false;
            txtId.Name = "txtId";
            txtId.Padding = new Padding(10, 7, 10, 7);
            txtId.PasswordChar = false;
            txtId.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtId.PlaceholderText = "";
            txtId.ReadOnly = false;
            txtId.Size = new Size(1016, 32);
            txtId.TabIndex = 75;
            txtId.Texts = "";
            txtId.UnderlinedStyle = false;
            // 
            // txtProcedureName
            // 
            txtProcedureName.BackColor = Color.White;
            txtProcedureName.BorderColor = Color.DarkGray;
            txtProcedureName.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtProcedureName.BorderRadius = 5;
            txtProcedureName.BorderSize = 1;
            txtProcedureName.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtProcedureName.Location = new Point(13, 78);
            txtProcedureName.Margin = new Padding(0);
            txtProcedureName.Multiline = false;
            txtProcedureName.Name = "txtProcedureName";
            txtProcedureName.Padding = new Padding(10, 7, 10, 7);
            txtProcedureName.PasswordChar = false;
            txtProcedureName.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtProcedureName.PlaceholderText = "";
            txtProcedureName.ReadOnly = false;
            txtProcedureName.Size = new Size(1016, 32);
            txtProcedureName.TabIndex = 74;
            txtProcedureName.Texts = "";
            txtProcedureName.UnderlinedStyle = false;
            // 
            // rtbDescription
            // 
            rtbDescription.BackColor = Color.White;
            rtbDescription.BorderColor = Color.DarkGray;
            rtbDescription.BorderFocusColor = Color.FromArgb(3, 120, 212);
            rtbDescription.BorderRadius = 5;
            rtbDescription.BorderSize = 1;
            rtbDescription.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rtbDescription.Location = new Point(13, 419);
            rtbDescription.Name = "rtbDescription";
            rtbDescription.PlaceholderColor = Color.FromArgb(153, 166, 184);
            rtbDescription.PlaceholderText = "";
            rtbDescription.RadiusBottomLeft = 5;
            rtbDescription.RadiusBottomRight = 5;
            rtbDescription.RadiusTopLeft = 5;
            rtbDescription.RadiusTopRight = 5;
            rtbDescription.ReadOnly = false;
            rtbDescription.Rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\nouicompat\\deflang1033{\\fonttbl{\\f0\\fnil\\fcharset0 Segoe UI;}}\r\n{\\*\\generator Riched20 10.0.26100}\\viewkind4\\uc1 \r\n\\pard\\f0\\fs21\\par\r\n}\r\n";
            rtbDescription.Size = new Size(1016, 106);
            rtbDescription.TabIndex = 73;
            rtbDescription.Texts = "";
            rtbDescription.UnderlinedStyle = false;
            // 
            // selectSearchDevices
            // 
            selectSearchDevices.BackColorG = Color.White;
            selectSearchDevices.BorderColorG = Color.DarkGray;
            selectSearchDevices.BorderSize = 1;
            selectSearchDevices.ForeColor = Color.FromArgb(0, 32, 77);
            selectSearchDevices.Location = new Point(528, 334);
            selectSearchDevices.Margin = new Padding(3, 4, 3, 4);
            selectSearchDevices.Name = "selectSearchDevices";
            selectSearchDevices.RadiusBottomLeft = 5;
            selectSearchDevices.RadiusBottomRight = 5;
            selectSearchDevices.RadiusTopLeft = 5;
            selectSearchDevices.RadiusTopRight = 5;
            selectSearchDevices.Size = new Size(501, 34);
            selectSearchDevices.TabIndex = 72;
            selectSearchDevices.Texts = "Select Device";
            selectSearchDevices.Visible = false;
            // 
            // selectSearchDUT
            // 
            selectSearchDUT.BackColorG = Color.White;
            selectSearchDUT.BorderColorG = Color.DarkGray;
            selectSearchDUT.BorderSize = 1;
            selectSearchDUT.ForeColor = Color.FromArgb(0, 32, 77);
            selectSearchDUT.Location = new Point(13, 334);
            selectSearchDUT.Margin = new Padding(3, 4, 3, 4);
            selectSearchDUT.Name = "selectSearchDUT";
            selectSearchDUT.RadiusBottomLeft = 5;
            selectSearchDUT.RadiusBottomRight = 5;
            selectSearchDUT.RadiusTopLeft = 5;
            selectSearchDUT.RadiusTopRight = 5;
            selectSearchDUT.Size = new Size(503, 34);
            selectSearchDUT.TabIndex = 71;
            selectSearchDUT.Texts = "Select DUT";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(0, 32, 77);
            label2.Location = new Point(525, 210);
            label2.Name = "label2";
            label2.Size = new Size(64, 19);
            label2.TabIndex = 69;
            label2.Text = "Duration";
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI", 10.5F);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(579, 295);
            label7.Name = "label7";
            label7.Size = new Size(15, 19);
            label7.TabIndex = 65;
            label7.Text = "*";
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 10.5F);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(171, 294);
            label6.Name = "label6";
            label6.Size = new Size(15, 19);
            label6.TabIndex = 65;
            label6.Text = "*";
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI", 10.5F);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(32, 124);
            label5.Name = "label5";
            label5.Size = new Size(15, 19);
            label5.TabIndex = 65;
            label5.Text = "*";
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 10.5F);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(118, 49);
            label4.Name = "label4";
            label4.Size = new Size(15, 19);
            label4.TabIndex = 65;
            label4.Text = "*";
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(0, 32, 77);
            label1.Location = new Point(11, 210);
            label1.Name = "label1";
            label1.Size = new Size(66, 22);
            label1.TabIndex = 62;
            label1.Text = "Category";
            // 
            // lblTitleContent
            // 
            lblTitleContent.BackColor = Color.Transparent;
            lblTitleContent.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblTitleContent.ForeColor = Color.FromArgb(0, 32, 77);
            lblTitleContent.Location = new Point(11, 11);
            lblTitleContent.Name = "lblTitleContent";
            lblTitleContent.Size = new Size(138, 24);
            lblTitleContent.TabIndex = 64;
            lblTitleContent.Text = "Basic Information";
            // 
            // lblId
            // 
            lblId.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblId.ForeColor = Color.FromArgb(0, 32, 77);
            lblId.Location = new Point(11, 125);
            lblId.Name = "lblId";
            lblId.Size = new Size(23, 22);
            lblId.TabIndex = 61;
            lblId.Text = "ID";
            // 
            // lblDescription
            // 
            lblDescription.AutoSize = true;
            lblDescription.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblDescription.ForeColor = Color.FromArgb(0, 32, 77);
            lblDescription.Location = new Point(11, 379);
            lblDescription.Name = "lblDescription";
            lblDescription.Size = new Size(81, 19);
            lblDescription.TabIndex = 60;
            lblDescription.Text = "Description";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(0, 32, 77);
            label8.Location = new Point(525, 295);
            label8.Name = "label8";
            label8.Size = new Size(57, 19);
            label8.TabIndex = 59;
            label8.Text = "Devices";
            label8.Visible = false;
            // 
            // lblDut
            // 
            lblDut.AutoSize = true;
            lblDut.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblDut.ForeColor = Color.FromArgb(0, 32, 77);
            lblDut.Location = new Point(11, 295);
            lblDut.Name = "lblDut";
            lblDut.Size = new Size(164, 19);
            lblDut.TabIndex = 63;
            lblDut.Text = "DUT (Device Under Test)";
            // 
            // lblName
            // 
            lblName.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblName.ForeColor = Color.FromArgb(0, 32, 77);
            lblName.Location = new Point(11, 49);
            lblName.Name = "lblName";
            lblName.Size = new Size(110, 22);
            lblName.TabIndex = 58;
            lblName.Text = "Procedure name";
            // 
            // panelFlow
            // 
            panelFlow.Controls.Add(panelMetaData);
            panelFlow.Controls.Add(panelVariable);
            panelFlow.Location = new Point(1, 564);
            panelFlow.Margin = new Padding(0);
            panelFlow.Name = "panelFlow";
            panelFlow.Size = new Size(1053, 493);
            panelFlow.TabIndex = 55;
            // 
            // panelMetaData
            // 
            panelMetaData.BackColor = Color.FromArgb(250, 250, 250);
            panelMetaData.BackColorG = Color.White;
            panelMetaData.BorderColor = Color.FromArgb(250, 250, 250);
            panelMetaData.BorderSize = 1;
            panelMetaData.Controls.Add(btnIconAddMedia);
            panelMetaData.Controls.Add(btnIconDelete);
            panelMetaData.Controls.Add(lblMetadata);
            panelMetaData.Controls.Add(tblMetaData);
            panelMetaData.Location = new Point(11, 5);
            panelMetaData.Margin = new Padding(11, 5, 0, 0);
            panelMetaData.Name = "panelMetaData";
            panelMetaData.RadiusBottomLeft = 5;
            panelMetaData.RadiusBottomRight = 5;
            panelMetaData.RadiusTopLeft = 5;
            panelMetaData.RadiusTopRight = 5;
            panelMetaData.Size = new Size(1054, 258);
            panelMetaData.TabIndex = 0;
            panelMetaData.VerticalPoints = (List<int>)resources.GetObject("panelMetaData.VerticalPoints");
            // 
            // btnIconAddMedia
            // 
            btnIconAddMedia.BackColor = Color.White;
            btnIconAddMedia.BackColorG = Color.FromArgb(0, 82, 130);
            btnIconAddMedia.BorderColorG = Color.FromArgb(0, 82, 130);
            btnIconAddMedia.BorderSize = 1;
            btnIconAddMedia.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconAddMedia.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconAddMedia.ForeColor = Color.White;
            btnIconAddMedia.ForeColorG = Color.White;
            btnIconAddMedia.HoverG = false;
            btnIconAddMedia.HoverColor = Color.Empty;
            btnIconAddMedia.iConLocation = new Point(13, 6);
            btnIconAddMedia.ImageAd = (Image)resources.GetObject("btnIconAddMedia.ImageAd");
            btnIconAddMedia.Location = new Point(956, 12);
            btnIconAddMedia.Name = "btnIconAddMedia";
            btnIconAddMedia.RadiusBottomLeft = 5;
            btnIconAddMedia.RadiusBottomRight = 5;
            btnIconAddMedia.RadiusTopLeft = 5;
            btnIconAddMedia.RadiusTopRight = 5;
            btnIconAddMedia.Size = new Size(86, 34);
            btnIconAddMedia.TabIndex = 54;
            btnIconAddMedia.TextAlign = ContentAlignment.MiddleLeft;
            btnIconAddMedia.TextLocation = new Point(35, 6);
            btnIconAddMedia.Texts = "Add";
            btnIconAddMedia.TextSizes = new Size(36, 22);
            btnIconAddMedia.Click += btnAddMetaData_Click;
            // 
            // btnIconDelete
            // 
            btnIconDelete.BackColor = Color.White;
            btnIconDelete.BackColorG = Color.White;
            btnIconDelete.BorderColorG = Color.DarkGray;
            btnIconDelete.BorderSize = 1;
            btnIconDelete.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconDelete.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconDelete.ForeColor = Color.FromArgb(0, 32, 77);
            btnIconDelete.ForeColorG = Color.FromArgb(0, 32, 77);
            btnIconDelete.HoverG = false;
            btnIconDelete.HoverColor = Color.Empty;
            btnIconDelete.iConLocation = new Point(13, 9);
            btnIconDelete.ImageAd = (Image)resources.GetObject("btnIconDelete.ImageAd");
            btnIconDelete.Location = new Point(860, 12);
            btnIconDelete.Name = "btnIconDelete";
            btnIconDelete.RadiusBottomLeft = 5;
            btnIconDelete.RadiusBottomRight = 5;
            btnIconDelete.RadiusTopLeft = 5;
            btnIconDelete.RadiusTopRight = 5;
            btnIconDelete.Size = new Size(91, 35);
            btnIconDelete.TabIndex = 53;
            btnIconDelete.TextAlign = ContentAlignment.MiddleLeft;
            btnIconDelete.TextLocation = new Point(33, 7);
            btnIconDelete.Texts = "Delete";
            btnIconDelete.TextSizes = new Size(50, 22);
            btnIconDelete._EventSelect += btnDeleteMetaData_Click;
            // 
            // lblMetadata
            // 
            lblMetadata.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            lblMetadata.ForeColor = Color.FromArgb(0, 32, 77);
            lblMetadata.Location = new Point(11, 17);
            lblMetadata.Name = "lblMetadata";
            lblMetadata.Size = new Size(70, 22);
            lblMetadata.TabIndex = 0;
            lblMetadata.Text = "MetaData";
            lblMetadata.Click += lblMetadata_Click;
            // 
            // tblMetaData
            // 
            tblMetaData.BackColor = Color.FromArgb(243, 242, 241);
            tblMetaData.Location = new Point(15, 76);
            tblMetaData.Margin = new Padding(3, 4, 3, 4);
            tblMetaData.Name = "tblMetaData";
            tblMetaData.Size = new Size(1153, 229);
            tblMetaData.TabIndex = 52;
            tblMetaData._UpdateHeight += tblMetaData__UpdateHeight;
            // 
            // panelVariable
            // 
            panelVariable.BackColor = Color.FromArgb(250, 250, 250);
            panelVariable.BackColorG = Color.White;
            panelVariable.BorderColor = Color.FromArgb(250, 250, 250);
            panelVariable.BorderSize = 1;
            panelVariable.Controls.Add(tableVariable);
            panelVariable.Controls.Add(label9);
            panelVariable.Location = new Point(11, 268);
            panelVariable.Margin = new Padding(11, 5, 0, 0);
            panelVariable.Name = "panelVariable";
            panelVariable.RadiusBottomLeft = 5;
            panelVariable.RadiusBottomRight = 5;
            panelVariable.RadiusTopLeft = 5;
            panelVariable.RadiusTopRight = 5;
            panelVariable.Size = new Size(1054, 200);
            panelVariable.TabIndex = 1;
            panelVariable.VerticalPoints = (List<int>)resources.GetObject("panelVariable.VerticalPoints");
            // 
            // tableVariable
            // 
            tableVariable.AutoHeight = true;
            tableVariable.BackColor = Color.White;
            tableVariable.Font = new Font("Segoe UI", 10.5F);
            tableVariable.Location = new Point(13, 44);
            tableVariable.Margin = new Padding(3, 4, 3, 4);
            tableVariable.Name = "tableVariable";
            tableVariable.OverwriteVariableNames = true;
            tableVariable.Size = new Size(1023, 138);
            tableVariable.TabIndex = 1;
            // 
            // label9
            // 
            label9.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(0, 32, 77);
            label9.Location = new Point(12, 18);
            label9.Name = "label9";
            label9.Size = new Size(70, 22);
            label9.TabIndex = 0;
            label9.Text = "Variables";
            label9.Click += lblMetadata_Click;
            // 
            // lblDesTemplateName
            // 
            lblDesTemplateName.Font = new Font("Segoe UI Variable Text", 10.5F);
            lblDesTemplateName.ForeColor = Color.FromArgb(0, 32, 77);
            lblDesTemplateName.Location = new Point(22, 44);
            lblDesTemplateName.Name = "lblDesTemplateName";
            lblDesTemplateName.Size = new Size(863, 19);
            lblDesTemplateName.TabIndex = 1;
            lblDesTemplateName.Text = "Template: Blank Template";
            // 
            // lblTitleForm
            // 
            lblTitleForm.BackColor = Color.Transparent;
            lblTitleForm.Font = new Font("Segoe UI Semibold", 15F, FontStyle.Bold);
            lblTitleForm.ForeColor = Color.FromArgb(0, 32, 77);
            lblTitleForm.Location = new Point(20, 16);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(325, 28);
            lblTitleForm.TabIndex = 0;
            lblTitleForm.Text = "Configure your new procedure";
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColorG = Color.Empty;
            panelBorderRadiusCustom1.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(btnChooseTemplate);
            panelBorderRadiusCustom1.Controls.Add(btnCancel);
            panelBorderRadiusCustom1.Location = new Point(1, 650);
            panelBorderRadiusCustom1.Margin = new Padding(0);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 5;
            panelBorderRadiusCustom1.RadiusBottomRight = 5;
            panelBorderRadiusCustom1.RadiusTopLeft = 0;
            panelBorderRadiusCustom1.RadiusTopRight = 0;
            panelBorderRadiusCustom1.Size = new Size(1078, 71);
            panelBorderRadiusCustom1.TabIndex = 7;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            // 
            // panelBorderRadiusCustom2
            // 
            panelBorderRadiusCustom2.BackColorG = Color.White;
            panelBorderRadiusCustom2.BorderColor = Color.FromArgb(14, 82, 98);
            panelBorderRadiusCustom2.BorderSize = 1;
            panelBorderRadiusCustom2.Controls.Add(btnCloseDefault);
            panelBorderRadiusCustom2.Controls.Add(lblTitleForm);
            panelBorderRadiusCustom2.Controls.Add(lblDesTemplateName);
            panelBorderRadiusCustom2.Location = new Point(0, 0);
            panelBorderRadiusCustom2.Margin = new Padding(0);
            panelBorderRadiusCustom2.Name = "panelBorderRadiusCustom2";
            panelBorderRadiusCustom2.RadiusBottomLeft = 0;
            panelBorderRadiusCustom2.RadiusBottomRight = 0;
            panelBorderRadiusCustom2.RadiusTopLeft = 5;
            panelBorderRadiusCustom2.RadiusTopRight = 5;
            panelBorderRadiusCustom2.Size = new Size(1078, 77);
            panelBorderRadiusCustom2.TabIndex = 8;
            panelBorderRadiusCustom2.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom2.VerticalPoints");
            // 
            // btnCloseDefault
            // 
            btnCloseDefault.Cursor = Cursors.Hand;
            btnCloseDefault.FlatAppearance.BorderColor = Color.White;
            btnCloseDefault.FlatAppearance.BorderSize = 0;
            btnCloseDefault.FlatAppearance.MouseDownBackColor = Color.FromArgb(232, 232, 232);
            btnCloseDefault.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 232, 232);
            btnCloseDefault.FlatStyle = FlatStyle.Flat;
            btnCloseDefault.Image = Properties.Resources.iconCloseBlack;
            btnCloseDefault.Location = new Point(1028, 14);
            btnCloseDefault.Margin = new Padding(0);
            btnCloseDefault.Name = "btnCloseDefault";
            btnCloseDefault.Size = new Size(41, 30);
            btnCloseDefault.TabIndex = 4;
            btnCloseDefault.UseVisualStyleBackColor = true;
            btnCloseDefault.Click += btnCloseDefault_Click;
            // 
            // panelBorderRadiusCustom5
            // 
            panelBorderRadiusCustom5.BackColorG = Color.White;
            panelBorderRadiusCustom5.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom5.BorderSize = 1;
            panelBorderRadiusCustom5.Controls.Add(panel2);
            panelBorderRadiusCustom5.Location = new Point(0, 76);
            panelBorderRadiusCustom5.Name = "panelBorderRadiusCustom5";
            panelBorderRadiusCustom5.RadiusBottomLeft = 0;
            panelBorderRadiusCustom5.RadiusBottomRight = 0;
            panelBorderRadiusCustom5.RadiusTopLeft = 0;
            panelBorderRadiusCustom5.RadiusTopRight = 0;
            panelBorderRadiusCustom5.Size = new Size(1078, 580);
            panelBorderRadiusCustom5.TabIndex = 9;
            panelBorderRadiusCustom5.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom5.VerticalPoints");
            // 
            // FormConfigureNewProcedure
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(1078, 716);
            Controls.Add(panelBorderRadiusCustom5);
            Controls.Add(panelBorderRadiusCustom2);
            Controls.Add(panelBorderRadiusCustom1);
            Font = new Font("Segoe UI", 10.5F);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1078, 716);
            MinimumSize = new Size(1078, 716);
            Name = "FormConfigureNewProcedure";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configure your new procedure";
            FormClosed += FormConfigureNewProcedure_FormClosed;
            panel2.ResumeLayout(false);
            panelBorderRadiusCustom3.ResumeLayout(false);
            panelBorderRadiusCustom3.PerformLayout();
            panelFlow.ResumeLayout(false);
            panelMetaData.ResumeLayout(false);
            panelVariable.ResumeLayout(false);
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelBorderRadiusCustom2.ResumeLayout(false);
            panelBorderRadiusCustom5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Label lblMetadata;
        private TableMetaData tblMetaData;
        private Label lblDesTemplateName;
        private Label lblTitleForm;
        private Button btnChooseTemplate;
        private Button btnCancel;
    
        private Label label3;
        private FlowLayoutPanel panelFlow;
        private PanelBorderRadiusCustom panelVariable;
        private PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private PanelBorderRadiusCustom panelBorderRadiusCustom2;
        private Button btnCloseDefault;
        private PanelBorderRadiusCustom panelBorderRadiusCustom3;
        private RJTextBox32 txtDuration;
        private RJTextBox32 txtCategory;
        private RJTextBox32 txtId;
        private RJTextBox32 txtProcedureName;
        private RJEditor rtbDescription;
        private SelectControl selectSearchDevices;
        private SelectControl selectSearchDUT;
        private Label label2;
        private Label label4;
        private Label label1;
        private Label lblTitleContent;
        private Label lblId;
        private Label lblDescription;
        private Label label8;
        private Label lblDut;
        private Label lblName;
        private Label label5;
        private Label label6;
        private Label label7;
        private PanelBorderRadiusCustom panelMetaData;
        private Controls.Buttons.ButtonCustom btnIconDelete;
        private Controls.Buttons.ButtonCustom btnIconAddMedia;
        private PanelBorderRadiusCustom panelBorderRadiusCustom4;
        private Label label9;
        private Controls.Table.TableReview tableVariable;
        private PanelBorderRadiusCustom panelBorderRadiusCustom5;
    }
}