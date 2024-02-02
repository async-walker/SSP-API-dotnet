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
                throw new HttpRequestException();

            if (response.Content is null)
                throw new ArgumentNullException(nameof(response.Content));

            return response;
        }
    }
}
