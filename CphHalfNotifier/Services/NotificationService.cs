using CphHalfNotifier.Interfaces;
using CphHalfNotifier.Models;
using CphHalfNotifier.Options;
using Microsoft.Extensions.Options;

namespace CphHalfNotifier.Services;

public class NotificationService(ITelegramClient telegramClient, IOptions<TelegramOptions> telegramOptions) : INotificationService
{
    public async Task NotifyCphHalfBot(string message)
    {
        var telegramMessage = new TelegramMessage
        {
            AccessToken = telegramOptions.Value.BotAccessToken,
            ChatId = telegramOptions.Value.BotChatId,
            Message = message
        };

        await telegramClient.SendMessage(telegramMessage);
    }
}