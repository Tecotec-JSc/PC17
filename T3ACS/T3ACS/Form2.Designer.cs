using T3ACS.Controls;

namespace T3ACS
{
    partial class Form2
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            panelHistory = new Panel();
            checkBox2 = new CheckBox();
            paneltableH = new Panel();
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
            label11 = new Label();
            label12 = new Label();
            label19 = new Label();
            label13 = new Label();
            label15 = new Label();
            label16 = new Label();
            label18 = new Label();
            panelBorderControl2 = new PanelBorderRadiusCustom();
            cboDUTHistory = new ComboBox();
            cboActionHistory = new ComboBox();
            btnFilterHistory = new Button();
            btnActionHistory = new Button();
            panelProcedureList = new Panel();
            checkBox1 = new CheckBox();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            ProcedureId = new DataGridViewTextBoxColumn();
            clmAction = new DataGridViewCheckBoxColumn();
            clmId = new DataGridViewTextBoxColumn();
            clmProcedure = new DataGridViewTextBoxColumn();
            clmDUT = new DataGridViewTextBoxColumn();
            clmVersion = new DataGridViewTextBoxColumn();
            label7 = new Label();
            label6 = new Label();
            label10 = new Label();
            label9 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            panelBorderControl1 = new PanelBorderRadiusCustom();
            cboDUT = new ComboBox();
            cboActionProcedure = new ComboBox();
            btnFilterProcedureList = new Button();
            btnActionProcedure = new Button();
            btnExport = new Button();
            button1 = new Button();
            btnPass2 = new Button();
            panelHistory.SuspendLayout();
            paneltableH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            panelProcedureList.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panelHistory
            // 
            panelHistory.AutoScroll = true;
            panelHistory.Controls.Add(checkBox2);
            panelHistory.Controls.Add(paneltableH);
            panelHistory.Controls.Add(label11);
            panelHistory.Controls.Add(label12);
            panelHistory.Controls.Add(label19);
            panelHistory.Controls.Add(label13);
            panelHistory.Controls.Add(label15);
            panelHistory.Controls.Add(label16);
            panelHistory.Controls.Add(label18);
            panelHistory.Controls.Add(panelBorderControl2);
            panelHistory.Controls.Add(cboDUTHistory);
            panelHistory.Controls.Add(cboActionHistory);
            panelHistory.Controls.Add(btnFilterHistory);
            panelHistory.Controls.Add(btnActionHistory);
            panelHistory.Location = new Point(41, 631);
            panelHistory.Name = "panelHistory";
            panelHistory.Size = new Size(1080, 585);
            panelHistory.TabIndex = 10;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.BackColor = SystemColors.Window;
            checkBox2.Location = new Point(27, 52);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 13;
            checkBox2.UseVisualStyleBackColor = false;
            // 
            // paneltableH
            // 
            paneltableH.AutoScroll = true;
            paneltableH.Controls.Add(dataGridView2);
            paneltableH.Location = new Point(16, 73);
            paneltableH.Name = "paneltableH";
            paneltableH.Size = new Size(1032, 510);
            paneltableH.TabIndex = 12;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView2.BackgroundColor = SystemColors.Window;
            dataGridView2.BorderStyle = BorderStyle.None;
            dataGridView2.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.ColumnHeadersVisible = false;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewCheckBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn4, clmAttachFile, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn6, Column1, Column2 });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(3, 5, 51);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView2.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView2.Location = new Point(0, 0);
            dataGridView2.Margin = new Padding(4, 5, 4, 5);
            dataGridView2.Name = "dataGridView2";
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Control;
            dataGridViewCellStyle4.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(5, 7, 72);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dataGridView2.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridView2.RowHeadersVisible = false;
            dataGridViewCellStyle5.Font = new Font("Segoe UI Variable Display", 10.5F);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(5, 7, 72);
            dataGridView2.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dataGridView2.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridView2.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(5, 7, 72);
            dataGridView2.RowTemplate.Height = 60;
            dataGridView2.ScrollBars = ScrollBars.Vertical;
            dataGridView2.Size = new Size(1032, 510);
            dataGridView2.TabIndex = 1;
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
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle2;
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
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = SystemColors.Window;
            label19.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label19.Location = new Point(616, 48);
            label19.Name = "label19";
            label19.Size = new Size(68, 19);
            label19.TabIndex = 11;
            label19.Text = "AUTHOR";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = SystemColors.Window;
            label13.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label13.Location = new Point(895, 48);
            label13.Name = "label13";
            label13.Size = new Size(72, 19);
            label13.TabIndex = 11;
            label13.Text = "END TIME";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = SystemColors.Window;
            label15.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label15.Location = new Point(744, 48);
            label15.Name = "label15";
            label15.Size = new Size(85, 19);
            label15.TabIndex = 11;
            label15.Text = "START TIME";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = SystemColors.Window;
            label16.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label16.Location = new Point(383, 48);
            label16.Name = "label16";
            label16.Size = new Size(37, 19);
            label16.TabIndex = 11;
            label16.Text = "DUT";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.BackColor = SystemColors.Window;
            label18.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.ForeColor = Color.FromArgb(3, 5, 51);
            label18.Location = new Point(54, 48);
            label18.Name = "label18";
            label18.Size = new Size(39, 19);
            label18.TabIndex = 11;
            label18.Text = "RUN";
            // 
            // panelBorderControl2
            // 
            panelBorderControl2.BackColor = Color.White;
            panelBorderControl2.BorderColor = Color.White;
            panelBorderControl2.BorderSize = 1;
            panelBorderControl2.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl2.Location = new Point(16, 41);
            panelBorderControl2.Margin = new Padding(0);
            panelBorderControl2.Name = "panelBorderControl2";
            panelBorderControl2.Padding = new Padding(2);
            panelBorderControl2.Size = new Size(1032, 32);
            panelBorderControl2.TabIndex = 10;
            // 
            // cboDUTHistory
            // 
            cboDUTHistory.FormattingEnabled = true;
            cboDUTHistory.Location = new Point(817, 6);
            cboDUTHistory.Name = "cboDUTHistory";
            cboDUTHistory.Size = new Size(160, 23);
            cboDUTHistory.TabIndex = 9;
            cboDUTHistory.Text = "DUT";
            // 
            // cboActionHistory
            // 
            cboActionHistory.FormattingEnabled = true;
            cboActionHistory.Items.AddRange(new object[] { "View log", "View report" });
            cboActionHistory.Location = new Point(16, 6);
            cboActionHistory.Name = "cboActionHistory";
            cboActionHistory.Size = new Size(160, 23);
            cboActionHistory.TabIndex = 9;
            cboActionHistory.Text = "Action";
            // 
            // btnFilterHistory
            // 
            btnFilterHistory.FlatAppearance.BorderSize = 0;
            btnFilterHistory.FlatStyle = FlatStyle.Flat;
            btnFilterHistory.Image = (Image)resources.GetObject("btnFilterHistory.Image");
            btnFilterHistory.Location = new Point(980, 3);
            btnFilterHistory.Margin = new Padding(0);
            btnFilterHistory.Name = "btnFilterHistory";
            btnFilterHistory.Size = new Size(68, 33);
            btnFilterHistory.TabIndex = 8;
            btnFilterHistory.UseVisualStyleBackColor = true;
            // 
            // btnActionHistory
            // 
            btnActionHistory.FlatAppearance.BorderSize = 0;
            btnActionHistory.FlatStyle = FlatStyle.Flat;
            btnActionHistory.Image = (Image)resources.GetObject("btnActionHistory.Image");
            btnActionHistory.Location = new Point(185, 3);
            btnActionHistory.Margin = new Padding(0);
            btnActionHistory.Name = "btnActionHistory";
            btnActionHistory.Size = new Size(68, 33);
            btnActionHistory.TabIndex = 8;
            btnActionHistory.UseVisualStyleBackColor = true;
            // 
            // panelProcedureList
            // 
            panelProcedureList.AutoScroll = true;
            panelProcedureList.Controls.Add(checkBox1);
            panelProcedureList.Controls.Add(panel3);
            panelProcedureList.Controls.Add(label7);
            panelProcedureList.Controls.Add(label6);
            panelProcedureList.Controls.Add(label10);
            panelProcedureList.Controls.Add(label9);
            panelProcedureList.Controls.Add(label5);
            panelProcedureList.Controls.Add(label4);
            panelProcedureList.Controls.Add(label3);
            panelProcedureList.Controls.Add(panelBorderControl1);
            panelProcedureList.Controls.Add(cboDUT);
            panelProcedureList.Controls.Add(cboActionProcedure);
            panelProcedureList.Controls.Add(btnFilterProcedureList);
            panelProcedureList.Controls.Add(btnActionProcedure);
            panelProcedureList.Location = new Point(89, 159);
            panelProcedureList.Name = "panelProcedureList";
            panelProcedureList.Size = new Size(1080, 585);
            panelProcedureList.TabIndex = 11;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.BackColor = SystemColors.Window;
            checkBox1.Location = new Point(29, 52);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 13;
            checkBox1.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(16, 73);
            panel3.Name = "panel3";
            panel3.Size = new Size(1032, 510);
            panel3.TabIndex = 12;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI Variable Display", 10.5F);
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Control;
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dataGridView1.BackgroundColor = SystemColors.Window;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ProcedureId, clmAction, clmId, clmProcedure, clmDUT, clmVersion });
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(3, 5, 51);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle8;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Margin = new Padding(4, 5, 4, 5);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle9.Font = new Font("Segoe UI Variable Display", 10.5F);
            dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle9;
            dataGridView1.RowTemplate.DefaultCellStyle.Font = new Font("Segoe UI Variable Display", 10.5F);
            dataGridView1.RowTemplate.DefaultCellStyle.ForeColor = Color.FromArgb(5, 7, 72);
            dataGridView1.RowTemplate.Height = 60;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1032, 510);
            dataGridView1.TabIndex = 1;
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
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            clmId.DefaultCellStyle = dataGridViewCellStyle7;
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
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.Window;
            label10.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label10.Location = new Point(874, 49);
            label10.Name = "label10";
            label10.Size = new Size(68, 19);
            label10.TabIndex = 11;
            label10.Text = "VERSION";
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
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.Window;
            label5.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label5.Location = new Point(561, 45);
            label5.Name = "label5";
            label5.Size = new Size(37, 19);
            label5.TabIndex = 11;
            label5.Text = "DUT";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Window;
            label4.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label4.Location = new Point(150, 47);
            label4.Name = "label4";
            label4.Size = new Size(91, 19);
            label4.TabIndex = 11;
            label4.Text = "PROCEDURE";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Window;
            label3.Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Bold);
            label3.Location = new Point(55, 47);
            label3.Name = "label3";
            label3.Size = new Size(23, 19);
            label3.TabIndex = 11;
            label3.Text = "ID";
            // 
            // panelBorderControl1
            // 
            panelBorderControl1.BackColor = Color.White;
            panelBorderControl1.BorderColor = Color.White;
            panelBorderControl1.BorderSize = 1;
            panelBorderControl1.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelBorderControl1.Location = new Point(16, 41);
            panelBorderControl1.Margin = new Padding(0);
            panelBorderControl1.Name = "panelBorderControl1";
            panelBorderControl1.Padding = new Padding(2);
            panelBorderControl1.Size = new Size(1032, 32);
            panelBorderControl1.TabIndex = 10;
            // 
            // cboDUT
            // 
            cboDUT.FormattingEnabled = true;
            cboDUT.Location = new Point(817, 6);
            cboDUT.Name = "cboDUT";
            cboDUT.Size = new Size(160, 23);
            cboDUT.TabIndex = 9;
            cboDUT.Text = "DUT";
            // 
            // cboActionProcedure
            // 
            cboActionProcedure.FormattingEnabled = true;
            cboActionProcedure.Items.AddRange(new object[] { "Open Procedure", "Edit Procedure", "Duplicate Procedure", "Delete Procedure" });
            cboActionProcedure.Location = new Point(16, 6);
            cboActionProcedure.Name = "cboActionProcedure";
            cboActionProcedure.Size = new Size(160, 23);
            cboActionProcedure.TabIndex = 9;
            cboActionProcedure.Text = "Open Procedure";
            // 
            // btnFilterProcedureList
            // 
            btnFilterProcedureList.FlatAppearance.BorderSize = 0;
            btnFilterProcedureList.FlatStyle = FlatStyle.Flat;
            btnFilterProcedureList.Image = (Image)resources.GetObject("btnFilterProcedureList.Image");
            btnFilterProcedureList.Location = new Point(980, 3);
            btnFilterProcedureList.Margin = new Padding(0);
            btnFilterProcedureList.Name = "btnFilterProcedureList";
            btnFilterProcedureList.Size = new Size(68, 33);
            btnFilterProcedureList.TabIndex = 8;
            btnFilterProcedureList.UseVisualStyleBackColor = true;
            // 
            // btnActionProcedure
            // 
            btnActionProcedure.FlatAppearance.BorderSize = 0;
            btnActionProcedure.FlatStyle = FlatStyle.Flat;
            btnActionProcedure.Image = (Image)resources.GetObject("btnActionProcedure.Image");
            btnActionProcedure.Location = new Point(185, 3);
            btnActionProcedure.Margin = new Padding(0);
            btnActionProcedure.Name = "btnActionProcedure";
            btnActionProcedure.Size = new Size(68, 33);
            btnActionProcedure.TabIndex = 8;
            btnActionProcedure.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            btnExport.FlatAppearance.BorderSize = 0;
            btnExport.FlatStyle = FlatStyle.Flat;
            btnExport.Image = (Image)resources.GetObject("btnExport.Image");
            btnExport.Location = new Point(519, 23);
            btnExport.Margin = new Padding(0);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(121, 33);
            btnExport.TabIndex = 12;
            btnExport.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(390, 23);
            button1.Margin = new Padding(0);
            button1.Name = "button1";
            button1.Size = new Size(121, 33);
            button1.TabIndex = 13;
            button1.UseVisualStyleBackColor = true;
            // 
            // btnPass2
            // 
            btnPass2.FlatAppearance.BorderSize = 0;
            btnPass2.FlatStyle = FlatStyle.Flat;
            btnPass2.Image = (Image)resources.GetObject("btnPass2.Image");
            btnPass2.Location = new Point(261, 23);
            btnPass2.Margin = new Padding(0);
            btnPass2.Name = "btnPass2";
            btnPass2.Size = new Size(121, 33);
            btnPass2.TabIndex = 14;
            btnPass2.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1285, 795);
            Controls.Add(btnExport);
            Controls.Add(button1);
            Controls.Add(btnPass2);
            Controls.Add(panelHistory);
            Controls.Add(panelProcedureList);
            Name = "Form2";
            Text = "Form2";
            panelHistory.ResumeLayout(false);
            panelHistory.PerformLayout();
            paneltableH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            panelProcedureList.ResumeLayout(false);
            panelProcedureList.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelHistory;
        private CheckBox checkBox2;
        private Panel paneltableH;
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
        private Label label11;
        private Label label12;
        private Label label19;
        private Label label13;
        private Label label15;
        private Label label16;
        private Label label18;
        private PanelBorderRadiusCustom panelBorderControl2;
        private ComboBox cboDUTHistory;
        private ComboBox cboActionHistory;
        private Button btnFilterHistory;
        private Button btnActionHistory;
        private Panel panelProcedureList;
        private CheckBox checkBox1;
        private Panel panel3;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ProcedureId;
        private DataGridViewCheckBoxColumn clmAction;
        private DataGridViewTextBoxColumn clmId;
        private DataGridViewTextBoxColumn clmProcedure;
        private DataGridViewTextBoxColumn clmDUT;
        private DataGridViewTextBoxColumn clmVersion;
        private Label label7;
        private Label label6;
        private Label label10;
        private Label label9;
        private Label label5;
        private Label label4;
        private Label label3;
        private PanelBorderRadiusCustom panelBorderControl1;
        private ComboBox cboDUT;
        private ComboBox cboActionProcedure;
        private Button btnFilterProcedureList;
        private Button btnActionProcedure;
        private Button btnExport;
        private Button button1;
        private Button btnPass2;
    }
}