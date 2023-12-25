using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes.Roles
{
    public class CreateRoleCommandeInfoRequest : IRequest<RoleDto>
    {
        public RoleDto RoleRequest { get; }
        public CreateRoleCommandeInfoRequest(RoleDto roleRequest)
        {
            RoleRequest = roleRequest;
        }
    }
}
