using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace T3.Configuration
{
    public static class ThemeManager
    {
        public static ThemeViewModel DefaultTheme { get; set; }
        public static ThemeViewModel ThemeSelect { get; set; }

        /// <summary>
        /// type 0: BackColor, 1: ForeColor,2: BorderColor,3: HoverColor
        /// </summary>
        /// <param name="color"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Color GetColorBy(Color color, int type)
        {
            Color result = color;
            switch (type)
            {
                case 0:
                    if (DefaultTheme.BackColors.Contains(color))
                        return ThemeSelect.BackColors[DefaultTheme.BackColors.IndexOf(color)];
                    break;
                case 1:
                    if (DefaultTheme.ForeColors.Contains(color))
                        return ThemeSelect.ForeColors[DefaultTheme.ForeColors.IndexOf(color)];
                    break;
                case 2:
                    if (DefaultTheme.BorderColors.Contains(color))
                        return ThemeSelect.BorderColors[DefaultTheme.BorderColors.IndexOf(color)];
                    break;
                case 3:
                    if (DefaultTheme.HoverColors.Contains(color))
                        return ThemeSelect.HoverColors[DefaultTheme.HoverColors.IndexOf(color)];
                    break;
            }
            return result;
        }
        public static Image GetImageBy(string name)
        {
            Image result = null;
            if (name.IndexOf("Icon") != -1)
            {
                string iconPath = ThemeSelect.PathIcon + name.Substring(name.IndexOf("Icon")) + ".png";
                if (System.IO.File.Exists(iconPath))
                {
                    result = Image.FromFile(iconPath);
                }
            }
            return result;
        }
    }
    
}
