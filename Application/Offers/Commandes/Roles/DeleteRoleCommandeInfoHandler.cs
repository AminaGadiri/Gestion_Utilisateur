using AutoMapper;
using Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes.Roles
{
    public class DeleteRoleCommandeInfoHandler : IRequestHandler<DeleteRoleCommandeInfoRequest, bool>
    {
        private readonly IMapper mapper;
        private readonly IRoleRepository roleRepository;
        public DeleteRoleCommandeInfoHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            this.mapper = mapper;
            this.roleRepository = roleRepository;
        }
        public async Task<bool> Handle(DeleteRoleCommandeInfoRequest request, CancellationToken cancellationToken)
        {
            var role = await roleRepository.GetByIdAsync(request.Id);
            if(role == null)
            {
                return false;
            }

            await roleRepository.DeleteAsync(request.Id);
            
            return true;



        }
    }
}
