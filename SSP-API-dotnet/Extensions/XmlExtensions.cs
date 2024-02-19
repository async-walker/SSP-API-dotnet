using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace SSP_API.Extensions
{
    internal static class XmlExtensions
    {
        public static string SerializeToXml<T>(this T element)
        {
            using var ms = new MemoryStream();

            var xmlSerializer = new XmlSerializer(typeof(T));

            xmlSerializer.Serialize(ms, element);

            var data = ms.GetString();

            return data;
        }

        public static T DeserializeXml<T>(this string xml)
        {
            using var sr = new StringReader(xml);

            var xmlSerializer = new XmlSerializer(typeof(T));

            var schemaModel = xmlSerializer.Deserialize(sr);

            return (T)schemaModel!;
        }

        public static bool Validate(this XmlSchemaSet schemaSet, string xmlData)
        {
            try
            {
                var xDoc = XDocument.Parse(xmlData);

                xDoc.Validate(schemaSet, ValidationEventHandler);
            }
            catch (XmlSchemaValidationException ex)
            {
                Console.WriteLine(ex.Message);

                return false;
            }

            return true;
        }

        public static void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    throw new XmlSchemaValidationException($"Error schema: {e.Message}");
                case XmlSeverityType.Warning:
                    throw new XmlSchemaValidationException($"Warning schema: {e.Message}");
            }
        }
    }
}
