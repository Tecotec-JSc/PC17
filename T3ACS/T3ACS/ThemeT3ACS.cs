using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3.Configuration;

namespace T3ACS
{
    public class ThemeT3ACS
    {
        public static bool IsSelectedTheme { get; set; }
        public void LoadThemeDefault()
        {
           ThemeManager.DefaultTheme = new ThemeViewModel
            {
                BackColors = new List<Color>() { Color.White, Color.FromArgb(232, 232, 232), Color.FromArgb(11, 123, 105), Color.FromArgb(250, 250, 250), Color.FromArgb(255, 255, 255), },
                BorderColors = new List<Color>() { Color.DarkGray, Color.FromArgb(250, 250, 250), Color.FromArgb(11, 123, 105) },
                strFont = "Segoe UI",
                ForeColors = new List<Color>() { Color.FromArgb(3, 5, 71), Color.FromArgb(0, 32, 77) },
                HoverColors = new List<Color>() { Color.FromArgb(232, 232, 232) },
                PlaceholdColor = Color.FromArgb(130, 130, 130),
                FontDefault = new Font("Segoe UI Variable Display", 10.5F),
                GraphicBackColor = Color.White,
                GraphicBorderColor = Color.Black,
                GraphicForeColor = Color.Black,
                HighlighBackColor = Color.FromArgb(232, 232, 232),
                //iconClose = Properties.Resources.iconCloseBlack,
                //iconFull = Properties.Resources.iconFullBlack,
                //iconMini = Properties.Resources.iconMiniBlack,



            };
        }
        public void LoadThemeSelected()
        {
           
                ThemeManager.ThemeSelect = new ThemeViewModel
                {
                    PathIcon = AppDomain.CurrentDomain.BaseDirectory + "Theme\\VSAT\\",
                    BackColors = new List<Color>() { Color.FromArgb(6, 16, 20), Color.FromArgb(6, 47, 56), Color.FromArgb(6, 47, 56), Color.FromArgb(15, 32, 39), Color.FromArgb(14, 82, 98) }, 
                    BorderColors = new List<Color>()
                    {Color.FromArgb(14, 82, 98), Color.FromArgb(15, 32, 39), Color.FromArgb(6, 47, 56) },
                    HoverColors = new List<Color>() { Color.DarkGray },
                    strFont = "Segoe UI",
                    FontDefault = new Font("Segoe UI Variable Display", 10.5F),
                    ForeColors = new List<Color>() { Color.White, Color.White },
                    GraphicBackColor = Color.White,
                    GraphicBorderColor = Color.Black,
                    GraphicForeColor = Color.Black,
                    HighlighBackColor = Color.FromArgb(6, 47, 56),
        
                };
        }
    }
}
