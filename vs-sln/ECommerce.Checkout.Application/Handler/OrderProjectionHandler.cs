using ECommerce.Checkout.Application.Gateway;
using ECommerce.Checkout.Application.Query;
using ECommerce.Checkout.Domain;
using static ECommerce.Checkout.Domain.CheckoutCommand;

namespace ECommerce.Checkout.Application.Handler;

public sealed class OrderProjectionHandler
{
	private IOrderQuery OrderQuery { get; }

	private IGetItemGateway GetItemGateway { get; }

    public OrderProjectionHandler(IOrderQuery orderQuery, IGetItemGateway getItemGateway)
	{
		OrderQuery = orderQuery;
		GetItemGateway = getItemGateway;
	}

	public async Task Execute(CheckoutInput input)
	{
		var order = await OrderQuery.GetByGuid2(input.Guid);
		foreach (var orderItem in order.OrderItems)
		{
			var item = await GetItemGateway.Execute(orderItem.ItemId);
			orderItem.Description = item.Description;
		}
		await OrderQuery.SaveOrderProjection(input.Guid, order);
	}
}
