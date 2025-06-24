using Infrastruture.Worker;
using MassTransit;
using NotificarCandidatos.Worker.Consumers;
using NotificarCandidatos.Worker.Interfaces;
using NotificarCandidatos.Worker.Process;

namespace NotificarCandidatos.Worker
{
    public static class WorkerServiceRegistration
    {
        public static void AddNotificadorPedidosWorker(this IServiceCollection services, IConfiguration config)
        {
            services.AddInfrastructureWorker(config);
            services.AddMassTransit(c =>
            {
                c.AddConsumer<CandidaturasConsumer>();

                c.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(config.GetValue<string>("RabbitMqSetting:HostName"), h =>
                    {
                        h.ConfigureBatchPublish(op =>
                        {
                            op.Enabled = true;
                        });
                        h.Username(config.GetValue<string>("RabbitMqSetting:UserName"));
                        h.Password(config.GetValue<string>("RabbitMqSetting:PassWord"));
                    });

                    cfg.ReceiveEndpoint(config.GetValue<string>("RabbitMqSetting:QueueCandidaturas"), e =>
                    {
                        e.ConfigureConsumer<CandidaturasConsumer>(context);
                    });

                    cfg.UseRawJsonSerializer();
                    cfg.ConfigureEndpoints(context);
                });

            });
            services.AddMassTransitHostedService();
            services.AddSingleton<IReportProcess, ReportProcess>();
        }
    }
}
