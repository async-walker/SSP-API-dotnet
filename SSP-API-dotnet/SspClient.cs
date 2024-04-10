using GostCryptography.Client;
using RestSharp;
using SSP_API.Extensions;
using SSP_API.Helpers;
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
        private readonly IGostCryptographyClient _gostCryptographyClient;
        private readonly RestClient _sspClient;
        
        /// <summary>
        /// Инициализация экземпляра <see cref="SspClient"/>
        /// </summary>
        /// <param name="options">Экземпляр <see cref="SspClientOptions"/> с настройками клиента</param>
        /// <param name="gostCryptographyAPI">Адрес REST сервиса</param>
        public SspClient(SspClientOptions options, string gostCryptographyAPI)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var restOptions = new RestClientOptions(options.ApiAddress)
            {
                ClientCertificates = options.ClientCertificates,
                UserAgent = "SspClient"
            };

            _sspClient = new RestClient(restOptions);
            _gostCryptographyClient = new GostCryptographyClient(
                new GostCryptographyOptions(gostCryptographyAPI));
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

            var responseAnswerPath = Path.Combine(directoryToSaveFiles, "qcb_answer.xml.p7s");

            using (var fs = new FileStream(
                path: responseAnswerPath,
                FileMode.Create))
                await fs.WriteAsync(signedMessage);

            var unsignedMessage = await _gostCryptographyClient.VerifySignCMS(
                message: signedMessage);

            var unsignedMessagePath = Path.Combine(directoryToSaveFiles, "qcb_answer.xml");

            using (var fs = new FileStream(
                path: unsignedMessagePath,
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
            string signerSubjectName)
        {
            var xml = sspRequest.ConvertToXml();

            var requestMessagePath = Path.Combine(directoryToSaveFiles, "qcb_request.xml");

            using (var fs = new FileStream(
                path: requestMessagePath,
                FileMode.Create))
                await fs.WriteAsync(Encoding.UTF8.GetBytes(xml));

            var signedMessage = await _gostCryptographyClient.SignMessageCMS(
                message: Encoding.UTF8.GetBytes(xml),
                signerSubjectName,
                StoreLocation.CurrentUser,
                StoreName.My);

            using (var fs = new FileStream(
                path: Path.Combine(directoryToSaveFiles, "qcb_request.xml.p7s"),
                FileMode.Create))
                await fs.WriteAsync(signedMessage);

            var request = new RestRequest("dlrequest", Method.Post)
                    .AddBody(signedMessage, ContentType.Xml);

            var response = await _sspClient.GetResponseAsync(request);

            var responseAnswerPath = Path.Combine(directoryToSaveFiles, "qcb_result.xml.p7s");

            using (var fs = new FileStream(
                path: responseAnswerPath,
                FileMode.Create))
                await fs.WriteAsync(response.RawBytes);

            var unsignedMessage = await _gostCryptographyClient.VerifySignCMS(
                message: response.RawBytes!);

            var requestResult = Encoding.Default
                .GetString(unsignedMessage)
                .DeserializeXml<RequestResult>();

            return requestResult;
        }
    }
}
