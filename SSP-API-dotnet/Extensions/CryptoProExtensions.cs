using CryptoPro.Adapter.CryptCP;
using System.Text;

namespace SSP_API.Extensions
{
    internal static class CryptoProExtensions
    {
        public static async Task<byte[]> SignDataAsync(
            this ICryptCP cryptCP, 
            CriteriasSearchCertificate criterias, 
            string data, 
            string directoryToSaveFiles)
        {
            var sspReqFile = $@"{directoryToSaveFiles}\qcb_request.xml";

            using (var xmlFile = new FileStream(
                path: sspReqFile,
                mode: FileMode.Create))
            {
                var bytes = Encoding.Default.GetBytes(data);

                await xmlFile.WriteAsync(bytes);
            }

            var signFilePath = await cryptCP.SignDataCreateMessage(
                criterias: criterias,
                der: true,
                directoryToSave: directoryToSaveFiles,
                sourceFilePath: sspReqFile);

            using var signedFile = new FileStream(
                path: signFilePath,
                mode: FileMode.Open);

            return signedFile.GetBytes();
        }

        public static async Task<byte[]> DelSignAsync(
            this ICryptCP cryptCP,
            CriteriasSearchCertificate criterias,
            string data,
            string directoryToSaveFiles)
        {
            var receivedFilePath = $@"{directoryToSaveFiles}\response.xml.sig";

            using (var sw = new StreamWriter(
                path: receivedFilePath,
                append: false,
                encoding: Encoding.Default))
            {
                await sw.WriteAsync(data);
            }

            //using (var responsedFile = new FileStream(
            //    path: receivedFilePath,
            //    mode: FileMode.Create))
            //{
            //    var bytes = Encoding.Default.GetBytes(data);

            //    await responsedFile.WriteAsync(bytes);
            //}

            var unsignedFilePath = cryptCP.DeleteSiganture();

            return [];
        }
    }
}
