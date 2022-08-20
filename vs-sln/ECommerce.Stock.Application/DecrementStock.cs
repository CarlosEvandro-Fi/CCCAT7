namespace eCommerce.Application;

public sealed class DecrementStock
{
    public IStockEntryRepository StockEntryRepository { get; }

    public DecrementStock(IStockEntryRepository stockEntryRepository)
        => StockEntryRepository = stockEntryRepository;


    public async Task Execute(IEnumerable<Input> input)
    {
		foreach (var stockEntryData in input)
        {
			var stockEntries = await StockEntryRepository.ListByIdItem(stockEntryData.ItemId);
            var total = StockCalculator.Calculate(stockEntries);
			if (total < stockEntryData.Quantity) throw new Exception("Insufficient stock");
            await StockEntryRepository.Save(new StockEntry(stockEntryData.ItemId, Operation.OUT, stockEntryData.Quantity));
		}
	}

    public class Input
    {
        public Int32 ItemId { get; set; }
        public Int32 Quantity { get; set; }
    }
}
