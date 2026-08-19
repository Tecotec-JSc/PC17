using T3.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS
{
    public class ThemeFont
    {
        public static Font fontLable;
        public static Font fontTitle;
        public static Font fontTitleCard;
        public static Font fonttext;
        public static Font fontHuge;
        public void SetThemeDefault()
        {
            Convert convert = new Convert();
            fontLable = convert.ConvertToFont(Main.fontLable);
            fontTitle = convert.ConvertToFont(Main.fontTitle);
            fontTitleCard = convert.ConvertToFont(Main.fontTitleCard);
            fonttext = convert.ConvertToFont(Main.fonttext);
            fontHuge = convert.ConvertToFont(Main.fontHuge);
        }
    }
}
