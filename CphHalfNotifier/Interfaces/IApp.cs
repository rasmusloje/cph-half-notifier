namespace CphHalfNotifier.Interfaces;

public interface IApp
{
    Task RunAsync(CancellationToken token);
}