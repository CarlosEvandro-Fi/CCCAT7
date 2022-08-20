namespace eCommerce.Application.Gateway;

public interface IDecrementStockGateway
{
    Task Decrement(Input input);

    public class Input
    {
        public Int32 ItemId { get; set; }
        public Int32 Quantity { get; set; }
    }
}
