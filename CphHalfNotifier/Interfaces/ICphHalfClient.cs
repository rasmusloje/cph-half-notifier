namespace CphHalfNotifier.Interfaces;

public interface ICphHalfClient
{
    Task<string> GetResalePlatformHtmlAsync();
}