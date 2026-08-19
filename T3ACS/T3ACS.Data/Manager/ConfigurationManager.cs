using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T3ACS.Data.Manager
{
    public class ConfigurationManager
    {
        SQLiteDataBase _sqlite;
        public ConfigurationManager()
        {
            _sqlite = new SQLiteDataBase();
        }
        
    }

}

