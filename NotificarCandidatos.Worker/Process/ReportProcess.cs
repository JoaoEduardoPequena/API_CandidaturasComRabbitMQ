using System.Reflection;
using System.Text;
using AspNetCore.Reporting;
using Infrastruture.Worker.Interfaces;
using NotificarCandidatos.Worker.Interfaces;

namespace NotificarCandidatos.Worker.Process
{
    public class ReportProcess : IReportProcess
    {
        private readonly ICandidaturaService _candidaturaService;
        private readonly ILogger<ReportProcess> _logger;
        public ReportProcess(ICandidaturaService candidaturaService, ILogger<ReportProcess> logger)
        {
            _candidaturaService = candidaturaService;
            _logger = logger;
        }
        private RenderType GetRenderType(string reportType)
        {
            var renderType = RenderType.Pdf;

            switch (reportType.ToUpper())
            {
                default:
                case "PDF":
                    renderType = RenderType.Pdf;
                    break;
                case "EXCEL":
                    renderType = RenderType.Excel;
                    break;
                case "WORD":
                    renderType = RenderType.Word;
                    break;
            }

            return renderType;
        }
        public async Task<byte[]> GenerateReportAsync(string reportName, string reportType, Guid IdCandidatura)
        {
            try
            {
                var candidaturaReportDTO = await _candidaturaService.ObterCandidaturaReport(IdCandidatura);
                if (candidaturaReportDTO is null) return null;
                var baseDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
                var rdlcFilePath = Path.Combine(baseDir, "ReportFiles", $"{reportName}.rdlc");
                if (!File.Exists(rdlcFilePath))
                {
                    _logger.LogError("Arquivo de relatório RDLC não encontrado em {Path}", rdlcFilePath);
                    return null;
                }
                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                Encoding.GetEncoding("utf-8");
                LocalReport report = new LocalReport(rdlcFilePath);
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                report.AddDataSource("DataSetCandidaturas", candidaturaReportDTO);
                var result = report.Execute(GetRenderType(reportType), 1, parameters);
                return result.MainStream;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao gerar relatório: {reportName} do tipo {reportType}. Detalhe do erro: {ex.Message}");
                return null;
            }
        }
    }
}
