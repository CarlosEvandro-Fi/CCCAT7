namespace ECommerce.Stock.Application;

public sealed class DecrementStock
{
    public IStockEntryRepository StockEntryRepository { get; }

    public DecrementStock(IStockEntryRepository stockEntryRepository)
        => StockEntryRepository = stockEntryRepository;


    public async Task Execute(IEnumerable<OrderItem> input)
    {
		foreach (var orderItem in input)
        {
			var stockEntries = await StockEntryRepository.ListByIdItem(orderItem.ItemId);
            var total = StockCalculator.Calculate(stockEntries);
			if (total < orderItem.Quantity) throw new Exception("Insufficient stock");
            await StockEntryRepository.Save(new StockEntry(orderItem.ItemId, Operation.OUT, orderItem.Quantity));
		}
	}
}
