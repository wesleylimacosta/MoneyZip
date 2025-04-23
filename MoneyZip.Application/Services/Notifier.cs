namespace MoneyZip.Services;

public interface Notifier
{
    // Simulate to send a notification to an external service  with base         _notifierMock.Setup(x => x.Notify(It.IsAny<string>())).Verifiable();

    
    void Notify(string message);
    
}