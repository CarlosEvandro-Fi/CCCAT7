using eCommerce.Application.Gateway;

namespace eCommerce.Application;

public sealed class SimulateFreight
{
	public ICalculateFreightGateway CalculateFreightGateway { get; }

	public IItemRepository ItemRepository { get; }

	public SimulateFreight(IItemRepository itemRepository, ICalculateFreightGateway calculateFreightGateway)
	{
		ItemRepository = itemRepository;
		CalculateFreightGateway = calculateFreightGateway;
	}

	public async Task<Output> Execute(Input input)
	{
		var orderItems = new List<ICalculateFreightGateway.OrderItem>();
		foreach (var orderItem in input.OrderItems)
		{
			var item = await ItemRepository.GetItem(orderItem.ItemId);
			orderItems.Add(new() { Volume = item.GetVolume(), Density = item.GetDensity(), Quantity = orderItem.Quantity });
		}
		var output = await CalculateFreightGateway.Calculate(new ICalculateFreightGateway.Input { From = input.From, To = input.To, OrderItems = orderItems });
		return new Output { Total = output.Total };
	}

	public sealed class Input
	{
		public String From { get; set; } = "";
		public String To { get; set; } = "";
		public IEnumerable<OrderItem> OrderItems { get; set; } = Array.Empty<OrderItem>();
	}

	public sealed class OrderItem
	{
		public Int32 ItemId { get; set; }
		public Int32 Quantity { get; set; }
	}

	public sealed class Output
	{
		public Decimal Total { get; set; }
	}
}
