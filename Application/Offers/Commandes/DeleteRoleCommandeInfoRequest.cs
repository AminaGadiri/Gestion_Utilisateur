using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class DeleteRoleCommandeInfoRequest : IRequest<bool>
    {
        public Guid Id { get; }

        public DeleteRoleCommandeInfoRequest(Guid id)
        {
            Id = id;
        }
    }
}
