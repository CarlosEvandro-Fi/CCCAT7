using ECommerce.Checkout.Application;
using ECommerce.Checkout.Infrastructure.Database;
using ECommerce.Checkout.Infrastructure.HTTP;
using ECommerce.Checkout.Infrastructure.Repository.Database;

namespace ECommerce.Checkout.Infrastructure.Controller.HTTP;

public sealed class OrderController
{
    public OrderController(IHTTP http, PreviewOrder previewOrder, Checkouting checkouting)
    {
        http.OnOrderPreview(
            async (input) =>
            {
                var output = await previewOrder.Execute(input);
                return output;
            });

        http.OnCheckout(
            async (input) =>
            {
                await checkouting.Execute(input);
            });
    }
}
