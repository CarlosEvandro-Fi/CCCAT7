using ECommerce.Stock.Application;
using ECommerce.Stock.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerce.Stock.Infrastructure.Queue;

public sealed class StockQueue : BackgroundService
{
    public IQueue Queue { get; }

    public IServiceProvider ServiceProvider { get; }

    public StockQueue(IServiceProvider iServiceProvider, IQueue iQueue)
    {
        ServiceProvider = iServiceProvider;
        Queue = iQueue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Queue.Consume<OrderPlaced>("OrderPlaced", async (OrderPlaced orderPlaced) =>
        {
            using var scope = ServiceProvider.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            var decremets = new List<DecrementStockDTO>();
            foreach (var item in orderPlaced.OrderItems)
            {
                decremets.Add(new DecrementStockDTO() { ItemId = item.ItemId, Quantity = item.Quantity });
            }
            var decrementCommand = new DecrementStockCommand(decremets);
            await mediator.Send(decrementCommand, default);
        });
    }

    public override async Task StartAsync(CancellationToken cancellationToken)
    {
        await Queue.Connect();

        await base.StartAsync(cancellationToken);
    }

    public override async Task StopAsync(CancellationToken cancellationToken)
    {
        await Queue.Close();

        await base.StopAsync(cancellationToken);
    }
}