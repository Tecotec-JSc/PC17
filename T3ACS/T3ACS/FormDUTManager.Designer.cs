
using T3ACS.Controls;

namespace T3ACS
{
    partial class FormDUTManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDUTManager));
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            panel1 = new Panel();
            panelBorderRadiusCustom3 = new PanelBorderRadiusCustom();
            dataGridView1 = new DataGridView();
            ProcedureId = new DataGridViewTextBoxColumn();
            clmAction = new DataGridViewCheckBoxColumn();
            clmId = new DataGridViewTextBoxColumn();
            clmProcedure = new DataGridViewTextBoxColumn();
            clmDUT = new DataGridViewTextBoxColumn();
            clmVersion = new DataGridViewTextBoxColumn();
            Manufacturer = new DataGridViewTextBoxColumn();
            cboAction = new SelectCustomD();
            panelBorderRadiusCustom2 = new PanelBorderRadiusCustom();
            label5 = new Label();
            label3 = new Label();
            checkBox1 = new CheckBox();
            label4 = new Label();
            label2 = new Label();
            label10 = new Label();
            tabProcedure = new Controls.tab.TabControl();
            btnIconAddNew = new Controls.Buttons.ButtonCustom();
            btnActionProcedure = new Controls.Buttons.ButtonCustom();
            btnIconExport = new Controls.Buttons.ButtonCustom();
            btnIconImport = new Controls.Buttons.ButtonCustom();
            panelBorderRadiusCustom1 = new PanelBorderRadiusCustom();
            btnCloseDefault = new Button();
            label1 = new Label();
            panelControl2 = new PanelBorderRadiusCustom();
            panel1.SuspendLayout();
            panelBorderRadiusCustom3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelBorderRadiusCustom2.SuspendLayout();
            panelBorderRadiusCustom1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(panelBorderRadiusCustom3);
            panel1.Controls.Add(cboAction);
            panel1.Controls.Add(panelBorderRadiusCustom2);
            panel1.Controls.Add(tabProcedure);
            panel1.Controls.Add(btnIconAddNew);
            panel1.Controls.Add(btnActionProcedure);
            panel1.Controls.Add(btnIconExport);
            panel1.Controls.Add(btnIconImport);
            panel1.Controls.Add(panelBorderRadiusCustom1);
            panel1.Dock = DockStyle.Fill;
            panel1.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panel1.ForeColor = Color.FromArgb(3, 5, 51);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1080, 720);
            panel1.TabIndex = 3;
            // 
            // panelBorderRadiusCustom3
            // 
            panelBorderRadiusCustom3.BackColorG = Color.Empty;
            panelBorderRadiusCustom3.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom3.BorderSize = 1;
            panelBorderRadiusCustom3.Controls.Add(dataGridView1);
            panelBorderRadiusCustom3.Location = new Point(12, 201);
            panelBorderRadiusCustom3.Margin = new Padding(0);
            panelBorderRadiusCustom3.Name = "panelBorderRadiusCustom3";
            panelBorderRadiusCustom3.Padding = new Padding(1);
            panelBorderRadiusCustom3.RadiusBottomLeft = 0;
            panelBorderRadiusCustom3.RadiusBottomRight = 0;
            panelBorderRadiusCustom3.RadiusTopLeft = 0;
            panelBorderRadiusCustom3.RadiusTopRight = 0;
            panelBorderRadiusCustom3.Size = new Size(1032, 486);
            panelBorderRadiusCustom3.TabIndex = 18;
            panelBorderRadiusCustom3.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom3.VerticalPoints");
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle9.BackColor = SystemColors.Control;
            dataGridViewCellStyle9.Font = new Font("Segoe UI Variable Display", 10.5F);
            dataGridViewCellStyle9.SelectionBackColor = SystemColors.Control;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ProcedureId, clmAction, clmId, clmProcedure, clmDUT, clmVersion, Manufacturer });
            dataGridViewCellStyle11.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = SystemColors.Window;
            dataGridViewCellStyle11.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle11.ForeColor = Color.FromArgb(3, 5, 51);
            dataGridViewCellStyle11.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle11.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle11.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle11;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(1, 1);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle12.Font = new Font("Segoe UI Variable Display", 10.5F);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle12;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI Variable Display", 10.5F);
            dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(5, 7, 72);
            dataGridView1.RowTemplate.Height = 54;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1030, 484);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // ProcedureId
            // 
            ProcedureId.DataPropertyName = "Id";
            ProcedureId.HeaderText = "ProcedureId";
            ProcedureId.Name = "ProcedureId";
            ProcedureId.ReadOnly = true;
            ProcedureId.Visible = false;
            // 
            // clmAction
            // 
            clmAction.DataPropertyName = "Action";
            clmAction.FalseValue = "false";
            clmAction.HeaderText = "";
            clmAction.Name = "clmAction";
            clmAction.ReadOnly = true;
            clmAction.Resizable = DataGridViewTriState.False;
            clmAction.TrueValue = "true";
            clmAction.Width = 36;
            // 
            // clmId
            // 
            clmId.DataPropertyName = "Name";
            dataGridViewCellStyle10.WrapMode = DataGridViewTriState.True;
            clmId.DefaultCellStyle = dataGridViewCellStyle10;
            clmId.HeaderText = "ID";
            clmId.Name = "clmId";
            clmId.ReadOnly = true;
            clmId.SortMode = DataGridViewColumnSortMode.NotSortable;
            clmId.Width = 271;
            // 
            // clmProcedure
            // 
            clmProcedure.DataPropertyName = "Category";
            clmProcedure.HeaderText = "Category";
            clmProcedure.Name = "clmProcedure";
            clmProcedure.ReadOnly = true;
            clmProcedure.SortMode = DataGridViewColumnSortMode.NotSortable;
            clmProcedure.Width = 186;
            // 
            // clmDUT
            // 
            clmDUT.DataPropertyName = "Model";
            clmDUT.HeaderText = "Model";
            clmDUT.Name = "clmDUT";
            clmDUT.ReadOnly = true;
            clmDUT.SortMode = DataGridViewColumnSortMode.NotSortable;
            clmDUT.Width = 193;
            // 
            // clmVersion
            // 
            clmVersion.DataPropertyName = "SerialNumber";
            clmVersion.HeaderText = "SerialNumber";
            clmVersion.Name = "clmVersion";
            clmVersion.ReadOnly = true;
            clmVersion.Width = 193;
            // 
            // Manufacturer
            // 
            Manufacturer.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Manufacturer.DataPropertyName = "Manufacturer";
            Manufacturer.HeaderText = "Manufacturer";
            Manufacturer.Name = "Manufacturer";
            // 
            // cboAction
            // 
            cboAction.ArrowColor = Color.FromArgb(0, 32, 77);
            cboAction.BackColor = Color.FromArgb(250, 250, 250);
            cboAction.BorderColor = Color.DarkGray;
            cboAction.BorderSize = 1;
            cboAction.Font = new Font("Segoe UI", 10.5F);
            cboAction.ForeColor = Color.FromArgb(0, 32, 77);
            cboAction.Items = new string[]
    {
    "Edit DUT",
    "Duplicate DUT",
    "Delete DUT"
    };
            cboAction.Location = new Point(11, 127);
            cboAction.Margin = new Padding(0);
            cboAction.Name = "cboAction";
            cboAction.RadiusBottomLeft = 5;
            cboAction.RadiusBottomRight = 5;
            cboAction.RadiusTopLeft = 5;
            cboAction.RadiusTopRight = 5;
            cboAction.SelectedIndex = -1;
            cboAction.ShowArrow = true;
            cboAction.Size = new Size(160, 34);
            cboAction.TabIndex = 15;
            cboAction.Texts = "Action";
            // 
            // panelBorderRadiusCustom2
            // 
            panelBorderRadiusCustom2.BackColor = Color.White;
            panelBorderRadiusCustom2.BackColorG = Color.Empty;
            panelBorderRadiusCustom2.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom2.BorderSize = 1;
            panelBorderRadiusCustom2.Controls.Add(label5);
            panelBorderRadiusCustom2.Controls.Add(label3);
            panelBorderRadiusCustom2.Controls.Add(checkBox1);
            panelBorderRadiusCustom2.Controls.Add(label4);
            panelBorderRadiusCustom2.Controls.Add(label2);
            panelBorderRadiusCustom2.Controls.Add(label10);
            panelBorderRadiusCustom2.Location = new Point(12, 170);
            panelBorderRadiusCustom2.Name = "panelBorderRadiusCustom2";
            panelBorderRadiusCustom2.RadiusBottomLeft = 0;
            panelBorderRadiusCustom2.RadiusBottomRight = 0;
            panelBorderRadiusCustom2.RadiusTopLeft = 0;
            panelBorderRadiusCustom2.RadiusTopRight = 0;
            panelBorderRadiusCustom2.Size = new Size(1032, 32);
            panelBorderRadiusCustom2.TabIndex = 17;
            panelBorderRadiusCustom2.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom2.VerticalPoints");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Window;
            label5.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label5.Location = new Point(495, 6);
            label5.Name = "label5";
            label5.Size = new Size(51, 19);
            label5.TabIndex = 11;
            label5.Text = "Model";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Window;
            label3.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label3.Location = new Point(44, 6);
            label3.Name = "label3";
            label3.Size = new Size(48, 19);
            label3.TabIndex = 11;
            label3.Text = "Name";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = SystemColors.Window;
            checkBox1.Location = new Point(10, 9);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 13;
            checkBox1.UseVisualStyleBackColor = false;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Window;
            label4.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label4.Location = new Point(315, 6);
            label4.Name = "label4";
            label4.Size = new Size(71, 19);
            label4.TabIndex = 11;
            label4.Text = "Category";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Window;
            label2.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label2.Location = new Point(876, 6);
            label2.Name = "label2";
            label2.Size = new Size(99, 19);
            label2.TabIndex = 11;
            label2.Text = "Manufacturer";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.Window;
            label10.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label10.Location = new Point(688, 6);
            label10.Name = "label10";
            label10.Size = new Size(104, 19);
            label10.TabIndex = 11;
            label10.Text = "Serial Number";
            // 
            // tabProcedure
            // 
            tabProcedure.BackColor = Color.Transparent;
            tabProcedure.BackColorG = Color.Transparent;
            tabProcedure.BottomLineColor = Color.FromArgb(0, 112, 203);
            tabProcedure.BottomLineSize = 2;
            tabProcedure.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tabProcedure.FontG = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabProcedure.ForeColorG = Color.FromArgb(3, 5, 51);
            tabProcedure.ForeColorNoSelect = Color.FromArgb(188, 189, 195);
            tabProcedure.HoverG = false;
            tabProcedure.HoverColor = Color.Empty;
            tabProcedure.Location = new Point(11, 87);
            tabProcedure.Margin = new Padding(3, 4, 3, 4);
            tabProcedure.Name = "tabProcedure";
            tabProcedure.ShowBottomLine = true;
            tabProcedure.Size = new Size(134, 31);
            tabProcedure.TabIndex = 14;
            tabProcedure.TextLocation = new Point(9, 5);
            tabProcedure.Texts = "DUT LIST";
            tabProcedure.Click += tabProcedureList_Click;
            // 
            // btnIconAddNew
            // 
            btnIconAddNew.BackColor = Color.White;
            btnIconAddNew.BackColorG = Color.FromArgb(11, 123, 105);
            btnIconAddNew.BorderColorG = Color.FromArgb(11, 123, 105);
            btnIconAddNew.BorderSize = 1;
            btnIconAddNew.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconAddNew.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconAddNew.ForeColor = Color.FromArgb(11, 123, 105);
            btnIconAddNew.ForeColorG = Color.White;
            btnIconAddNew.HoverG = false;
            btnIconAddNew.HoverColor = Color.Empty;
            btnIconAddNew.iConLocation = new Point(31, 5);
            btnIconAddNew.ImageAd = (Image)resources.GetObject("btnIconAddNew.ImageAd");
            btnIconAddNew.Location = new Point(11, 43);
            btnIconAddNew.Name = "btnIconAddNew";
            btnIconAddNew.RadiusBottomLeft = 5;
            btnIconAddNew.RadiusBottomRight = 5;
            btnIconAddNew.RadiusTopLeft = 5;
            btnIconAddNew.RadiusTopRight = 5;
            btnIconAddNew.Size = new Size(121, 32);
            btnIconAddNew.TabIndex = 13;
            btnIconAddNew.TextAlign = ContentAlignment.MiddleLeft;
            btnIconAddNew.TextLocation = new Point(55, 4);
            btnIconAddNew.Texts = "NEW";
            btnIconAddNew._EventSelect += btnPass2_Click;
            btnIconAddNew.Load += btnIconAddNew_Load;
            // 
            // btnActionProcedure
            // 
            btnActionProcedure.BackColor = Color.White;
            btnActionProcedure.BackColorG = Color.FromArgb(11, 123, 105);
            btnActionProcedure.BorderColorG = Color.FromArgb(11, 123, 105);
            btnActionProcedure.BorderSize = 1;
            btnActionProcedure.Cursor = Cursors.Hand;
            btnActionProcedure.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActionProcedure.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActionProcedure.ForeColor = Color.FromArgb(0, 32, 77);
            btnActionProcedure.ForeColorG = Color.White;
            btnActionProcedure.HoverG = false;
            btnActionProcedure.HoverColor = Color.Empty;
            btnActionProcedure.iConLocation = new Point(11, 5);
            btnActionProcedure.ImageAd = null;
            btnActionProcedure.Location = new Point(180, 128);
            btnActionProcedure.Name = "btnActionProcedure";
            btnActionProcedure.RadiusBottomLeft = 5;
            btnActionProcedure.RadiusBottomRight = 5;
            btnActionProcedure.RadiusTopLeft = 5;
            btnActionProcedure.RadiusTopRight = 5;
            btnActionProcedure.Size = new Size(68, 32);
            btnActionProcedure.TabIndex = 16;
            btnActionProcedure.TextAlign = ContentAlignment.MiddleLeft;
            btnActionProcedure.TextLocation = new Point(10, 4);
            btnActionProcedure.Texts = "Apply";
            btnActionProcedure._EventSelect += btnAction_Click;
            // 
            // btnIconExport
            // 
            btnIconExport.BackColor = Color.White;
            btnIconExport.BackColorG = Color.White;
            btnIconExport.BorderColorG = Color.DarkGray;
            btnIconExport.BorderSize = 1;
            btnIconExport.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconExport.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconExport.ForeColor = Color.FromArgb(0, 32, 77);
            btnIconExport.ForeColorG = Color.Black;
            btnIconExport.HoverG = false;
            btnIconExport.HoverColor = Color.Empty;
            btnIconExport.iConLocation = new Point(22, 5);
            btnIconExport.ImageAd = (Image)resources.GetObject("btnIconExport.ImageAd");
            btnIconExport.Location = new Point(281, 43);
            btnIconExport.Name = "btnIconExport";
            btnIconExport.RadiusBottomLeft = 5;
            btnIconExport.RadiusBottomRight = 5;
            btnIconExport.RadiusTopLeft = 5;
            btnIconExport.RadiusTopRight = 5;
            btnIconExport.Size = new Size(121, 32);
            btnIconExport.TabIndex = 12;
            btnIconExport.TextAlign = ContentAlignment.MiddleLeft;
            btnIconExport.TextLocation = new Point(46, 4);
            btnIconExport.Texts = "EXPORT";
            btnIconExport.Visible = false;
            btnIconExport._EventSelect += btnExport_Click;
            // 
            // btnIconImport
            // 
            btnIconImport.BackColor = Color.White;
            btnIconImport.BackColorG = Color.White;
            btnIconImport.BorderColorG = Color.DarkGray;
            btnIconImport.BorderSize = 1;
            btnIconImport.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconImport.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconImport.ForeColor = Color.FromArgb(0, 32, 77);
            btnIconImport.ForeColorG = Color.Black;
            btnIconImport.HoverG = false;
            btnIconImport.HoverColor = Color.Empty;
            btnIconImport.iConLocation = new Point(22, 5);
            btnIconImport.ImageAd = (Image)resources.GetObject("btnIconImport.ImageAd");
            btnIconImport.Location = new Point(145, 43);
            btnIconImport.Name = "btnIconImport";
            btnIconImport.RadiusBottomLeft = 5;
            btnIconImport.RadiusBottomRight = 5;
            btnIconImport.RadiusTopLeft = 5;
            btnIconImport.RadiusTopRight = 5;
            btnIconImport.Size = new Size(121, 32);
            btnIconImport.TabIndex = 12;
            btnIconImport.TextAlign = ContentAlignment.MiddleLeft;
            btnIconImport.TextLocation = new Point(46, 4);
            btnIconImport.Texts = "IMPORT";
            btnIconImport.Visible = false;
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColor = Color.White;
            panelBorderRadiusCustom1.BackColorG = Color.Empty;
            panelBorderRadiusCustom1.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(btnCloseDefault);
            panelBorderRadiusCustom1.Controls.Add(label1);
            panelBorderRadiusCustom1.Location = new Point(0, 0);
            panelBorderRadiusCustom1.Margin = new Padding(5);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 0;
            panelBorderRadiusCustom1.RadiusBottomRight = 0;
            panelBorderRadiusCustom1.RadiusTopLeft = 5;
            panelBorderRadiusCustom1.RadiusTopRight = 5;
            panelBorderRadiusCustom1.Size = new Size(1080, 32);
            panelBorderRadiusCustom1.TabIndex = 10;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            panelBorderRadiusCustom1.MouseDown += panel1_MouseDown;
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
            btnCloseDefault.Location = new Point(1034, 1);
            btnCloseDefault.Margin = new Padding(0);
            btnCloseDefault.Name = "btnCloseDefault";
            btnCloseDefault.Size = new Size(41, 30);
            btnCloseDefault.TabIndex = 3;
            btnCloseDefault.UseVisualStyleBackColor = true;
            btnCloseDefault.Click += btnCloseDefault_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 7);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(129, 19);
            label1.TabIndex = 2;
            label1.Text = "DUT Management";
            // 
            // panelControl2
            // 
            panelControl2.BackColor = Color.White;
            panelControl2.BorderColor = Color.LightGray;
            panelControl2.BorderSize = 1;
            panelControl2.Dock = DockStyle.Top;
            panelControl2.Location = new Point(0, 0);
            panelControl2.Margin = new Padding(2);
            panelControl2.Name = "panelControl2";
            panelControl2.Padding = new Padding(3);
            panelControl2.Size = new Size(1080, 32);
            panelControl2.TabIndex = 2;
            // 
            // FormDUTManager
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1080, 720);
            Controls.Add(panel1);
            Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormDUTManager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Procedure Management";
            panel1.ResumeLayout(false);
            panelBorderRadiusCustom3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelBorderRadiusCustom2.ResumeLayout(false);
            panelBorderRadiusCustom2.PerformLayout();
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelBorderRadiusCustom1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private PanelBorderRadiusCustom panelControl2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private Button btnCloseDefault;
        private Controls.Buttons.ButtonCustom btnIconImport;
        private Controls.Buttons.ButtonCustom btnIconExport;
        private Controls.Buttons.ButtonCustom btnIconAddNew;
        private Controls.tab.TabControl tabProcedure;
        private Controls.Buttons.ButtonCustom btnActionProcedure;
        private SelectCustomD cboAction;
        private PanelBorderRadiusCustom panelBorderRadiusCustom2;
        private Label label5;
        private Label label3;
        private CheckBox checkBox1;
        private Label label4;
        private Label label10;
        private DataGridView dataGridView1;
        private Label label2;
        private PanelBorderRadiusCustom panelBorderRadiusCustom3;
        private DataGridViewTextBoxColumn ProcedureId;
        private DataGridViewCheckBoxColumn clmAction;
        private DataGridViewTextBoxColumn clmId;
        private DataGridViewTextBoxColumn clmProcedure;
        private DataGridViewTextBoxColumn clmDUT;
        private DataGridViewTextBoxColumn clmVersion;
        private DataGridViewTextBoxColumn Manufacturer;
    }
}