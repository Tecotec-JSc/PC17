using System.Xml.Serialization;
using System.Xml;
using System.Reflection;

namespace T3ACS.Util
{
    public static class FileXML
    {
        public static void SaveToXml<T>(T obj, string filePath)
        {
            RemoveInvalidXmlChars(obj);

            var serializer = new XmlSerializer(typeof(T));

            var settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = System.Text.Encoding.UTF8
            };

            using (var writer = XmlWriter.Create(filePath, settings))
            {
                serializer.Serialize(writer, obj);
            }
        }
        public static void DirectoryCopy(string sourceDir, string destDir, bool copySubDirs)
        {
            if (Directory.Exists(sourceDir))
            {
                DirectoryInfo dir = new DirectoryInfo(sourceDir);
                DirectoryInfo[] dirs = dir.GetDirectories();

                Directory.CreateDirectory(destDir);

                foreach (FileInfo file in dir.GetFiles())
                    file.CopyTo(Path.Combine(destDir, file.Name), true);

                if (copySubDirs)
                    foreach (DirectoryInfo subdir in dirs)
                        DirectoryCopy(subdir.FullName, Path.Combine(destDir, subdir.Name), true);
            }
            
        }
        public static void RemoveInvalidXmlChars(object obj)
        {
            if (obj == null) return;

            Type type = obj.GetType();

            foreach (PropertyInfo prop in type.GetProperties())
            {
                if (!prop.CanRead || !prop.CanWrite)
                    continue;

                object value = prop.GetValue(obj);

                if (value == null)
                    continue;

                if (prop.PropertyType == typeof(string))
                {
                    string cleaned = new string(
                        ((string)value)
                        .Where(XmlConvert.IsXmlChar)
                        .ToArray());

                    prop.SetValue(obj, cleaned);
                }
                else if (!prop.PropertyType.IsPrimitive &&
                         prop.PropertyType != typeof(DateTime) &&
                         prop.PropertyType != typeof(decimal))
                {
                    if (value is System.Collections.IEnumerable collection &&
                        !(value is string))
                    {
                        foreach (var item in collection)
                            RemoveInvalidXmlChars(item);
                    }
                    else
                    {
                        RemoveInvalidXmlChars(value);
                    }
                }
            }
        }
    }
}
