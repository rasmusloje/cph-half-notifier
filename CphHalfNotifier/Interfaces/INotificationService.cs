namespace CphHalfNotifier.Interfaces;

public interface INotificationService
{
    Task NotifyCphHalfBot(string message);
}