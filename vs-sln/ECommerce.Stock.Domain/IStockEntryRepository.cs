namespace ECommerce.Stock.Domain;

public interface IStockEntryRepository
{
	Task<IEnumerable<StockEntry>> ListByIdItem(Int64 itemId);
	Task Save(StockEntry stockEntry);
	Task Clean();
}
