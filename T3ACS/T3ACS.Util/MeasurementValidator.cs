using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace T3ACS.Util
{
    public static class MeasurementValidator
    {
   

        public static bool ValidateTitle(
      string title,
      string input,
      int minLength,
      int maxLength,
      IEnumerable<string> existingTitles,
      out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                errorMessage = title + " is required.";
                return false;
            }

            input = input.Trim();

            if (input.Length < minLength || input.Length > maxLength)
            {
                errorMessage = $"{title} must be between {minLength} and {maxLength} characters.";
                return false;
            }

            // Cho phép Unicode (tiếng Việt), số, khoảng trắng, - _
            if (!Regex.IsMatch(input, @"^[\p{L}\p{N} _\-\.,]+$"))
            {
                errorMessage = title + " contains invalid characters.";
                return false;
            }

            // Không trùng (không phân biệt hoa thường)
            if (existingTitles != null &&
                existingTitles.Any(t =>
                    string.Equals(t?.Trim(), input, StringComparison.OrdinalIgnoreCase)))
            {
                errorMessage = title + " already exists.";
                return false;
            }

            return true;
        }
        public static bool ValidateName(string name, string title,  List<string> nameExists, int minLength, int maxLength, out string mess)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                mess = title + " is required.";
                return false;
            }

            if (name.Length < minLength || name.Length > maxLength)
            {
                mess = title + $" must be {minLength}–{maxLength} characters long.";
                return false;
            }

            // Bắt đầu bằng chữ cái A-Z
            if (!Regex.IsMatch(name, @"^[A-Za-z]"))
            {
                mess = title + " must start with a letter (A–Z).";
                return false;
            }

            // ❌ Không cho tiếng Việt & ký tự đặc biệt
            // ✅ Chỉ cho A-Z a-z 0-9
            if (!Regex.IsMatch(name, @"^[A-Za-z0-9]+$"))
            {
                mess = title + " can only contain letters (A–Z) and numbers (0–9).";
                return false;
            }

            if (nameExists.Contains(name))
            {
                mess = title + " already exists.";
                return false;
            }

            mess = "";
            return true;


            //if (string.IsNullOrWhiteSpace(name))
            //{
            //    mess = title + " is required.";
            //    return false;
            //}               
            //if (name.Length < minLength || name.Length > maxLength)
            //{
            //    mess = title + " must be " + minLength + "–" + maxLength + " characters long.";
            //    return false;
            //}             
            //if (!char.IsLetter(name[0]))
            //{
            //    mess = title +" must start with a letter.";
            //    return false;
            //}
            //if (!((name[0] >= 'a' && name[0] <= 'z') || (name[0] >= 'A' && name[0] <= 'Z')))
            //{
            //    mess = title + " must start with a letter (A–Z).";
            //    return false;
            //}
            //// no consecutive special chars
            //string specials = "._-";
            //for (int i = 1; i < name.Length; i++)
            //{
            //    if (specials.Contains(name[i]) && specials.Contains(name[i - 1]))
            //    {
            //        mess = title + " cannot contain consecutive special characters like '..' or '._'.";
            //        return false;
            //    }               
            //}
            //if (name.EndsWith(".") || name.EndsWith("-"))
            //{
            //    mess = title + " cannot end with '.' or '-'.";
            //    return false;
            //}          
            ////
            //if (nameExists.Contains(name))
            //{
            //    mess = title + " is exist.";
            //    return false;
            //}
            //mess = "";
            //return true;
        }
        public static bool ValidateFrequency(string title, string valueinput, double? min, double? max, out string mess, out double value)
        {
            mess = string.Empty;
            value = 0;
            if (string.IsNullOrEmpty(valueinput))
            {
                mess = title += " is required.";
                return false;
            }
            else
            {
                var upstr = valueinput.ToUpper();     
                if (upstr.EndsWith("GHZ"))
                {
                    var strva = upstr.Substring(0, upstr.Length - 3).Trim();
                    if (!double.TryParse(strva, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out value))
                    {
                        mess = title += " is a number ex: 7GHz.";
                        return false;
                    }
                    else
                    {
                        value = value * 1000000000;
                    }
                }
                else if (upstr.EndsWith("MHZ"))
                {
                    var strva = upstr.Substring(0, upstr.Length - 3).Trim();
                    if (!double.TryParse(strva, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out value))
                    {
                        mess = title += " is a number ex: 7MHz.";
                        return false;
                    }
                    else
                    {
                        value = value * 1000000;
                    }
                }
                else if (upstr.EndsWith("KHZ"))
                {
                    var strva = upstr.Substring(0, upstr.Length - 3).Trim();
                    if (!double.TryParse(strva, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out value))
                    {
                        mess = title += " is a number ex: 7KHz.";
                        return false;
                    }
                    else
                    {
                        value = value * 1000;
                    }
                }
                else if (upstr.EndsWith("HZ"))
                {
                    var strva = upstr.Substring(0, upstr.Length - 2).Trim();
                    if (!double.TryParse(strva, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out value))
                    {
                        mess = title += " is a number ex: 7Hz.";
                        return false;
                    }
                }
                else
                {
                    if (!double.TryParse(upstr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out value))
                    {
                        mess = title += " is a number ex: 7.";
                        return false;
                    }
                }
            }
            if (min.HasValue && value < min)
            {
                mess = title + " cannot be less than ";
                if (min < 100000) mess += min / 1000 + "kHz.";
                else if (min < 100000000) mess += min / 1000000 + "MHz";
                else if (min < 1000000000000) mess += min / 1000000000 + "GHz";
                return false;
            }
            if (max.HasValue && value > max)
            {
                mess = title + " cannot be greater than ";
                if (max < 100000) mess += max / 1000 + "kHz.";
                else if (max < 100000000) mess += max / 1000000 + "MHz";
                else if (max < 1000000000000) mess += max / 1000000000 + "GHz";
                return false;
            }
            return true;
        }


        public static bool CheckValue(string title, string input, string strmin, string strmax, string type, out string mess1)
        {
            try
            {

                bool check = true;
                double? valuecheck = null;
                double? min = null;
                double? max = null;
                StringBuilder str = new StringBuilder();
                //Integer Double String Boolean
                if (type == "Integer")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
               
                        try
                        {
                            valuecheck = int.Parse(input);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be a integer");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmin))
                    {
                        try
                        {
                            min = int.Parse(strmin);
                        }
                        catch
                        {
                            str.AppendLine(title + " min  must be a integer");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmax))
                    {
                        try
                        {
                            max = int.Parse(strmax);
                        }
                        catch
                        {
                            str.AppendLine(title + " max must be a integer");
                            check = false;
                        }
                    }
                    if (min != null && max != null)
                    {
                        if (min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
                        }
                    }
                    if (valuecheck != null && min != null && valuecheck < min)
                    {
                        str.AppendLine(title + " value must be no less than Min");
                        check = false;
                    }
                    if (valuecheck != null && max != null && valuecheck > max)
                    {
                        str.AppendLine(title + " value must be no greater than Min");
                        check = false;
                    }

                }
                else if (type == "Double")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
               
                        try
                        {
                            valuecheck = double.Parse(input, CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmin))
                    {
                        try
                        {
                            min = double.Parse(strmin, CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " min  must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmax))
                    {
                        try
                        {
                            max = double.Parse(strmax, CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " max must be a number");
                            check = false;
                        }
                    }
                    if (min != null && max != null)
                    {
                        if (min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
                        }
                    }
                    if (valuecheck != null && min != null && valuecheck < min)
                    {
                        str.AppendLine(title + " value must be no less than Min");
                        check = false;
                    }
                    if (valuecheck != null && max != null && valuecheck > max)
                    {
                        str.AppendLine(title + " value must be no greater than Max");
                        check = false;
                    }
                }
                else if (type == "Boolean")
                {
                    if(!string.IsNullOrEmpty(input))
                    {

                        bool valuep = false;
                        if(!bool.TryParse(input,out valuep))
                        {
                            str.AppendLine(title + " value must be true or false.");
                        }
                    }
                }
                else if (type == "Float")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
                  
                        try
                        {
                            valuecheck = float.Parse(input, CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmin))
                    {
                        try
                        {
                            min = float.Parse(strmin, CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " min  must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmax))
                    {
                        try
                        {
                            max = float.Parse(strmax, CultureInfo.InvariantCulture);
                        }
                        catch
                        {
                            str.AppendLine(title + " max must be a number");
                            check = false;
                        }
                    }
                    if (min != null && max != null)
                    {
                        if (min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
                        }
                    }
                    if (valuecheck != null && min != null && valuecheck < min)
                    {
                        str.AppendLine(title + " value must be no less than Min");
                        check = false;
                    }
                    if (valuecheck != null && max != null && valuecheck > max)
                    {
                        str.AppendLine(title + " value must be no greater than Max");
                        check = false;
                    }
                }
                else if (type == "Ushort")
                {

                    if (!string.IsNullOrEmpty(input))
                    {
                 
                        try
                        {
                            valuecheck = ushort.Parse(input);
                        }
                        catch
                        {
                            str.AppendLine(title + " value must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmin))
                    {
                        try
                        {
                            min = ushort.Parse(strmin);
                        }
                        catch
                        {
                            str.AppendLine(title + " min  must be a number");
                            check = false;
                        }
                    }
                    if (!string.IsNullOrEmpty(strmax))
                    {
                        try
                        {
                            max = ushort.Parse(strmax);
                        }
                        catch
                        {
                            str.AppendLine(title + " max must be a number");
                            check = false;
                        }
                    }
                    if (min != null && max != null)
                    {
                        if (min > max)
                        {
                            str.AppendLine(title + " min must be less than Max");
                            check = false;
                        }
                    }
                    if (valuecheck != null && min != null && valuecheck < min)
                    {
                        str.AppendLine(title + " value must be no less than Min");
                        check = false;
                    }
                    if (valuecheck != null && max != null && valuecheck > max)
                    {
                        str.AppendLine(title + " value must be no greater than Max");
                        check = false;
                    }
                }
                mess1 = str.ToString();
                return check;
            }
            catch
            {
                mess1 = "Error.";
                return false;
            }

        }
        public static bool ValidateUnit(string title, string valueinput, string unit, double? min, double? max, out string mess, out double value)
        {
            mess = string.Empty;
            value = 0;
            List<string> units = new List<string>();
            var col = unit.Split(',');
            foreach (var c in col)
            {
                if (!string.IsNullOrEmpty(c))
                    units.Add(c);
            }
            if (string.IsNullOrEmpty(valueinput))
            {
                mess = title += " is required.";
                return false;
            }
            else
            {
                var upstr = valueinput.ToUpper();
                var warparse = false;
                foreach (var ite in units)
                {
                    if (upstr.EndsWith(ite.ToUpper()))
                    {
                        warparse = true;
                        var strva = upstr.Substring(0, upstr.Length - ite.Length).Trim();
                        if (!double.TryParse(strva, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out value))
                        {
                            mess = title += " is a number ex: 7" + ite + ".";
                            return false;
                        }
                    }
                }
                if (!warparse)
                {
                    if (!double.TryParse(upstr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out value))
                    {
                        mess = title += " is a number ex: 7.";
                        return false;
                    }
                }
            }
            if (min.HasValue && value < min)
            {
                mess = title + " cannot be less than " + min + " " + units[0] + ".";
                return false;
            }
            if (max.HasValue && value > max)
            {
                mess = title + " cannot be greater than " + max + "  " + units[0] + ".";

                return false;
            }
            return true;
        }
    }
}
