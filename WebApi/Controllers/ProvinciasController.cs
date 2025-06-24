using Application.DTO;
using Application.Features.UseCases.Provincias.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Tags("Provincias")]
    [Route("api/provincias")]
    [ApiExplorerSettings(GroupName = "candidaturas")]
    [ApiController]
    public class ProvinciasController : Controller
    {
        private readonly ISender _sender;
        public ProvinciasController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ProvinciasDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProvincias()
        {
            return Ok(await _sender.Send(new ListarTodasProvinciasQuery()));
        }
    }
}
