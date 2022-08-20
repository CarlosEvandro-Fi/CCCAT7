using ECommerce.Checkout.Domain;
using ECommerce.Checkout.Infrastructure.Database;

namespace ECommerce.Checkout.Infrastructure.Repository.Database;

public sealed class ItemRepositoryDatabase : IItemRepository
{
    private Repository.Memory.ItemRepositoryMemory Memory { get; } = new();

    private IConnection Connection { get; }

    public ItemRepositoryDatabase(IConnection connection) => Connection = connection;
    
    public Task<Item> GetItem(int itemId) => Memory.GetItem(itemId);
}
