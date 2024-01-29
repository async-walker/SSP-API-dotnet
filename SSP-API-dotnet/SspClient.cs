using RestSharp;
using RestSharp.Authenticators;
using SSP_API.Types;

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
                UserAgent = "SSP-API-dotnet/clientV1"
            };

            _client = new RestClient(restOptions);
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<SspInfo> GetAnswerAsync(string answerId)
        {
            var request = new RestRequest("dlanswer", Method.Get)
                .AddQueryParameter(name: "id", value: answerId);

            var response = await _client.ExecuteAsync(request);

            return new SspInfo();
        }

        public async Task<RequestResult> SendRequestAsync(RequestSspInfo sspRequest)
        {
            var request = new RestRequest("dlrequest", Method.Post)
                .AddXmlBody(sspRequest);

            var response = await _client.ExecuteAsync(request);

            return new RequestResult();
        }
    }
}
