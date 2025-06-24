using Domain.Entites;

namespace Domain.Interfaces
{
    public interface ICandidaturaRepository
    {
        public Task<bool> CriarCandidatura(Candidatura candidatura);
    }
}
