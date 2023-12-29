using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Offers.Queries
{
    public class GetByIdRoleQueryHandler : IRequestHandler<GetByIdRoleQueryRequest, RoleDto>
    {
        private readonly IMapper mapper;
        private readonly IRoleRepository roleRepository;

        public GetByIdRoleQueryHandler(IMapper mapper, IRoleRepository roleRepository)
        {
            this.mapper = mapper;
            this.roleRepository = roleRepository;
        }

        public async Task<RoleDto> Handle(GetByIdRoleQueryRequest request, CancellationToken cancellationToken)
        {
            var role = await roleRepository.GetByIdAsync(request.Id);


            // Return DTO back to client
            return mapper.Map<RoleDto>(role);
        }
    }
}
