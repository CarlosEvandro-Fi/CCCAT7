using ECommerce.Checkout.Application.Handler;
using ECommerce.Checkout.Application.Queue;
using ECommerce.Checkout.Domain;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ECommerce.Checkout.Infrastructure.Queue;

public sealed class CheckoutQueue : BackgroundService
{
    public IQueue Queue { get; }

    public IServiceProvider ServiceProvider { get; }

    public CheckoutQueue(IServiceProvider iServiceProvider, IQueue iQueue)
    {
        ServiceProvider = iServiceProvider;
        Queue = iQueue;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await Queue.Consume<CheckoutCommand>("Checkout", async (CheckoutCommand command) =>
        {
            if (command is null || command.Input is null) return;

            var checkoutHandler = ServiceProvider.GetRequiredService<CheckoutHandler>();
            var orderProjectionHandler = ServiceProvider.GetRequiredService<OrderProjectionHandler>();
            // command.Input.Date = new Date(input.input.date); // *** ERA PARA CORRIGIR A DATA QUE FICAVA COMO STRING
            await checkoutHandler.Execute(command.Input);
            // outro lugar consumindo este evento
            await orderProjectionHandler.Execute(command.Input);
        });

        // TESTE
        //var IncrementStock = ServiceProvider.GetRequiredService<IncrementStock>();
        //await IncrementStock.Execute(new IncrementStock.Input[] { new IncrementStock.Input() { ItemId = 1, Quantity = 100 } });
        //await Queue.Publish(new OrderPlaced("1", new OrderItem[] { new(1, 1) }));
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