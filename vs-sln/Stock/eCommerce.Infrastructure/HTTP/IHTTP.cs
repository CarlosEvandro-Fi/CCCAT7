using eCommerce.Application;

namespace eCommerce.Infrastructure.HTTP;

public interface IHTTP
{
    void OnDecrementStock(Func<IEnumerable<DecrementStock.Input>, Task> on);
    void OnIncrementStock(Func<IEnumerable<IncrementStock.Input>, Task> on);
    void OnGetStock(Func<Int32, Task<Int32>> on);
}
