using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3.Configuration;
using T3ACS.Model.Interface;

namespace  T3ACS.Controls.PanelCustoms
{
    public partial class PanelCustomBorder : Panel, IThemeSupport
    {
        public PanelCustomBorder()
        {           
            this.DoubleBuffered = true;
        }
        public void ApplyTheme()
        {
            BackColor =ThemeManager.GetColorBy(BackColor, 0);
            BorderColor = ThemeManager.GetColorBy(BorderColor,2);
            Invalidate();
        }
        /// <summary>
        /// type 0: BackColor, 1: ForeColor,2: BorderColor
        /// </summary>
        /// <param name="colorForm"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        private Color GetColorBy(Color color, int type, ThemeViewModel themeDefault, ThemeViewModel theme)
        {
            Color result = Color.Empty;
            switch (type)
            {
                case 0:
                    if (themeDefault.BackColors.Contains(color))
                        return theme.BackColors[themeDefault.BackColors.IndexOf(color)];
                    break;
                case 1:
                    if (themeDefault.ForeColors.Contains(color))
                        return theme.ForeColors[themeDefault.ForeColors.IndexOf(color)];
                    break;
                case 2:
                    if (themeDefault.BorderColors.Contains(color))
                        return theme.BorderColors[themeDefault.BorderColors.IndexOf(color)];
                    break;
            }
            return result;
        }
        public bool BorderTop { get; set; } = true;
        public bool BorderBottom { get; set; } = true;
        public bool BorderLeft { get; set; } = true;
        public bool BorderRight { get; set; } = true;

        public Color BorderColor { get; set; } = Color.DarkGray;
        public int BorderSize { get; set; } = 1;


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen pen = new Pen(BorderColor, BorderSize))
            {
                if (BorderTop)
                    e.Graphics.DrawLine(pen, 0, 0, Width - 1, 0);

                if (BorderBottom)
                    e.Graphics.DrawLine(pen, 0, Height - 1, Width - 1, Height - 1);

                if (BorderLeft)
                    e.Graphics.DrawLine(pen, 0, 0, 0, Height - 1);

                if (BorderRight)
                    e.Graphics.DrawLine(pen, Width - 1, 0, Width - 1, Height - 1);
            }
        }
    }
}
