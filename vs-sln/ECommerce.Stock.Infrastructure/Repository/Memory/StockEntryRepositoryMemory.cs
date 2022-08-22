using ECommerce.Stock.Domain;

namespace ECommerce.Stock.Infrastructure.Repository.Memory;

public sealed class StockEntryRepositoryMemory : IStockEntryRepository
{
    private static readonly List<StockEntry> StockEntries = new()
    {
        new StockEntry(1, Operation.IN, 1000),
        new StockEntry(2, Operation.IN, 1000),
        new StockEntry(3, Operation.IN, 1000),
    };

    public async Task Clean()
    {
        StockEntries.Clear();
    }

    public async Task<IEnumerable<StockEntry>> ListByIdItem(Int64 itemId)
    {
        return StockEntries.Where(where => where.ItemId == itemId);
    }

    public async Task Save(StockEntry stockEntry)
    {
        StockEntries.Add(stockEntry);
    }
}
