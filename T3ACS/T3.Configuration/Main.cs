using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3.Configuration
{
    public class Main
    {
        public static string Permission;
        public static string ConnectionStringSQLite;
        public static string KeyLicense;
        public static string NameControlClick;
        public static string FormNames;
        public static bool Simulation;
        public static Color backColorBody;
        public static Color backColorTitle;
        public static Color forceColorText;
        public static Color forceColorTitle;
        public static Color forceColorPlaceholdText;
        public static string fontLable;
        public static string fontTitle;
        public static string fontTitleCard;
        public static string fonttext;
        public static string fontHuge;
        public static void LoadVariablesFromRegistry()
        {
            KeyLicense = "AKLYG-G157T-L46ZY-D158S-NRU45";
            // link dblite
            ConnectionStringSQLite = Registry.LoadValue("linkDBSQLite");
            if (string.IsNullOrEmpty(ConnectionStringSQLite))
                ConnectionStringSQLite = AppDomain.CurrentDomain.BaseDirectory + "\\T3.db";
         
        }
        public static void LoadThemeDefault()
        {
            // loadTheme
            backColorBody = Color.White;
            backColorTitle = Color.White;
            forceColorText = Color.FromArgb(0, 32, 77);
            forceColorTitle = Color.FromArgb(0, 32, 77);
            forceColorPlaceholdText = Color.FromArgb(153, 166, 184);
            fontLable = "Segoe UI Semibold, 10.5pt, style=Bold";
            fontHuge = "Segoe UI Variable Text, 15pt, style=Bold";
            fontTitleCard = "Segoe UI Variable Display Semib, 12pt, style=Bold";
            fonttext = "Segoe UI Variable Text, 10.5pt";
            fontTitle = "Segoe UI Semibold, 12pt, style=Bold";
        }

    }
}
