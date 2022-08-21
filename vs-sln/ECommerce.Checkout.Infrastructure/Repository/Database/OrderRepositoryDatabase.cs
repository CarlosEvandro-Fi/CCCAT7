using ECommerce.Checkout.Domain;
using ECommerce.Checkout.Infrastructure.Database;

namespace ECommerce.Checkout.Infrastructure.Repository.Database;

public sealed class OrderRepositoryDatabase : IOrderRepository
{
    private Repository.Memory.OrderRepositoryMemory Memory { get; } = new();

    private IConnection Connection { get; }

    public OrderRepositoryDatabase(IConnection connection) => Connection = connection;
    
    public Task Clean() => Memory.Clean();

    public Task<Int32> Count() => Memory.Count();

    public Task Save(Order order) => Memory.Save(order);

    public Task<Order> GetByGuid(String guid) => Memory.GetByGuid(guid);
}
