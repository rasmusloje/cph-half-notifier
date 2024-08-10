namespace CphHalfNotifier.Models;

public record TelegramMessage
{
    public required string AccessToken { get; init; }
    public required string ChatId { get; init; }
    public required string Message { get; init; }
}