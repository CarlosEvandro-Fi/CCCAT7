namespace eCommerce.Domain;

public sealed class Item
{
    public String Description { get; }
    public Dimension Dimension { get; }
    public Int64 ItemId { get; }
    public Decimal Price { get; }

    public Item(Int64 itemId, String description, Decimal price, Dimension? dimension = null)
    {
        Description = description;
        ItemId = itemId;
        Price = price;
        Dimension = dimension ?? new Dimension(0,0,0,0);
    }

    public Decimal GetDensity() => Dimension.GetDensity();

    public Decimal GetVolume() => Dimension.GetVolume();
}
