
using T3ACS.Controls;
using T3ACS.Controls.PanelCustoms;

namespace T3ACS
{
    partial class FormTableInspections
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTableInspections));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            panelControl2 = new PanelBorderRadiusCustom();
            panelProcedureList = new Panel();
            panelProcedureTable = new PanelBorderRadiusCustom();
            dataGridView1 = new DataGridView();
            ProcedureId = new DataGridViewTextBoxColumn();
            clmAction = new DataGridViewCheckBoxColumn();
            clmId = new DataGridViewTextBoxColumn();
            clmProcedure = new DataGridViewTextBoxColumn();
            clmDUT = new DataGridViewTextBoxColumn();
            clmVersion = new DataGridViewTextBoxColumn();
            btnFilterProcedureList = new Controls.Buttons.ButtonCustom();
            btnActionProcedure = new Controls.Buttons.ButtonCustom();
            label7 = new Label();
            label6 = new Label();
            label9 = new Label();
            cboDUT = new ComboBox();
            cboActionProcedure = new ComboBox();
            panelTableResult = new PanelBorderRadiusCustom();
            label18 = new Label();
            checkBox2 = new CheckBox();
            label16 = new Label();
            label15 = new Label();
            label13 = new Label();
            label19 = new Label();
            panelBorderRadiusCustom4 = new PanelBorderRadiusCustom();
            dataGridView2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewCheckBoxColumn1 = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            clmAttachFile = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            panelHistory = new Panel();
            btnFilterHistory = new Controls.Buttons.ButtonCustom();
            label11 = new Label();
            panelTableProcedure = new PanelBorderRadiusCustom();
            label5 = new Label();
            label3 = new Label();
            checkBox1 = new CheckBox();
            label4 = new Label();
            label10 = new Label();
            btnActionHistory = new Controls.Buttons.ButtonCustom();
            label12 = new Label();
            panelBorderControl2 = new PanelBorderRadiusCustom();
            cboDUTHistory = new ComboBox();
            cboActionHistory = new ComboBox();
            panelTitle = new PanelBorderRadiusCustom();
            btnIconCloseDefault = new Button();
            lblTitleForm = new Label();
            btnIconImport = new Controls.Buttons.ButtonCustom();
            btnIconExport = new Controls.Buttons.ButtonCustom();
            btnIconAddNew = new Controls.Buttons.ButtonCustom();
            tabProcedure = new Controls.tab.TabControl();
            tabHistory = new Controls.tab.TabControl();
            panelContent = new PanelCustomBorder();
            panelProcedureList.SuspendLayout();
            panelProcedureTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelTableResult.SuspendLayout();
            panelBorderRadiusCustom4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panelHistory.SuspendLayout();
            panelTableProcedure.SuspendLayout();
            panelTitle.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelControl2
            // 
            panelControl2.BackColor = Color.White;
            panelControl2.BackColorG = Color.White;
            panelControl2.BorderColor = Color.LightGray;
            panelControl2.BorderSize = 1;
            panelControl2.Dock = DockStyle.Top;
            panelControl2.Location = new Point(0, 0);
            panelControl2.Margin = new Padding(2);
            panelControl2.Name = "panelControl2";
            panelControl2.Padding = new Padding(3);
            panelControl2.RadiusBottomLeft = 5;
            panelControl2.RadiusBottomRight = 5;
            panelControl2.RadiusTopLeft = 5;
            panelControl2.RadiusTopRight = 5;
            panelControl2.Size = new Size(1080, 32);
            panelControl2.TabIndex = 2;
            panelControl2.VerticalPoints = (List<int>)resources.GetObject("panelControl2.VerticalPoints");
            // 
            // panelProcedureList
            // 
            panelProcedureList.AutoScroll = true;
            panelProcedureList.Controls.Add(panelProcedureTable);
            panelProcedureList.Controls.Add(btnFilterProcedureList);
            panelProcedureList.Controls.Add(btnActionProcedure);
            panelProcedureList.Controls.Add(label7);
            panelProcedureList.Controls.Add(label6);
            panelProcedureList.Controls.Add(label9);
            panelProcedureList.Controls.Add(cboDUT);
            panelProcedureList.Controls.Add(cboActionProcedure);
            panelProcedureList.Controls.Add(panelTableResult);
            panelProcedureList.Location = new Point(1, 95);
            panelProcedureList.Name = "panelProcedureList";
            panelProcedureList.Size = new Size(1078, 624);
            panelProcedureList.TabIndex = 9;
            // 
            // panelProcedureTable
            // 
            panelProcedureTable.BackColorG = Color.Empty;
            panelProcedureTable.BorderColor = Color.DarkGray;
            panelProcedureTable.BorderSize = 1;
            panelProcedureTable.Controls.Add(dataGridView1);
            panelProcedureTable.Location = new Point(12, 71);
            panelProcedureTable.Margin = new Padding(0);
            panelProcedureTable.Name = "panelProcedureTable";
            panelProcedureTable.Padding = new Padding(1);
            panelProcedureTable.RadiusBottomLeft = 0;
            panelProcedureTable.RadiusBottomRight = 0;
            panelProcedureTable.RadiusTopLeft = 0;
            panelProcedureTable.RadiusTopRight = 0;
            panelProcedureTable.Size = new Size(1056, 500);
            panelProcedureTable.TabIndex = 18;
            panelProcedureTable.VerticalPoints = (List<int>)resources.GetObject("panelProcedureTable.VerticalPoints");
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Variable Display", 10.5F);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Control;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ProcedureId, clmAction, clmId, clmProcedure, clmDUT, clmVersion });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(3, 5, 51);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(1, 1);
            dataGridView1.Margin = new Padding(0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Variable Display", 10.5F);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI Variable Display", 10.5F);
            dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(5, 7, 72);
            dataGridView1.RowTemplate.Height = 54;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1054, 498);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // ProcedureId
            // 
            ProcedureId.DataPropertyName = "ProcedureId";
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
            clmId.DataPropertyName = "Id";
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            clmId.DefaultCellStyle = dataGridViewCellStyle2;
            clmId.HeaderText = "ID";
            clmId.Name = "clmId";
            clmId.ReadOnly = true;
            clmId.SortMode = DataGridViewColumnSortMode.NotSortable;
            clmId.Width = 96;
            // 
            // clmProcedure
            // 
            clmProcedure.DataPropertyName = "Name";
            clmProcedure.HeaderText = "PROCEDURE";
            clmProcedure.Name = "clmProcedure";
            clmProcedure.ReadOnly = true;
            clmProcedure.SortMode = DataGridViewColumnSortMode.NotSortable;
            clmProcedure.Width = 409;
            // 
            // clmDUT
            // 
            clmDUT.DataPropertyName = "DUT";
            clmDUT.HeaderText = "DUT";
            clmDUT.Name = "clmDUT";
            clmDUT.ReadOnly = true;
            clmDUT.SortMode = DataGridViewColumnSortMode.NotSortable;
            clmDUT.Width = 316;
            // 
            // clmVersion
            // 
            clmVersion.DataPropertyName = "Version";
            clmVersion.HeaderText = "VERSION";
            clmVersion.Name = "clmVersion";
            clmVersion.ReadOnly = true;
            clmVersion.Width = 176;
            // 
            // btnFilterProcedureList
            // 
            btnFilterProcedureList.BackColor = Color.White;
            btnFilterProcedureList.BackColorG = Color.FromArgb(11, 123, 105);
            btnFilterProcedureList.BorderColorG = Color.FromArgb(11, 123, 105);
            btnFilterProcedureList.BorderSize = 1;
            btnFilterProcedureList.Cursor = Cursors.Hand;
            btnFilterProcedureList.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFilterProcedureList.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFilterProcedureList.ForeColor = Color.FromArgb(0, 32, 77);
            btnFilterProcedureList.ForeColorG = Color.White;
            btnFilterProcedureList.HoverColor = Color.FromArgb(11, 123, 105);
            btnFilterProcedureList.HoverG = false;
            btnFilterProcedureList.iConLocation = new Point(11, 5);
            btnFilterProcedureList.ImageAd = null;
            btnFilterProcedureList.Location = new Point(983, 0);
            btnFilterProcedureList.Name = "btnFilterProcedureList";
            btnFilterProcedureList.RadiusBottomLeft = 5;
            btnFilterProcedureList.RadiusBottomRight = 5;
            btnFilterProcedureList.RadiusTopLeft = 5;
            btnFilterProcedureList.RadiusTopRight = 5;
            btnFilterProcedureList.Size = new Size(68, 30);
            btnFilterProcedureList.TabIndex = 16;
            btnFilterProcedureList.TextAlign = ContentAlignment.MiddleLeft;
            btnFilterProcedureList.TextLocation = new Point(15, 2);
            btnFilterProcedureList.Texts = "Filter";
            btnFilterProcedureList.TextSizes = new Size(42, 22);
            btnFilterProcedureList.Click += btnFilterProcedureList_Click;
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
            btnActionProcedure.HoverColor = Color.FromArgb(11, 123, 105);
            btnActionProcedure.HoverG = false;
            btnActionProcedure.iConLocation = new Point(11, 5);
            btnActionProcedure.ImageAd = null;
            btnActionProcedure.Location = new Point(182, 0);
            btnActionProcedure.Name = "btnActionProcedure";
            btnActionProcedure.RadiusBottomLeft = 5;
            btnActionProcedure.RadiusBottomRight = 5;
            btnActionProcedure.RadiusTopLeft = 5;
            btnActionProcedure.RadiusTopRight = 5;
            btnActionProcedure.Size = new Size(67, 30);
            btnActionProcedure.TabIndex = 16;
            btnActionProcedure.TextAlign = ContentAlignment.MiddleLeft;
            btnActionProcedure.TextLocation = new Point(10, 2);
            btnActionProcedure.Texts = "Apply";
            btnActionProcedure.TextSizes = new Size(48, 23);
            btnActionProcedure._EventSelect += btnAction_Click;
            btnActionProcedure.Click += btnAction_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.Window;
            label7.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(862, 92);
            label7.Name = "label7";
            label7.Size = new Size(78, 21);
            label7.TabIndex = 11;
            label7.Text = "VERSION";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.Window;
            label6.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(686, 92);
            label6.Name = "label6";
            label6.Size = new Size(0, 21);
            label6.TabIndex = 11;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.Window;
            label9.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(704, 47);
            label9.Name = "label9";
            label9.Size = new Size(0, 21);
            label9.TabIndex = 11;
            // 
            // cboDUT
            // 
            cboDUT.BackColor = Color.FromArgb(232, 232, 232);
            cboDUT.Font = new Font("Segoe UI Variable Display", 13F);
            cboDUT.FormattingEnabled = true;
            cboDUT.Location = new Point(817, 0);
            cboDUT.Name = "cboDUT";
            cboDUT.Size = new Size(160, 30);
            cboDUT.TabIndex = 9;
            cboDUT.Text = "DUT";
            // 
            // cboActionProcedure
            // 
            cboActionProcedure.BackColor = Color.FromArgb(232, 232, 232);
            cboActionProcedure.Font = new Font("Segoe UI Variable Display", 13F);
            cboActionProcedure.FormattingEnabled = true;
            cboActionProcedure.Items.AddRange(new object[] { "Open Procedure", "Edit Procedure", "Duplicate Procedure", "Delete Procedure" });
            cboActionProcedure.Location = new Point(12, 0);
            cboActionProcedure.Name = "cboActionProcedure";
            cboActionProcedure.Size = new Size(160, 30);
            cboActionProcedure.TabIndex = 9;
            cboActionProcedure.Text = "Open Procedure";
            // 
            // panelTableResult
            // 
            panelTableResult.BackColor = Color.FromArgb(232, 232, 232);
            panelTableResult.BackColorG = Color.Empty;
            panelTableResult.BorderColor = Color.DarkGray;
            panelTableResult.BorderSize = 1;
            panelTableResult.Controls.Add(label18);
            panelTableResult.Controls.Add(checkBox2);
            panelTableResult.Controls.Add(label16);
            panelTableResult.Controls.Add(label15);
            panelTableResult.Controls.Add(label13);
            panelTableResult.Controls.Add(label19);
            panelTableResult.Location = new Point(12, 40);
            panelTableResult.Name = "panelTableResult";
            panelTableResult.RadiusBottomLeft = 0;
            panelTableResult.RadiusBottomRight = 0;
            panelTableResult.RadiusTopLeft = 0;
            panelTableResult.RadiusTopRight = 0;
            panelTableResult.Size = new Size(1056, 32);
            panelTableResult.TabIndex = 18;
            panelTableResult.VerticalPoints = (List<int>)resources.GetObject("panelTableResult.VerticalPoints");
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = Color.Transparent;
            label18.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.FromArgb(3, 5, 51);
            label18.Location = new Point(40, 5);
            label18.Name = "label18";
            label18.Size = new Size(39, 19);
            label18.TabIndex = 11;
            label18.Text = "RUN";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = Color.Transparent;
            checkBox2.Location = new Point(13, 9);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 13;
            checkBox2.UseVisualStyleBackColor = false;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label16.Location = new Point(369, 5);
            label16.Name = "label16";
            label16.Size = new Size(37, 19);
            label16.TabIndex = 11;
            label16.Text = "DUT";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label15.Location = new Point(730, 5);
            label15.Name = "label15";
            label15.Size = new Size(85, 19);
            label15.TabIndex = 11;
            label15.Text = "START TIME";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.Transparent;
            label13.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label13.Location = new Point(881, 5);
            label13.Name = "label13";
            label13.Size = new Size(72, 19);
            label13.TabIndex = 11;
            label13.Text = "END TIME";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.Transparent;
            label19.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label19.Location = new Point(602, 5);
            label19.Name = "label19";
            label19.Size = new Size(68, 19);
            label19.TabIndex = 11;
            label19.Text = "AUTHOR";
            // 
            // panelBorderRadiusCustom4
            // 
            panelBorderRadiusCustom4.BackColorG = Color.Empty;
            panelBorderRadiusCustom4.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom4.BorderSize = 1;
            panelBorderRadiusCustom4.Controls.Add(dataGridView2);
            panelBorderRadiusCustom4.Location = new Point(12, 71);
            panelBorderRadiusCustom4.Margin = new Padding(0);
            panelBorderRadiusCustom4.Name = "panelBorderRadiusCustom4";
            panelBorderRadiusCustom4.Padding = new Padding(1);
            panelBorderRadiusCustom4.RadiusBottomLeft = 0;
            panelBorderRadiusCustom4.RadiusBottomRight = 0;
            panelBorderRadiusCustom4.RadiusTopLeft = 0;
            panelBorderRadiusCustom4.RadiusTopRight = 0;
            panelBorderRadiusCustom4.Size = new Size(1056, 500);
            panelBorderRadiusCustom4.TabIndex = 19;
            panelBorderRadiusCustom4.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom4.VerticalPoints");
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle5.BackColor = SystemColors.Control;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView2.BackgroundColor = SystemColors.Window;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn4, clmAttachFile, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn6, Column1, Column2 });
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = SystemColors.Window;
            dataGridViewCellStyle7.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle7.ForeColor = Color.FromArgb(3, 5, 51);
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle7;
            dataGridView2.Dock = DockStyle.Fill;
            dataGridView2.Location = new Point(1, 1);
            dataGridView2.Margin = new Padding(4, 5, 4, 5);
            dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Control;
            dataGridViewCellStyle8.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(5, 7, 72);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            dataGridView2.RowHeadersVisible = false;
            dataGridViewCellStyle9.Font = new Font("Segoe UI Variable Display", 10.5F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(5, 7, 72);
            dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle9;
            dataGridView2.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView2.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(5, 7, 72);
            dataGridView2.RowTemplate.Height = 54;
            dataGridView2.ScrollBars = ScrollBars.Vertical;
            dataGridView2.Size = new Size(1054, 498);
            dataGridView2.TabIndex = 1;
            dataGridView2.CellClick += dataGridView2_CellClick;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "ResultProcedureId";
            dataGridViewTextBoxColumn1.HeaderText = "ProcedureId";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            dataGridViewCheckBoxColumn1.DataPropertyName = "Action";
            dataGridViewCheckBoxColumn1.FalseValue = "false";
            dataGridViewCheckBoxColumn1.HeaderText = "";
            dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            dataGridViewCheckBoxColumn1.Resizable = DataGridViewTriState.True;
            dataGridViewCheckBoxColumn1.TrueValue = "true";
            dataGridViewCheckBoxColumn1.Width = 36;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "RUN";
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle6;
            dataGridViewTextBoxColumn2.HeaderText = "RUN";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn2.Width = 332;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "DUT";
            dataGridViewTextBoxColumn4.HeaderText = "DUT";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn4.Width = 233;
            // 
            // clmAttachFile
            // 
            clmAttachFile.DataPropertyName = "Author";
            clmAttachFile.HeaderText = "Author";
            clmAttachFile.Name = "clmAttachFile";
            clmAttachFile.Width = 128;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "STARTTIME";
            dataGridViewTextBoxColumn3.HeaderText = "STARTTIME";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.SortMode = DataGridViewColumnSortMode.NotSortable;
            dataGridViewTextBoxColumn3.Width = 152;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn6.DataPropertyName = "ENDTIME";
            dataGridViewTextBoxColumn6.HeaderText = "ENDTIME";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.DataPropertyName = "PROGRESS";
            Column1.HeaderText = "PROGRESS";
            Column1.Name = "Column1";
            Column1.Visible = false;
            // 
            // Column2
            // 
            Column2.DataPropertyName = "STATUS";
            Column2.HeaderText = "STATUS";
            Column2.Name = "Column2";
            Column2.Visible = false;
            // 
            // panelHistory
            // 
            panelHistory.AutoScroll = true;
            panelHistory.Controls.Add(panelBorderRadiusCustom4);
            panelHistory.Controls.Add(btnFilterHistory);
            panelHistory.Controls.Add(label11);
            panelHistory.Controls.Add(panelTableProcedure);
            panelHistory.Controls.Add(btnActionHistory);
            panelHistory.Controls.Add(label12);
            panelHistory.Controls.Add(panelBorderControl2);
            panelHistory.Controls.Add(cboDUTHistory);
            panelHistory.Controls.Add(cboActionHistory);
            panelHistory.Location = new Point(1, 95);
            panelHistory.Margin = new Padding(1);
            panelHistory.Name = "panelHistory";
            panelHistory.Size = new Size(1077, 624);
            panelHistory.TabIndex = 9;
            // 
            // btnFilterHistory
            // 
            btnFilterHistory.BackColor = Color.White;
            btnFilterHistory.BackColorG = Color.FromArgb(11, 123, 105);
            btnFilterHistory.BorderColorG = Color.FromArgb(11, 123, 105);
            btnFilterHistory.BorderSize = 1;
            btnFilterHistory.Cursor = Cursors.Hand;
            btnFilterHistory.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFilterHistory.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnFilterHistory.ForeColor = Color.FromArgb(0, 32, 77);
            btnFilterHistory.ForeColorG = Color.White;
            btnFilterHistory.HoverColor = Color.FromArgb(11, 123, 105);
            btnFilterHistory.HoverG = false;
            btnFilterHistory.iConLocation = new Point(11, 5);
            btnFilterHistory.ImageAd = null;
            btnFilterHistory.Location = new Point(983, 0);
            btnFilterHistory.Name = "btnFilterHistory";
            btnFilterHistory.RadiusBottomLeft = 5;
            btnFilterHistory.RadiusBottomRight = 5;
            btnFilterHistory.RadiusTopLeft = 5;
            btnFilterHistory.RadiusTopRight = 5;
            btnFilterHistory.Size = new Size(68, 30);
            btnFilterHistory.TabIndex = 16;
            btnFilterHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnFilterHistory.TextLocation = new Point(13, 2);
            btnFilterHistory.Texts = "Filter";
            btnFilterHistory.TextSizes = new Size(48, 23);
            btnFilterHistory.Click += btnFilterHistory_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = SystemColors.Window;
            label11.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(862, 92);
            label11.Name = "label11";
            label11.Size = new Size(78, 21);
            label11.TabIndex = 11;
            label11.Text = "VERSION";
            // 
            // panelTableProcedure
            // 
            panelTableProcedure.BackColor = Color.FromArgb(232, 232, 232);
            panelTableProcedure.BackColorG = Color.Empty;
            panelTableProcedure.BorderColor = Color.DarkGray;
            panelTableProcedure.BorderSize = 1;
            panelTableProcedure.Controls.Add(label5);
            panelTableProcedure.Controls.Add(label3);
            panelTableProcedure.Controls.Add(checkBox1);
            panelTableProcedure.Controls.Add(label4);
            panelTableProcedure.Controls.Add(label10);
            panelTableProcedure.Location = new Point(12, 40);
            panelTableProcedure.Name = "panelTableProcedure";
            panelTableProcedure.RadiusBottomLeft = 0;
            panelTableProcedure.RadiusBottomRight = 0;
            panelTableProcedure.RadiusTopLeft = 0;
            panelTableProcedure.RadiusTopRight = 0;
            panelTableProcedure.Size = new Size(1056, 32);
            panelTableProcedure.TabIndex = 17;
            panelTableProcedure.VerticalPoints = (List<int>)resources.GetObject("panelTableProcedure.VerticalPoints");
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label5.Location = new Point(542, 5);
            label5.Name = "label5";
            label5.Size = new Size(37, 19);
            label5.TabIndex = 11;
            label5.Text = "DUT";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label3.Location = new Point(36, 5);
            label3.Name = "label3";
            label3.Size = new Size(23, 19);
            label3.TabIndex = 11;
            label3.Text = "ID";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = Color.Transparent;
            checkBox1.Cursor = Cursors.Hand;
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
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label4.Location = new Point(131, 5);
            label4.Name = "label4";
            label4.Size = new Size(91, 19);
            label4.TabIndex = 11;
            label4.Text = "PROCEDURE";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label10.Location = new Point(855, 5);
            label10.Name = "label10";
            label10.Size = new Size(68, 19);
            label10.TabIndex = 11;
            label10.Text = "VERSION";
            // 
            // btnActionHistory
            // 
            btnActionHistory.BackColor = Color.White;
            btnActionHistory.BackColorG = Color.FromArgb(11, 123, 105);
            btnActionHistory.BorderColorG = Color.FromArgb(11, 123, 105);
            btnActionHistory.BorderSize = 1;
            btnActionHistory.Cursor = Cursors.Hand;
            btnActionHistory.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActionHistory.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnActionHistory.ForeColor = Color.FromArgb(0, 32, 77);
            btnActionHistory.ForeColorG = Color.White;
            btnActionHistory.HoverColor = Color.FromArgb(11, 123, 105);
            btnActionHistory.HoverG = false;
            btnActionHistory.iConLocation = new Point(11, 5);
            btnActionHistory.ImageAd = null;
            btnActionHistory.Location = new Point(182, 0);
            btnActionHistory.Name = "btnActionHistory";
            btnActionHistory.RadiusBottomLeft = 5;
            btnActionHistory.RadiusBottomRight = 5;
            btnActionHistory.RadiusTopLeft = 5;
            btnActionHistory.RadiusTopRight = 5;
            btnActionHistory.Size = new Size(67, 30);
            btnActionHistory.TabIndex = 16;
            btnActionHistory.TextAlign = ContentAlignment.MiddleLeft;
            btnActionHistory.TextLocation = new Point(10, 2);
            btnActionHistory.Texts = "Apply";
            btnActionHistory.TextSizes = new Size(48, 23);
            btnActionHistory._EventSelect += btnAction_Click;
            btnActionHistory.Click += btnActionHistory_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = SystemColors.Window;
            label12.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(686, 92);
            label12.Name = "label12";
            label12.Size = new Size(75, 21);
            label12.TabIndex = 11;
            label12.Text = "AUTHOR";
            // 
            // panelBorderControl2
            // 
            panelBorderControl2.BackColor = Color.White;
            panelBorderControl2.BackColorG = Color.White;
            panelBorderControl2.BorderColor = Color.White;
            panelBorderControl2.BorderSize = 1;
            panelBorderControl2.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl2.Location = new Point(16, 41);
            panelBorderControl2.Margin = new Padding(0);
            panelBorderControl2.Name = "panelBorderControl2";
            panelBorderControl2.Padding = new Padding(2);
            panelBorderControl2.RadiusBottomLeft = 5;
            panelBorderControl2.RadiusBottomRight = 5;
            panelBorderControl2.RadiusTopLeft = 5;
            panelBorderControl2.RadiusTopRight = 5;
            panelBorderControl2.Size = new Size(1032, 32);
            panelBorderControl2.TabIndex = 10;
            panelBorderControl2.VerticalPoints = (List<int>)resources.GetObject("panelBorderControl2.VerticalPoints");
            // 
            // cboDUTHistory
            // 
            cboDUTHistory.BackColor = Color.FromArgb(232, 232, 232);
            cboDUTHistory.Cursor = Cursors.Hand;
            cboDUTHistory.Font = new Font("Segoe UI Variable Display", 13F);
            cboDUTHistory.FormattingEnabled = true;
            cboDUTHistory.Location = new Point(817, 0);
            cboDUTHistory.Name = "cboDUTHistory";
            cboDUTHistory.Size = new Size(160, 30);
            cboDUTHistory.TabIndex = 9;
            cboDUTHistory.Text = "DUT";
            // 
            // cboActionHistory
            // 
            cboActionHistory.BackColor = Color.FromArgb(232, 232, 232);
            cboActionHistory.Cursor = Cursors.Hand;
            cboActionHistory.Font = new Font("Segoe UI Variable Display", 13F);
            cboActionHistory.FormattingEnabled = true;
            cboActionHistory.Items.AddRange(new object[] { "View log", "View report", "Delete" });
            cboActionHistory.Location = new Point(12, 0);
            cboActionHistory.Name = "cboActionHistory";
            cboActionHistory.Size = new Size(160, 30);
            cboActionHistory.TabIndex = 9;
            cboActionHistory.Text = "Action";
            cboActionHistory.SelectedIndexChanged += cboActionHistory_SelectedIndexChanged;
            // 
            // panelTitle
            // 
            panelTitle.BackColor = Color.White;
            panelTitle.BackColorG = Color.White;
            panelTitle.BorderColor = Color.DarkGray;
            panelTitle.BorderSize = 1;
            panelTitle.Controls.Add(btnIconCloseDefault);
            panelTitle.Controls.Add(lblTitleForm);
            panelTitle.Dock = DockStyle.Top;
            panelTitle.Location = new Point(0, 0);
            panelTitle.Margin = new Padding(5);
            panelTitle.Name = "panelTitle";
            panelTitle.RadiusBottomLeft = 0;
            panelTitle.RadiusBottomRight = 0;
            panelTitle.RadiusTopLeft = 5;
            panelTitle.RadiusTopRight = 5;
            panelTitle.Size = new Size(1080, 32);
            panelTitle.TabIndex = 10;
            panelTitle.VerticalPoints = (List<int>)resources.GetObject("panelTitle.VerticalPoints");
            panelTitle.MouseDown += panel1_MouseDown;
            // 
            // btnIconCloseDefault
            // 
            btnIconCloseDefault.Cursor = Cursors.Hand;
            btnIconCloseDefault.FlatAppearance.BorderColor = Color.White;
            btnIconCloseDefault.FlatAppearance.BorderSize = 0;
            btnIconCloseDefault.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            btnIconCloseDefault.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnIconCloseDefault.FlatStyle = FlatStyle.Flat;
            btnIconCloseDefault.Image = Properties.Resources.iconCloseBlack;
            btnIconCloseDefault.Location = new Point(1036, 1);
            btnIconCloseDefault.Margin = new Padding(0);
            btnIconCloseDefault.Name = "btnIconCloseDefault";
            btnIconCloseDefault.Size = new Size(42, 30);
            btnIconCloseDefault.TabIndex = 3;
            btnIconCloseDefault.UseVisualStyleBackColor = true;
            btnIconCloseDefault.Click += btnCloseDefault_Click;
            // 
            // lblTitleForm
            // 
            lblTitleForm.AutoSize = true;
            lblTitleForm.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleForm.ForeColor = Color.FromArgb(0, 32, 77);
            lblTitleForm.Location = new Point(10, 7);
            lblTitleForm.Margin = new Padding(0);
            lblTitleForm.Name = "lblTitleForm";
            lblTitleForm.Size = new Size(171, 19);
            lblTitleForm.TabIndex = 2;
            lblTitleForm.Text = "Procedure Management";
            // 
            // btnIconImport
            // 
            btnIconImport.BackColor = Color.White;
            btnIconImport.BackColorG = Color.White;
            btnIconImport.BorderColorG = Color.DarkGray;
            btnIconImport.BorderSize = 1;
            btnIconImport.Cursor = Cursors.Hand;
            btnIconImport.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconImport.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconImport.ForeColor = Color.FromArgb(0, 32, 77);
            btnIconImport.ForeColorG = Color.FromArgb(0, 32, 77);
            btnIconImport.HoverColor = Color.FromArgb(232, 232, 232);
            btnIconImport.HoverG = false;
            btnIconImport.iConLocation = new Point(22, 5);
            btnIconImport.ImageAd = (Image)resources.GetObject("btnIconImport.ImageAd");
            btnIconImport.Location = new Point(138, 11);
            btnIconImport.Name = "btnIconImport";
            btnIconImport.RadiusBottomLeft = 5;
            btnIconImport.RadiusBottomRight = 5;
            btnIconImport.RadiusTopLeft = 5;
            btnIconImport.RadiusTopRight = 5;
            btnIconImport.Size = new Size(120, 32);
            btnIconImport.TabIndex = 12;
            btnIconImport.TextAlign = ContentAlignment.MiddleLeft;
            btnIconImport.TextLocation = new Point(46, 4);
            btnIconImport.Texts = "IMPORT";
            btnIconImport.TextSizes = new Size(70, 22);
            btnIconImport._EventSelect += btnIconImport__EventSelect;
            // 
            // btnIconExport
            // 
            btnIconExport.BackColor = Color.White;
            btnIconExport.BackColorG = Color.White;
            btnIconExport.BorderColorG = Color.DarkGray;
            btnIconExport.BorderSize = 1;
            btnIconExport.Cursor = Cursors.Hand;
            btnIconExport.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconExport.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconExport.ForeColor = Color.FromArgb(0, 32, 77);
            btnIconExport.ForeColorG = Color.FromArgb(0, 32, 77);
            btnIconExport.HoverColor = Color.FromArgb(232, 232, 232);
            btnIconExport.HoverG = false;
            btnIconExport.iConLocation = new Point(22, 5);
            btnIconExport.ImageAd = (Image)resources.GetObject("btnIconExport.ImageAd");
            btnIconExport.Location = new Point(266, 11);
            btnIconExport.Name = "btnIconExport";
            btnIconExport.RadiusBottomLeft = 5;
            btnIconExport.RadiusBottomRight = 5;
            btnIconExport.RadiusTopLeft = 5;
            btnIconExport.RadiusTopRight = 5;
            btnIconExport.Size = new Size(120, 32);
            btnIconExport.TabIndex = 12;
            btnIconExport.TextAlign = ContentAlignment.MiddleLeft;
            btnIconExport.TextLocation = new Point(46, 4);
            btnIconExport.Texts = "EXPORT";
            btnIconExport.TextSizes = new Size(70, 22);
            btnIconExport._EventSelect += btnExport_Click;
            btnIconExport.Load += btnIconExport_Load;
            // 
            // btnIconAddNew
            // 
            btnIconAddNew.BackColor = Color.White;
            btnIconAddNew.BackColorG = Color.FromArgb(11, 123, 105);
            btnIconAddNew.BorderColorG = Color.FromArgb(11, 123, 105);
            btnIconAddNew.BorderSize = 1;
            btnIconAddNew.Cursor = Cursors.Hand;
            btnIconAddNew.Font = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconAddNew.FontG = new Font("Segoe UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIconAddNew.ForeColor = Color.FromArgb(11, 123, 105);
            btnIconAddNew.ForeColorG = Color.White;
            btnIconAddNew.HoverColor = Color.FromArgb(11, 123, 105);
            btnIconAddNew.HoverG = false;
            btnIconAddNew.iConLocation = new Point(31, 5);
            btnIconAddNew.ImageAd = (Image)resources.GetObject("btnIconAddNew.ImageAd");
            btnIconAddNew.Location = new Point(10, 11);
            btnIconAddNew.Name = "btnIconAddNew";
            btnIconAddNew.RadiusBottomLeft = 5;
            btnIconAddNew.RadiusBottomRight = 5;
            btnIconAddNew.RadiusTopLeft = 5;
            btnIconAddNew.RadiusTopRight = 5;
            btnIconAddNew.Size = new Size(120, 32);
            btnIconAddNew.TabIndex = 13;
            btnIconAddNew.TextAlign = ContentAlignment.MiddleLeft;
            btnIconAddNew.TextLocation = new Point(55, 4);
            btnIconAddNew.Texts = "NEW";
            btnIconAddNew.TextSizes = new Size(65, 22);
            btnIconAddNew._EventSelect += btnPass2_Click;
            // 
            // tabProcedure
            // 
            tabProcedure.BackColor = Color.Transparent;
            tabProcedure.BackColorG = Color.Transparent;
            tabProcedure.BottomLineColor = Color.FromArgb(11, 123, 105);
            tabProcedure.BottomLineSize = 2;
            tabProcedure.Cursor = Cursors.Hand;
            tabProcedure.Font = new Font("Segoe UI", 10.5F);
            tabProcedure.FontG = new Font("Segoe UI", 10.5F);
            tabProcedure.ForeColorG = Color.FromArgb(3, 5, 51);
            tabProcedure.ForeColorNoSelect = Color.FromArgb(188, 189, 195);
            tabProcedure.HoverColor = Color.Empty;
            tabProcedure.HoverG = false;
            tabProcedure.Location = new Point(11, 54);
            tabProcedure.Margin = new Padding(3, 4, 3, 4);
            tabProcedure.Name = "tabProcedure";
            tabProcedure.ShowBottomLine = true;
            tabProcedure.Size = new Size(130, 31);
            tabProcedure.TabIndex = 14;
            tabProcedure.TextLocation = new Point(9, 5);
            tabProcedure.Texts = "PROCEDURE LIST";
            tabProcedure.Click += tabProcedureList_Click;
            // 
            // tabHistory
            // 
            tabHistory.BackColor = Color.Transparent;
            tabHistory.BackColorG = Color.Transparent;
            tabHistory.BottomLineColor = Color.FromArgb(11, 123, 105);
            tabHistory.BottomLineSize = 2;
            tabHistory.Cursor = Cursors.Hand;
            tabHistory.Font = new Font("Segoe UI", 10.5F);
            tabHistory.FontG = new Font("Segoe UI", 10.5F);
            tabHistory.ForeColorG = Color.FromArgb(3, 5, 51);
            tabHistory.ForeColorNoSelect = Color.FromArgb(188, 189, 195);
            tabHistory.HoverColor = Color.Empty;
            tabHistory.HoverG = false;
            tabHistory.Location = new Point(144, 54);
            tabHistory.Margin = new Padding(3, 4, 3, 4);
            tabHistory.Name = "tabHistory";
            tabHistory.ShowBottomLine = false;
            tabHistory.Size = new Size(122, 31);
            tabHistory.TabIndex = 15;
            tabHistory.TextLocation = new Point(9, 5);
            tabHistory.Texts = "RUN HISTORY";
            tabHistory.Load += tabHistory_Load;
            tabHistory.Click += tabHistory_Click;
            // 
            // panelContent
            // 
            panelContent.BackColor = Color.White;
            panelContent.BorderBottom = true;
            panelContent.BorderColor = Color.DarkGray;
            panelContent.BorderLeft = true;
            panelContent.BorderRight = true;
            panelContent.BorderSize = 1;
            panelContent.BorderTop = false;
            panelContent.Controls.Add(panelHistory);
            panelContent.Controls.Add(tabHistory);
            panelContent.Controls.Add(tabProcedure);
            panelContent.Controls.Add(btnIconAddNew);
            panelContent.Controls.Add(btnIconExport);
            panelContent.Controls.Add(btnIconImport);
            panelContent.Controls.Add(panelProcedureList);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelContent.ForeColor = Color.FromArgb(3, 5, 51);
            panelContent.Location = new Point(0, 32);
            panelContent.Margin = new Padding(0);
            panelContent.Name = "panelContent";
            panelContent.Size = new Size(1080, 688);
            panelContent.TabIndex = 3;
            // 
            // FormTableInspections
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1080, 720);
            Controls.Add(panelContent);
            Controls.Add(panelTitle);
            Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            Name = "FormTableInspections";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Procedure Management";
            Load += FormTableInspections_Load;
            panelProcedureList.ResumeLayout(false);
            panelProcedureList.PerformLayout();
            panelProcedureTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelTableResult.ResumeLayout(false);
            panelTableResult.PerformLayout();
            panelBorderRadiusCustom4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panelHistory.ResumeLayout(false);
            panelHistory.PerformLayout();
            panelTableProcedure.ResumeLayout(false);
            panelTableProcedure.PerformLayout();
            panelTitle.ResumeLayout(false);
            panelTitle.PerformLayout();
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private PanelBorderRadiusCustom panelTitle;
        private PanelBorderRadiusCustom panelControl2;
        private Panel panelProcedureList;
        private PanelBorderRadiusCustom panelProcedureTable;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ProcedureId;
        private DataGridViewCheckBoxColumn clmAction;
        private DataGridViewTextBoxColumn clmId;
        private DataGridViewTextBoxColumn clmProcedure;
        private DataGridViewTextBoxColumn clmDUT;
        private DataGridViewTextBoxColumn clmVersion;
        private PanelBorderRadiusCustom panelTableProcedure;
        private Label label5;
        private Label label3;
        private CheckBox checkBox1;
        private Label label4;
        private Label label10;
        private Controls.Buttons.ButtonCustom btnFilterProcedureList;
        private Controls.Buttons.ButtonCustom btnActionProcedure;
        private Label label7;
        private Label label6;
        private Label label9;
        private ComboBox cboDUT;
        private ComboBox cboActionProcedure;
        private Panel panelHistory;
        private PanelBorderRadiusCustom panelBorderRadiusCustom4;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn clmAttachFile;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private PanelBorderRadiusCustom panelTableResult;
        private Label label18;
        private CheckBox checkBox2;
        private Label label16;
        private Label label15;
        private Label label13;
        private Label label19;
        private Label label11;
        private Label label12;
        private PanelBorderRadiusCustom panelBorderControl2;
        private ComboBox cboDUTHistory;
        private ComboBox cboActionHistory;

        private Button btnIconCloseDefault;
        private Label lblTitleForm;
        private Controls.Buttons.ButtonCustom btnIconImport;
        private Controls.Buttons.ButtonCustom btnIconExport;
        private Controls.Buttons.ButtonCustom btnIconAddNew;
        private Controls.tab.TabControl tabProcedure;
        private Controls.tab.TabControl tabHistory;
        private PanelCustomBorder panelContent;
        private Controls.Buttons.ButtonCustom btnActionHistory;
        private Controls.Buttons.ButtonCustom btnFilterHistory;
    }
}