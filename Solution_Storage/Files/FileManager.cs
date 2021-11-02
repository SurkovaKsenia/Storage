using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;

namespace Files
{
    public class FileManager
    {
        public static void SaveToJson(string fileName, Dictionary<string, long> Locations)
        {
            File.WriteAllText(fileName, JsonConvert.SerializeObject(Locations));
            
        }

        public static void LoadFromJson(string fileName, Dictionary<string,long> Locations)
        {
            Locations.Clear();
            JsonTextReader reader = new JsonTextReader(new StreamReader(fileName));
            reader.SupportMultipleContent = true;
            while (true)
            {
                if (!reader.Read()) break;

                JsonSerializer serializer = new JsonSerializer();

                Dictionary <string,string> loc = serializer.Deserialize<Dictionary<string, string>>(reader);

                foreach (var l in loc)
                {
                    Console.WriteLine(l.Key+ " "+l.Value);
                    Locations.Add(l.Key, Convert.ToInt64(l.Value));
                }
            }  
        }

        public static void SaveToXml(string fileName, Dictionary<string,long> Locations)
        {
            XmlDocument xmlDoc = new XmlDocument();
            //создание пустого файла
            XmlDeclaration XmlDec = xmlDoc.CreateXmlDeclaration("1.0", "utf-8", null);
            xmlDoc.AppendChild(XmlDec);
            XmlElement Element = xmlDoc.CreateElement("database");
            xmlDoc.AppendChild(Element);
            xmlDoc.Save(fileName);

            foreach (var loc in Locations)
            {
                //запись данных в созданный файл
                    xmlDoc.Load(fileName);
                    XmlElement elem = xmlDoc.CreateElement("StorageLocation");
                    XmlAttribute attribute = xmlDoc.CreateAttribute("location");
                    XmlElement barelem = xmlDoc.CreateElement("barcode");

                    XmlElement xmlRoot = xmlDoc.DocumentElement;

                    XmlText textelem = xmlDoc.CreateTextNode(loc.Key);
                    XmlText textbarelem = xmlDoc.CreateTextNode(Convert.ToString(loc.Value));

                    attribute.AppendChild(textelem);
                    barelem.AppendChild(textbarelem);

                    elem.Attributes.Append(attribute);
                    elem.AppendChild(barelem);

                    xmlRoot.AppendChild(elem);
                    xmlDoc.Save(fileName);
            }  
        }

        public static void LoadFromXml(string fileName, Dictionary<string,long> Locations)
        {
            Locations.Clear();
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(fileName);
            XmlElement element = xmldoc.DocumentElement;
            foreach (XmlNode xnode in element)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("location");
                    if (attr != null)
                    {
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            if (childnode.Name == "barcode")
                            {
                                Locations.Add(attr.Value, Convert.ToInt64(childnode.InnerText));
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
            foreach(var loc in Locations)
            {
                Console.WriteLine($"{loc.Key}-{loc.Value}");
            }
        }

        public static FileTypes? GetFileType(string extension)
        {
            switch (extension.ToLower().Trim('.'))
            {
                case "xml": return FileTypes.Xml;
                case "json": return FileTypes.Json;
                default: return null;
            }
        }

        public static FileTypes? CheckFileType(string fileName)
        {
            return GetFileType(Path.GetExtension(fileName));
        }
    }
}
