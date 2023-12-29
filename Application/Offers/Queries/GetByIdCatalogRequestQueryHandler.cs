using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace Application.Offers.Queries
{
    public class GetByIdCatalogRequestQueryHandler : IRequestHandler<GetByIdCatalogRequestQueryRequest, Catalogue>
    {
        private readonly string apiUrl = "https://localhost:7024/api/Catalogue";
        
        public async Task<Catalogue> Handle(GetByIdCatalogRequestQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await apiUrl
                   .AppendPathSegment($"/{request.Id}")
                   .GetJsonAsync<Catalogue>();

            return response;
        }
    }
}
