﻿using ECommerce.Checkout.Application.Gateway;

namespace ECommerce.Checkout.Application;

public sealed class SimulateFreight
{
	public ICalculateFreightGateway CalculateFreightGateway { get; }

	public IGetItemGateway GetItemGateway { get; }

	public SimulateFreight(IGetItemGateway getItemGateway, ICalculateFreightGateway calculateFreightGateway)
	{
        GetItemGateway = getItemGateway;
		CalculateFreightGateway = calculateFreightGateway;
	}

	public async Task<Output> Execute(Input input)
	{
		var orderItems = new List<ICalculateFreightGateway.OrderItem>();
		foreach (var orderItem in input.OrderItems)
		{
			var item = await GetItemGateway.Execute(orderItem.ItemId);
			orderItems.Add(new() { Volume = item.Volume, Density = item.Density, Quantity = orderItem.Quantity });
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
