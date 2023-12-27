using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly;
using RestSharp;

namespace Gestion_Utilisateur.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersionNeutral]
    [ApiController]
    public class RetryPolicyController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var retryPolicy = Policy
                .Handle<Exception>()
                .RetryAsync(5, onRetry: (exception, retryCount) =>
                {
                    Console.WriteLine("Error:" + exception.Message + "...Retry Count" + retryCount);
                });

            await retryPolicy.ExecuteAsync(async () =>
            {
                await ConnectToAPI();
            });

            return Ok();

        }

        private async Task ConnectToAPI()
        {
            var url = "https://matchilling-chuck-norris-jokes-v1.p.rapidapi.com/jokes/random";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("accept", "application/json");

            request.AddHeader("X-RapidAPI-Key", "eb2e095abemsh7be5bcc8cd5856ap162a53jsndec0e5c82b29");

            request.AddHeader("X-RapidAPI-Host", "matchilling-chuck-norris-jokes-v1.p.rapidapi.com");

            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                Console.WriteLine(response.Content);
            }
            else
            {
                Console.WriteLine(response.ErrorMessage);
                throw new Exception("Not able to connect to the service");
            }
        }
    }
}
