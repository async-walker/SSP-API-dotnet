using System.Text;

namespace SSP_API.Extensions
{
    internal static class StreamExtensions
    {
        public static string GetStringFromMemoryStream(this MemoryStream stream)
        {
            var byteData = stream.ToArray();

            var requestData = Encoding.UTF8.GetString(byteData);

            return requestData;
        }
    }
}
