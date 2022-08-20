using ECommerce.Stock.Application;
using ECommerce.Stock.Domain;

namespace ECommerce.Stock.Infrastructure.Queue;

public sealed class StockQueue
{
    public StockQueue(IQueue queue, DecrementStock decrementStock)
    {
		queue.Consume<OrderPlaced>("OrderPlaced", async (OrderPlaced input) =>
        {
            await decrementStock.Execute(input.OrderItems);
        });
	}
}
