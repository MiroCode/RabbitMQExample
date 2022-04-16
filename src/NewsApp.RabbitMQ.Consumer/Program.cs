using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;


namespace RabbitMQ.Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", UserName = "ProjeRabbit", Password = "hkn999" };//Konfigurasyondan alınabilir            

            using (IConnection connection = factory.CreateConnection())
            using (IModel channel = connection.CreateModel())
            {
                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    var message = Encoding.UTF8.GetString(body);
                    Console.WriteLine($" Welcome {message}");
                };
                channel.BasicConsume(queue: "NotificationQueue", //Kuyruk adı
                    autoAck: true, //Kuyruk adı doğrulanması
                    consumer: consumer);
                Console.ReadLine();
            }
        }
    }
}
