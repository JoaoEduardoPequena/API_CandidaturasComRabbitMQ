using Application.DTO;
using MediatR;

namespace Application.Features.UseCases.Categoria.Query
{
    public record ListarTodasCategoriasQuery: IRequest<List<CategoriaDTO>>;
    
}
