using Infrastruture.Worker.DTO;
using Infrastruture.Worker.Interfaces;
using Infrastruture.Worker.Setting;
using MassTransit;
using Microsoft.Extensions.Options;
using NotificarCandidatos.Worker.Interfaces;

namespace NotificarCandidatos.Worker.Consumers
{
    public class CandidaturasConsumer : IConsumer<CandidaturasMessageDTO>
    {
        private readonly ISendEmailService _sendEmailService;
        private readonly IReportProcess _reportService;
        private readonly ReportsFilesNameSetting _reportsFilesNameSetting;
        public CandidaturasConsumer(ISendEmailService sendEmailService, IReportProcess reportService, IOptions<ReportsFilesNameSetting> reportsFilesNameSetting)
        {
            _sendEmailService = sendEmailService;
            _reportService = reportService;
            _reportsFilesNameSetting = reportsFilesNameSetting.Value;
        }

        public async Task Consume(ConsumeContext<CandidaturasMessageDTO> context)
        {
            if(context.Message is not null)
            {
                var generateFile=await _reportService.GenerateReportAsync(_reportsFilesNameSetting.ReportName, _reportsFilesNameSetting.ReportType, context.Message.IdCandidatura);
                var dtoEmail = new EmailDTO();
                dtoEmail.File = generateFile;
                dtoEmail.EmailSubject = "Confirmação de Candidatura Recebida";
                dtoEmail.To = context.Message.Email;
                dtoEmail.EmailText = $"Prezado (a) {context.Message.Nome},\n\nSua candidatura foi recebida com sucesso no dia {context.Message.DataCricao:dd/MM/yyyy}.\n\nObrigado por se candidatar!";
                await _sendEmailService.SendEmailAsync(dtoEmail);
            }
        }
    }
}
