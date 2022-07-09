namespace Aula02Lib;

public sealed class OrderItem
{
    public Int64 ItemId { get; set; }
    public Decimal Price { get; set; }
    public Int32 Quantity { get; set; }

    public OrderItem(Int64 itemId, Decimal price, Int32 quantity)
    {
        ItemId = itemId;
        Price = price;
        Quantity = quantity;
    }

    public Decimal GetTotal() => Price * Quantity;
}
