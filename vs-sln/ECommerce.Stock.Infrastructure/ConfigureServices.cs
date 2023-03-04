using ECommerce.Stock.Application;
using ECommerce.Stock.Domain;
using ECommerce.Stock.Infrastructure.Database;
using ECommerce.Stock.Infrastructure.Queue;
using ECommerce.Stock.Infrastructure.Repository.Database;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ECommerce.Stock.Infrastructure;

public static class ConfigureServicesExtension
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<GetStock>();
		// services.AddTransient<IQueryHandler<GetStockQuery, Int32>, GetStockQueryHandler>();
		// services.AddTransient<IGetStockQueryHandler, GetStockQueryHandler>();
		services.AddQueryHandler<GetStockQueryHandler, GetStockQuery, Int32>();

		services.AddTransient<IncrementStock>();
        services.AddTransient<ICommandHandler<IncrementStockCommand>, IncrementStockCommandHandler>();
        services.AddTransient<DecrementStock>();
        services.AddTransient<ICommandHandler<DecrementStockCommand>, DecrementStockCommandHandler>();
        services.AddSingleton<IConnection, PgPromiseAdapter>();
        services.AddSingleton<IStockEntryRepository, StockEntryRepositoryDatabase>();
        services.AddSingleton<IQueue, RabbitMQAdapter>();
        services.AddHostedService<StockQueue>();
        return services;
    }

	public static IServiceCollection AddQueryHandler<TQueryHandler, TQuery, TResponse>(this IServiceCollection services)
			where TQuery : IQuery<TResponse>
			where TQueryHandler : class, IQueryHandler<TQuery, TResponse>
	{
		services.AddTransient<TQueryHandler>();
		services.AddTransient<IQueryHandler<TQuery, TResponse>>(x =>
			new QueryHandlerDecorator<TQuery, TResponse>(x.GetService<TQueryHandler>()));
		return services;
	}
}
