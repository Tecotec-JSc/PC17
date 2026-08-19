using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class FormCustomStepPopup : Form
    {

        // Click title to move
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void panelTitle_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }
        // end move






        int borderRadius = 15;
        int borderSize = 2;
        Color borderColor = Color.DarkGray;
        FormCustomContent _frmContent;
        public FormCustomStepPopup()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            _frmContent = new FormCustomContent();
            _frmContent.TopLevel = false;
            _frmContent.Dock = DockStyle.Fill;
            panelContent.Controls.Add(_frmContent);
            _frmContent.Show();
        }
        public void LoadData(List<ProcedureVariableViewModel> vm)
        {
            _frmContent.LoadData(vm);
        }
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;

            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);

            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rectSurface = this.ClientRectangle;
            Rectangle rectBorder = Rectangle.Inflate(rectSurface, 0, 0);

            using (GraphicsPath pathSurface = GetRoundedPath(rectSurface, borderRadius))
            using (GraphicsPath pathBorder = GetRoundedPath(rectBorder, borderRadius - borderSize))
            using (Pen penBorder = new Pen(borderColor, borderSize))
            {
                this.Region = new Region(pathSurface);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                e.Graphics.DrawPath(penBorder, pathBorder);
            }
        }
        private void panelContent_Paint(object sender, PaintEventArgs e)
        {
            Panel p = sender as Panel;

            using (Pen pen = new Pen(Color.DarkGray, 1))
            {
                // Viền trên
                e.Graphics.DrawLine(pen, 0, 0, p.Width, 0);

                // Viền dưới
                e.Graphics.DrawLine(pen, 0, p.Height - 1, p.Width, p.Height - 1);
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
