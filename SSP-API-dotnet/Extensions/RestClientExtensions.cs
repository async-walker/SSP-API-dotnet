using RestSharp;
using Serilog;

namespace SSP_API.Extensions
{
    internal static class RestClientExtensions
    {
        public static async Task<RestResponse> GetResponseAsync(
            this IRestClient client, 
            RestRequest request)
        {
            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessStatusCode)
            {
                Log.Warning("Запрос на адрес [{0}] ответил неуспешным статусным кодом {1}", 
                    request.Resource, response.StatusCode);

                if (response.RawBytes is not null)
                    return response;
                else if (response.Content is not null)
                    return response;
                else
                    throw new ArgumentNullException(
                        paramName: nameof(response.Content),
                        message: $"Ответ неуспешен ({response.StatusCode})");
            }

            return response;
        }
    }
}
