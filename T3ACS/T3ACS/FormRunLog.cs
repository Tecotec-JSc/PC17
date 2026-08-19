using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3ACS
{
    public partial class FormRunLog : Form
    {
        public FormRunLog()
        {
            InitializeComponent();
        }

        #region hover control
        // hover 
        private Color originalColor;
        private void UserControl_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Label item)
            {
                originalColor = item.BackColor;
                item.BackColor = DarkerColor(originalColor, 0.90f);
            }
        }
        public bool _hover;
        private void UserControl_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Label item)
            {
                if (originalColor != null)
                    item.BackColor = originalColor;
            }
        }
        private Color DarkerColor(Color color, float factor)
        {
            return Color.FromArgb(
                color.A,
                (int)(color.R * factor),
                (int)(color.G * factor),
                (int)(color.B * factor)
            );
        }
        #endregion



        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonControl1_btnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonCustomIcon1_btnClick(object sender, EventArgs e)
        {

        }
    }
}
