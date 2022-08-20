using eCommerce.Application;
using eCommerce.Infrastructure.Database;
using eCommerce.Infrastructure.HTTP;
using eCommerce.Infrastructure.Repository.Database;

namespace eCommerce.Infrastructure.Controller.HTTP;

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
