using eCommerce.Domain;
using eCommerce.Infrastructure.DB;

namespace eCommerce.Infrastructure.Repository.DB;

public sealed class OrderRepositoryDatabase : IOrderRepository
{
    private Repository.Memory.OrderRepositoryMemory Memory { get; } = new();

    public IConnection Connection { get; }

    public OrderRepositoryDatabase(IConnection connection)
    {
        Connection = connection;
    }

    public Task<Int32> Count() => Memory.Count();

    public Task Save(Order order) => Memory.Save(order);

    public Task Clean() => Memory.Clean();
}
