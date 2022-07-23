namespace AulaLib;

public sealed class OrderItem
{
    public Int64 ItemId { get; }
    public Decimal Price { get; }
    public Int32 Quantity { get; }

    public OrderItem(Int64 itemId, Decimal price, Int32 quantity)
    {
        ItemId = itemId;
        Price = price;
        Quantity = quantity;
        if (Quantity <= 0) throw new Exception("Invalid Quantity.");
    }

    public Decimal GetTotal() => Price * Quantity;
}
