using ECommerce.Stock.Application;
using ECommerce.Stock.Domain;
using ECommerce.Stock.Infrastructure.Database;
using ECommerce.Stock.Infrastructure.Queue;
using ECommerce.Stock.Infrastructure.Repository.Database;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Stock.Infrastructure;

public static class ConfigureServicesExtension
{
    public static IServiceCollection ConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<GetStock>();
        services.AddTransient<IQueryHandler<GetStockQuery, Int32>, GetStockQueryHandler>();
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
}
