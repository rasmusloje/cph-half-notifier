using System.Web;
using CphHalfNotifier.Interfaces;
using CphHalfNotifier.Models;
using CphHalfNotifier.Options;
using Microsoft.Extensions.Options;

namespace CphHalfNotifier.Clients;

public class TelegramClient(HttpClient httpClient, IOptions<TelegramOptions> telegramOptions) : ITelegramClient
{
    public async Task SendMessage(TelegramMessage message)
    {
        var botPath = $"bot{message.AccessToken}";
        var sendMessageEndpoint = $"{telegramOptions.Value.ApiBaseUrl}{botPath}/sendMessage";
        
        var queryParams = HttpUtility.ParseQueryString(string.Empty);
        queryParams["chat_id"] = message.ChatId;
        queryParams["text"] = message.Message;

        var builder = new UriBuilder(sendMessageEndpoint)
        {
            Query = queryParams.ToString()
        };

        var url = builder.ToString();
        
        await httpClient.GetAsync(url);
    }
}