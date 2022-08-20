// *** ESSA CLASSE TOMA LUGAR DO ExpressAdapter

using ECommerce.Stock.Application;
using static ECommerce.Stock.Infrastructure.Controller.StockController;

namespace ECommerce.Stock.Infrastructure.HTTP;

public sealed class WebApiAdapter : IHTTP
{
    //  DECREMENT STOCK

    private Func<IEnumerable<DecrementStock.Input>, Task>? OnDecrementStockFunction { get; set; }

    void IHTTP.OnDecrementStock(Func<IEnumerable<DecrementStock.Input>, Task> on) => OnDecrementStockFunction = on;

    public async Task DecrementStock(IEnumerable<DecrementStockDTO> increments)
    {
        if (OnDecrementStockFunction is null) throw new Exception("Configure o DecrementStock");

        List<DecrementStock.Input> inputs = new();

        foreach (var increment in increments)
        {
            inputs.Add(new Application.DecrementStock.Input() { ItemId = increment.ItemId, Quantity = increment.Quantity });
        }

        await OnDecrementStockFunction.Invoke(inputs);
    }

    public class DecrementStockDTO
    {
        public Int32 ItemId { get; set; }
        public Int32 Quantity { get; set; }
    }

    // INCREMENT STOCK

    private Func<IEnumerable<IncrementStock.Input>, Task>? OnIncrementStockFunction { get; set; }

    void IHTTP.OnIncrementStock(Func<IEnumerable<IncrementStock.Input>, Task> on) => OnIncrementStockFunction = on;

    public async Task IncrementStock(IEnumerable<IncrementStockDTO> increments)
    {
        if (OnIncrementStockFunction is null) throw new Exception("Configure o IncrementStock");

        List<IncrementStock.Input> inputs = new();

        foreach (var increment in increments)
        {
            inputs.Add(new Application.IncrementStock.Input() { ItemId = increment.ItemId, Quantity = increment.Quantity });
        }

        await OnIncrementStockFunction.Invoke(inputs);
    }

    public class IncrementStockDTO
    {
        public Int32 ItemId { get; set; }
        public Int32 Quantity { get; set; }
    }

    // GET STOCK

    private Func<Int32, Task<Int32>>? OnGetStockFunction { get; set; }

    void IHTTP.OnGetStock(Func<Int32, Task<Int32>> on) => OnGetStockFunction = on;

    public async Task<Int32> GetStock(Int32 itemId)
    {
        if (OnGetStockFunction is null) throw new Exception("Configure o GetStock");

        return await OnGetStockFunction.Invoke(itemId);
    }
}
