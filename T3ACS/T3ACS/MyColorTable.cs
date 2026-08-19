using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using T3.Configuration;

namespace T3ACS
{
    public class MyColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
            => ThemeManager.ThemeSelect.HighlighBackColor ;

        public override Color MenuItemSelectedGradientBegin
            => ThemeManager.ThemeSelect.HighlighBackColor;

        public override Color MenuItemSelectedGradientEnd
             => ThemeManager.ThemeSelect.HighlighBackColor;

        public override Color MenuItemPressedGradientBegin
              => ThemeManager.ThemeSelect.HighlighBackColor;

        public override Color MenuItemPressedGradientMiddle
      => ThemeManager.ThemeSelect.HighlighBackColor;

        public override Color MenuItemPressedGradientEnd
            => ThemeManager.ThemeSelect.HighlighBackColor;
    }
}
