using eCommerce.Domain;

namespace eCommerce.Infrastructure.Repository.Database;

public sealed class StockEntryRepositoryDatabase : IStockEntryRepository
{
    private Repository.Memory.StockEntryRepositoryMemory Memory = new();

    public Task Clean() => Memory.Clean();

    public Task<IEnumerable<StockEntry>> ListByIdItem(Int32 itemId) => Memory.ListByIdItem(itemId);

    public Task Save(StockEntry stockEntry) => Memory.Save(stockEntry);
}
