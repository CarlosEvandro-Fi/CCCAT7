namespace ECommerce.Catalog.Application;

public sealed class ItemDTO
{
    public String Description { get; }
    public Int64 ItemId { get; }
    public Decimal Price { get; }
    public Decimal Height { get; } // cm
    public Decimal Lenght { get; } // cm
    public Decimal Weight { get; } // kg
    public Decimal Width { get; } // cm
    public Decimal Density { get; } // kg/m3
    public Decimal Volume { get; } // m3

    public ItemDTO(Int64 itemId, String description, Decimal price, Decimal width, Decimal height, Decimal lenght, Decimal weight, Decimal density, Decimal volume)
    {
        Description = description;
        ItemId = itemId;
        Price = price;
        Width = width;
        Height = height;
        Lenght = lenght;
        Weight = weight;
        Density = density;
        Volume = volume;
    }

    public static ItemDTO FromItem(Item item)
        => new(
            item.ItemId,
            item.Description,
            item.Price,
            item.Dimension.Width,
            item.Dimension.Height,
            item.Dimension.Lenght,
            item.Dimension.Weight,
            item.Dimension.GetDensity(),
            item.Dimension.GetVolume());
}
