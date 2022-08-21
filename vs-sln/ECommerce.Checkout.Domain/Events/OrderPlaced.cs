namespace ECommerce.Checkout.Domain;

public sealed class OrderPlaced : DomainEvent
{
	public String Code { get; }

    public String Name { get; } = "OrderPlaced";

	public IEnumerable<OrderItemPlaced> OrderItems { get; }

    public OrderPlaced(String code, IEnumerable<OrderItemPlaced> orderItems)
	{
		Code = code;
		OrderItems = orderItems;
	}

	public sealed class OrderItemPlaced
    {
		public Int64 ItemId { get; set; }

		public Int32 Quantity { get; set; }
	}
}
