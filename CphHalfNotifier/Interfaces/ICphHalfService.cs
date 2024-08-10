namespace CphHalfNotifier.Interfaces;

public interface ICphHalfService
{
    Task<bool> HasTicketsAvailableAsync();
}