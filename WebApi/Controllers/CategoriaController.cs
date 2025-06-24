using Application.DTO;
using Application.Features.UseCases.Categoria.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Tags("Categoria")]
    [Route("api/categoria")]
    [ApiExplorerSettings(GroupName = "candidaturas")]
    [ApiController]
    public class CategoriaController : Controller
    {
        private readonly ISender _sender;
        public CategoriaController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriaDTO>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllCategorias()
        {
            return Ok(await _sender.Send(new ListarTodasCategoriasQuery()));
        }
    }
}
