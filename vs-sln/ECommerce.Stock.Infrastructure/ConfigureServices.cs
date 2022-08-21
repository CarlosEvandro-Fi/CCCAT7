using ECommerce.Stock.Application;
using ECommerce.Stock.Domain;
using ECommerce.Stock.Infrastructure.Database;
using ECommerce.Stock.Infrastructure.HTTP;
using ECommerce.Stock.Infrastructure.Queue;
using ECommerce.Stock.Infrastructure.Repository.Database;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Stock.Infrastructure;

public static class ConfigureServicesExtension
{
    public static async Task<IServiceCollection> ConfigureServices(this IServiceCollection services)
    {
        services.AddSingleton<IHTTP, WebApiAdapter>();

        services.AddSingleton<IConnection, PgPromiseAdapter>();

        services.AddSingleton<IStockEntryRepository, StockEntryRepositoryDatabase>
            (
            (provider) => new StockEntryRepositoryDatabase(provider.GetRequiredService<IConnection>())
            );

        services.AddSingleton<DecrementStock>
            (
            (provider) => new DecrementStock(provider.GetRequiredService<IStockEntryRepository>())
            );

        var connection = new PgPromiseAdapter();
        var stockEntryRepositoryDatabase = new StockEntryRepositoryDatabase(connection);
        var decrementStock = new DecrementStock(stockEntryRepositoryDatabase);
        var queue = new RabbitMQAdapter();
        _ = new StockQueue(queue, decrementStock);
        await queue.Connect();

        return services;
    }
}
