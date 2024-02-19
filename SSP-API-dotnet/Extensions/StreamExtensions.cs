using System.Text;

namespace SSP_API.Extensions
{
    internal static class StreamExtensions
    {
        public static string GetString(this MemoryStream stream)
        {
            var byteData = stream.ToArray();

            var requestData = Encoding.UTF8.GetString(byteData);

            return requestData;
        }

        public static byte[] GetBytes(this Stream stream)
        {
            byte[] bytes;

            using (var binaryReader = new BinaryReader(stream))
                bytes = binaryReader.ReadBytes((int)stream.Length);

            return bytes;
        }
    }
}
