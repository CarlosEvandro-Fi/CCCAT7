namespace eCommerce.Infrastructure.CLI;

public interface IInputDevice
{
    void OnData(Action<String> callback);
}
