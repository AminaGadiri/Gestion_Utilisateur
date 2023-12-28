using AutoMapper;
using Gestion_Catalogue1.DTO;
using Gestion_Catalogue1.Model;
using Gestion_Catalogue1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Catalogue1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private readonly CatalogueDbContext context;
        private readonly ICatalogueRepository catalogueRepository;
        private readonly IMapper mapper;

        public CatalogueController(CatalogueDbContext context, ICatalogueRepository catalogueRepository, IMapper mapper)
        {
            this.context = context;
            this.catalogueRepository = catalogueRepository;
            this.mapper = mapper;
        }
        [HttpGet]

        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain models
            var catalogue = await catalogueRepository.GetAllAsync();

            // Return DTOs
            return Ok(mapper.Map<List<CatalogueDto>>(catalogue));
        }

        [HttpGet]
        [Route("{id:Guid}")]

        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {

            var catalogue = await catalogueRepository.GetByIdAsync(id);

            if (catalogue == null)
            {
                return NotFound();
            }

            // Return DTO back to client
            return Ok(mapper.Map<CatalogueDto>(catalogue));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CatalogueDto catalogueDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map or Convert DTO to Domain Model
            var catalogue = mapper.Map<Catalogue>(catalogueDto);

            // Use Domain Model to create Utilisateur
            catalogue = await catalogueRepository.CreateAsync(catalogue);

            // Map Domain model back to DTO
            var cataloguedto = mapper.Map<CatalogueDto>(catalogue);

            // Return Created status along with the created resource
            return Ok(cataloguedto);


        }
        [HttpPut]
        [Route("{id:Guid}")]


        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CatalogueDto catalogueDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var catalogue = await catalogueRepository.GetByIdAsync(id);

            mapper.Map(catalogueDto, catalogue);
            catalogueRepository.UpdateAsync(catalogue);
            //await utilisateurRepository.SaveAsync();
            return Ok(catalogue);

        }
        [HttpDelete]
        [Route("{id:Guid}")]


        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var catalogue = await catalogueRepository.DeleteAsync(id);

            if (catalogue == null)
            {
                return NotFound();
            }

            return Ok("done");
        }
    }
}
