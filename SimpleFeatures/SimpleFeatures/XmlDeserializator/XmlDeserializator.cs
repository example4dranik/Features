using System.Text;
using System.Xml.Serialization;

namespace SimpleFeatures.XmlDeserializator
{
    internal class XmlDeserializator : ISolution
    {
        public void Execute()
        {
            var fileName = SaveExampleXmlFile().Result;
            Output(DeserializeGroup(fileName));
            Output(HelperDeserializer.LoadXml<Group>(fileName));
        }

        private void Output(Group gr)
        {
            if (gr == null)
            {
                Console.WriteLine($"{nameof(Group)}: NULL");
                return;
            }

            if (gr.Employees == null)
            {
                Console.WriteLine($"{nameof(gr.Employees)}: NULL");
                return;
            }

            foreach (var em in gr.Employees)
            {
                Console.WriteLine($"{em.Name};{em.Level}");
            }
        }

        private async Task<string> SaveExampleXmlFile()
        {
            var fileName = "test.xml";

            string content = "<Group><Employees><Employee><Name>Haley</Name></Employee><Employee><Name>Ann</Name><Level>3</Level></Employee></Employees></Group>";

            await File.WriteAllTextAsync(fileName, content);

            return fileName;
        }

        private Group DeserializeGroup(string fileName)
        {
            var result = new Group();

            using (var reader = new StreamReader(fileName, Encoding.Default))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Group));
                result = (Group)serializer.Deserialize(reader);
            }

            return result;
        }
    }
}