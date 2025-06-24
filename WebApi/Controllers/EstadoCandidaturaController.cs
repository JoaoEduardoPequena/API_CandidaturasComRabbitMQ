using Application.DTO;
using Application.Features.UseCases.EstadoCandidaturas.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Tags("Estados Candidaturas")]
    [Route("api/estados")]
    [ApiExplorerSettings(GroupName = "candidaturas")]
    [ApiController]
    public class EstadoCandidaturaController : Controller
    {
        private readonly ISender _sender;
        public EstadoCandidaturaController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<EstadoCandidaturaDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllEstados()
        {
            return Ok(await _sender.Send(new ListarTodosEstadoCandidaturaQuery()) );
        }
    }
}
