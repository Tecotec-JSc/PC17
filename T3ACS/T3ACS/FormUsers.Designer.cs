
using T3ACS.Controls;

namespace T3ACS
{
    partial class FormUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUsers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlTop = new PanelBorderRadiusCustom();
            this.pnlTitle = new System.Windows.Forms.Panel();
            this.lblClose = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnProcedureList = new System.Windows.Forms.Button();
            this.btnAddNew = new System.Windows.Forms.Button();
            this.cboActionHistory = new System.Windows.Forms.ComboBox();
            this.btnAction = new System.Windows.Forms.Button();
            this.pnlTable = new System.Windows.Forms.Panel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.clmUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmAction = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clmUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clmPermission = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlHeader = new PanelBorderRadiusCustom();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.lblPermission = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.pnlTitle.SuspendLayout();
            this.pnlTable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTop.BorderColor = System.Drawing.Color.LightGray;
            this.pnlTop.BorderSize = 1;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Margin = new System.Windows.Forms.Padding(2);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlTop.Size = new System.Drawing.Size(1080, 32);
            this.pnlTop.TabIndex = 11;
            // 
            // pnlTitle
            // 
            this.pnlTitle.BackColor = System.Drawing.SystemColors.Window;
            this.pnlTitle.Controls.Add(this.lblClose);
            this.pnlTitle.Controls.Add(this.lblTitle);
            this.pnlTitle.Location = new System.Drawing.Point(6, 1);
            this.pnlTitle.Name = "pnlTitle";
            this.pnlTitle.Size = new System.Drawing.Size(1065, 29);
            this.pnlTitle.TabIndex = 12;
            this.pnlTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlTitle_MouseDown);
            // 
            // lblClose
            // 
            this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
            this.lblClose.Location = new System.Drawing.Point(1031, 3);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(35, 24);
            this.lblClose.TabIndex = 2;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(15, 3);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(149, 21);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "User Management";
            // 
            // btnProcedureList
            // 
            this.btnProcedureList.FlatAppearance.BorderSize = 0;
            this.btnProcedureList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcedureList.Image = ((System.Drawing.Image)(resources.GetObject("btnProcedureList.Image")));
            this.btnProcedureList.Location = new System.Drawing.Point(16, 88);
            this.btnProcedureList.Margin = new System.Windows.Forms.Padding(0);
            this.btnProcedureList.Name = "btnProcedureList";
            this.btnProcedureList.Size = new System.Drawing.Size(92, 33);
            this.btnProcedureList.TabIndex = 13;
            this.btnProcedureList.UseVisualStyleBackColor = true;
            // 
            // btnAddNew
            // 
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Image = ((System.Drawing.Image)(resources.GetObject("btnAddNew.Image")));
            this.btnAddNew.Location = new System.Drawing.Point(16, 40);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(121, 33);
            this.btnAddNew.TabIndex = 14;
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // cboActionHistory
            // 
            this.cboActionHistory.FormattingEnabled = true;
            this.cboActionHistory.Items.AddRange(new object[] {
            "Edit",
            "Delete"});
            this.cboActionHistory.Location = new System.Drawing.Point(16, 138);
            this.cboActionHistory.Name = "cboActionHistory";
            this.cboActionHistory.Size = new System.Drawing.Size(160, 29);
            this.cboActionHistory.TabIndex = 16;
            this.cboActionHistory.Text = "Action";
            // 
            // btnAction
            // 
            this.btnAction.FlatAppearance.BorderSize = 0;
            this.btnAction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAction.Image = ((System.Drawing.Image)(resources.GetObject("btnAction.Image")));
            this.btnAction.Location = new System.Drawing.Point(185, 135);
            this.btnAction.Margin = new System.Windows.Forms.Padding(0);
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(68, 33);
            this.btnAction.TabIndex = 15;
            this.btnAction.UseVisualStyleBackColor = true;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // pnlTable
            // 
            this.pnlTable.AutoScroll = true;
            this.pnlTable.Controls.Add(this.dgvUsers);
            this.pnlTable.Location = new System.Drawing.Point(19, 207);
            this.pnlTable.Name = "pnlTable";
            this.pnlTable.Size = new System.Drawing.Size(1032, 510);
            this.pnlTable.TabIndex = 18;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeColumns = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgvUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUsers.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.ColumnHeadersVisible = false;
            this.dgvUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.clmUserId,
            this.clmAction,
            this.clmUserName,
            this.clmFullName,
            this.clmPermission});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUsers.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.Location = new System.Drawing.Point(0, 0);
            this.dgvUsers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Variable Display", 10.5F);
            this.dgvUsers.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUsers.RowTemplate.Height = 54;
            this.dgvUsers.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgvUsers.Size = new System.Drawing.Size(1032, 510);
            this.dgvUsers.TabIndex = 1;
            // 
            // clmUserId
            // 
            this.clmUserId.DataPropertyName = "UserId";
            this.clmUserId.HeaderText = "UserId";
            this.clmUserId.Name = "clmUserId";
            this.clmUserId.ReadOnly = true;
            this.clmUserId.Visible = false;
            // 
            // clmAction
            // 
            this.clmAction.DataPropertyName = "Action";
            this.clmAction.FalseValue = "false";
            this.clmAction.HeaderText = "";
            this.clmAction.Name = "clmAction";
            this.clmAction.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmAction.TrueValue = "true";
            this.clmAction.Width = 36;
            // 
            // clmUserName
            // 
            this.clmUserName.DataPropertyName = "UserName";
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.clmUserName.DefaultCellStyle = dataGridViewCellStyle2;
            this.clmUserName.HeaderText = "UserName";
            this.clmUserName.Name = "clmUserName";
            this.clmUserName.ReadOnly = true;
            this.clmUserName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmUserName.Width = 300;
            // 
            // clmFullName
            // 
            this.clmFullName.DataPropertyName = "FullName";
            this.clmFullName.HeaderText = "Full Name";
            this.clmFullName.Name = "clmFullName";
            this.clmFullName.ReadOnly = true;
            this.clmFullName.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmFullName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.clmFullName.Width = 300;
            // 
            // clmPermission
            // 
            this.clmPermission.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.clmPermission.DataPropertyName = "Permission";
            this.clmPermission.HeaderText = "Permission";
            this.clmPermission.Name = "clmPermission";
            this.clmPermission.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.clmPermission.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.Window;
            this.pnlHeader.BorderColor = System.Drawing.Color.White;
            this.pnlHeader.BorderSize = 1;
            this.pnlHeader.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlHeader.Location = new System.Drawing.Point(19, 175);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(2);
            this.pnlHeader.Size = new System.Drawing.Size(1032, 32);
            this.pnlHeader.TabIndex = 17;
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.BackColor = System.Drawing.SystemColors.Window;
            this.chkSelectAll.Location = new System.Drawing.Point(27, 185);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(15, 14);
            this.chkSelectAll.TabIndex = 24;
            this.chkSelectAll.UseVisualStyleBackColor = false;
            // 
            // lblPermission
            // 
            this.lblPermission.AutoSize = true;
            this.lblPermission.BackColor = System.Drawing.SystemColors.Window;
            this.lblPermission.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPermission.Location = new System.Drawing.Point(653, 181);
            this.lblPermission.Name = "lblPermission";
            this.lblPermission.Size = new System.Drawing.Size(92, 21);
            this.lblPermission.TabIndex = 19;
            this.lblPermission.Text = "Permission";
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.BackColor = System.Drawing.SystemColors.Window;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Location = new System.Drawing.Point(356, 181);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(84, 21);
            this.lblFullName.TabIndex = 22;
            this.lblFullName.Text = "Full Name";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.BackColor = System.Drawing.SystemColors.Window;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Location = new System.Drawing.Point(54, 181);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(86, 21);
            this.lblUserName.TabIndex = 23;
            this.lblUserName.Text = "Username";
            // 
            // FormUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 720);
            this.Controls.Add(this.chkSelectAll);
            this.Controls.Add(this.lblPermission);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.pnlTable);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.cboActionHistory);
            this.Controls.Add(this.btnAction);
            this.Controls.Add(this.btnProcedureList);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.pnlTitle);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI Variable Display", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormUsers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Management";
            this.pnlTitle.ResumeLayout(false);
            this.pnlTitle.PerformLayout();
            this.pnlTable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PanelBorderRadiusCustom pnlTop;
        private System.Windows.Forms.Panel pnlTitle;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnProcedureList;
        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.ComboBox cboActionHistory;
        private System.Windows.Forms.Button btnAction;
        private System.Windows.Forms.Panel pnlTable;
        private System.Windows.Forms.DataGridView dgvUsers;
        private PanelBorderRadiusCustom pnlHeader;
        private System.Windows.Forms.CheckBox chkSelectAll;
        private System.Windows.Forms.Label lblPermission;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUserId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clmAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn clmPermission;
    }
}