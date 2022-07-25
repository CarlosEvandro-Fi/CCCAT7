namespace eCommerce.Infrastructure.CLI;

public sealed class StdinAdapter : IInputDevice
{
    public void OnData(Action<String> callback)
    {
        throw new NotImplementedException();
    }
}
