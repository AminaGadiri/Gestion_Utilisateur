using Application.DTO;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.DB;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Utilisateur.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersionNeutral]
    [ApiController]
    public class UtilisateurController : ControllerBase
    {
        private readonly BiblioDBContext context;
        private readonly IUtilisateurRepository utilisateurRepository;
        private readonly IMapper mapper;

        public UtilisateurController(BiblioDBContext context, IUtilisateurRepository utilisateurRepository, IMapper mapper)
        {
            this.context = context;
            this.utilisateurRepository = utilisateurRepository;
            this.mapper = mapper;
        }
        [HttpGet]
       
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var utilisateur = await utilisateurRepository.GetAllAsync();

            // Return DTOs
            return Ok(mapper.Map<List<UtilisateurDto>>(utilisateur));
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var utilisateur = await utilisateurRepository.GetByIdAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<UtilisateurDto>(utilisateur));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UtilisateurDto utilisateurDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map or Convert DTO to Domain Model
            var utilisateur = mapper.Map<Utilisateur>(utilisateurDto);

            // Use Domain Model to create Utilisateur
            utilisateur = await utilisateurRepository.CreateAsync(utilisateur);

            // Map Domain model back to DTO
            var utilisateurdto = mapper.Map<UtilisateurDto>(utilisateur);

            // Return Created status along with the created resource
            return Ok(utilisateurdto);


        }

        [HttpPut]
        [Route("{id:Guid}")]

       
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UtilisateurDto utilisateurDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var utilisateur = await utilisateurRepository.GetByIdAsync(id);

            mapper.Map(utilisateurDto, utilisateur);
            utilisateurRepository.UpdateAsync(utilisateur);
            //await utilisateurRepository.SaveAsync();
            return Ok(utilisateur);

        }
        [HttpDelete]
        [Route("{id:Guid}")]


        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var utilisateur = await utilisateurRepository.DeleteAsync(id);

            if (utilisateur == null)
            {
                return NotFound();
            }

            return Ok("done");
        }
    }
}
