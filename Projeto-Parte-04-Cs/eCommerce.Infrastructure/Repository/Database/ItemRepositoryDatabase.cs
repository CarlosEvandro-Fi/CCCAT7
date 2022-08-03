using eCommerce.Domain;
using eCommerce.Infrastructure.Database;

namespace eCommerce.Infrastructure.Repository.Database;

public sealed class ItemRepositoryDatabase : IItemRepository
{
    private Repository.Memory.ItemRepositoryMemory Memory { get; } = new();

    private IConnection Connection { get; }

    public ItemRepositoryDatabase(IConnection connection) => Connection = connection;
    
    public Task<Item> GetItem(int itemId) => Memory.GetItem(itemId);
}
