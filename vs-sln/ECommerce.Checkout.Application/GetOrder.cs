using ECommerce.Checkout.Application.Gateway;

namespace ECommerce.Checkout.Application;

public sealed class GetOrder
{
	private IGetItemGateway GetItemGateway { get; }

    private IOrderRepository OrderRepository { get; }

    public GetOrder(IOrderRepository orderRepository, IGetItemGateway getItemGateway)
	{
		OrderRepository = orderRepository;
        GetItemGateway = getItemGateway;
    }

	public async Task<Output> Execute(string guid)
	{
		var order = await OrderRepository.GetByGuid(guid);
		var items = new List<OutputItem>();
		foreach (var orderItem in order.Items)
		{
			var item = await GetItemGateway.Execute(orderItem.ItemId);
            items.Add(
				new OutputItem
				{
					ItemId = orderItem.ItemId,
					Description = item.Description,
					Price = orderItem.Price,
					Quantity = orderItem.Quantity
				});
        }
        var output = new Output
        {
            Total = order.GetTotal(),
            OrderItems = items,
        };
		return output;
	}

	public sealed class Output
	{
		public Decimal Total { get; set; }

		public IEnumerable<OutputItem> OrderItems { get; set; } = Enumerable.Empty<OutputItem>();
	}

	public sealed class OutputItem
	{
		public Int64 ItemId { get; set; }
		public String Description { get; set; } = "";
		public Decimal Price { get; set; }
		public Int32 Quantity { get; set; }
	}
}
