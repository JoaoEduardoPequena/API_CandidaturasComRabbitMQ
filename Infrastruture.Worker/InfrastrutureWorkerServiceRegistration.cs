using Infrastruture.Worker.Interfaces;
using Infrastruture.Worker.Services;
using Infrastruture.Worker.Setting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace Infrastruture.Worker
{
    public static class InfrastrutureWorkerServiceRegistration
    {
        public static void AddInfrastructureWorker(this IServiceCollection services, IConfiguration conf)
        {
            services.Configure<ConnectionStringSetting>(op => conf.GetSection("ConnectionStringSetting").Bind(op));
            services.Configure<EmailSetting>(op => conf.GetSection("EmailSetting").Bind(op));
            services.AddSingleton<ISendEmailService, SendEmailService>();
            services.AddSingleton<ICandidaturaService, CandidaturaService>();
            services.Configure<RabbitMqSetting>(op => conf.GetSection("RabbitMqSetting").Bind(op));
            services.Configure<ReportsFilesNameSetting>(op => conf.GetSection("ReportsFilesNameSetting").Bind(op));
        }
    }
}
