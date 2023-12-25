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

namespace Gestion_Utilisateur.Controllers
{
    [Route("api/[controller]")]
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
            var role = await roleRepository.GetByIdAsync(id);

            mapper.Map(roleDto, role);
            roleRepository.UpdateAsync(role);
            await roleRepository.SaveAsync();
            return Ok(role);

        }
        [HttpDelete]
        [Route("{id:Guid}")]

       
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var role = await roleRepository.DeleteAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok("done");
        }


    }
}
