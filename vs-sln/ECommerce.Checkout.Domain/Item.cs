namespace ECommerce.Checkout.Domain;

public sealed class Item
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

    public Item(Int64 itemId, String description, Decimal price, Decimal width = 0, Decimal height = 0, Decimal lenght = 0, Decimal weight = 0, Decimal density = 0, Decimal volume = 0)
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

    public OrderItem CreateOrderItem(Int32 quantity)
    {
        return new OrderItem(ItemId, Price, quantity);
    }
}