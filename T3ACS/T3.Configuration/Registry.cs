using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3.Configuration
{
    public class Registry
    {
        public static string KeyName = @"SOFTWARE\T3";

        #region SaveValue
        public static void SaveValue(string Name, string Value)
        {
            try
            {
                Microsoft.Win32.RegistryKey regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(KeyName);
                if (regKey != null)
                {
                    byte[] bValues = StringToBytes(Value);
                    regKey.SetValue(Name, bValues);
                }
            }
            catch
            {
            }
        }
        #endregion SaveValue

        #region LoadValue
        public static string LoadValue(string Name)
        {

            try
            {
                object sValue = null;

                string[] arr = KeyName.Split(System.Convert.ToChar(@"\"));
                Microsoft.Win32.RegistryKey regKey = null;
                string key = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    key += @"\" + arr[i].Trim();
                    regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key.Substring(1));
                }

                if (regKey != null)
                {
                    sValue = regKey.GetValue(Name, "");
                }
                if (sValue != null)
                {
                    //byte[] bValues = (byte[])sValue;
                    //UTF8Encoding pUTF8Encoding = new UTF8Encoding();
                    //sValue = pUTF8Encoding.GetString(bValues);
                    //return sValue.ToString();
                    return BytesToString((byte[])sValue);
                }
                else return "";
            }
            catch
            {
                return "";
            }
        }

        public static string LoadValue(string Name, string Root)
        {
            //if (!Tumiki.License.Main.CheckLicense()) return "";
            try
            {
                object sValue = null;

                string[] arr = Root.Split(System.Convert.ToChar(@"\"));
                Microsoft.Win32.RegistryKey regKey = null;
                string key = "";
                for (int i = 0; i < arr.Length; i++)
                {
                    key += @"\" + arr[i].Trim();
                    regKey = Microsoft.Win32.Registry.CurrentUser.CreateSubKey(key.Substring(1));
                }

                if (regKey != null)
                {
                    sValue = regKey.GetValue(Name, "");
                }
                if (sValue != null)
                {
                    return BytesToString((byte[])sValue);
                }
                else return "";
            }
            catch
            {
                return "";
            }
        }
        #endregion LoadValue

        #region Encode
        public static byte[] StringToBytes(string Value)
        {
            //if (!Tumiki.License.Main.CheckLicense()) return null;
            UTF8Encoding pUTF8Encoding = new UTF8Encoding();
            byte[] bValues = pUTF8Encoding.GetBytes(Value);
            return bValues;
        }

        public static string BytesToString(byte[] Values)
        {
            //if (!Tumiki.License.Main.CheckLicense()) return "";
            UTF8Encoding pUTF8Encoding = new UTF8Encoding();
            string sValue = pUTF8Encoding.GetString(Values);
            return sValue.ToString();
        }
        #endregion Encode
    }
}
