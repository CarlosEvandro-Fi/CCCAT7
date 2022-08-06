namespace eCommerce.Application;

public sealed class IncrementStock
{
	public IStockEntryRepository StockEntryRepository { get; }

	public IncrementStock(IStockEntryRepository stockEntryRepository)
		=> StockEntryRepository = stockEntryRepository;

	public async Task Execute(IEnumerable<Input> input)
	{
		foreach (var stockEntryData in input)
		{
			await StockEntryRepository.Save(new StockEntry(stockEntryData.ItemId, Operation.IN, stockEntryData.Quantity));
		}
	}

    public class Input
    {
        public Int32 ItemId { get; set; }
        public Int32 Quantity { get; set; }
    }
}
