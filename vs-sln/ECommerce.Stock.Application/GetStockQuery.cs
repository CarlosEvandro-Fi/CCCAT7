namespace ECommerce.Stock.Application;

public sealed class GetStockQuery : IQuery<Int32>
{
    public Int32 ItemId { get; }

    public GetStockQuery(Int32 itemId)
    {
        if (itemId <= 0) throw new Exception("ItemId Inválido.");
        ItemId = itemId;
    }
}

public sealed class GetStockQueryHandler : IQueryHandler<GetStockQuery, Int32>
{
    public GetStock GetStock { get; }

    public GetStockQueryHandler(GetStock getStock) => GetStock = getStock;

    public async Task<Int32> Handle(GetStockQuery query, CancellationToken cancellation)
    {
        return await GetStock.Execute(query.ItemId);
    }
}