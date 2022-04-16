using NewsApp.RabbitMQ.Api.Abstract;
using Newtonsoft.Json;
using RabbitMQ.Client;
using NewsApp.RabbitMQ.Api.Models;
using System.Text;

namespace NewsApp.RabbitMQ.Api
{
    public class RabbitMqService : IRabbitMqService
    {
        public void SendToQueue(Notification notification)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "ProjeRabbit", Password = "hkn999" };//Konfigurasyondan alınabilir            
            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "NotificationQueue",
                    durable: false, //Data saklama yöntemi (memory-fiziksel)
                    exclusive: false, //Başka bağlantıların kuyruğa ulaşmasını istersek true kullanabiliriz.
                    autoDelete: false,
                    arguments: null);//Exchange parametre tanımları.          

                var body = Encoding.UTF8.GetBytes(notification.Name);
                channel.BasicPublish(exchange: "",
                    routingKey: "NotificationQueue", basicProperties: null, body: body);
            }
        }
    }
}
