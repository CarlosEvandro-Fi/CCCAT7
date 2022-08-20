using ECommerce.Catalog.Infrastructure.Database;

namespace ECommerce.Catalog.Infrastructure.Repository.Database;

public sealed class ItemRepositoryDatabase : IItemRepository
{
    private Repository.Memory.ItemRepositoryMemory Memory { get; } = new();

    private IConnection Connection { get; }

    public ItemRepositoryDatabase(IConnection connection) => Connection = connection;
    
    public Task<Item> GetItem(Int32 itemId) => Memory.GetItem(itemId);

    public Task<IEnumerable<Item>> List() => Memory.List();
}
