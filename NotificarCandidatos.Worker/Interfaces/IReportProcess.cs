namespace NotificarCandidatos.Worker.Interfaces
{
    public interface IReportProcess
    {
        public Task<byte[]> GenerateReportAsync(string reportName, string reportType, Guid IdCandidatura);
    }
}
