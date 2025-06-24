using Domain.Entites;

namespace Domain.Interfaces
{
    public interface IEstadosCandidaturaRepository
    {
        public Task<List<EstadoCandidatura>>GetAllEstados();
    }
}
