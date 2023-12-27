using Application.DTO;
using Application.Offers.Commandes.Roles;
using Application.Offers.Queries.Role;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DB;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using System.Data;

namespace Gestion_Utilisateur.Controllers.v1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0", Deprecated = true)]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly BiblioDBContext context;
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;
        private readonly IMediator mediator;

        public RoleController(BiblioDBContext context, IRoleRepository roleRepository, IMapper mapper, IMediator mediator)
        {
            this.context = context;
            this.roleRepository = roleRepository;
            this.mapper = mapper;
            this.mediator = mediator;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            var query = new GetRoleQueryRequest();
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpGet]
        [Route("{id:Guid}")]
        //Rate Limit
        [EnableRateLimiting("fixedwindow")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var role = await roleRepository.GetByIdAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<RoleDto>(role));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RoleDto roleDto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var command = new CreateRoleCommandeInfoRequest(roleDto);
            var result = await mediator.Send(command);

            return Ok(result);


        }

        [HttpPut]
        [Route("{id:Guid}")]

        // [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] RoleDto roleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();



            var command = new UpdateRoleCommandeInfoRequest(id, roleDto);
            var result = await mediator.Send(command);

            return result ? NoContent() : BadRequest();

        }
        [HttpDelete]
        [Route("{id:Guid}")]


        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteRoleCommandeInfoRequest(id);
            var result = await mediator.Send(command);

            return result ? NoContent() : BadRequest();
        }


    }
}
