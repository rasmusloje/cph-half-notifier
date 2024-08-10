using CphHalfNotifier.Interfaces;
using CphHalfNotifier.Options;
using Microsoft.Extensions.Options;

namespace CphHalfNotifier.Clients;

public class CphHalfClient(HttpClient httpClient, IOptions<CphHalfOptions> options) : ICphHalfClient
{
    public async Task<string> GetResalePlatformHtmlAsync()
    {
        var resalePlatformHtml = await httpClient.GetStringAsync(options.Value.ResalePlatformUrl);

        return resalePlatformHtml;
    }
}