namespace ECommerce.Stock.Application;

public sealed class IncrementStock
{
	public IStockEntryRepository StockEntryRepository { get; }

	public IncrementStock(IStockEntryRepository iStockEntryRepository)
		=> StockEntryRepository = iStockEntryRepository;

	public async Task Execute(IEnumerable<IncrementStockDTO> values)
	{
		foreach (var entry in values)
		{
			await StockEntryRepository.Save(new StockEntry(entry.ItemId, Operation.IN, entry.Quantity));
		}
	}
}
