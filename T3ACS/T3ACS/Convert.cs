using OfficeOpenXml.ConditionalFormatting.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS
{
    public class Convert
    {
        public Font ConvertToFont(string input)
        {
         
            string[] parts = input.Split(',');

            string fontName = parts[0].Trim();
            float size = float.Parse(
                parts[1].Replace("pt", "").Trim(),
                System.Globalization.CultureInfo.InvariantCulture
            );

            FontStyle style = FontStyle.Regular;

            if (input.Contains("Bold")) style |= FontStyle.Bold;
            if (input.Contains("Italic")) style |= FontStyle.Italic;
            if (input.Contains("Underline")) style |= FontStyle.Underline;

            Font font = new Font(fontName, size, style);
            return font;
        }
        public static Size GetTextSize(string text, Font font)
        {
            return TextRenderer.MeasureText(text, font);
        }
        public static Size GetTextSize(string text, Font font, int weight,int heigh)
        {
            var size = TextRenderer.MeasureText(text, font);
            var maxweight = size.Width;
            var countRow = maxweight / weight;
            if (maxweight % weight != 0) countRow++;
            return new Size(weight, heigh * countRow);
        }
    }
    }

