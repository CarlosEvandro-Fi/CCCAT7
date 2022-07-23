namespace AulaLib;

public sealed class Item
{
    public String Description { get; }
    public Int64 ItemId { get; }
    public Decimal Price { get; }

    public Item(Int64 itemId, String description, Decimal price)
    {
        Description = description;
        ItemId = itemId;
        Price = price;
    }
}
