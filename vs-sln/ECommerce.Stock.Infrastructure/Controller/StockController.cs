using ECommerce.Stock.Application;
using ECommerce.Stock.Infrastructure.HTTP;

namespace ECommerce.Stock.Infrastructure.Controller;

public sealed class StockController
{
    public StockController(IHTTP http, IncrementStock incrementStock, DecrementStock decrementStock, GetStock getStock)
    {
        http.OnIncrementStock(
            async (inputs) =>
            {
                await incrementStock.Execute(inputs);
            });

        http.OnDecrementStock(
            async (inputs) =>
            {
                await decrementStock.Execute(inputs);
            });

        http.OnGetStock(
            async (itemId) =>
            {
                return await getStock.Execute(itemId);
            });
    }
}
