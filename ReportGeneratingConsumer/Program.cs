using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ReportGeneratingConsumer.Services;
using ReportGeneratingConsumer;
using ReportGeneratingConsumer.Data.Repositories;

using IHost host = CreateHostBuilder(args).Build();

using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try 
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

// implementatinon of 'CreateHostBuilder' static method and create host object
 static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder()
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<RabbitMQConnectionManager>();
            services.AddSingleton<PointsReportGenerationService>();
            services.AddScoped<PointsRepository>();
            services.AddSingleton<App>();
        });
}