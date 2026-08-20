using System.Drawing.Drawing2D;

namespace T3ACS
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();

        }

        private void lblCloseIcon_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetFormRadius(int radius)
        {
            GraphicsPath path = new GraphicsPath();

            Rectangle r = new Rectangle(0, 0, Width, Height);
            path.StartFigure();
            int tl = radius;
            int tr = radius;
            int bl = radius;
            int br = radius;
            // Top left
            if (tl > 0)
                path.AddArc(r.X, r.Y, tl * 2, tl * 2, 180, 90);
            else
                path.AddLine(r.X, r.Y, r.X, r.Y);

            // Top
            path.AddLine(r.X + tl, r.Y, r.Right - tr, r.Y);

            // Top right
            if (tr > 0)
                path.AddArc(r.Right - tr * 2, r.Y, tr * 2, tr * 2, 270, 90);

            // Right
            path.AddLine(r.Right, r.Y + tr, r.Right, r.Bottom - br);

            // Bottom right
            if (br > 0)
                path.AddArc(r.Right - br * 2, r.Bottom - br * 2, br * 2, br * 2, 0, 90);

            // Bottom
            path.AddLine(r.Right - br, r.Bottom, r.X + bl, r.Bottom);

            // Bottom left
            if (bl > 0)
                path.AddArc(r.X, r.Bottom - bl * 2, bl * 2, bl * 2, 90, 90);

            // Left
            path.AddLine(r.X, r.Bottom - bl, r.X, r.Y + tl);

            path.CloseFigure();

            Region?.Dispose();
            Region = new Region(path);
            path.Dispose();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            SetFormRadius(5);
        }

        private void btnClose__EventSelect(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
