namespace ECommerce.Stock.Domain;

public sealed class StockCalculator
{
    public static Int32 Calculate(IEnumerable<StockEntry> stockEntries)
    {
        return stockEntries.Sum(s => (s.Operation == Operation.IN ? s.Quantity : s.Quantity * -1));
    }
}
