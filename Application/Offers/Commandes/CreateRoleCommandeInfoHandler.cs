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
    public class CreateRoleCommandeInfoHandler : IRequestHandler<CreateRoleCommandeInfoRequest, RoleDto>
    {
        private readonly IMapper mapper;
        private readonly IRoleRepository roleRepository;

        public CreateRoleCommandeInfoHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            this.mapper = mapper;
            this.roleRepository = roleRepository;
        }
        public async Task<RoleDto> Handle(CreateRoleCommandeInfoRequest request, CancellationToken cancellationToken)
        {
            var role = mapper.Map<Role>(request.RoleRequest);


            await roleRepository.CreateAsync(role);

            return mapper.Map<RoleDto>(role);
        }
    }
}
