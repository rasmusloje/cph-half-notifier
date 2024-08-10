namespace CphHalfNotifier.Options;

public class NotificationOptions
{
    public int MessageRateInSeconds { get; set; }
    public int PollingRateInSeconds { get; set; }
    public bool EnableHealthCheckMessages { get; set; }
    
    public TimeSpan MessageRate => TimeSpan.FromSeconds(MessageRateInSeconds);
    public TimeSpan PollingRate => TimeSpan.FromSeconds(PollingRateInSeconds);
}