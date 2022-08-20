namespace ECommerce.Stock.Domain;

public sealed class OrderItem
{
    public Int64 ItemId { get; }
    public Int32 Quantity { get; }

    public OrderItem(Int64 itemId, Int32 quantity)
    {
        ItemId = itemId;
        Quantity = quantity;
        if (Quantity <= 0) throw new Exception("Invalid Quantity.");
    }
}
