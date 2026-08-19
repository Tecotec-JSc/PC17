using T3ACS.Controls;

namespace T3ACS
{
    partial class FormRunMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRunMain));
            panelBorderControl1 = new PanelBorderRadiusCustom();
            panelBorderControl2 = new PanelBorderRadiusCustom();
            panelBorderControl3 = new PanelBorderRadiusCustom();
            panelTop = new Panel();
            flowLayoutPanel2 = new FlowLayoutPanel();
            lblHugProcedureName = new Label();
            lblHugIDProcedure = new Label();
            lblHugVersionProcedure = new Label();
            lblTextDescription = new Label();
            panel1 = new Panel();
            btnActionNext = new ButtonActionControl();
            btnActionRun = new ButtonActionControl();
            btnActionStop = new ButtonActionControl();
            btnActionBack = new ButtonActionControl();
            panelLeft = new Panel();
            tblStep = new TableStepControl();
            panelRight = new Panel();
            panelContent = new Panel();
            panelBorderControl4 = new PanelBorderRadiusCustom();
            panelRight2 = new Panel();
            panelRightModem = new Panel();
            label2 = new Label();
            label1 = new Label();
            lblHugDetail = new Label();
            panelTitleRight = new PanelBorderRadiusCustom();
            panelBorderTerminal = new PanelBorderRadiusCustom();
            lblHugTerminal = new Label();
            panelBorderDetail = new PanelBorderRadiusCustom();
            panelBorderRadiusCustom1 = new PanelBorderRadiusCustom();
            panelCustomRadius1 = new PanelBorderRadiusCustom();
            panelTop.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            panelLeft.SuspendLayout();
            panelTitleRight.SuspendLayout();
            panelBorderTerminal.SuspendLayout();
            panelBorderDetail.SuspendLayout();
            panelBorderRadiusCustom1.SuspendLayout();
            panelCustomRadius1.SuspendLayout();
            SuspendLayout();
            // 
            // panelBorderControl1
            // 
            panelBorderControl1.BackColor = SystemColors.Window;
            panelBorderControl1.BorderColor = Color.DarkGray;
            panelBorderControl1.BorderSize = 1;
            resources.ApplyResources(panelBorderControl1, "panelBorderControl1");
            panelBorderControl1.Name = "panelBorderControl1";
            // 
            // panelBorderControl2
            // 
            panelBorderControl2.BackColor = SystemColors.Window;
            panelBorderControl2.BorderColor = Color.DarkGray;
            panelBorderControl2.BorderSize = 1;
            resources.ApplyResources(panelBorderControl2, "panelBorderControl2");
            panelBorderControl2.Name = "panelBorderControl2";
            // 
            // panelBorderControl3
            // 
            panelBorderControl3.BackColor = SystemColors.Window;
            panelBorderControl3.BorderColor = Color.DarkGray;
            panelBorderControl3.BorderSize = 1;
            resources.ApplyResources(panelBorderControl3, "panelBorderControl3");
            panelBorderControl3.Name = "panelBorderControl3";
            // 
            // panelTop
            // 
            panelTop.Controls.Add(flowLayoutPanel2);
            panelTop.Controls.Add(panel1);
            resources.ApplyResources(panelTop, "panelTop");
            panelTop.Name = "panelTop";
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(lblHugProcedureName);
            flowLayoutPanel2.Controls.Add(lblHugIDProcedure);
            flowLayoutPanel2.Controls.Add(lblHugVersionProcedure);
            flowLayoutPanel2.Controls.Add(lblTextDescription);
            resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // lblHugProcedureName
            // 
            resources.ApplyResources(lblHugProcedureName, "lblHugProcedureName");
            lblHugProcedureName.Name = "lblHugProcedureName";
            // 
            // lblHugIDProcedure
            // 
            resources.ApplyResources(lblHugIDProcedure, "lblHugIDProcedure");
            lblHugIDProcedure.Name = "lblHugIDProcedure";
            // 
            // lblHugVersionProcedure
            // 
            resources.ApplyResources(lblHugVersionProcedure, "lblHugVersionProcedure");
            lblHugVersionProcedure.Name = "lblHugVersionProcedure";
            // 
            // lblTextDescription
            // 
            resources.ApplyResources(lblTextDescription, "lblTextDescription");
            lblTextDescription.Name = "lblTextDescription";
            // 
            // panel1
            // 
            panel1.Controls.Add(btnActionNext);
            panel1.Controls.Add(btnActionRun);
            panel1.Controls.Add(btnActionStop);
            panel1.Controls.Add(btnActionBack);
            resources.ApplyResources(panel1, "panel1");
            panel1.Name = "panel1";
            // 
            // btnActionNext
            // 
            resources.ApplyResources(btnActionNext, "btnActionNext");
            btnActionNext.ForeColor = Color.FromArgb(2, 161, 255);
            btnActionNext.ForeColors = Color.FromArgb(0, 32, 77);
            btnActionNext.IconActive = null;
            btnActionNext.IconDefault = null;
            btnActionNext.IconDisable = null;
            btnActionNext.Name = "btnActionNext";
            btnActionNext.Texts = "Stop";
            // 
            // btnActionRun
            // 
            resources.ApplyResources(btnActionRun, "btnActionRun");
            btnActionRun.ForeColor = Color.FromArgb(2, 161, 255);
            btnActionRun.ForeColors = Color.FromArgb(0, 32, 77);
            btnActionRun.IconActive = null;
            btnActionRun.IconDefault = null;
            btnActionRun.IconDisable = null;
            btnActionRun.Name = "btnActionRun";
            btnActionRun.Texts = "Stop";
            // 
            // btnActionStop
            // 
            resources.ApplyResources(btnActionStop, "btnActionStop");
            btnActionStop.ForeColor = Color.FromArgb(2, 161, 255);
            btnActionStop.ForeColors = Color.FromArgb(0, 32, 77);
            btnActionStop.IconActive = null;
            btnActionStop.IconDefault = null;
            btnActionStop.IconDisable = null;
            btnActionStop.Name = "btnActionStop";
            btnActionStop.Texts = "Stop";
            // 
            // btnActionBack
            // 
            resources.ApplyResources(btnActionBack, "btnActionBack");
            btnActionBack.ForeColor = Color.FromArgb(2, 161, 255);
            btnActionBack.ForeColors = Color.FromArgb(0, 32, 77);
            btnActionBack.IconActive = null;
            btnActionBack.IconDefault = null;
            btnActionBack.IconDisable = null;
            btnActionBack.Name = "btnActionBack";
            btnActionBack.Texts = "Stop";
            // 
            // panelLeft
            // 
            panelLeft.Controls.Add(tblStep);
            resources.ApplyResources(panelLeft, "panelLeft");
            panelLeft.Name = "panelLeft";
            // 
            // tblStep
            // 
            resources.ApplyResources(tblStep, "tblStep");
            tblStep.Name = "tblStep";
            tblStep._ClickControl += tblStep__ClickControl;
            // 
            // panelRight
            // 
            resources.ApplyResources(panelRight, "panelRight");
            panelRight.Name = "panelRight";
            // 
            // panelContent
            // 
            resources.ApplyResources(panelContent, "panelContent");
            panelContent.Name = "panelContent";
            // 
            // panelBorderControl4
            // 
            panelBorderControl4.BackColor = SystemColors.Window;
            panelBorderControl4.BorderColor = Color.DarkGray;
            panelBorderControl4.BorderSize = 1;
            resources.ApplyResources(panelBorderControl4, "panelBorderControl4");
            panelBorderControl4.Name = "panelBorderControl4";
            // 
            // panelRight2
            // 
            resources.ApplyResources(panelRight2, "panelRight2");
            panelRight2.Name = "panelRight2";
            // 
            // panelRightModem
            // 
            resources.ApplyResources(panelRightModem, "panelRightModem");
            panelRightModem.Name = "panelRightModem";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // lblHugDetail
            // 
            resources.ApplyResources(lblHugDetail, "lblHugDetail");
            lblHugDetail.Name = "lblHugDetail";
            lblHugDetail.Click += panelBorderDetail_Click;
            // 
            // panelTitleRight
            // 
            panelTitleRight.BackColorG = Color.Empty;
            panelTitleRight.BorderColor = Color.DarkGray;
            panelTitleRight.BorderSize = 1;
            panelTitleRight.Controls.Add(panelBorderTerminal);
            panelTitleRight.Controls.Add(panelBorderDetail);
            resources.ApplyResources(panelTitleRight, "panelTitleRight");
            panelTitleRight.Name = "panelTitleRight";
            panelTitleRight.RadiusBottomLeft = 0;
            panelTitleRight.RadiusBottomRight = 0;
            panelTitleRight.RadiusTopLeft = 0;
            panelTitleRight.RadiusTopRight = 0;
            panelTitleRight.VerticalPoints = (List<int>)resources.GetObject("panelTitleRight.VerticalPoints");
            // 
            // panelBorderTerminal
            // 
            panelBorderTerminal.BackColorG = Color.Empty;
            panelBorderTerminal.BorderColor = Color.DarkGray;
            panelBorderTerminal.BorderSize = 1;
            panelBorderTerminal.Controls.Add(lblHugTerminal);
            resources.ApplyResources(panelBorderTerminal, "panelBorderTerminal");
            panelBorderTerminal.Name = "panelBorderTerminal";
            panelBorderTerminal.RadiusBottomLeft = 0;
            panelBorderTerminal.RadiusBottomRight = 0;
            panelBorderTerminal.RadiusTopLeft = 0;
            panelBorderTerminal.RadiusTopRight = 0;
            panelBorderTerminal.VerticalPoints = (List<int>)resources.GetObject("panelBorderTerminal.VerticalPoints");
            panelBorderTerminal.Click += panelBorderTerminal_Click;
            // 
            // lblHugTerminal
            // 
            resources.ApplyResources(lblHugTerminal, "lblHugTerminal");
            lblHugTerminal.Name = "lblHugTerminal";
            lblHugTerminal.Click += panelBorderTerminal_Click;
            // 
            // panelBorderDetail
            // 
            panelBorderDetail.BackColorG = Color.Empty;
            panelBorderDetail.BorderColor = Color.DarkGray;
            panelBorderDetail.BorderSize = 1;
            panelBorderDetail.Controls.Add(lblHugDetail);
            resources.ApplyResources(panelBorderDetail, "panelBorderDetail");
            panelBorderDetail.Name = "panelBorderDetail";
            panelBorderDetail.RadiusBottomLeft = 0;
            panelBorderDetail.RadiusBottomRight = 0;
            panelBorderDetail.RadiusTopLeft = 0;
            panelBorderDetail.RadiusTopRight = 0;
            panelBorderDetail.VerticalPoints = (List<int>)resources.GetObject("panelBorderDetail.VerticalPoints");
            panelBorderDetail.Click += panelBorderDetail_Click;
            // 
            // panelBorderRadiusCustom1
            // 
            panelBorderRadiusCustom1.BackColorG = Color.Empty;
            panelBorderRadiusCustom1.BorderColor = Color.DarkGray;
            panelBorderRadiusCustom1.BorderSize = 1;
            panelBorderRadiusCustom1.Controls.Add(label2);
            resources.ApplyResources(panelBorderRadiusCustom1, "panelBorderRadiusCustom1");
            panelBorderRadiusCustom1.Name = "panelBorderRadiusCustom1";
            panelBorderRadiusCustom1.RadiusBottomLeft = 0;
            panelBorderRadiusCustom1.RadiusBottomRight = 0;
            panelBorderRadiusCustom1.RadiusTopLeft = 0;
            panelBorderRadiusCustom1.RadiusTopRight = 0;
            panelBorderRadiusCustom1.VerticalPoints = (List<int>)resources.GetObject("panelBorderRadiusCustom1.VerticalPoints");
            // 
            // panelCustomRadius1
            // 
            panelCustomRadius1.BorderColor = Color.DarkGray;
            panelCustomRadius1.BorderSize = 1;
            panelCustomRadius1.Controls.Add(label1);
            resources.ApplyResources(panelCustomRadius1, "panelCustomRadius1");
            panelCustomRadius1.Name = "panelCustomRadius1";
            panelCustomRadius1.RadiusBottomLeft = 0;
            panelCustomRadius1.RadiusBottomRight = 0;
            panelCustomRadius1.RadiusTopLeft = 0;
            panelCustomRadius1.RadiusTopRight = 0;
            panelCustomRadius1.VerticalPoints = (List<int>)resources.GetObject("panelCustomRadius1.VerticalPoints");
            // 
            // FormRunMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            resources.ApplyResources(this, "$this");
            Controls.Add(panelCustomRadius1);
            Controls.Add(panelBorderRadiusCustom1);
            Controls.Add(panelTitleRight);
            Controls.Add(panelRight2);
            Controls.Add(panelRightModem);
            Controls.Add(panelContent);
            Controls.Add(panelBorderControl4);
            Controls.Add(panelRight);
            Controls.Add(panelLeft);
            Controls.Add(panelTop);
            Controls.Add(panelBorderControl3);
            Controls.Add(panelBorderControl2);
            Controls.Add(panelBorderControl1);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormRunMain";
            panelTop.ResumeLayout(false);
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            panelLeft.ResumeLayout(false);
            panelTitleRight.ResumeLayout(false);
            panelBorderTerminal.ResumeLayout(false);
            panelBorderDetail.ResumeLayout(false);
            panelBorderRadiusCustom1.ResumeLayout(false);
            panelBorderRadiusCustom1.PerformLayout();
            panelCustomRadius1.ResumeLayout(false);
            panelCustomRadius1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PanelBorderRadiusCustom panelBorderControl1;
        private PanelBorderRadiusCustom panelBorderControl2;
        private PanelBorderRadiusCustom panelBorderControl3;
        private Panel panelTop;
        private Panel panelLeft;
        private Panel panelRight;
        private Panel panelContent;
        private PanelBorderRadiusCustom panelBorderControl4;
        private Label lblTextDescription;
        private Panel panel1;
        private TableStepControl tblStep;
        private Panel panelRight2;
        private Label label2;
        private Label label1;
        private Label lblHugDetail;
        private ButtonActionControl btnActionNext;
        private ButtonActionControl btnActionRun;
        private ButtonActionControl btnActionStop;
        private ButtonActionControl btnActionBack;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label lblHugProcedureName;
        private Label lblHugIDProcedure;
        private Label lblHugVersionProcedure;
        private PanelBorderRadiusCustom panelTitleRight;
        private PanelBorderRadiusCustom panelBorderDetail;
        private PanelBorderRadiusCustom panelBorderTerminal;
        private Label lblHugTerminal;
        private PanelBorderRadiusCustom panelTitleACU;
        private Label lblTitleACU;
        private PanelBorderRadiusCustom panelTitleModem;
        private Label lblTitleModem;
        private PanelBorderRadiusCustom panelBorderRadiusCustom1;
        private PanelBorderRadiusCustom panelCustomRadius1;
        private Panel panelRightModem;
        private Panel panelRightACU;
    }
}