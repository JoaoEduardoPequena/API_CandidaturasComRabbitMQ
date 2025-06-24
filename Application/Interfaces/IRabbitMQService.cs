namespace Application.Interfaces
{
    public interface IRabbitMQService
    {
        public Task<bool> PublishAsync<T>(T message, string QueueName);
    }
}
