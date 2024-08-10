using CphHalfNotifier.Models;

namespace CphHalfNotifier.Interfaces;

public interface ITelegramClient
{
    Task SendMessage(TelegramMessage message);
}