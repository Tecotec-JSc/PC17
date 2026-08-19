
using T3ACS.Controls;
using T3ACS.Controls.PanelCustoms;

namespace T3ACS
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            panelTitleForm = new PanelCustomBorder();
            btnIconCloseDefault = new Button();
            lblSwName = new Label();
            btnIconMaximunDisable = new Button();
            menuSw = new MenuStrip();
            menuFile = new ToolStripMenuItem();
            runWorkInspectionToolStripMenuItem = new ToolStripMenuItem();
            MenuUser = new ToolStripMenuItem();
            MenuUserCreate = new ToolStripMenuItem();
            MenuUserLstUser = new ToolStripMenuItem();
            manuProcedure = new ToolStripMenuItem();
            managementToolStripMenuItem2 = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            manuDevices = new ToolStripMenuItem();
            createToolStripMenuItem = new ToolStripMenuItem();
            managementToolStripMenuItem = new ToolStripMenuItem();
            manuTool = new ToolStripMenuItem();
            manuHelp = new ToolStripMenuItem();
            helpToolStripMenuItem1 = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            managerExtensionToolStripMenuItem = new ToolStripMenuItem();
            testToolStripMenuItem2 = new ToolStripMenuItem();
            test2ToolStripMenuItem = new ToolStripMenuItem();
            test3ToolStripMenuItem = new ToolStripMenuItem();
            testFormURLToolStripMenuItem = new ToolStripMenuItem();
            btnIconMinimunDefault = new Button();
            lblSwIcon = new Label();
            panelMain = new PanelBorderRadiusCustom();
            panelTitleForm.SuspendLayout();
            menuSw.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitleForm
            // 
            panelTitleForm.BackColor = Color.White;
            panelTitleForm.BorderBottom = true;
            panelTitleForm.BorderColor = Color.DarkGray;
            panelTitleForm.BorderLeft = false;
            panelTitleForm.BorderRight = false;
            panelTitleForm.BorderSize = 1;
            panelTitleForm.BorderTop = false;
            panelTitleForm.Controls.Add(btnIconCloseDefault);
            panelTitleForm.Controls.Add(lblSwName);
            panelTitleForm.Controls.Add(btnIconMaximunDisable);
            panelTitleForm.Controls.Add(menuSw);
            panelTitleForm.Controls.Add(btnIconMinimunDefault);
            panelTitleForm.Controls.Add(lblSwIcon);
            resources.ApplyResources(panelTitleForm, "panelTitleForm");
            panelTitleForm.Name = "panelTitleForm";
            // 
            // btnIconCloseDefault
            // 
            resources.ApplyResources(btnIconCloseDefault, "btnIconCloseDefault");
            btnIconCloseDefault.BackColor = Color.Transparent;
            btnIconCloseDefault.Cursor = Cursors.Hand;
            btnIconCloseDefault.FlatAppearance.BorderColor = Color.White;
            btnIconCloseDefault.FlatAppearance.BorderSize = 0;
            btnIconCloseDefault.FlatAppearance.MouseDownBackColor = Color.FromArgb(192, 0, 0);
            btnIconCloseDefault.FlatAppearance.MouseOverBackColor = Color.FromArgb(192, 0, 0);
            btnIconCloseDefault.ForeColor = Color.Black;
            btnIconCloseDefault.Image = Properties.Resources.iconCloseBlack;
            btnIconCloseDefault.Name = "btnIconCloseDefault";
            btnIconCloseDefault.UseVisualStyleBackColor = false;
            btnIconCloseDefault.Click += btnClose_Click;
            // 
            // lblSwName
            // 
            lblSwName.BackColor = Color.Transparent;
            resources.ApplyResources(lblSwName, "lblSwName");
            lblSwName.ForeColor = Color.FromArgb(0, 32, 77);
            lblSwName.Name = "lblSwName";
            lblSwName.Click += lblSwName_Click;
            // 
            // btnIconMaximunDisable
            // 
            resources.ApplyResources(btnIconMaximunDisable, "btnIconMaximunDisable");
            btnIconMaximunDisable.BackColor = Color.Transparent;
            btnIconMaximunDisable.Cursor = Cursors.No;
            btnIconMaximunDisable.FlatAppearance.BorderColor = Color.White;
            btnIconMaximunDisable.FlatAppearance.BorderSize = 0;
            btnIconMaximunDisable.FlatAppearance.MouseDownBackColor = Color.FromArgb(232, 232, 232);
            btnIconMaximunDisable.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 232, 232);
            btnIconMaximunDisable.ForeColor = Color.Black;
            btnIconMaximunDisable.Image = Properties.Resources.iconFullBlack;
            btnIconMaximunDisable.Name = "btnIconMaximunDisable";
            btnIconMaximunDisable.UseVisualStyleBackColor = false;
            // 
            // menuSw
            // 
            resources.ApplyResources(menuSw, "menuSw");
            menuSw.BackColor = Color.Transparent;
            menuSw.GripMargin = new Padding(0);
            menuSw.Items.AddRange(new ToolStripItem[] { menuFile, MenuUser, manuProcedure, manuDevices, manuTool, manuHelp, testToolStripMenuItem, testToolStripMenuItem2, test2ToolStripMenuItem, test3ToolStripMenuItem, testFormURLToolStripMenuItem });
            menuSw.Name = "menuSw";
            menuSw.ItemClicked += menuSw_ItemClicked;
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { runWorkInspectionToolStripMenuItem });
            resources.ApplyResources(menuFile, "menuFile");
            menuFile.ForeColor = Color.FromArgb(0, 32, 77);
            menuFile.Name = "menuFile";
            menuFile.Padding = new Padding(0);
            // 
            // runWorkInspectionToolStripMenuItem
            // 
            runWorkInspectionToolStripMenuItem.ForeColor = Color.FromArgb(0, 32, 77);
            runWorkInspectionToolStripMenuItem.Name = "runWorkInspectionToolStripMenuItem";
            resources.ApplyResources(runWorkInspectionToolStripMenuItem, "runWorkInspectionToolStripMenuItem");
            runWorkInspectionToolStripMenuItem.Click += runWorkInspectionToolStripMenuItem_Click;
            // 
            // MenuUser
            // 
            MenuUser.DropDownItems.AddRange(new ToolStripItem[] { MenuUserCreate, MenuUserLstUser });
            MenuUser.Name = "MenuUser";
            resources.ApplyResources(MenuUser, "MenuUser");
            // 
            // MenuUserCreate
            // 
            MenuUserCreate.ForeColor = Color.FromArgb(0, 32, 77);
            MenuUserCreate.Name = "MenuUserCreate";
            resources.ApplyResources(MenuUserCreate, "MenuUserCreate");
            MenuUserCreate.Click += MenuUserCreate_Click;
            // 
            // MenuUserLstUser
            // 
            MenuUserLstUser.ForeColor = Color.FromArgb(0, 32, 77);
            MenuUserLstUser.Name = "MenuUserLstUser";
            resources.ApplyResources(MenuUserLstUser, "MenuUserLstUser");
            MenuUserLstUser.Click += MenuUserLstUser_Click;
            // 
            // manuProcedure
            // 
            manuProcedure.BackColor = Color.Transparent;
            manuProcedure.DropDownItems.AddRange(new ToolStripItem[] { managementToolStripMenuItem2, toolStripMenuItem1 });
            resources.ApplyResources(manuProcedure, "manuProcedure");
            manuProcedure.ForeColor = Color.FromArgb(0, 32, 77);
            manuProcedure.Name = "manuProcedure";
            // 
            // managementToolStripMenuItem2
            // 
            managementToolStripMenuItem2.ForeColor = Color.FromArgb(0, 32, 77);
            managementToolStripMenuItem2.Name = "managementToolStripMenuItem2";
            resources.ApplyResources(managementToolStripMenuItem2, "managementToolStripMenuItem2");
            managementToolStripMenuItem2.Click += managementToolStripMenuItem2_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
            toolStripMenuItem1.Click += toolStripMenuItem1_Click;
            // 
            // manuDevices
            // 
            manuDevices.BackColor = Color.Transparent;
            manuDevices.DropDownItems.AddRange(new ToolStripItem[] { createToolStripMenuItem, managementToolStripMenuItem });
            resources.ApplyResources(manuDevices, "manuDevices");
            manuDevices.ForeColor = Color.FromArgb(0, 32, 77);
            manuDevices.Name = "manuDevices";
            manuDevices.Padding = new Padding(0);
            // 
            // createToolStripMenuItem
            // 
            createToolStripMenuItem.ForeColor = Color.FromArgb(0, 32, 77);
            createToolStripMenuItem.Name = "createToolStripMenuItem";
            resources.ApplyResources(createToolStripMenuItem, "createToolStripMenuItem");
            createToolStripMenuItem.Click += createToolStripMenuItem_Click;
            // 
            // managementToolStripMenuItem
            // 
            managementToolStripMenuItem.ForeColor = Color.FromArgb(0, 32, 77);
            managementToolStripMenuItem.Name = "managementToolStripMenuItem";
            resources.ApplyResources(managementToolStripMenuItem, "managementToolStripMenuItem");
            managementToolStripMenuItem.Click += managementToolStripMenuItem_Click;
            // 
            // manuTool
            // 
            resources.ApplyResources(manuTool, "manuTool");
            manuTool.ForeColor = Color.FromArgb(0, 32, 77);
            manuTool.Name = "manuTool";
            manuTool.Padding = new Padding(0);
            // 
            // manuHelp
            // 
            manuHelp.DropDownItems.AddRange(new ToolStripItem[] { helpToolStripMenuItem1, aboutToolStripMenuItem });
            resources.ApplyResources(manuHelp, "manuHelp");
            manuHelp.ForeColor = Color.FromArgb(0, 32, 77);
            manuHelp.Name = "manuHelp";
            manuHelp.Padding = new Padding(0);
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.ForeColor = Color.FromArgb(0, 32, 77);
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            resources.ApplyResources(helpToolStripMenuItem1, "helpToolStripMenuItem1");
            helpToolStripMenuItem1.Click += helpToolStripMenuItem1_Click;
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.ForeColor = Color.FromArgb(0, 32, 77);
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            resources.ApplyResources(aboutToolStripMenuItem, "aboutToolStripMenuItem");
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { managerExtensionToolStripMenuItem });
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            resources.ApplyResources(testToolStripMenuItem, "testToolStripMenuItem");
            // 
            // managerExtensionToolStripMenuItem
            // 
            managerExtensionToolStripMenuItem.ForeColor = Color.FromArgb(0, 32, 77);
            managerExtensionToolStripMenuItem.Name = "managerExtensionToolStripMenuItem";
            resources.ApplyResources(managerExtensionToolStripMenuItem, "managerExtensionToolStripMenuItem");
            managerExtensionToolStripMenuItem.Click += managerExtensionToolStripMenuItem_Click;
            // 
            // testToolStripMenuItem2
            // 
            testToolStripMenuItem2.Name = "testToolStripMenuItem2";
            resources.ApplyResources(testToolStripMenuItem2, "testToolStripMenuItem2");
            testToolStripMenuItem2.Click += testToolStripMenuItem2_Click;
            // 
            // test2ToolStripMenuItem
            // 
            test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            resources.ApplyResources(test2ToolStripMenuItem, "test2ToolStripMenuItem");
            test2ToolStripMenuItem.Click += test2ToolStripMenuItem_Click;
            // 
            // test3ToolStripMenuItem
            // 
            test3ToolStripMenuItem.Name = "test3ToolStripMenuItem";
            resources.ApplyResources(test3ToolStripMenuItem, "test3ToolStripMenuItem");
            test3ToolStripMenuItem.Click += test3ToolStripMenuItem_Click;
            // 
            // testFormURLToolStripMenuItem
            // 
            testFormURLToolStripMenuItem.Name = "testFormURLToolStripMenuItem";
            resources.ApplyResources(testFormURLToolStripMenuItem, "testFormURLToolStripMenuItem");
            testFormURLToolStripMenuItem.Click += testFormURLToolStripMenuItem_Click;
            // 
            // btnIconMinimunDefault
            // 
            resources.ApplyResources(btnIconMinimunDefault, "btnIconMinimunDefault");
            btnIconMinimunDefault.BackColor = Color.Transparent;
            btnIconMinimunDefault.Cursor = Cursors.Hand;
            btnIconMinimunDefault.FlatAppearance.BorderColor = Color.White;
            btnIconMinimunDefault.FlatAppearance.BorderSize = 0;
            btnIconMinimunDefault.FlatAppearance.MouseDownBackColor = Color.FromArgb(232, 232, 232);
            btnIconMinimunDefault.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 232, 232);
            btnIconMinimunDefault.ForeColor = Color.Black;
            btnIconMinimunDefault.Image = Properties.Resources.iconMiniBlack;
            btnIconMinimunDefault.Name = "btnIconMinimunDefault";
            btnIconMinimunDefault.UseVisualStyleBackColor = false;
            btnIconMinimunDefault.Click += btnMinimun_Click;
            // 
            // lblSwIcon
            // 
            lblSwIcon.BackColor = Color.Transparent;
            resources.ApplyResources(lblSwIcon, "lblSwIcon");
            lblSwIcon.Name = "lblSwIcon";
            // 
            // panelMain
            // 
            panelMain.BackColorG = Color.Empty;
            panelMain.BorderColor = Color.DarkGray;
            panelMain.BorderSize = 0;
            resources.ApplyResources(panelMain, "panelMain");
            panelMain.Name = "panelMain";
            panelMain.RadiusBottomLeft = 0;
            panelMain.RadiusBottomRight = 0;
            panelMain.RadiusTopLeft = 0;
            panelMain.RadiusTopRight = 0;
            panelMain.VerticalPoints = (List<int>)resources.GetObject("panelMain.VerticalPoints");
            // 
            // FormMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.White;
            resources.ApplyResources(this, "$this");
            Controls.Add(panelMain);
            Controls.Add(panelTitleForm);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormMain";
            Load += FormMain_Load;
            Click += FormMain_Click;
            panelTitleForm.ResumeLayout(false);
            menuSw.ResumeLayout(false);
            menuSw.PerformLayout();
            ResumeLayout(false);
        }

        #endregion



        private System.Windows.Forms.Label lblSwIcon;
        private PanelCustomBorder panelTitleForm;
        private System.Windows.Forms.Label lblSwName;
        private System.Windows.Forms.Button btnIconCloseDefault;
        private System.Windows.Forms.Button btnIconMinimunDefault;
        private Button btnIconMaximunDisable;
        private MenuStrip menuSw;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem runWorkInspectionToolStripMenuItem;
        private ToolStripMenuItem MenuUser;
        private ToolStripMenuItem MenuUserCreate;
        private ToolStripMenuItem MenuUserLstUser;
        private ToolStripMenuItem manuProcedure;
        private ToolStripMenuItem managementToolStripMenuItem2;
        private ToolStripMenuItem manuDevices;
        private ToolStripMenuItem createToolStripMenuItem;
        private ToolStripMenuItem managementToolStripMenuItem;
        private ToolStripMenuItem manuTool;
        private ToolStripMenuItem manuHelp;
        private ToolStripMenuItem helpToolStripMenuItem1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem managerExtensionToolStripMenuItem;
        private ToolStripMenuItem testToolStripMenuItem2;
        private PanelBorderRadiusCustom panelMain;
        private ToolStripMenuItem test2ToolStripMenuItem;
        private ToolStripMenuItem test3ToolStripMenuItem;
        private ToolStripMenuItem testFormURLToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
    }
}