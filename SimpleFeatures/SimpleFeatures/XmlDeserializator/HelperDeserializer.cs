using System.Text;
using System.Xml.Serialization;

namespace SimpleFeatures.XmlDeserializator
{
    internal static class HelperDeserializer
    {
        public static T LoadXml<T>(string fileName) where T: class
        {
            T result = default(T);

            using (var reader = new StreamReader(fileName, Encoding.Default))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                result = serializer.Deserialize(reader) as T;
            }

            return result;
        }
    }
}