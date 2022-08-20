using ECommerce.Stock.Application;
using ECommerce.Stock.Domain;

namespace ECommerce.Stock.Infrastructure.HTTP;

public interface IHTTP
{
    void OnDecrementStock(Func<IEnumerable<OrderItem>, Task> on);
    void OnIncrementStock(Func<IEnumerable<IncrementStock.Input>, Task> on);
    void OnGetStock(Func<Int32, Task<Int32>> on);
}
