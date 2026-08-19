namespace T3ACS
{
    partial class FormAddDUT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddDUT));
            panelBorderRadiusCustom1 = new Controls.PanelBorderRadiusCustom();
            label2 = new Label();
            lblTitleDUT = new Label();
            panelBorderRadiusCustom2 = new Controls.PanelBorderRadiusCustom();
            btnSave = new Controls.Buttons.ButtonCustom();
            ButtonCustom1 = new Controls.Buttons.ButtonCustom();
            label1 = new Label();
            panelBorderRadiusCustom3 = new Controls.PanelBorderRadiusCustom();
            txtCalibrationDue = new T3.TextBoxCustom();
            txtSerialNumber = new T3.TextBoxCustom();
            txtCalibrationDate = new T3.TextBoxCustom();
            txtModel = new T3.TextBoxCustom();
            txtUserUnit = new T3.TextBoxCustom();
            txtShipmentDate = new T3.TextBoxCustom();
            txtManufacturer = new T3.TextBoxCustom();
            txtCategory = new T3.TextBoxCustom();
            txtName = new T3.TextBoxCustom();
            label8 = new Label();
            label5 = new Label();
            label7 = new Label();
            label10 = new Label();
            label9 = new Label();
            label6 = new Label();
            label4 = new Label();
            label3 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            panelBorderRadiusCustom1.SuspendLayout();
            panelBorderRadiusCustom2.SuspendLayout();
            panelBorderRadiusCustom3.SuspendLayout();
            SuspendLayout();
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColorG = Color.Empty;
            panelBorderRadiusCustom1.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(label2);
            panelBorderRadiusCustom1.Controls.Add(lblTitleDUT);
            panelBorderRadiusCustom1.Dock = DockStyle.Top;
            panelBorderRadiusCustom1.ForeColor = Color.FromArgb(3, 5, 51);
            panelBorderRadiusCustom1.Location = new Point(0, 0);
            panelBorderRadiusCustom1.Margin = new Padding(0);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 0;
            panelBorderRadiusCustom1.RadiusBottomRight = 0;
            panelBorderRadiusCustom1.RadiusTopLeft = 5;
            panelBorderRadiusCustom1.RadiusTopRight = 5;
            panelBorderRadiusCustom1.Size = new Size(500, 48);
            panelBorderRadiusCustom1.TabIndex = 0;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            // 
            // label2
            // 
            label2.Image = (Image)resources.GetObject("label2.Image");
            label2.Location = new Point(454, 11);
            label2.Name = "label2";
            label2.Size = new Size(34, 24);
            label2.TabIndex = 3;
            label2.Click += label2_Click;
            // 
            // lblTitleDUT
            // 
            lblTitleDUT.AutoSize = true;
            lblTitleDUT.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleDUT.ForeColor = Color.FromArgb(3, 5, 51);
            lblTitleDUT.Location = new Point(12, 13);
            lblTitleDUT.Name = "lblTitleDUT";
            lblTitleDUT.Size = new Size(117, 21);
            lblTitleDUT.TabIndex = 1;
            lblTitleDUT.Text = "Add New DUT ";
            // 
            // panelBorderRadiusCustom2
            // 
            panelBorderRadiusCustom2.BackColorG = Color.Empty;
            panelBorderRadiusCustom2.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom2.BorderSize = 1;
            panelBorderRadiusCustom2.Controls.Add(btnSave);
            panelBorderRadiusCustom2.Controls.Add(ButtonCustom1);
            panelBorderRadiusCustom2.Dock = DockStyle.Bottom;
            panelBorderRadiusCustom2.ForeColor = Color.FromArgb(3, 5, 51);
            panelBorderRadiusCustom2.Location = new Point(0, 685);
            panelBorderRadiusCustom2.Margin = new Padding(0);
            panelBorderRadiusCustom2.Name = "panelBorderRadiusCustom2";
            panelBorderRadiusCustom2.RadiusBottomLeft = 5;
            panelBorderRadiusCustom2.RadiusBottomRight = 5;
            panelBorderRadiusCustom2.RadiusTopLeft = 0;
            panelBorderRadiusCustom2.RadiusTopRight = 0;
            panelBorderRadiusCustom2.Size = new Size(500, 57);
            panelBorderRadiusCustom2.TabIndex = 1;
            panelBorderRadiusCustom2.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom2.VerticalPoints");
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.White;
            btnSave.BackColorG = Color.FromArgb(250, 250, 250);
            btnSave.BorderColorG = Color.DarkGray;
            btnSave.BorderSize = 1;
            btnSave.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.ForeColor = Color.FromArgb(0, 32, 77);
            btnSave.ForeColorG = Color.FromArgb(0, 32, 77);
            btnSave.HoverG = false;
            btnSave.HoverColor = Color.Empty;
            btnSave.iConLocation = new Point(11, 5);
            btnSave.ImageAd = null;
            btnSave.Location = new Point(354, 13);
            btnSave.Name = "btnSave";
            btnSave.RadiusBottomLeft = 5;
            btnSave.RadiusBottomRight = 5;
            btnSave.RadiusTopLeft = 5;
            btnSave.RadiusTopRight = 5;
            btnSave.Size = new Size(120, 34);
            btnSave.TabIndex = 0;
            btnSave.TextAlign = ContentAlignment.MiddleLeft;
            btnSave.TextLocation = new Point(24, 4);
            btnSave.Texts = "Add DUT";
            btnSave._EventSelect += ButtonCustom2__EventSelect;
            btnSave.Load += btnSave_Load;
            // 
            // ButtonCustom1
            // 
            ButtonCustom1.BackColor = Color.White;
            ButtonCustom1.BackColorG = Color.White;
            ButtonCustom1.BorderColorG = Color.DarkGray;
            ButtonCustom1.BorderSize = 1;
            ButtonCustom1.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonCustom1.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ButtonCustom1.ForeColor = Color.FromArgb(0, 32, 77);
            ButtonCustom1.ForeColorG = Color.FromArgb(0, 32, 77);
            ButtonCustom1.HoverG = false;
            ButtonCustom1.HoverColor = Color.Empty;
            ButtonCustom1.iConLocation = new Point(11, 5);
            ButtonCustom1.ImageAd = null;
            ButtonCustom1.Location = new Point(256, 13);
            ButtonCustom1.Name = "ButtonCustom1";
            ButtonCustom1.RadiusBottomLeft = 5;
            ButtonCustom1.RadiusBottomRight = 5;
            ButtonCustom1.RadiusTopLeft = 5;
            ButtonCustom1.RadiusTopRight = 5;
            ButtonCustom1.Size = new Size(80, 34);
            ButtonCustom1.TabIndex = 0;
            ButtonCustom1.TextAlign = ContentAlignment.MiddleLeft;
            ButtonCustom1.TextLocation = new Point(15, 4);
            ButtonCustom1.Texts = "Cancel";
            ButtonCustom1._EventSelect += ButtonCustom1__EventSelect;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(22, 22);
            label1.Name = "label1";
            label1.Size = new Size(82, 19);
            label1.TabIndex = 2;
            label1.Text = "DUT  Name";
            // 
            // panelBorderRadiusCustom3
            // 
            panelBorderRadiusCustom3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelBorderRadiusCustom3.BackColorG = Color.Empty;
            panelBorderRadiusCustom3.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom3.BorderSize = 1;
            panelBorderRadiusCustom3.Controls.Add(label15);
            panelBorderRadiusCustom3.Controls.Add(label14);
            panelBorderRadiusCustom3.Controls.Add(label13);
            panelBorderRadiusCustom3.Controls.Add(label12);
            panelBorderRadiusCustom3.Controls.Add(label11);
            panelBorderRadiusCustom3.Controls.Add(txtCalibrationDue);
            panelBorderRadiusCustom3.Controls.Add(txtSerialNumber);
            panelBorderRadiusCustom3.Controls.Add(txtCalibrationDate);
            panelBorderRadiusCustom3.Controls.Add(txtModel);
            panelBorderRadiusCustom3.Controls.Add(txtUserUnit);
            panelBorderRadiusCustom3.Controls.Add(txtShipmentDate);
            panelBorderRadiusCustom3.Controls.Add(txtManufacturer);
            panelBorderRadiusCustom3.Controls.Add(txtCategory);
            panelBorderRadiusCustom3.Controls.Add(txtName);
            panelBorderRadiusCustom3.Controls.Add(label8);
            panelBorderRadiusCustom3.Controls.Add(label5);
            panelBorderRadiusCustom3.Controls.Add(label7);
            panelBorderRadiusCustom3.Controls.Add(label10);
            panelBorderRadiusCustom3.Controls.Add(label9);
            panelBorderRadiusCustom3.Controls.Add(label6);
            panelBorderRadiusCustom3.Controls.Add(label4);
            panelBorderRadiusCustom3.Controls.Add(label3);
            panelBorderRadiusCustom3.Controls.Add(label1);
            panelBorderRadiusCustom3.Location = new Point(0, 47);
            panelBorderRadiusCustom3.Margin = new Padding(0);
            panelBorderRadiusCustom3.Name = "panelBorderRadiusCustom3";
            panelBorderRadiusCustom3.RadiusBottomLeft = 0;
            panelBorderRadiusCustom3.RadiusBottomRight = 0;
            panelBorderRadiusCustom3.RadiusTopLeft = 0;
            panelBorderRadiusCustom3.RadiusTopRight = 0;
            panelBorderRadiusCustom3.Size = new Size(500, 639);
            panelBorderRadiusCustom3.TabIndex = 3;
            panelBorderRadiusCustom3.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom3.VerticalPoints");
            // 
            // txtCalibrationDue
            // 
            txtCalibrationDue.BackColor = Color.White;
            txtCalibrationDue.BorderColor = Color.DarkGray;
            txtCalibrationDue.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtCalibrationDue.BorderRadius = 5;
            txtCalibrationDue.BorderSize = 1;
            txtCalibrationDue.Font = new Font("Segoe UI", 10.5F);
            txtCalibrationDue.Location = new Point(256, 419);
            txtCalibrationDue.Margin = new Padding(0);
            txtCalibrationDue.Multiline = false;
            txtCalibrationDue.Name = "txtCalibrationDue";
            txtCalibrationDue.PasswordChar = false;
            txtCalibrationDue.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtCalibrationDue.PlaceholderText = " Serial Number";
            txtCalibrationDue.ReadOnly = false;
            txtCalibrationDue.Size = new Size(218, 40);
            txtCalibrationDue.TabIndex = 3;
            txtCalibrationDue.Texts = "";
            txtCalibrationDue.UnderlinedStyle = false;
            // 
            // txtSerialNumber
            // 
            txtSerialNumber.BackColor = Color.White;
            txtSerialNumber.BorderColor = Color.DarkGray;
            txtSerialNumber.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtSerialNumber.BorderRadius = 5;
            txtSerialNumber.BorderSize = 1;
            txtSerialNumber.Font = new Font("Segoe UI", 10.5F);
            txtSerialNumber.Location = new Point(256, 232);
            txtSerialNumber.Margin = new Padding(0);
            txtSerialNumber.Multiline = false;
            txtSerialNumber.Name = "txtSerialNumber";
            txtSerialNumber.PasswordChar = false;
            txtSerialNumber.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtSerialNumber.PlaceholderText = " Serial Number";
            txtSerialNumber.ReadOnly = false;
            txtSerialNumber.Size = new Size(218, 40);
            txtSerialNumber.TabIndex = 3;
            txtSerialNumber.Texts = "";
            txtSerialNumber.UnderlinedStyle = false;
            // 
            // txtCalibrationDate
            // 
            txtCalibrationDate.BackColor = Color.White;
            txtCalibrationDate.BorderColor = Color.DarkGray;
            txtCalibrationDate.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtCalibrationDate.BorderRadius = 5;
            txtCalibrationDate.BorderSize = 1;
            txtCalibrationDate.Font = new Font("Segoe UI", 10.5F);
            txtCalibrationDate.Location = new Point(24, 419);
            txtCalibrationDate.Margin = new Padding(0);
            txtCalibrationDate.Multiline = false;
            txtCalibrationDate.Name = "txtCalibrationDate";
            txtCalibrationDate.PasswordChar = false;
            txtCalibrationDate.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtCalibrationDate.PlaceholderText = " Model";
            txtCalibrationDate.ReadOnly = false;
            txtCalibrationDate.Size = new Size(218, 40);
            txtCalibrationDate.TabIndex = 3;
            txtCalibrationDate.Texts = "";
            txtCalibrationDate.UnderlinedStyle = false;
            // 
            // txtModel
            // 
            txtModel.BackColor = Color.White;
            txtModel.BorderColor = Color.DarkGray;
            txtModel.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtModel.BorderRadius = 5;
            txtModel.BorderSize = 1;
            txtModel.Font = new Font("Segoe UI", 10.5F);
            txtModel.Location = new Point(24, 232);
            txtModel.Margin = new Padding(0);
            txtModel.Multiline = false;
            txtModel.Name = "txtModel";
            txtModel.PasswordChar = false;
            txtModel.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtModel.PlaceholderText = " Model";
            txtModel.ReadOnly = false;
            txtModel.Size = new Size(218, 40);
            txtModel.TabIndex = 3;
            txtModel.Texts = "";
            txtModel.UnderlinedStyle = false;
            // 
            // txtUserUnit
            // 
            txtUserUnit.BackColor = Color.White;
            txtUserUnit.BorderColor = Color.DarkGray;
            txtUserUnit.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtUserUnit.BorderRadius = 5;
            txtUserUnit.BorderSize = 1;
            txtUserUnit.Font = new Font("Segoe UI", 10.5F);
            txtUserUnit.Location = new Point(24, 589);
            txtUserUnit.Margin = new Padding(0);
            txtUserUnit.Multiline = false;
            txtUserUnit.Name = "txtUserUnit";
            txtUserUnit.PasswordChar = false;
            txtUserUnit.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtUserUnit.PlaceholderText = " Manufacturer";
            txtUserUnit.ReadOnly = false;
            txtUserUnit.Size = new Size(452, 40);
            txtUserUnit.TabIndex = 3;
            txtUserUnit.Texts = "";
            txtUserUnit.UnderlinedStyle = false;
            // 
            // txtShipmentDate
            // 
            txtShipmentDate.BackColor = Color.White;
            txtShipmentDate.BorderColor = Color.DarkGray;
            txtShipmentDate.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtShipmentDate.BorderRadius = 5;
            txtShipmentDate.BorderSize = 1;
            txtShipmentDate.Font = new Font("Segoe UI", 10.5F);
            txtShipmentDate.Location = new Point(24, 508);
            txtShipmentDate.Margin = new Padding(0);
            txtShipmentDate.Multiline = false;
            txtShipmentDate.Name = "txtShipmentDate";
            txtShipmentDate.PasswordChar = false;
            txtShipmentDate.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtShipmentDate.PlaceholderText = " Manufacturer";
            txtShipmentDate.ReadOnly = false;
            txtShipmentDate.Size = new Size(452, 40);
            txtShipmentDate.TabIndex = 3;
            txtShipmentDate.Texts = "";
            txtShipmentDate.UnderlinedStyle = false;
            // 
            // txtManufacturer
            // 
            txtManufacturer.BackColor = Color.White;
            txtManufacturer.BorderColor = Color.DarkGray;
            txtManufacturer.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtManufacturer.BorderRadius = 5;
            txtManufacturer.BorderSize = 1;
            txtManufacturer.Font = new Font("Segoe UI", 10.5F);
            txtManufacturer.Location = new Point(22, 323);
            txtManufacturer.Margin = new Padding(0);
            txtManufacturer.Multiline = false;
            txtManufacturer.Name = "txtManufacturer";
            txtManufacturer.PasswordChar = false;
            txtManufacturer.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtManufacturer.PlaceholderText = " Manufacturer";
            txtManufacturer.ReadOnly = false;
            txtManufacturer.Size = new Size(452, 40);
            txtManufacturer.TabIndex = 3;
            txtManufacturer.Texts = "";
            txtManufacturer.UnderlinedStyle = false;
            // 
            // txtCategory
            // 
            txtCategory.BackColor = Color.White;
            txtCategory.BorderColor = Color.DarkGray;
            txtCategory.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtCategory.BorderRadius = 5;
            txtCategory.BorderSize = 1;
            txtCategory.Font = new Font("Segoe UI", 10.5F);
            txtCategory.Location = new Point(24, 144);
            txtCategory.Margin = new Padding(0);
            txtCategory.Multiline = false;
            txtCategory.Name = "txtCategory";
            txtCategory.PasswordChar = false;
            txtCategory.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtCategory.PlaceholderText = " Category";
            txtCategory.ReadOnly = false;
            txtCategory.Size = new Size(452, 40);
            txtCategory.TabIndex = 3;
            txtCategory.Texts = "";
            txtCategory.UnderlinedStyle = false;
            // 
            // txtName
            // 
            txtName.BackColor = Color.White;
            txtName.BorderColor = Color.DarkGray;
            txtName.BorderFocusColor = Color.FromArgb(3, 120, 212);
            txtName.BorderRadius = 5;
            txtName.BorderSize = 1;
            txtName.Font = new Font("Segoe UI", 10.5F);
            txtName.Location = new Point(24, 54);
            txtName.Margin = new Padding(0);
            txtName.Multiline = false;
            txtName.Name = "txtName";
            txtName.PasswordChar = false;
            txtName.PlaceholderColor = Color.FromArgb(153, 166, 184);
            txtName.PlaceholderText = " Enter DUT  name";
            txtName.ReadOnly = false;
            txtName.Size = new Size(452, 40);
            txtName.TabIndex = 3;
            txtName.Texts = "";
            txtName.UnderlinedStyle = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(254, 387);
            label8.Name = "label8";
            label8.Size = new Size(107, 19);
            label8.TabIndex = 2;
            label8.Text = "Calibration Due";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(254, 200);
            label5.Name = "label5";
            label5.Size = new Size(99, 19);
            label5.TabIndex = 2;
            label5.Text = "Serial Number";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(22, 387);
            label7.Name = "label7";
            label7.Size = new Size(111, 19);
            label7.TabIndex = 2;
            label7.Text = "Calibration Date";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(22, 559);
            label10.Name = "label10";
            label10.Size = new Size(68, 19);
            label10.TabIndex = 2;
            label10.Text = "User Unit";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(22, 478);
            label9.Name = "label9";
            label9.Size = new Size(102, 19);
            label9.TabIndex = 2;
            label9.Text = "Shipment Date";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 291);
            label6.Name = "label6";
            label6.Size = new Size(94, 19);
            label6.TabIndex = 2;
            label6.Text = "Manufacturer";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(22, 200);
            label4.Name = "label4";
            label4.Size = new Size(49, 19);
            label4.TabIndex = 2;
            label4.Text = "Model";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(22, 112);
            label3.Name = "label3";
            label3.Size = new Size(66, 19);
            label3.TabIndex = 2;
            label3.Text = "Category";
            // 
            // label11
            // 
            label11.ForeColor = Color.Red;
            label11.Location = new Point(101, 22);
            label11.Name = "label11";
            label11.Size = new Size(12, 15);
            label11.TabIndex = 4;
            label11.Text = "*";
            // 
            // label12
            // 
            label12.ForeColor = Color.Red;
            label12.Location = new Point(87, 112);
            label12.Name = "label12";
            label12.Size = new Size(12, 15);
            label12.TabIndex = 4;
            label12.Text = "*";
            // 
            // label13
            // 
            label13.ForeColor = Color.Red;
            label13.Location = new Point(69, 200);
            label13.Name = "label13";
            label13.Size = new Size(12, 15);
            label13.TabIndex = 4;
            label13.Text = "*";
            // 
            // label14
            // 
            label14.ForeColor = Color.Red;
            label14.Location = new Point(359, 200);
            label14.Name = "label14";
            label14.Size = new Size(12, 15);
            label14.TabIndex = 4;
            label14.Text = "*";
            // 
            // label15
            // 
            label15.ForeColor = Color.Red;
            label15.Location = new Point(111, 291);
            label15.Name = "label15";
            label15.Size = new Size(12, 15);
            label15.TabIndex = 4;
            label15.Text = "*";
            // 
            // FormAddDUT
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            ClientSize = new Size(500, 742);
            Controls.Add(panelBorderRadiusCustom3);
            Controls.Add(panelBorderRadiusCustom2);
            Controls.Add(panelBorderRadiusCustom1);
            Font = new Font("Segoe UI", 10.5F);
            ForeColor = Color.FromArgb(3, 5, 51);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormAddDUT";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormAddDUT";
            Load += FormAddDUT_Load;
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelBorderRadiusCustom1.PerformLayout();
            panelBorderRadiusCustom2.ResumeLayout(false);
            panelBorderRadiusCustom3.ResumeLayout(false);
            panelBorderRadiusCustom3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Controls.PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private Controls.PanelBorderRadiusCustom panelBorderRadiusCustom2;
        private Label lblTitleDUT;
        private Label label2;
        private Label label1;
        private Controls.PanelBorderRadiusCustom panelBorderRadiusCustom3;
        private T3.TextBoxCustom txtSerialNumber;
        private T3.TextBoxCustom txtModel;
        private T3.TextBoxCustom txtCategory;
        private T3.TextBoxCustom txtName;
        private Label label5;
        private Label label4;
        private Label label3;
        private T3.TextBoxCustom txtManufacturer;
        private Label label6;
        private T3.TextBoxCustom txtCalibrationDue;
        private T3.TextBoxCustom txtCalibrationDate;
        private T3.TextBoxCustom txtUserUnit;
        private T3.TextBoxCustom txtShipmentDate;
        private Label label8;
        private Label label7;
        private Label label10;
        private Label label9;
        private Controls.Buttons.ButtonCustom btnSave;
        private Controls.Buttons.ButtonCustom ButtonCustom1;
        private Label label11;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
    }
}