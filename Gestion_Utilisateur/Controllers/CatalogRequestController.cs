using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Flurl.Http;
using Domain.Models;
using MediatR;
using Application.Offers.Queries;

namespace Gestion_Utilisateur.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersionNeutral]
    [ApiController]
    public class CatalogRequestController : ControllerBase
    {
       
        private readonly IMediator mediator;
        public CatalogRequestController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Catalogue>>> GetCatalogRequest()
        {
            //try
            //{
                var query = new GetAllCatalogRequestQueryRequest();
                var result = await mediator.Send(query);
                return Ok(result);
            //}
            //catch (FlurlHttpException ex)
            //{
            //    return StatusCode((int)ex.Call.Response.StatusCode, ex.Message);
            //}
        }
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<ActionResult<IEnumerable<Catalogue>>> GetCatalogRequestById([FromRoute] Guid id)
        {
            //try
            //{
                var query = new GetByIdCatalogRequestQueryRequest(id);
                var result = await mediator.Send(query);
                return Ok(result);
            //}
            //catch (FlurlHttpException ex)
            //{
            //    return StatusCode((int)ex.Call.Response.StatusCode, ex.Message);
            //}
        }
    }
}
