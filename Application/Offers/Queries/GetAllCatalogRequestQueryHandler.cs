using Application.DTO;
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
    public class GetAllCatalogRequestQueryHandler : IRequestHandler<GetAllCatalogRequestQueryRequest, IEnumerable<Catalogue>>
    {
        private readonly string apiUrl = "https://localhost:7024/api/Catalogue";
        public async Task<IEnumerable<Catalogue>> Handle(GetAllCatalogRequestQueryRequest request, CancellationToken cancellationToken)
        {
            var response = await apiUrl
                    .GetJsonAsync<IEnumerable<Catalogue>>();
            return response;
            
        }
    }
}
