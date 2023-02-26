namespace ECommerce.Stock.Domain;

public interface ICommand
{ }

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
	Task Handle(TCommand command, CancellationToken cancellation);
}

public interface ICommand<out TResponse>
{ }

public interface ICommandHandler<in TCommand, TResponse> where TCommand : ICommand<TResponse>
{
	Task<TResponse> Handle(TCommand command, CancellationToken cancellation);
}