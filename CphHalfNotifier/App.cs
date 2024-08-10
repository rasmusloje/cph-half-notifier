using System.Text;
using CphHalfNotifier.Interfaces;
using CphHalfNotifier.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CphHalfNotifier;

public class App(
    ICphHalfService cphHalfService, 
    INotificationService notificationService,
    IOptions<NotificationOptions> notificationOptions,
    IOptions<CphHalfOptions> cphHalfOptions,
    ILogger<IApp> logger) : IApp
{
    private readonly NotificationOptions _notificationOptions = notificationOptions.Value;
    private readonly CphHalfOptions _cphHalfOptions = cphHalfOptions.Value;
    private DateTime _lastNotificationTime = DateTime.Now;
    private const int MinutesBetweenHealthCheck = 60;

    public async Task RunAsync(CancellationToken cancellationToken)
    {
        var jobStartingText = new StringBuilder();
        jobStartingText.AppendLine("Starting checking for available tickets!");
        jobStartingText.AppendLine();
        jobStartingText.AppendLine("Notification settings:");
        jobStartingText.AppendLine($"- Message rate: {_notificationOptions.MessageRate}");
        jobStartingText.AppendLine($"- Polling rate: {_notificationOptions.PollingRate}");
        jobStartingText.AppendLine();
        jobStartingText.AppendLine($"Resale platform: {_cphHalfOptions.ResalePlatformUrl}");
        
        await notificationService.NotifyCphHalfBot(jobStartingText.ToString());

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var hasAvailableTickets = await cphHalfService.HasTicketsAvailableAsync();
                if (hasAvailableTickets)
                {
                    await notificationService.NotifyCphHalfBot($"Tickets available! \n{_cphHalfOptions.ResalePlatformUrl}");
                    logger.LogInformation("Tickets available!");

                    await Task.Delay((int)_notificationOptions.MessageRate.TotalMilliseconds, cancellationToken);
                }
                else
                {
                    logger.LogInformation("No tickets available.");
                    await Task.Delay((int)_notificationOptions.PollingRate.TotalMilliseconds, cancellationToken);
                }
                
                // Check if X hours have passed since the last notification
                if (_notificationOptions.EnableHealthCheckMessages && (DateTime.Now - _lastNotificationTime).TotalMinutes >= MinutesBetweenHealthCheck)
                {
                    await notificationService.NotifyCphHalfBot("Health check notification: Still running.");
                    _lastNotificationTime = DateTime.Now;
                }
            }
            catch (Exception e)
            {
                await notificationService.NotifyCphHalfBot($"Error: {e.Message}");
            }
        }

        await notificationService.NotifyCphHalfBot("Stopping checking for available tickets!");
    }
}