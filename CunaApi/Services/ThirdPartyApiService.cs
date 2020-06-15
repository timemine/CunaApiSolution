using CunaApi.Interfaces;
using CunaApi.Models;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CunaApi.Services
{
    /// <summary>
    /// Facilitates communication with third-party service.
    /// </summary>
    public class ThirdPartyApiService : IThirdPartyApiService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        // By injecting the client factory this class remains unit testable
        public ThirdPartyApiService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public Task InitiateRequestAsync(RequestCallback callback)
        {
            var httpClient = _httpClientFactory.CreateClient(Constants.ThirdPartyClientName);

            var jsonBody = new StringContent(JsonSerializer.Serialize(callback), Encoding.UTF8, "application/json");

            // Would use Polly to implement a retry patttern like below. 
            // Commented it out because the endpoint specified returns a 405 so we would keep getting an exception 

            //var maxRetryAttempts = 3;
            //var pauseBetweenFailures = TimeSpan.FromSeconds(2);

            //var retryPolicy = Policy
            //                    .Handle<HttpRequestException>()
            //                    .WaitAndRetryAsync(maxRetryAttempts, i => pauseBetweenFailures);

            //await retryPolicy.ExecuteAsync(async () =>
            //{
            //    var response = await httpClient.PostAsync(Constants.ThirdPartyUrl, jsonBody);
            //    // Throws an exception if theIsSuccessStatusCode is false
            //    response.EnsureSuccessStatusCode();
            //});

            // Just returning successful task for this exercise
            return Task.FromResult<object>(null);
        }
    }
}
