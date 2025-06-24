using Application.DTO;
using Domain.Interfaces;
using Mapster;
using MediatR;

namespace Application.Features.UseCases.Provincias.Query
{
    public record ListarTodasProvinciasQueryHandler : IRequestHandler<ListarTodasProvinciasQuery, List<ProvinciasDTO>>
    {
        private readonly IProvinciasRepository _provinciaRepository;
        public ListarTodasProvinciasQueryHandler(IProvinciasRepository provinciaRepository)
        {
            _provinciaRepository = provinciaRepository;
        }
        public async Task<List<ProvinciasDTO>> Handle(ListarTodasProvinciasQuery request, CancellationToken cancellationToken)
        {
            return _provinciaRepository.GetAllProvincias().Adapt<List<ProvinciasDTO>>();
        }
    }
}
