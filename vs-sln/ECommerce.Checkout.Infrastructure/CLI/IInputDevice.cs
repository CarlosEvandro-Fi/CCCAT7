namespace ECommerce.Checkout.Infrastructure.CLI;

public interface IInputDevice
{
    void OnData(Action<String> callback);
}
