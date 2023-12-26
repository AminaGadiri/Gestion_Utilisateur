using Application.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes.Roles
{
    public class UpdateRoleCommandeInfoRequest : IRequest<bool>
    {   
        public Guid Id { get; }
        public RoleDto Role { get;  }
        public UpdateRoleCommandeInfoRequest(Guid id, RoleDto role)
        {
            Id = id;
            Role = role;
        }
        
    }
}
