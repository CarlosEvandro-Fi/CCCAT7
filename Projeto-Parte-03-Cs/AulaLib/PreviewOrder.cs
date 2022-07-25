namespace AulaLib;

public class PreviewOrder
{
	public ItemRepository ItemRepository { get; }

	public PreviewOrder(ItemRepository itemRepository)
	{
		ItemRepository = itemRepository;
	}

	public async Task<Output> Execute(Input input)
	{
		var order = new Order(input.CPF);
		foreach (var orderItem in input.OrderItems)
		{
			var item = await this.ItemRepository.GetItem(orderItem.ItemId);
			order.AddItem(item, orderItem.Quantity);
		}
		var total = order.GetTotal();
		return new Output { Total = total };
	}

	public class Input
	{
		public String CPF { get; set; } = "";
		public DateTime Date { get; set; }
		public (Int32 ItemId, Int32 Quantity)[] OrderItems { get; set; } = Array.Empty<(Int32, Int32)>();
	}
	public class Output
	{
		public Decimal Total { get; set; }
	}
}
