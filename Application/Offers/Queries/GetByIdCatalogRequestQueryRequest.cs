using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Queries
{
    public class GetByIdCatalogRequestQueryRequest : IRequest<Catalogue>
    {
        public Guid Id { get; }

        public GetByIdCatalogRequestQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
