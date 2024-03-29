using RestSharp;

namespace SSP_API.Extensions
{
    internal static class RestClientExtensions
    {
        public static async Task<RestResponse> GetResponseAsync(
            this RestClient client, 
            RestRequest request)
        {
            var response = await client.ExecuteAsync(request);

            if (!response.IsSuccessStatusCode)
            {
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
