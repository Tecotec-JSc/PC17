using T3ACS.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class FormOKCancelAll : Form
    {
        public FormOKCancelAll()
        {
            InitializeComponent();
            btnOK.BackColors = Color.FromArgb(0, 82, 130);
            btnOK.BorderColor = Color.FromArgb(0, 82, 130);
            btnOK.BorderFocusColor = Color.FromArgb(0, 82, 130);
            btnOK.ForeColors = Color.White;

            btnCancel.BackColors = Color.White;
            btnCancel.BorderColor = Color.FromArgb(204, 215, 230);
            btnCancel.BorderFocusColor = Color.FromArgb(0, 82, 130);
            btnCancel.ForeColors = Color.FromArgb(0, 32, 77);
        }
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.StartFigure();
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();

            return path;
        }
        private int _radius = 20;
        private int _borderSize = 2;
        private Color _borderColor = Color.FromArgb(224, 224, 224);

        private void ApplyRoundedRegion()
        {
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            this.Region = new Region(GetRoundedPath(rect, _radius));
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rectBorder = new Rectangle(
                _borderSize / 2,
                _borderSize / 2,
                this.Width - _borderSize,
                this.Height - _borderSize
            );

            using (GraphicsPath path = GetRoundedPath(rectBorder, _radius))
            using (Pen pen = new Pen(_borderColor, _borderSize))
            {
                e.Graphics.DrawPath(pen, path);
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ApplyRoundedRegion();
        }
        /// <summary>
        /// type 1: Save  change , 2: warning
        /// </summary>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="strBtnOk"></param>
        /// <param name="strBtnCancel"></param>
        /// <param name="type"></param>
        public void LoadData(string title, string content, string strBtnOk, string strBtnCancel, int type)
        {
            lblTitle.Text = title;
            lblContent.Text = content;
            btnCancel.Texts = strBtnCancel;
            btnOK.Texts = strBtnOk;
            if (type == 0)
            {

            }
            else if (type == 1)
            {

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
