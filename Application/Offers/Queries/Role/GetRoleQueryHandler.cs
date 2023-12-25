using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Queries.Role
{
    public class GetRoleQueryHandler : IRequestHandler<GetRoleQueryRequest, List<RoleDto>>
    {
        private readonly IMapper mapper;
        private readonly IRoleRepository roleRepository;

        public GetRoleQueryHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            this.mapper = mapper;
            this.roleRepository = roleRepository;
        }

        public async Task<List<RoleDto>> Handle(GetRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var roles = await roleRepository.GetAllAsync();

            return mapper.Map<List<RoleDto>>(roles);
        }
    }
}
