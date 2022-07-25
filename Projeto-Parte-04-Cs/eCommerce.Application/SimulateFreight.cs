namespace eCommerce.Application;

public sealed class SimulateFreight
{
	public IItemRepository ItemRepository { get; }

	public SimulateFreight(IItemRepository itemRepository)
	{
		ItemRepository = itemRepository;
	}

	public async Task<Output> Execute(Input input)
	{
		decimal total = 0;
		foreach (var orderItem in input.OrderItems) {
			var item = await this.ItemRepository.GetItem(orderItem.ItemId);
			total += FreightCalculator.Calculate(item) * orderItem.Quantity;
		}
		return new Output { Total = total };
	}

	public sealed class Input
	{
		public (Int32 ItemId, Int32 Quantity)[] OrderItems { get; set; } = Array.Empty<(Int32, Int32)>();
	}
	public sealed class Output
	{
		public Decimal Total { get; set; }
	}
}
