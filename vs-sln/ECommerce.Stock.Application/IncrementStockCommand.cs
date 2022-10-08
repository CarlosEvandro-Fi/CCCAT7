namespace ECommerce.Stock.Application;

public sealed class IncrementStockCommand : ICommand
{
    public IEnumerable<IncrementStockDTO> Values { get; }

    public IncrementStockCommand(IEnumerable<IncrementStockDTO> values)
    {
        foreach (var entry in values)
        {
            if (entry.ItemId <= 0) throw new Exception("ItemId Inválido.");
            if (entry.Quantity <= 0) throw new Exception("Quantity Inválido.");
        }
        Values = values;
    }
}

public sealed class IncrementStockCommandHandler : ICommandHandler<IncrementStockCommand>
{
    public IncrementStock IncrementStock { get; }

    public IncrementStockCommandHandler(IncrementStock incrementStock)
    {
        IncrementStock = incrementStock;
    }

    public async Task Handle(IncrementStockCommand command, CancellationToken cancellation)
    {
        await IncrementStock.Execute(command.Values);
    }
}