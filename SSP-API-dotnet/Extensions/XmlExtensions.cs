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

            var data = ms.GetStringFromMemoryStream();

            return data;
        }
    }
}
