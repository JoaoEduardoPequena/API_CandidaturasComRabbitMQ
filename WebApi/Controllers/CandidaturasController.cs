using Application.Features.UseCases.Candidaturas.Command.CriarCandidaturas;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Tags("Candidaturas")]
    [Route("api/candidaturas")]
    [ApiExplorerSettings(GroupName = "candidaturas")]
    [ApiController]
    public class CandidaturasController : Controller
    {
        private readonly ISender _sender;
        public CandidaturasController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        public async Task<IActionResult> EnviarCandidaturas(CriarCandidaturasCommand request)
        {
            return Ok(await _sender.Send(request));
        }
    }
}
