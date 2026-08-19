using T3ACS.Controls;

namespace T3ACS
{
    partial class FormEvaluateCorrection
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEvaluateCorrection));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            rtbNote = new RJEditor();
            panelControlAll1 = new PanelControlAll();
            panelStickBottom = new Panel();
            label11 = new Label();
            btnExport = new ButtonIconLable();
            btnFailed = new ButtonIconLable();
            btnPass = new ButtonIconLable();
            btnQuit = new ButtonControl();
            panelForm = new Panel();
            panelBorderRadiusCustom1 = new PanelBorderRadiusCustom();
            panelBorderRadiusCustom2 = new PanelBorderRadiusCustom();
            panelBorderRadiusCustom4 = new PanelBorderRadiusCustom();
            dataGridView1 = new DataGridView();
            clmNO = new DataGridViewTextBoxColumn();
            clmMarkerID = new DataGridViewTextBoxColumn();
            clmReadingValue = new DataGridViewTextBoxColumn();
            clmCorrectionValue = new DataGridViewTextBoxColumn();
            clmReportValue = new DataGridViewTextBoxColumn();
            clmUncertainty = new DataGridViewTextBoxColumn();
            clmResult = new DataGridViewTextBoxColumn();
            panelBorderRadiusCustom3 = new PanelBorderRadiusCustom();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panelHold = new Panel();
            panelStickBottom.SuspendLayout();
            panelForm.SuspendLayout();
            panelBorderRadiusCustom1.SuspendLayout();
            panelBorderRadiusCustom2.SuspendLayout();
            panelBorderRadiusCustom4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panelBorderRadiusCustom3.SuspendLayout();
            SuspendLayout();
            // 
            // rtbNote
            // 
            rtbNote.BackColor = Color.White;
            rtbNote.BorderColor = Color.DarkGray;
            rtbNote.BorderFocusColor = Color.FromArgb(3, 120, 212);
            rtbNote.BorderRadius = 5;
            rtbNote.BorderSize = 1;
            rtbNote.Location = new Point(31, 7);
            rtbNote.Name = "rtbNote";
            rtbNote.PlaceholderColor = Color.FromArgb(153, 166, 184);
            rtbNote.PlaceholderText = "Notes";
            rtbNote.RadiusBottomLeft = 5;
            rtbNote.RadiusBottomRight = 5;
            rtbNote.RadiusTopLeft = 5;
            rtbNote.RadiusTopRight = 5;
            rtbNote.Size = new Size(1071, 158);
            rtbNote.TabIndex = 1;
            rtbNote.Texts = "";
            rtbNote.UnderlinedStyle = false;
            // 
            // panelControlAll1
            // 
            panelControlAll1.BackColor = SystemColors.Window;
            panelControlAll1.BorderColor = Color.WhiteSmoke;
            panelControlAll1.BorderFocusColor = Color.HotPink;
            panelControlAll1.BorderSize = 5;
            panelControlAll1.Location = new Point(307, 2);
            panelControlAll1.Margin = new Padding(2, 3, 2, 3);
            panelControlAll1.Name = "panelControlAll1";
            panelControlAll1.Padding = new Padding(2, 3, 2, 3);
            panelControlAll1.Size = new Size(581, 62);
            panelControlAll1.TabIndex = 10;
            // 
            // panelStickBottom
            // 
            panelStickBottom.Anchor = AnchorStyles.None;
            panelStickBottom.Controls.Add(label11);
            panelStickBottom.Controls.Add(btnExport);
            panelStickBottom.Controls.Add(btnFailed);
            panelStickBottom.Controls.Add(btnPass);
            panelStickBottom.Controls.Add(btnQuit);
            panelStickBottom.Controls.Add(panelControlAll1);
            panelStickBottom.Location = new Point(15, 728);
            panelStickBottom.Name = "panelStickBottom";
            panelStickBottom.Size = new Size(1089, 73);
            panelStickBottom.TabIndex = 17;
            // 
            // label11
            // 
            label11.BackColor = Color.White;
            label11.Image = (Image)resources.GetObject("label11.Image");
            label11.Location = new Point(587, 10);
            label11.Name = "label11";
            label11.Size = new Size(10, 53);
            label11.TabIndex = 20;
            // 
            // btnExport
            // 
            btnExport._ImageDefault = null;
            btnExport._ImageDisable = null;
            btnExport._ImageSelect = null;
            btnExport.Font = new Font("Segoe UI", 10.5F);
            btnExport.ForeColor = Color.FromArgb(0, 32, 77);
            btnExport.Location = new Point(632, 19);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(120, 36);
            btnExport.TabIndex = 17;
            // 
            // btnFailed
            // 
            btnFailed._ImageDefault = null;
            btnFailed._ImageDisable = null;
            btnFailed._ImageSelect = null;
            btnFailed.Font = new Font("Segoe UI", 10.5F);
            btnFailed.ForeColor = Color.FromArgb(0, 32, 77);
            btnFailed.Location = new Point(454, 19);
            btnFailed.Margin = new Padding(3, 4, 3, 4);
            btnFailed.Name = "btnFailed";
            btnFailed.Size = new Size(93, 36);
            btnFailed.TabIndex = 18;
            btnFailed.Click += btnFailed_Click;
            // 
            // btnPass
            // 
            btnPass._ImageDefault = null;
            btnPass._ImageDisable = null;
            btnPass._ImageSelect = null;
            btnPass.Font = new Font("Segoe UI", 10.5F);
            btnPass.ForeColor = Color.FromArgb(0, 32, 77);
            btnPass.Location = new Point(332, 19);
            btnPass.Margin = new Padding(3, 4, 3, 4);
            btnPass.Name = "btnPass";
            btnPass.Size = new Size(90, 36);
            btnPass.TabIndex = 19;
            btnPass.Click += btnPass_Click;
            // 
            // btnQuit
            // 
            btnQuit.BackColor = Color.White;
            btnQuit.BackColors = Color.White;
            btnQuit.BorderColor = Color.FromArgb(227, 242, 253);
            btnQuit.BorderFocusColor = Color.FromArgb(3, 120, 212);
            btnQuit.BorderRadius = 5;
            btnQuit.BorderSize = 1;
            btnQuit.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnQuit.ForeColors = Color.FromArgb(0, 32, 77);
            btnQuit.HoverColors = Color.DarkGray;
            btnQuit.Location = new Point(781, 19);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(94, 36);
            btnQuit.TabIndex = 16;
            btnQuit.Texts = "lblbtn1";
            btnQuit.Click += btnQuit_Click;
            // 
            // panelForm
            // 
            panelForm.Controls.Add(panelBorderRadiusCustom1);
            panelForm.Controls.Add(panelHold);
            panelForm.Controls.Add(panelStickBottom);
            panelForm.Controls.Add(rtbNote);
            panelForm.Dock = DockStyle.Fill;
            panelForm.Location = new Point(0, 0);
            panelForm.Name = "panelForm";
            panelForm.Size = new Size(1118, 804);
            panelForm.TabIndex = 18;
            panelForm.Scroll += FormEvaluate_Scroll;
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColorG = Color.Empty;
            panelBorderRadiusCustom1.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(panelBorderRadiusCustom2);
            panelBorderRadiusCustom1.Controls.Add(label1);
            panelBorderRadiusCustom1.Location = new Point(12, 184);
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 5;
            panelBorderRadiusCustom1.RadiusBottomRight = 5;
            panelBorderRadiusCustom1.RadiusTopLeft = 5;
            panelBorderRadiusCustom1.RadiusTopRight = 5;
            panelBorderRadiusCustom1.Size = new Size(1096, 541);
            panelBorderRadiusCustom1.TabIndex = 19;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            // 
            // panelBorderRadiusCustom2
            // 
            panelBorderRadiusCustom2.BackColorG = Color.Empty;
            panelBorderRadiusCustom2.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom2.BorderSize = 1;
            panelBorderRadiusCustom2.Controls.Add(panelBorderRadiusCustom4);
            panelBorderRadiusCustom2.Controls.Add(panelBorderRadiusCustom3);
            panelBorderRadiusCustom2.Location = new Point(12, 52);
            panelBorderRadiusCustom2.Margin = new Padding(0);
            panelBorderRadiusCustom2.Name = "panelBorderRadiusCustom2";
            panelBorderRadiusCustom2.RadiusBottomLeft = 0;
            panelBorderRadiusCustom2.RadiusBottomRight = 0;
            panelBorderRadiusCustom2.RadiusTopLeft = 0;
            panelBorderRadiusCustom2.RadiusTopRight = 0;
            panelBorderRadiusCustom2.Size = new Size(1058, 474);
            panelBorderRadiusCustom2.TabIndex = 1;
            panelBorderRadiusCustom2.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom2.VerticalPoints");
            // 
            // panelBorderRadiusCustom4
            // 
            panelBorderRadiusCustom4.BackColorG = Color.Empty;
            panelBorderRadiusCustom4.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom4.BorderSize = 1;
            panelBorderRadiusCustom4.Controls.Add(dataGridView1);
            panelBorderRadiusCustom4.Location = new Point(0, 44);
            panelBorderRadiusCustom4.Margin = new Padding(0);
            panelBorderRadiusCustom4.Name = "panelBorderRadiusCustom4";
            panelBorderRadiusCustom4.RadiusBottomLeft = 0;
            panelBorderRadiusCustom4.RadiusBottomRight = 0;
            panelBorderRadiusCustom4.RadiusTopLeft = 0;
            panelBorderRadiusCustom4.RadiusTopRight = 0;
            panelBorderRadiusCustom4.Size = new Size(1058, 434);
            panelBorderRadiusCustom4.TabIndex = 1;
            panelBorderRadiusCustom4.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom4.VerticalPoints");
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { clmNO, clmMarkerID, clmReadingValue, clmCorrectionValue, clmReportValue, clmUncertainty, clmResult });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Segoe UI Variable Text", 10.5F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(0, 32, 77);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridView1.Size = new Size(1056, 433);
            dataGridView1.TabIndex = 2;
            // 
            // clmNO
            // 
            clmNO.DataPropertyName = "No";
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            clmNO.DefaultCellStyle = dataGridViewCellStyle2;
            clmNO.HeaderText = "NO";
            clmNO.Name = "clmNO";
            clmNO.ReadOnly = true;
            clmNO.SortMode = DataGridViewColumnSortMode.NotSortable;
            clmNO.Width = 50;
            // 
            // clmMarkerID
            // 
            clmMarkerID.DataPropertyName = "MarkerID";
            clmMarkerID.HeaderText = "Marker ID";
            clmMarkerID.Name = "clmMarkerID";
            clmMarkerID.ReadOnly = true;
            clmMarkerID.SortMode = DataGridViewColumnSortMode.NotSortable;
            clmMarkerID.Width = 170;
            // 
            // clmReadingValue
            // 
            clmReadingValue.DataPropertyName = "ReadingValue";
            clmReadingValue.HeaderText = "Reading Value";
            clmReadingValue.Name = "clmReadingValue";
            clmReadingValue.ReadOnly = true;
            clmReadingValue.SortMode = DataGridViewColumnSortMode.NotSortable;
            clmReadingValue.Width = 170;
            // 
            // clmCorrectionValue
            // 
            clmCorrectionValue.DataPropertyName = "CorrectionValue";
            clmCorrectionValue.HeaderText = "Correction Value";
            clmCorrectionValue.Name = "clmCorrectionValue";
            clmCorrectionValue.ReadOnly = true;
            clmCorrectionValue.Width = 170;
            // 
            // clmReportValue
            // 
            clmReportValue.DataPropertyName = "ReportValue";
            clmReportValue.HeaderText = "Report Value";
            clmReportValue.Name = "clmReportValue";
            clmReportValue.Width = 170;
            // 
            // clmUncertainty
            // 
            clmUncertainty.DataPropertyName = "Uncertainty";
            clmUncertainty.HeaderText = "Uncertainty";
            clmUncertainty.Name = "clmUncertainty";
            clmUncertainty.Width = 170;
            // 
            // clmResult
            // 
            clmResult.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            clmResult.DataPropertyName = "Result";
            clmResult.HeaderText = "Result";
            clmResult.Name = "clmResult";
            // 
            // panelBorderRadiusCustom3
            // 
            panelBorderRadiusCustom3.BackColorG = Color.Empty;
            panelBorderRadiusCustom3.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom3.BorderSize = 1;
            panelBorderRadiusCustom3.Controls.Add(label8);
            panelBorderRadiusCustom3.Controls.Add(label7);
            panelBorderRadiusCustom3.Controls.Add(label6);
            panelBorderRadiusCustom3.Controls.Add(label5);
            panelBorderRadiusCustom3.Controls.Add(label4);
            panelBorderRadiusCustom3.Controls.Add(label3);
            panelBorderRadiusCustom3.Controls.Add(label2);
            panelBorderRadiusCustom3.Location = new Point(0, 0);
            panelBorderRadiusCustom3.Margin = new Padding(0);
            panelBorderRadiusCustom3.Name = "panelBorderRadiusCustom3";
            panelBorderRadiusCustom3.RadiusBottomLeft = 0;
            panelBorderRadiusCustom3.RadiusBottomRight = 0;
            panelBorderRadiusCustom3.RadiusTopLeft = 0;
            panelBorderRadiusCustom3.RadiusTopRight = 0;
            panelBorderRadiusCustom3.Size = new Size(1058, 45);
            panelBorderRadiusCustom3.TabIndex = 0;
            panelBorderRadiusCustom3.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom3.VerticalPoints");
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(902, 10);
            label8.Name = "label8";
            label8.Size = new Size(117, 22);
            label8.TabIndex = 0;
            label8.Text = "Pass / Failse";
            label8.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            label7.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(732, 10);
            label7.Name = "label7";
            label7.Size = new Size(117, 22);
            label7.TabIndex = 0;
            label7.Text = "Uncerrtenty";
            label7.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(562, 10);
            label6.Name = "label6";
            label6.Size = new Size(117, 22);
            label6.TabIndex = 0;
            label6.Text = "Report Value";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(393, 10);
            label5.Name = "label5";
            label5.Size = new Size(117, 22);
            label5.TabIndex = 0;
            label5.Text = "Correction Value ";
            label5.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(224, 10);
            label4.Name = "label4";
            label4.Size = new Size(117, 22);
            label4.TabIndex = 0;
            label4.Text = "Reading Value ";
            label4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            label3.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(54, 10);
            label3.Name = "label3";
            label3.Size = new Size(93, 22);
            label3.TabIndex = 0;
            label3.Text = "Marker ID";
            label3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(8, 10);
            label2.Name = "label2";
            label2.Size = new Size(28, 22);
            label2.TabIndex = 0;
            label2.Text = "No";
            label2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 10);
            label1.Name = "label1";
            label1.Size = new Size(124, 19);
            label1.TabIndex = 0;
            label1.Text = "Correction Results";
            // 
            // panelHold
            // 
            panelHold.Location = new Point(12, 775);
            panelHold.Name = "panelHold";
            panelHold.Size = new Size(14, 80);
            panelHold.TabIndex = 18;
            // 
            // FormEvaluateCorrection
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1118, 804);
            Controls.Add(panelForm);
            Font = new Font("Segoe UI Variable Text", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormEvaluateCorrection";
            Text = "FormEvaluateCorrection";
            panelStickBottom.ResumeLayout(false);
            panelForm.ResumeLayout(false);
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelBorderRadiusCustom1.PerformLayout();
            panelBorderRadiusCustom2.ResumeLayout(false);
            panelBorderRadiusCustom4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panelBorderRadiusCustom3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private RJEditor rtbNote;
        private PanelControlAll panelControlAll1;
        private Panel panelStickBottom;
        private Label label11;
        private ButtonIconLable btnExport;
        private ButtonIconLable btnFailed;
        private ButtonIconLable btnPass;
        private ButtonControl btnQuit;
        private Panel panelForm;
        private Panel panelHold;
        private PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private Label label1;
        private PanelBorderRadiusCustom panelBorderRadiusCustom2;
        private PanelBorderRadiusCustom panelBorderRadiusCustom4;
        private PanelBorderRadiusCustom panelBorderRadiusCustom3;
        private Label label2;
        private Label label4;
        private Label label3;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn clmNO;
        private DataGridViewTextBoxColumn clmMarkerID;
        private DataGridViewTextBoxColumn clmReadingValue;
        private DataGridViewTextBoxColumn clmCorrectionValue;
        private DataGridViewTextBoxColumn clmReportValue;
        private DataGridViewTextBoxColumn clmUncertainty;
        private DataGridViewTextBoxColumn clmResult;
    }
}