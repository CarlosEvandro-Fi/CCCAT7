﻿namespace eCommerce.Application;

public sealed class PreviewOrder
{
	public IItemRepository ItemRepository { get; }

	public PreviewOrder(IItemRepository itemRepository)
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

	public sealed class Input
	{
		public String CPF { get; set; } = "";
		public DateTime Date { get; set; }
		public List<InputItem> OrderItems { get; set; } = new(); // = Array.Empty<(Int32, Int32)>();
	}
	public sealed class InputItem
    {
		public Int32 ItemId { get; set; }
		public Int32 Quantity { get; set; }
    }
	public sealed class Output
	{
		public Decimal Total { get; set; }
	}
}
