using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Health
{
    public class ApiHealthCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
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
                return Task.FromResult(HealthCheckResult.Healthy());
            }
            else
            {
                return Task.FromResult(HealthCheckResult.Unhealthy());
            }
        }
    }
}
