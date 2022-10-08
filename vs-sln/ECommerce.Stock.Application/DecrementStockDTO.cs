namespace ECommerce.Stock.Application;

public sealed class DecrementStockDTO
{
    public Int64 ItemId { get; set; }
    public Int32 Quantity { get; set; }
}
