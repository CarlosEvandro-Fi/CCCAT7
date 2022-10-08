namespace ECommerce.Stock.Application;

public sealed class DecrementStock
{
    public IStockEntryRepository StockEntryRepository { get; }

    public DecrementStock(IStockEntryRepository iStockEntryRepository)
        => StockEntryRepository = iStockEntryRepository;

    public async Task Execute(IEnumerable<DecrementStockDTO> values)
    {
		foreach (var entry in values)
        {
			var stockEntries = await StockEntryRepository.ListByIdItem(entry.ItemId);
            var total = StockCalculator.Calculate(stockEntries);
			if (total < entry.Quantity) throw new Exception("Insufficient Stock.");
            await StockEntryRepository.Save(new StockEntry(entry.ItemId, Operation.OUT, entry.Quantity));
		}
	}
}
