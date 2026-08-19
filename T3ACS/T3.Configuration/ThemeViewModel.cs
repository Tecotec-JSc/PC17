using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3.Configuration
{
    public class ThemeViewModel
    {
        public string PathIcon { get; set; }
        public string strFont { get; set; }
        public Font FontDefault { get; set; }
        public List<Color> BackColors { get; set; }
        public List<Color> HoverColors { get; set; }
        public List<Color> ForeColors { get; set; }
        public Color PlaceholdColor { get; set; }
        public List<Color> BorderColors { get; set; }    
        public Color HighlighBorderColor { get; set; }
        public Color HighlighBackColor { get; set; }
        public Color HighlighForeColor { get; set; }      
        public List<Color> GraphicTracesColor { get; set; }
        public Color GraphicBackColor { get; set; }
        public Color GraphicBorderColor { get; set; }
        public Color GraphicForeColor { get; set; }
    }
}
