namespace ECommerce.Stock.Application;

public sealed class DecrementStockCommand : ICommand
{
    public IEnumerable<DecrementStockDTO> Values { get; }

	public DecrementStockCommand(IEnumerable<DecrementStockDTO> orderItems)
	{
		Values = orderItems;
	}
}

public sealed class DecrementStockCommandHandler : ICommandHandler<DecrementStockCommand>
{
	public DecrementStock DecrementStock { get; }

	public DecrementStockCommandHandler(DecrementStock decrementStock)
	{
		DecrementStock = decrementStock;
    }

    public async Task Handle(DecrementStockCommand command, CancellationToken cancellation)
	{
		await DecrementStock.Execute(command.Values);
    }
}