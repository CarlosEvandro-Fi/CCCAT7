namespace ECommerce.Stock.Application;

public interface IMediator : IQuerySender, ICommandSender
{ }

public interface ICommand
{ }

public interface ICommand<out TResponse>
{ }

public interface ICommandHandler<in TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    Task<TResponse> Handle(TCommand command, CancellationToken cancellation);
}
public interface ICommandHandler<in TCommand>
    where TCommand : ICommand
{
    Task Handle(TCommand command, CancellationToken cancellation);
}

public interface ICommandSender
{
    Task Send<TCommand>(TCommand command, CancellationToken cancellation)
        where TCommand : ICommand;

    Task<TResponse> Send<TCommand, TResponse>(TCommand command, CancellationToken cancellation)
        where TCommand : ICommand<TResponse>;
}

public interface IQuery<out TResponse>
{ }

public interface IQueryHandler<in TQuery, TResponse>
    where TQuery : IQuery<TResponse>
{
    Task<TResponse> Handle(TQuery query, CancellationToken cancellation);
}

public interface IQuerySender
{
    Task<TResponse> Send<TQuery, TResponse>(TQuery query, CancellationToken cancellation)
        where TQuery : IQuery<TResponse>;
}