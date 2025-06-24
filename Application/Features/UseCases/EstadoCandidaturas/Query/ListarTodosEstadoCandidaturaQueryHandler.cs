using Application.DTO;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Features.UseCases.EstadoCandidaturas.Query
{
    public record ListarTodosEstadoCandidaturaQueryHandler : IRequestHandler<ListarTodosEstadoCandidaturaQuery, List<EstadoCandidaturaDTO>>
    {
        private readonly IEstadosCandidaturaRepository _estadosCandidaturaRepository;
        public ListarTodosEstadoCandidaturaQueryHandler(IEstadosCandidaturaRepository estadosCandidaturaRepository)
        {
            _estadosCandidaturaRepository = estadosCandidaturaRepository;
        }
        public async Task<List<EstadoCandidaturaDTO>> Handle(ListarTodosEstadoCandidaturaQuery request, CancellationToken cancellationToken)
        {
            var listEstados=await _estadosCandidaturaRepository.GetAllEstados();
            return listEstados.Adapt<List<EstadoCandidaturaDTO>>();
        }
    }
}
