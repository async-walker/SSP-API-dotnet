using RestSharp;
using SSP_API.Extensions;
using SSP_API.Helpers;
using SSP_API.Types.Xsd;
using System.Text;

namespace SSP_API
{
    /// <summary>
    /// Реализация интерфейса клиента
    /// </summary>
    public class SspClient : ISspClient, IDisposable
    {
        private readonly RestClient _sspClient;
        private readonly string _gostCryptographyExe;

        /// <summary>
        /// Инициализация экземпляра <see cref="SspClient"/>
        /// </summary>
        /// <param name="options">Экземпляр <see cref="SspClientOptions"/> с настройками клиента</param>
        /// <param name="gostCryptographyExe">Путь к исполняемому файлу GostCryptography</param>
        public SspClient(SspClientOptions options, string gostCryptographyExe)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var restOptions = new RestClientOptions(options.ApiAddress)
            {
                ClientCertificates = options.ClientCertificates,
                UserAgent = "SspClient"
            };

            _sspClient = new RestClient(restOptions);
            _gostCryptographyExe = gostCryptographyExe;
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

            var unsignedMessagePath = GostCryptographyHelper.VerifyMessage(
                exe: _gostCryptographyExe,
                inMessagePath: responseAnswerPath);

            var unsignedMessage = File.ReadAllBytes(unsignedMessagePath);

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

            var signedMessagePath = GostCryptographyHelper.SignMessage(
                exe: _gostCryptographyExe,
                subjectName: signerSubjectName,
                inMessagePath: requestMessagePath);

            var signedData = File.ReadAllBytes(signedMessagePath);

            var request = new RestRequest("dlrequest", Method.Post)
                .AddBody(signedData, ContentType.Xml);

            var response = await _sspClient.GetResponseAsync(request);

            var responseAnswerPath = Path.Combine(directoryToSaveFiles, "qcb_result.xml.p7s");

            using (var fs = new FileStream(
                path: responseAnswerPath,
                FileMode.Create))
                await fs.WriteAsync(response.RawBytes);

            var unsignedMessagePath = GostCryptographyHelper.VerifyMessage(
                exe: _gostCryptographyExe,
                inMessagePath: responseAnswerPath);

            var unsignedData = File.ReadAllBytes(unsignedMessagePath);

            var requestResult = Encoding.Default
                .GetString(unsignedData)
                .DeserializeXml<RequestResult>();

            return requestResult;
        }
    }
}
