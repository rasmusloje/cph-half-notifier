using CphHalfNotifier;
using CphHalfNotifier.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration(builder =>
    {
        builder.AddJsonFile("appsettings.json");
    })
    .ConfigureServices((context, services) =>
    {
        services.AddCphHalfServices(context.Configuration);
    })
    .Build();

var lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();

var app = host.Services.GetRequiredService<IApp>();

await app.RunAsync(lifetime.ApplicationStopping);