using eCommerce.Domain;

namespace eCommerce.Infrastructure.Repository.Memory;

public sealed class StockEntryRepositoryMemory : IStockEntryRepository
{
    private static readonly List<StockEntry> StockEntries = new();

    public async Task Clean()
    {
        StockEntries.Clear();
    }

    public async Task<IEnumerable<StockEntry>> ListByIdItem(int itemId)
    {
        return StockEntries.Where(where => where.ItemId == itemId);
    }

    public async Task Save(StockEntry stockEntry)
    {
        StockEntries.Add(stockEntry);
    }
}
