using CryptoPro.Adapter.CryptCP;
using CryptoPro.Adapter.CryptCP.Types;
using System.Text;

namespace SSP_API.Extensions
{
    internal static class CryptoProExtensions
    {
        public static async Task<byte[]> SignDataAsync(
            this ICryptCP cryptCP, 
            CriteriasSearchCertificates criterias, 
            string data, 
            string directoryToSaveFiles,
            string fileName)
        {
            var sspReqFile = Path.Combine(
                directoryToSaveFiles, fileName);

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

        public static async Task<byte[]> VerifySignAsync(
            this ICryptCP cryptCP,
            CriteriasSearchCertificates criterias,
            byte[] data,
            string directoryToSaveFiles,
            string fileName)
        {
            var receivedFilePath = Path.Combine(
                directoryToSaveFiles, fileName);

            using (var recievedFile = new FileStream(
                path: receivedFilePath,
                mode: FileMode.Create))
            {
                await recievedFile.WriteAsync(data);
            }

            var unsignedFilePath = Path.Combine(
                directoryToSaveFiles, Path.ChangeExtension(
                    path: fileName,
                    extension: string.Empty));

            await cryptCP.VerifyMessageSignature(
                criterias,
                sourceFilePath: receivedFilePath,
                destinationFilePath: unsignedFilePath);

            using var unsignedFile = new FileStream(
                path: unsignedFilePath, 
                mode: FileMode.Open);

            return unsignedFile.GetBytes();
        }
    }
}
