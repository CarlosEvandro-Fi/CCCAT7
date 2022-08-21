using ECommerce.Checkout.Application;
using static ECommerce.Checkout.Domain.CheckoutCommand;

namespace ECommerce.Checkout.Infrastructure.HTTP;

public interface IHTTP
{
    void OnOrderPreview(Func<PreviewOrder.Input, Task<PreviewOrder.Output>> on);

    void OnCheckout(Func<CheckoutInput, Task> on);
}
