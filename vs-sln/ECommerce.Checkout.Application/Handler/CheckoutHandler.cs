using ECommerce.Checkout.Application.Gateway;
using ECommerce.Checkout.Application.Queue;
using static ECommerce.Checkout.Domain.CheckoutCommand;
using static ECommerce.Checkout.Domain.OrderPlaced;

namespace ECommerce.Checkout.Application.Handler;

public sealed class CheckoutHandler
{
    private IOrderRepository OrderRepository { get; }

    private ICalculateFreightGateway CalculateFreightGateway { get; }

    private IDecrementStockGateway DecrementStockGateway { get; }

    private IGetItemGateway GetItemGateway { get; }

    private IQueue Queue { get; }

    public CheckoutHandler(
        IOrderRepository orderRepository,
        ICalculateFreightGateway calculateFreightGateway,
        IDecrementStockGateway decrementStockGateway,
        IGetItemGateway getItemGateway,
        IQueue queue 
	)
    {
        OrderRepository = orderRepository;
        CalculateFreightGateway = calculateFreightGateway;
        DecrementStockGateway = decrementStockGateway;
        GetItemGateway = getItemGateway;
        Queue = queue;
	}

	public async Task Execute(CheckoutInput input)
    {
		var sequence = await OrderRepository.Count() + 1;
        var order = new Order(input.CPF, input.Date, sequence);
        order.SetGuid(input.Guid);
		var orderItemsFreight = new List<ICalculateFreightGateway.OrderItem>();
        var orderItemsStock = new List<OrderItemPlaced>();
		foreach (var orderItem in input.OrderItems)
        {
		    var item = await GetItemGateway.Execute(orderItem.ItemId);
            order.AddItem(item, orderItem.Quantity);
            orderItemsFreight.Add(
                new ICalculateFreightGateway.OrderItem()
                {
                    Density = item.Density,
                    Quantity = orderItem.Quantity,
                    Volume = item.Volume,
                });
            orderItemsStock.Add(
                new OrderItemPlaced()
                {
                    ItemId = orderItem.ItemId,
                    Quantity = orderItem.Quantity,
                });
	    }
	    var freight = await CalculateFreightGateway.Calculate(
            new ICalculateFreightGateway.Input()
            {
                From = input.From,
                To = input.To,
                OrderItems = orderItemsFreight
            }
        );
        order.SetFreight(freight.Total);
        await OrderRepository.Save(order);
        await Queue.Publish(new OrderPlaced(order.GetCode(), orderItemsStock));
	}


    //public sealed class Input
    //{
    //    public String Guid { get; set; } = "";
    //    public String From { get; set; } = "";
    //    public String To { get; set; } = "";
    //    public String CPF { get; set; } = "";
    //    public DateTime Date { get; set; }
    //    public IEnumerable<InputItem> OrderItems { get; set; } = Enumerable.Empty<InputItem>();
    //}
    //public sealed class InputItem
    //{
    //    public Int64 ItemId { get; set; }
    //    public Int32 Quantity { get; set; }
    //}
}
