using Application.Behaviors;
using Application.Interfaces;
using Application.Services;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using Application.Setting;
using StackExchange.Redis;
using MassTransit;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration conf)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            });
            services.Configure<RabbitMqSetting>(op => conf.GetSection("RabbitMqSetting").Bind(op));
            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(conf.GetValue<string>("RabbitMqSetting:HostName"), h =>
                    {
                        h.Username(conf.GetValue<string>("RabbitMqSetting:UserName"));
                        h.Password(conf.GetValue<string>("RabbitMqSetting:PassWord"));
                    });
                    cfg.UseRawJsonSerializer();
                });
            });
            services.AddTransient<IRabbitMQService,RabbitMQService>();
            return services;
        }

    }
}
