namespace ECommerce.Stock.Application;

public sealed class IncrementStockDTO
{
    public Int64 ItemId { get; set; }
    public Int32 Quantity { get; set; }
}
