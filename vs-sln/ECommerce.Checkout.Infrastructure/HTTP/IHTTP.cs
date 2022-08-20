using ECommerce.Checkout.Application;

namespace ECommerce.Checkout.Infrastructure.HTTP;

public interface IHTTP
{
    void OnOrderPreview(Func<PreviewOrder.Input, Task<PreviewOrder.Output>> on);
}
