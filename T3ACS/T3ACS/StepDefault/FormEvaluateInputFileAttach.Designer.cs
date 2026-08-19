using T3ACS.Controls;

namespace T3ACS
{
    partial class FormEvaluateInputFileAttach
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEvaluateInputFileAttach));
            rtbNote = new RJEditor();
            panelControlAll1 = new PanelControlAll();
            btnPass = new ButtonIconLable();
            btnFailed = new ButtonIconLable();
            label11 = new Label();
            btnQuit = new ButtonControl();
            btnExport = new ButtonIconLable();
            panelFileContent = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // rtbNote
            // 
            rtbNote.BackColor = Color.White;
            rtbNote.BorderColor = Color.DarkGray;
            rtbNote.BorderFocusColor = Color.FromArgb(3, 120, 212);
            rtbNote.BorderRadius = 5;
            rtbNote.BorderSize = 1;
            rtbNote.Location = new Point(35, 12);
            rtbNote.Name = "rtbNote";
            rtbNote.PlaceholderColor = Color.FromArgb(153, 166, 184);
            rtbNote.PlaceholderText = "";
            rtbNote.Size = new Size(1071, 158);
            rtbNote.TabIndex = 0;
            rtbNote.Texts = "";
            rtbNote.UnderlinedStyle = false;
            // 
            // panelControlAll1
            // 
            panelControlAll1.BackColor = SystemColors.Window;
            panelControlAll1.BorderColor = Color.WhiteSmoke;
            panelControlAll1.BorderFocusColor = Color.HotPink;
            panelControlAll1.BorderSize = 5;
            panelControlAll1.Location = new Point(337, 728);
            panelControlAll1.Margin = new Padding(2);
            panelControlAll1.Name = "panelControlAll1";
            panelControlAll1.Padding = new Padding(2);
            panelControlAll1.Size = new Size(581, 65);
            panelControlAll1.TabIndex = 2;
            // 
            // btnPass
            // 
            btnPass.Font = new Font("Segoe UI", 10.5F);
            btnPass.ForeColor = Color.FromArgb(0, 32, 77);
            btnPass.Location = new Point(355, 745);
            btnPass.Margin = new Padding(3, 4, 3, 4);
            btnPass.Name = "btnPass";
            btnPass.Size = new Size(90, 36);
            btnPass.TabIndex = 4;
            // 
            // btnFailed
            // 
            btnFailed.Font = new Font("Segoe UI", 10.5F);
            btnFailed.ForeColor = Color.FromArgb(0, 32, 77);
            btnFailed.Location = new Point(477, 745);
            btnFailed.Margin = new Padding(3, 4, 3, 4);
            btnFailed.Name = "btnFailed";
            btnFailed.Size = new Size(93, 36);
            btnFailed.TabIndex = 4;
            // 
            // label11
            // 
            label11.BackColor = Color.White;
            label11.Image = (Image)resources.GetObject("label11.Image");
            label11.Location = new Point(610, 736);
            label11.Name = "label11";
            label11.Size = new Size(10, 53);
            label11.TabIndex = 9;
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
            btnQuit.Location = new Point(804, 745);
            btnQuit.Name = "btnQuit";
            btnQuit.Size = new Size(94, 36);
            btnQuit.TabIndex = 3;
            btnQuit.Texts = "lblbtn1";
            btnQuit.Click += btnQuit_Click;
            // 
            // btnExport
            // 
            btnExport.Font = new Font("Segoe UI", 10.5F);
            btnExport.ForeColor = Color.FromArgb(0, 32, 77);
            btnExport.Location = new Point(655, 745);
            btnExport.Margin = new Padding(3, 4, 3, 4);
            btnExport.Name = "btnExport";
            btnExport.Size = new Size(120, 36);
            btnExport.TabIndex = 4;
            // 
            // panelFileContent
            // 
            panelFileContent.Location = new Point(29, 189);
            panelFileContent.Name = "panelFileContent";
            panelFileContent.Size = new Size(1085, 534);
            panelFileContent.TabIndex = 10;
            // 
            // FormEvaluateInputFileAttach
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1118, 804);
            Controls.Add(panelFileContent);
            Controls.Add(label11);
            Controls.Add(btnExport);
            Controls.Add(btnFailed);
            Controls.Add(btnPass);
            Controls.Add(btnQuit);
            Controls.Add(panelControlAll1);
            Controls.Add(rtbNote);
            Font = new Font("Segoe UI Variable Text", 10.5F);
            ForeColor = Color.FromArgb(0, 32, 77);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormEvaluateInputFileAttach";
            Text = "FormEvaluateInputFileAttach";
            ResumeLayout(false);
        }

        #endregion

        private RJEditor rtbNote;
        private PanelControlAll panelControlAll1;
        private ButtonIconLable btnPass;
        private ButtonIconLable btnFailed;
        private Label label11;
        private ButtonControl btnQuit;
        private ButtonIconLable btnExport;
        private FlowLayoutPanel panelFileContent;
    }
}