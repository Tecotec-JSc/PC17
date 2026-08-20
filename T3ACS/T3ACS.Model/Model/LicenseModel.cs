using T3.Configuration;
using T3ACS.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace T3ACS.Model
{
    public class LicenseModel : ILicenseModel
    {
        public LicenseModel() { }
        public bool CheckKeyLicense()
        {
            var needCheck = true;
            var filePath = AppDomain.CurrentDomain.BaseDirectory + "Configuration.xml";
            if (File.Exists(filePath))
            {
                ConfigurationViewModel config;

                var serializer = new XmlSerializer(typeof(ConfigurationViewModel));
                using (var reader = new StreamReader(filePath))
                {
                    config = (ConfigurationViewModel)serializer.Deserialize(reader);
                }
                if (config.IsFirst)
                {
                    needCheck = false;
                }
            }
            if(needCheck)
            {
                string value = Registry.LoadValue("KeyLicenseT3ACS");
                if (value != Main.KeyLicense)
                {
                    return false;
                }
                else return true;
            }
            return false;
        }
        public bool SaveKeyLicense(string key)
        {
            try
            {
                if (key == Main.KeyLicense)
                {
                    Registry.SaveValue("KeyLicenseT3ACS", Main.KeyLicense);
                    //
                    var needCheck = true;
                    var filePath = AppDomain.CurrentDomain.BaseDirectory + "Configuration.xml";
                    var serializer = new XmlSerializer(typeof(ConfigurationViewModel));
                    ConfigurationViewModel config = new ConfigurationViewModel();
                    if (File.Exists(filePath))
                    {
                      
                        using (var reader = new StreamReader(filePath))
                        {
                            config = (ConfigurationViewModel)serializer.Deserialize(reader);
                        }
                    }
                    config.IsFirst = false;
                    using (var writer = new StreamWriter(filePath))
                    {
                        serializer.Serialize(writer, config);
                    }
                    return true;
                }
                return false;
            }
            catch
            {
                return false ;
            }
         
        }
            
    }
}
