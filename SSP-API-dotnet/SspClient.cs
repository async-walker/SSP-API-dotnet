using CryptoPro.Adapter.CryptCP;
using CryptoPro.Adapter.CryptCP.Types;
using RestSharp;
using SSP_API.Extensions;
using SSP_API.Types.Xsd;
using System.Text;

namespace SSP_API
{
    /// <summary>
    /// Реализация интерфейса клиента
    /// </summary>
    public class SspClient : ISspClient, IDisposable
    {
        readonly RestClient _client;
        readonly ICryptCP _cryptCP;

        /// <summary>
        /// Инициализация экземпляра <see cref="SspClient"/>
        /// </summary>
        /// <param name="options"></param>
        /// <param name="cryptCP"></param>
        public SspClient(SspClientOptions options, ICryptCP cryptCP)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var restOptions = new RestClientOptions(options.ApiAddress)
            {
                ClientCertificates = options.ClientCertificates,
                UserAgent = "SspClient"
            };

            _client = new RestClient(restOptions);
            _cryptCP = cryptCP;
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public async Task<SspInfo> GetAnswerAsync(
            string answerId,
            string directoryToSaveFiles,
            CriteriasSearchCertificates delSignCriterias)
        {
            var request = new RestRequest("dlanswer", Method.Get)
                .AddQueryParameter("id", answerId);

            var response = await _client.GetResponseAsync(request);

            var unsignedContent = await _cryptCP.DelSignAsync(
                criterias: delSignCriterias,
                data: response.Content!,
                directoryToSaveFiles);

            var sspInfo = Encoding.Default
                .GetString(unsignedContent)
                .DeserializeXml<SspInfo>();

            return sspInfo;
        }

        /// <inheritdoc/>
        public async Task<RequestResult> SendRequestAsync(
            SspRequest sspRequest,
            string directoryToSaveFiles,
            CriteriasSearchCertificates signCriterias,
            CriteriasSearchCertificates delSignCriterias)
        {
            var xml = sspRequest.ConvertToXml();

            var signedData = await _cryptCP.SignDataAsync(
                criterias: signCriterias,
                data: xml,
                directoryToSaveFiles);

            var request = new RestRequest("dlrequest", Method.Post)
                .AddBody(signedData, ContentType.Xml);

            var response = await _client.GetResponseAsync(request);

            var unsignedContent = await _cryptCP.DelSignAsync(
                criterias: delSignCriterias,
                data: response.Content!,
                directoryToSaveFiles);

            var requestResult = Encoding.Default
                .GetString(unsignedContent)
                .DeserializeXml<RequestResult>();

            return requestResult;
        }
    }
}
