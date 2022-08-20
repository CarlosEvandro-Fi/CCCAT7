namespace ECommerce.Stock.Application;

public sealed class GetStock
{
	public IStockEntryRepository StockEntryRepository { get; }

	public GetStock(IStockEntryRepository stockEntryRepository)
		=> StockEntryRepository = stockEntryRepository;

	public async Task<Int32> Execute(Int32 itemId)
	{
		var stockEntries = await StockEntryRepository.ListByIdItem(itemId);
		var total = StockCalculator.Calculate(stockEntries);
		return total;
	}
}
