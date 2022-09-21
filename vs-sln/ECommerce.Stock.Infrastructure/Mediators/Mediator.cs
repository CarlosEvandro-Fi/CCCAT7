using ECommerce.Stock.Application;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Stock.Infrastructure.Mediators;

public sealed class Mediator : IMediator
{
    private readonly IServiceProvider ServiceProvider;

    public Mediator(IServiceProvider provider) => ServiceProvider = provider;

    Task<TResponse> ICommandSender.Send<TCommand, TResponse>(TCommand command, CancellationToken cancellation)
        //where TCommand : ICommand<TResponse>
    {
        var handler = ServiceProvider.GetRequiredService<ICommandHandler<TCommand, TResponse>>();
        return handler.Handle(command, cancellation);
    }

    Task<TResponse> IQuerySender.Send<TQuery, TResponse>(TQuery query, CancellationToken cancellation)
        //where TQuery : IQuery<TResponse>
    {
        var handler = ServiceProvider.GetRequiredService<IQueryHandler<TQuery, TResponse>>();
        return handler.Handle(query, cancellation);
    }
}