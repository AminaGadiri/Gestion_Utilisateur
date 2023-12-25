using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Health
{
    public class UserApiCheck : IHealthCheck
    {
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            var url = "https://localhost:7011/api/Utilisateur";
            var client = new RestClient(url);
            var request = new RestRequest(url, Method.Get);
            request.AddHeader("accept", "application/json");

         

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
