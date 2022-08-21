namespace ECommerce.Checkout.Domain;

public sealed class CheckoutCommand : DomainEvent
{
	public CheckoutInput Input { get; }

    public String Name { get; } = "Checkout";

    public CheckoutCommand(CheckoutInput input)
	{
        Input = input;
    }

    public sealed class CheckoutInput
    {
        public String Guid { get; set; } = "";
        public String From { get; set; } = "";
        public String To { get; set; } = "";
        public String CPF { get; set; } = "";
        public DateTime Date { get; set; }
        public IEnumerable<CheckoutInputItem> OrderItems { get; set; } = Enumerable.Empty<CheckoutInputItem>();
    }
    public sealed class CheckoutInputItem
    {
        public Int64 ItemId { get; set; }
        public Int32 Quantity { get; set; }
    }
}
