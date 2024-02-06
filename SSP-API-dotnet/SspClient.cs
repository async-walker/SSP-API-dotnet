using RestSharp;
using RestSharp.Authenticators;
using SSP_API.Extensions;
using SSP_API.Types.Xsd;

namespace SSP_API
{
    /// <summary>
    /// Реализация интерфейса клиента
    /// </summary>
    public class SspClient : ISspClient, IDisposable
    {
        readonly RestClient _client = default!;

        /// <summary>
        /// Инициализация <see cref="SspClient"/>
        /// </summary>
        /// <param name="options"></param>
        public SspClient(SspClientOptions options)
        {
            var restOptions = new RestClientOptions(options.ApiAddress)
            {
                Authenticator = new HttpBasicAuthenticator(
                    username: options.Credential.UserName,
                    password: options.Credential.Password),
                ClientCertificates = options.ClientCertificates,
                UserAgent = "SspClient"
            };

            _client = new RestClient(restOptions);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

        /// <inheritdoc/>
        public async Task<SspInfo> GetAnswerAsync(string answerId)
        {
            var request = new RestRequest("dlanswer", Method.Get)
                .AddQueryParameter("id", answerId);

            var response = await _client.GetResponseAsync(request);

            var sspInfo = response.Content!.DeserializeXml<SspInfo>();

            return sspInfo;
        }

        /// <inheritdoc/>
        public async Task<RequestResult> SendRequestAsync(SspRequest sspRequest)
        {
            var request = new RestRequest("dlrequest", Method.Post)
                .AddXmlBody(sspRequest);

            var response = await _client.GetResponseAsync(request);

            var requestResult = response.Content!.DeserializeXml<RequestResult>();

            return requestResult;
        }
    }
}
