using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Queries
{
    public class GetByIdRoleQueryRequest : IRequest<RoleDto>
    {
        public Guid Id { get; }

        public GetByIdRoleQueryRequest(Guid id)
        {
            Id = id;
        }
    }
}
