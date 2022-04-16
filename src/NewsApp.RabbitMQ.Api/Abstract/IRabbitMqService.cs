using NewsApp.RabbitMQ.Api.Models;

namespace NewsApp.RabbitMQ.Api.Abstract
{
    public interface IRabbitMqService
    {
        void SendToQueue(Notification notification);
    }
}
