namespace eCommerce.Application.Gateway;

public interface ICalculateFreightGateway
{
    Task<Output> Calculate(Input input);

	public sealed class Input
	{
		public String From { get; set; } = "";
		public String To { get; set; } = "";
		public List<OrderItem> OrderItems { get; set; } = new();
	}

	public sealed class OrderItem
	{
		public Decimal Density { get; set; }
		public Int32 Quantity { get; set; }
		public Decimal Volume { get; set; }
	}

	public sealed class Output
	{
		public Decimal Total { get; set; }
	}
}
