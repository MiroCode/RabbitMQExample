using Microsoft.OpenApi.Models;
using NewsApp.RabbitMQ.Api;

var builder = WebApplication.CreateBuilder(args);

#region ConfigureService

builder.Services.AddControllers();

builder.Services.AddScoped();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "RabbitMqApi", Version = "v1" });
});
#endregion

var app = builder.Build();

#region Configure

app.UseHttpsRedirection();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RabbitMqProducerApi v1"));

app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapGet("/", context =>
    {
        return Task.Run(() => context.Response.Redirect("/hangfire"));
    });
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
#endregion
app.Run();
