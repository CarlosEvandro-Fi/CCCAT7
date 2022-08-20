using ECommerce.Stock.Domain;
using ECommerce.Stock.Infrastructure.Database;

namespace ECommerce.Stock.Infrastructure.Repository.Database;

public sealed class StockEntryRepositoryDatabase : IStockEntryRepository
{
    private Repository.Memory.StockEntryRepositoryMemory Memory = new();

    public IConnection Connection { get; }

    public StockEntryRepositoryDatabase(IConnection connection) => Connection = connection;

    public Task Clean() => Memory.Clean();

    public Task<IEnumerable<StockEntry>> ListByIdItem(Int64 itemId) => Memory.ListByIdItem(itemId);

    public Task Save(StockEntry stockEntry) => Memory.Save(stockEntry);
}
