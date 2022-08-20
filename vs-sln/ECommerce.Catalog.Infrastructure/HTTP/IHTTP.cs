using ECommerce.Catalog.Application;

namespace ECommerce.Catalog.Infrastructure.HTTP;

public interface IHTTP
{
    void OnGetItem(Func<Int32, Task<ItemDTO>> on);
    void OnGetItems(Func<Task<IEnumerable<ItemDTO>>> on);
}
