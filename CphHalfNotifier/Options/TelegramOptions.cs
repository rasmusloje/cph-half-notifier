namespace CphHalfNotifier.Options;

public class TelegramOptions
{
    public Uri ApiBaseUrl { get; set; } = null!;
    public string BotAccessToken { get; set; } = null!;
    public string BotChatId { get; set; } = null!;
}