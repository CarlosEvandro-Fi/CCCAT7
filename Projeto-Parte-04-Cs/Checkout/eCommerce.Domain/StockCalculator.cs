namespace eCommerce.Domain;

public sealed class StockCalculator
{
    public static Int32 Calculate(IEnumerable<StockEntry> stockEntries)
    {
        return stockEntries.Sum(s => (s.Operation == Operation.IN ? s.Quantity : s.Quantity * -1));

        //return stockEntries.reduce((total, stockEntry) =>
        //{
        //    if (stockEntry.operation === "in")
        //    {
        //        total += stockEntry.quantity;
        //    }
        //    if (stockEntry.operation === "out")
        //    {
        //        total -= stockEntry.quantity;
        //    }
        //    return total;
        //}, 0);
    }


}
