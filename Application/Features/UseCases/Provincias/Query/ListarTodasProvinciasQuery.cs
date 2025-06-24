using Application.DTO;
using MediatR;

namespace Application.Features.UseCases.Provincias.Query
{
    public record ListarTodasProvinciasQuery: IRequest<List<ProvinciasDTO>>;
   
}
