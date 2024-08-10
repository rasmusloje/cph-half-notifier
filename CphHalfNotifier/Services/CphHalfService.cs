using CphHalfNotifier.Interfaces;
using HtmlAgilityPack;
using Microsoft.Extensions.Logging;

namespace CphHalfNotifier.Services;

public class CphHalfService(ICphHalfClient cphHalfClient, ILogger<ICphHalfService> logger) : ICphHalfService
{
    private const string NoTicketsAvailableString =
        "Der er ikke nogen startnumre til salg i øjeblikket. Prøv igen lidt senere.";

    public async Task<bool> HasTicketsAvailableAsync()
    {
        var html = await cphHalfClient.GetResalePlatformHtmlAsync();
        if (html.Contains(NoTicketsAvailableString))
        {
            return false;
        }
        
        var doc = new HtmlDocument();
        doc.LoadHtml(html);
        
        var table = doc.DocumentNode.SelectSingleNode("//table[@class='table']//tbody");

        foreach (var row in table.SelectNodes("tr"))
        {
            var cells = row.SelectNodes("td");
            var race = cells[0].InnerText.Trim();
            var id = cells[1].InnerText.Trim();
            var price = cells[2].InnerText.Trim();
            var status = cells[3].InnerText.Trim();
            
            logger.LogInformation($"Race: {race}, ID: {id}, Price: {price}, Status: {status}");

            if (status != "Køb i gang")
            {
                return true;
            }
        }

        return false;
    }
}