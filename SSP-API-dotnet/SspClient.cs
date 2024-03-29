using Client;
using RestSharp;
using SSP_API.Extensions;
using SSP_API.Types.Xsd;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace SSP_API
{
    /// <summary>
    /// Реализация интерфейса клиента
    /// </summary>
    public class SspClient : ISspClient, IDisposable
    {
        private readonly RestClient _sspClient;
        private readonly ICryptoGostClient _cryptoGostClient;

        /// <summary>
        /// Инициализация экземпляра <see cref="SspClient"/>
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cryptoGostApiAddress"></param>
        public SspClient(SspClientOptions options, string cryptoGostApiAddress)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var restOptions = new RestClientOptions(options.ApiAddress)
            {
                ClientCertificates = options.ClientCertificates,
                UserAgent = "SspClient"
            };

            _sspClient = new RestClient(restOptions);
            _cryptoGostClient = new CryptoGostClient(cryptoGostApiAddress);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _sspClient?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public async Task<SspInfo> GetAnswerAsync(string answerId, string directoryToSaveFiles)
        {
            var request = new RestRequest("dlanswer", Method.Get)
                .AddQueryParameter("id", answerId);

            var response = await _sspClient.GetResponseAsync(request);

            var signedMessage = response.RawBytes!;

            using (var fs = new FileStream(
                path: Path.Combine(directoryToSaveFiles, "qcb_answer.xml.p7s"),
                FileMode.Create))
                await fs.WriteAsync(signedMessage);

            var unsignedMessage = await _cryptoGostClient.VerifySignCMS(signedMessage);

            using (var fs = new FileStream(
                path: Path.Combine(directoryToSaveFiles, "qcb_answer.xml"),
                FileMode.Create))
                await fs.WriteAsync(unsignedMessage);

            var sspInfo = Encoding.Default
                .GetString(unsignedMessage)
                .DeserializeXml<SspInfo>();

            return sspInfo;
        }

        /// <inheritdoc/>
        public async Task<RequestResult> SendRequestAsync(
            SspRequest sspRequest,
            string directoryToSaveFiles,
            string thumbprint,
            StoreName storeName = StoreName.My,
            StoreLocation storeLocation = StoreLocation.CurrentUser)
        {
            var xml = sspRequest.ConvertToXml();

            using (var fs = new FileStream(
                path: Path.Combine(directoryToSaveFiles, "qcb_request.xml"),
                FileMode.Create))
                await fs.WriteAsync(Encoding.UTF8.GetBytes(xml));

            var xmlData = Encoding.UTF8.GetBytes(xml);

            var signedData = await _cryptoGostClient.SignMessageCMS(
                message: xmlData,
                thumbprint: thumbprint,
                storeName,
                storeLocation);

            using (var fs = new FileStream(
                path: Path.Combine(directoryToSaveFiles, "qcb_request.xml.p7s"),
                FileMode.Create))
                await fs.WriteAsync(signedData);

            var request = new RestRequest("dlrequest", Method.Post)
                .AddBody(signedData, ContentType.Xml);

            var response = await _sspClient.GetResponseAsync(request);

            using (var fs = new FileStream(
                path: Path.Combine(directoryToSaveFiles, "qcb_result.xml.p7s"),
                FileMode.Create))
                await fs.WriteAsync(response.RawBytes);

            var unsignedContent = await _cryptoGostClient.VerifySignCMS(response.RawBytes!);

            using (var fs = new FileStream(
                path: Path.Combine(directoryToSaveFiles, "qcb_result.xml"),
                FileMode.Create))
                await fs.WriteAsync(unsignedContent);

            var requestResult = Encoding.Default
                .GetString(unsignedContent)
                .DeserializeXml<RequestResult>();

            return requestResult;
        }
    }
}
