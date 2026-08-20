using T3ACS.Controls;
using T3ACS.Controls.Buttons;

namespace T3ACS
{
    partial class FormRunLog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRunLog));
            pnlHeader = new PanelBorderRadiusCustom();
            lblTitleProcedure = new Label();
            lblClose = new Label();
            lblRunLogTitle = new Label();
            lblIcon = new Label();
            pnlInfo = new PanelBorderRadiusCustom();
            lblEnd = new Label();
            lblEndCaption = new Label();
            lblStart = new Label();
            lblStartCaption = new Label();
            lblAuthor = new Label();
            lblAuthorCaption = new Label();
            lblDut = new Label();
            lblDutCaption = new Label();
            rtbLog = new RichTextBox();
            pnlFooter = new PanelBorderRadiusCustom();
            btnExportReport = new ButtonCustom();
            btnCancel = new ButtonControl();
            lblRunId = new Label();
            pnlHeader.SuspendLayout();
            pnlInfo.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BorderColor = Color.FromArgb(229, 231, 235);
            pnlHeader.BorderSize = 1;
            pnlHeader.Controls.Add(lblTitleProcedure);
            pnlHeader.Controls.Add(lblClose);
            pnlHeader.Controls.Add(lblRunLogTitle);
            pnlHeader.Controls.Add(lblIcon);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.RadiusBottomLeft = 0;
            pnlHeader.RadiusBottomRight = 0;
            pnlHeader.RadiusTopLeft = 0;
            pnlHeader.RadiusTopRight = 0;
            pnlHeader.Size = new Size(760, 45);
            pnlHeader.TabIndex = 0;
            pnlHeader.VerticalPoints = (List<int>)resources.GetObject("pnlHeader.VerticalPoints");
            // 
            // lblTitleProcedure
            // 
            lblTitleProcedure.Font = new Font("Segoe UI Variable Text", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitleProcedure.Location = new Point(131, 10);
            lblTitleProcedure.Margin = new Padding(0);
            lblTitleProcedure.Name = "lblTitleProcedure";
            lblTitleProcedure.Size = new Size(568, 23);
            lblTitleProcedure.TabIndex = 4;
            lblTitleProcedure.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblClose
            // 
            lblClose.Image = (Image)resources.GetObject("lblClose.Image");
            lblClose.Location = new Point(715, 1);
            lblClose.Name = "lblClose";
            lblClose.Size = new Size(44, 43);
            lblClose.TabIndex = 3;
            lblClose.Click += lblClose_Click;
            lblClose.MouseEnter += lblClose_MouseEnter;
            lblClose.MouseLeave += lblClose_MouseLeave;
            // 
            // lblRunLogTitle
            // 
            lblRunLogTitle.Font = new Font("Segoe UI Variable Text", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRunLogTitle.Location = new Point(36, 10);
            lblRunLogTitle.Margin = new Padding(0);
            lblRunLogTitle.Name = "lblRunLogTitle";
            lblRunLogTitle.Size = new Size(95, 23);
            lblRunLogTitle.TabIndex = 2;
            lblRunLogTitle.Text = "Run Log  —";
            lblRunLogTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIcon
            // 
            lblIcon.Image = (Image)resources.GetObject("lblIcon.Image");
            lblIcon.Location = new Point(16, 14);
            lblIcon.Name = "lblIcon";
            lblIcon.Size = new Size(15, 15);
            lblIcon.TabIndex = 1;
            // 
            // pnlInfo
            // 
            pnlInfo.BorderColor = Color.DarkGray;
            pnlInfo.BorderSize = 1;
            pnlInfo.Controls.Add(lblEnd);
            pnlInfo.Controls.Add(lblEndCaption);
            pnlInfo.Controls.Add(lblStart);
            pnlInfo.Controls.Add(lblStartCaption);
            pnlInfo.Controls.Add(lblAuthor);
            pnlInfo.Controls.Add(lblAuthorCaption);
            pnlInfo.Controls.Add(lblDut);
            pnlInfo.Controls.Add(lblDutCaption);
            pnlInfo.Dock = DockStyle.Top;
            pnlInfo.Location = new Point(0, 45);
            pnlInfo.Name = "pnlInfo";
            pnlInfo.RadiusBottomLeft = 5;
            pnlInfo.RadiusBottomRight = 5;
            pnlInfo.RadiusTopLeft = 5;
            pnlInfo.RadiusTopRight = 5;
            pnlInfo.Size = new Size(760, 42);
            pnlInfo.TabIndex = 1;
            pnlInfo.VerticalPoints = (List<int>)resources.GetObject("pnlInfo.VerticalPoints");
            // 
            // lblEnd
            // 
            lblEnd.Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEnd.Location = new Point(641, 9);
            lblEnd.Margin = new Padding(0);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(119, 22);
            lblEnd.TabIndex = 0;
            lblEnd.Text = "2022-06-10 00:09:07";
            lblEnd.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblEndCaption
            // 
            lblEndCaption.Font = new Font("Segoe UI Variable Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEndCaption.Location = new Point(591, 9);
            lblEndCaption.Margin = new Padding(0);
            lblEndCaption.Name = "lblEndCaption";
            lblEndCaption.Size = new Size(50, 22);
            lblEndCaption.TabIndex = 0;
            lblEndCaption.Text = "End :";
            lblEndCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStart
            // 
            lblStart.Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStart.Location = new Point(473, 9);
            lblStart.Margin = new Padding(0);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(119, 22);
            lblStart.TabIndex = 0;
            lblStart.Text = "2022-06-10 00:09:07";
            lblStart.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStartCaption
            // 
            lblStartCaption.Font = new Font("Segoe UI Variable Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStartCaption.Location = new Point(423, 9);
            lblStartCaption.Margin = new Padding(0);
            lblStartCaption.Name = "lblStartCaption";
            lblStartCaption.Size = new Size(50, 22);
            lblStartCaption.TabIndex = 0;
            lblStartCaption.Text = "Start :";
            lblStartCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblAuthor
            // 
            lblAuthor.Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAuthor.Location = new Point(325, 9);
            lblAuthor.Margin = new Padding(0);
            lblAuthor.Name = "lblAuthor";
            lblAuthor.Size = new Size(88, 22);
            lblAuthor.TabIndex = 0;
            lblAuthor.Text = "Admin";
            lblAuthor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAuthorCaption
            // 
            lblAuthorCaption.Font = new Font("Segoe UI Variable Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAuthorCaption.Location = new Point(275, 9);
            lblAuthorCaption.Margin = new Padding(0);
            lblAuthorCaption.Name = "lblAuthorCaption";
            lblAuthorCaption.Size = new Size(50, 22);
            lblAuthorCaption.TabIndex = 0;
            lblAuthorCaption.Text = "Athor :";
            lblAuthorCaption.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblDut
            // 
            lblDut.Font = new Font("Segoe UI Variable Text", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDut.Location = new Point(52, 9);
            lblDut.Margin = new Padding(0);
            lblDut.Name = "lblDut";
            lblDut.Size = new Size(223, 22);
            lblDut.TabIndex = 0;
            lblDut.Text = "r";
            lblDut.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDutCaption
            // 
            lblDutCaption.Font = new Font("Segoe UI Variable Small", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDutCaption.Location = new Point(15, 9);
            lblDutCaption.Margin = new Padding(0);
            lblDutCaption.Name = "lblDutCaption";
            lblDutCaption.Size = new Size(38, 22);
            lblDutCaption.TabIndex = 0;
            lblDutCaption.Text = "DUT :";
            lblDutCaption.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = SystemColors.InfoText;
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.ForeColor = Color.White;
            rtbLog.Location = new Point(0, 87);
            rtbLog.Margin = new Padding(0);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(760, 423);
            rtbLog.TabIndex = 2;
            rtbLog.Text = "";
            // 
            // pnlFooter
            // 
            pnlFooter.BorderColor = Color.DarkGray;
            pnlFooter.BorderSize = 1;
            pnlFooter.Controls.Add(btnExportReport);
            pnlFooter.Controls.Add(btnCancel);
            pnlFooter.Controls.Add(lblRunId);
            pnlFooter.Location = new Point(0, 510);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.RadiusBottomLeft = 0;
            pnlFooter.RadiusBottomRight = 0;
            pnlFooter.RadiusTopLeft = 0;
            pnlFooter.RadiusTopRight = 0;
            pnlFooter.Size = new Size(760, 50);
            pnlFooter.TabIndex = 3;
            pnlFooter.VerticalPoints = (List<int>)resources.GetObject("pnlFooter.VerticalPoints");
            // 
            // btnExportReport
            // 
            btnExportReport.BackColor = Color.FromArgb(49, 102, 156);
            btnExportReport.BackColorG = Color.FromArgb(49, 102, 156);
            btnExportReport.BorderColorG = Color.FromArgb(49, 102, 156);
            btnExportReport.BorderSize = 1;
            btnExportReport.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportReport.Font = new Font("Segoe UI Variable Text Semibold", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
  
            btnExportReport.ImageAd = (Image)resources.GetObject("btnExportReport.Images");
            btnExportReport.Location = new Point(622, 10);
            btnExportReport.Margin = new Padding(0);
            btnExportReport.Name = "btnExportReport";
            btnExportReport.Size = new Size(129, 32);
            btnExportReport.TabIndex = 2;
            btnExportReport.Texts = " Export Report";
            btnExportReport._EventSelect += btnExportReport_btnClick;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.BackColors = Color.White;
            btnCancel.BorderColor = Color.FromArgb(201, 201, 201);
            btnCancel.BorderFocusColor = Color.FromArgb(3, 120, 212);
            btnCancel.BorderRadius = 5;
            btnCancel.BorderSize = 1;
            btnCancel.Font = new Font("Segoe UI Variable Text Semibold", 10.5F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColors = Color.FromArgb(0, 32, 77);
            btnCancel.HoverColors = Color.DarkGray;
            btnCancel.Location = new Point(515, 10);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(102, 32);
            btnCancel.TabIndex = 1;
            btnCancel.Texts = "Cancel";
            btnCancel.btnClick += btnCancel_btnClick;
            // 
            // lblRunId
            // 
            lblRunId.ForeColor = Color.FromArgb(153, 161, 175);
            lblRunId.Location = new Point(16, 15);
            lblRunId.Name = "lblRunId";
            lblRunId.Size = new Size(187, 22);
            lblRunId.TabIndex = 0;
            lblRunId.Text = "Run ID: RUN-0002";
            // 
            // FormRunLog
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(760, 560);
            Controls.Add(pnlFooter);
            Controls.Add(rtbLog);
            Controls.Add(pnlInfo);
            Controls.Add(pnlHeader);
            Font = new Font("Segoe UI Variable Display", 10.5F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(3, 5, 51);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormRunLog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FormRunLog";
            pnlHeader.ResumeLayout(false);
            pnlInfo.ResumeLayout(false);
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private PanelBorderRadiusCustom pnlHeader;
        private Label lblIcon;
        private Label lblRunLogTitle;
        private Label lblClose;
        private Label lblTitleProcedure;
        private PanelBorderRadiusCustom pnlInfo;
        private Label lblDutCaption;
        private Label lblDut;
        private Label lblEnd;
        private Label lblEndCaption;
        private Label lblStart;
        private Label lblStartCaption;
        private Label lblAuthor;
        private Label lblAuthorCaption;
        private RichTextBox rtbLog;
        private PanelBorderRadiusCustom pnlFooter;
        private Label lblRunId;
        private ButtonControl btnCancel;
        private ButtonCustom btnExportReport;
    }
}