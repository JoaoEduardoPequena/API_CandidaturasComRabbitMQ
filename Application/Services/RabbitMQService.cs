using Application.Interfaces;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Application.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IBus _IBus;
        private readonly ILogger<RabbitMQService> _logger;
        public RabbitMQService(IBus bus, ILogger<RabbitMQService> logger)
        {
            _IBus = bus;
            _logger = logger;
        }
        public async Task<bool> PublishAsync<T>(T message, string QueueName)
        {
            try
            {
                var uri = new Uri($"queue:{QueueName}");
                var iBus = await _IBus.GetSendEndpoint(uri);
                await iBus.Send(message);
                return true;
            }
            catch (Exception ex)
            {
               _logger.LogError($"Erro ao publicar mensagem na fila {QueueName}. Detalhe do erro: {ex.Message}");
               return true;
            }
        }
    }
}
