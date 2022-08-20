using ECommerce.Checkout.Application;
using ECommerce.Checkout.Infrastructure.Database;
using ECommerce.Checkout.Infrastructure.HTTP;
using ECommerce.Checkout.Infrastructure.Repository.Database;

namespace ECommerce.Checkout.Infrastructure.Controller.HTTP;

public sealed class OrderController
{
    public OrderController(IHTTP http, IConnection connection)
    {
        http.OnOrderPreview(
            async (input) =>
            {
                var itemRepository = new ItemRepositoryDatabase(connection);
                var previewOrder = new PreviewOrder(itemRepository);
                var output = await previewOrder.Execute(input);
                return output;
            });
    }
}
