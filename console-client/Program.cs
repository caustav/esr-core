using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using esr_core;
using console_client;

 Host.CreateDefaultBuilder()
    .ConfigureAppConfiguration(app =>
    {
        app.AddJsonFile("appsettings.json");
    })
    .ConfigureServices(services =>
    {
        services.AddScoped<IESRObserver, ConsoleObserver>();

        services.AddRabbitEventStore(new SystemConfiguration
        {
            SQLServerConnectionString = "Server=localhost,1433;Initial Catalog=EventStore;User ID=SA;Password=abcd@123456;MultipleActiveResultSets=False;TrustServerCertificate=False;Connection Timeout=30;",
            RabbitMqConnectionString = "localhost"
        });

        var esrClient = services.BuildServiceProvider().GetRequiredService<IESRClient>();
        var @event = new InvoiceCreated
        {
            InvoiceNumber = "IC-900",
            Amount = "1500",
            Vendor = "S&S Corp."
        };
        esrClient.Publish(@event, @event.InvoiceNumber);
      
    }).Build().Run();