using NewsApp.RabbitMQ.Api.Abstract;

namespace NewsApp.RabbitMQ.Api
{
    public static class ConfigureServiceExtension
    {
       
        public static void AddScoped(this IServiceCollection services)
        {
            services.AddScoped<IRabbitMqService, RabbitMqService>();
        }
    }
}
