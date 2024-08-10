using CphHalfNotifier.Clients;
using CphHalfNotifier.Interfaces;
using CphHalfNotifier.Options;
using CphHalfNotifier.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CphHalfNotifier;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCphHalfServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<CphHalfOptions>(configuration.GetSection("CphHalf"));
        services.Configure<TelegramOptions>(configuration.GetSection("Telegram"));
        services.Configure<NotificationOptions>(configuration.GetSection("Notification"));

        services.AddScoped<ICphHalfService, CphHalfService>();
        services.AddScoped<INotificationService, NotificationService>();

        services.AddHttpClient<ICphHalfClient, CphHalfClient>();
        services.AddHttpClient<ITelegramClient, TelegramClient>();
        
        services.AddScoped<IApp, App>();

        return services;
    }
}