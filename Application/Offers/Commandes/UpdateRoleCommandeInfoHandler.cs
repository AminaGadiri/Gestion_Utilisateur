using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Commandes
{
    public class UpdateRoleCommandeInfoHandler : IRequestHandler<UpdateRoleCommandeInfoRequest, bool>
    {
        private readonly IMapper mapper;
        private readonly IRoleRepository roleRepository;
        public UpdateRoleCommandeInfoHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            this.mapper = mapper;
            this.roleRepository = roleRepository;
        }
        public async Task<bool> Handle(UpdateRoleCommandeInfoRequest request, CancellationToken cancellationToken)
        {

            var role = await roleRepository.GetByIdAsync(request.Id);

            mapper.Map(request.Role, role);

            await roleRepository.UpdateAsync(role);
            //await roleRepository.SaveAsync();


            return true;
        }

    }
}
