using DomainReport.Worker.DTO;
using Infrastruture.Worker.DTO;

namespace Infrastruture.Worker.Interfaces
{
    public interface ICandidaturaService
    {
        public Task<CandidaturaReportDTO> ObterCandidaturaReport(Guid idCandidatura);
    }
}
