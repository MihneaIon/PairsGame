using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Pairs.Models
{
   public class Serializer
    {
        public static void Serialize(Object obj, string path)
        {
            using (StreamWriter file = File.CreateText(path)) 
            {
                XmlSerializer serializer = new XmlSerializer(obj.GetType());
                serializer.Serialize(file, obj);
            }
        }

        public static T Deserialize<T>(string xmlFileName)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(T));
            FileStream file = new FileStream(xmlFileName, FileMode.OpenOrCreate);
            var entity = xmlser.Deserialize(file);
            file.Dispose();
            return (T)entity;
        }
    }
}
