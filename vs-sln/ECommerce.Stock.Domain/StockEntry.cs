namespace ECommerce.Stock.Domain;

public enum Operation
{
    IN, OUT
}

public sealed class StockEntry
{
    public Int32 ItemId { get; private set; }

    public Operation Operation { get; private set; }

    public Int32 Quantity { get; private set; }

    public StockEntry(Int32 itemId, Operation operation, Int32 quantity)
    {
        ItemId = itemId;
        Operation = operation;
        Quantity = quantity;
    }
}
