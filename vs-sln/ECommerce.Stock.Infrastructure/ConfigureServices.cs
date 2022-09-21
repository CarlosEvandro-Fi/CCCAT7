using ECommerce.Stock.Application;
using ECommerce.Stock.Domain;
using ECommerce.Stock.Infrastructure.Database;
using ECommerce.Stock.Infrastructure.HTTP;
using ECommerce.Stock.Infrastructure.Mediators;
using ECommerce.Stock.Infrastructure.Queue;
using ECommerce.Stock.Infrastructure.Repository.Database;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Stock.Infrastructure;

public static class ConfigureServicesExtension
{
    public static async Task<IServiceCollection> ConfigureServices(this IServiceCollection services)
    {
        services.AddTransient<IMediator, Mediator>();
        services.AddTransient<GetStock>();
        services.AddTransient<IQueryHandler<GetStockQuery, Int32>, GetStockQueryHandler>();

        services.AddSingleton<IHTTP, WebApiAdapter>();
        services.AddSingleton<IConnection, PgPromiseAdapter>();
        services.AddSingleton<IStockEntryRepository, StockEntryRepositoryDatabase>();
        services.AddSingleton<DecrementStock>();
        services.AddSingleton<IncrementStock>();
        services.AddSingleton<IQueue, RabbitMQAdapter>();
        services.AddHostedService<StockQueue>();
        return services;
    }
}
