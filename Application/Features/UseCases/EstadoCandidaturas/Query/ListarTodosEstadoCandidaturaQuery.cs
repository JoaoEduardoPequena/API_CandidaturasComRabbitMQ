using Application.DTO;
using MediatR;

namespace Application.Features.UseCases.EstadoCandidaturas.Query
{
    public record ListarTodosEstadoCandidaturaQuery:IRequest<List<EstadoCandidaturaDTO>>;
    
}
