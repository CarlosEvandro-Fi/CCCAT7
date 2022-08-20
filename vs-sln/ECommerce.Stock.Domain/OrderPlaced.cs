namespace ECommerce.Stock.Domain;

public sealed class OrderPlaced : DomainEvent
{
	public String Code { get; }

    public String Name { get; } = "OrderPlaced";

	public IEnumerable<OrderItem> OrderItems { get; }

    public OrderPlaced(String code, IEnumerable<OrderItem> orderItems)
	{
		Code = code;
		OrderItems = orderItems;
	}
}
