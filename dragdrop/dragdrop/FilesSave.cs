using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelpers;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;
using System.Xml.Serialization;

namespace dragdrop
{
    class FilesSave
    {
        public string fileName;

        public FilesSave()
        {

        }

        public FilesSave(string FileName)
        {
            this.fileName = FileName;
        }

        public bool ReadCSVFile(List<Shape> list)
        {
            var engine = new FileHelperEngine<Shape>();

            try
            {
                var result = engine.ReadFile(fileName);

                if (result.Any())
                {
                    foreach (Shape data in result)
                    {
                        list.Add(data);
                    }

                    return true;
                }
                
            }
            catch
            {
                
            }

            return false;
        }
        public bool WriteCSVFile(List<Shape> list)
        {
            var engine = new FileHelperEngine<Shape>();

            try
            {
                engine.WriteFile(fileName, list);
                return true;
            }
            catch
            {

            }

            return false;
        }

        public bool ReadJSFile(List<Shape> list)
        {
            try
            {
                string fileString = File.ReadAllText(fileName);
                var result = JsonConvert.DeserializeObject<List<Shape>>(fileString);

                foreach (Shape data in result)
                {
                    list.Add(data);
                }

                return true;
            }
            catch
            {

            }
            return false;
        }

        public bool WriteJSFile(List<Shape> list)
        {
            try
            {
                string json = JsonConvert.SerializeObject(list);
                File.WriteAllText(fileName + ".json", json);

                return true;
            }
            catch
            {

            }

            return false;
        }

        public bool ReadXMLFile(List<Shape> list)
        {
            try
            {
                XmlSerializer xmlDoc = new XmlSerializer(list.GetType());
                list = (List<Shape>)xmlDoc.Deserialize(new StreamReader(fileName));

                return true;
            }
            catch
            {

            }

            return false;
        }

        public bool WriteXMLFile(List<Shape> list)
        {
            try
            {
                XmlSerializer xmlDoc = new XmlSerializer(list.GetType());
                xmlDoc.Serialize(new StreamWriter(fileName + ".xml"), list);

                return true;
            }
            catch
            {

            }

            return false;
        }
    }
}
