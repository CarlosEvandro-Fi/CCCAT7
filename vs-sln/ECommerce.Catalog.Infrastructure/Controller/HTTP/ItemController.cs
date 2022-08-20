using ECommerce.Catalog.Application;
using ECommerce.Catalog.Infrastructure.HTTP;

namespace ECommerce.Catalog.Infrastructure.Controller.HTTP;

public sealed class ItemController
{
    public ItemController(IHTTP http, GetItem getItem, GetItems getItems)
    {
        http.OnGetItem(
            async (itemId) =>
            {
                return await getItem.Execute(itemId);
            });
        http.OnGetItems(
            async () =>
            {
                return await getItems.Execute();
            });
    }
}
