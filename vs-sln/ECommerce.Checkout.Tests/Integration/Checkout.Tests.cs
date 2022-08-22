using ECommerce.Checkout.Application;
using ECommerce.Checkout.Application.Gateway;
using ECommerce.Checkout.Application.Handler;
using ECommerce.Checkout.Application.Queue;
using ECommerce.Checkout.Domain;
using ECommerce.Checkout.Infrastructure.Database;
using ECommerce.Checkout.Infrastructure.Query;
using ECommerce.Checkout.Infrastructure.Repository.Database;
using System;
using static ECommerce.Checkout.Domain.CheckoutCommand;

namespace ECommerce.Checkout.Tests.Integration;

public class Checkout_Tests
{
    [Fact]
    public async Task Deve_Fazer_um_Pedido()
    {
		var connection = new PgPromiseAdapter();
		var orderRepository = new OrderRepositoryDatabase(connection);
		await orderRepository.Clean();
        // var calculateFreightGateway = new CalculateFreightHttpGateway();
        var calculateFreightGateway = new CalculateFreightGatewayFake();
        // var getItemGateway = new GetItemHttpGateway();
        var getItemGateway = new PlaceboGetItemGateway();
        var decrementStockGateway = new DecrementStockGatewayFake();
        var queue = new QueueFake();
        var guid = Random.Shared.Next(1, 9999999).ToString();
        var checkoutInput = new CheckoutInput
        {
            From = "22060030",
            Guid = guid,
            To = "88015600",
            CPF = "886.634.854-68",
            OrderItems = new List<CheckoutInputItem> // (Int32 ItemId, Int32 Quantity)[]
			{
                new CheckoutInputItem { ItemId = 1, Quantity = 1 },
                new CheckoutInputItem { ItemId = 2, Quantity = 1 },
                new CheckoutInputItem { ItemId = 3, Quantity = 3 },
            },
            Date = new DateTime(2022, 03, 01, 10, 00, 00)
        };
        var checkout = new CheckoutHandler(orderRepository, calculateFreightGateway, decrementStockGateway, getItemGateway, queue);
        await checkout.Execute(checkoutInput);
        // API Composition - acoplamento
        // var getOrder = new GetOrder(orderRepository, getItemGateway);
        // var output = await getOrder.execute(guid);
        // Query - acoplamento
        var orderQuery = new OrderQuery(connection);
        // var getOrder2 = new GetOrder2(orderQuery);
        // var output = await getOrder2.Execute(guid);
        // Assert.Equal(6292.09M, output.Total);
        var orderProjectionHandler = new OrderProjectionHandler(orderQuery, getItemGateway);
        await orderProjectionHandler.Execute(guid);
        var getOrder3 = new GetOrder3(orderQuery);
        var output = await getOrder3.Execute(guid);
        System.Diagnostics.Debug.WriteLine(output.OrderItems);
        await connection.Close();
    }

    internal class CalculateFreightGatewayFake : ICalculateFreightGateway
    {
        public async Task<ICalculateFreightGateway.Output> Calculate(ICalculateFreightGateway.Input input)
        {
            return new ICalculateFreightGateway.Output() { Total = 202.09M };
        }
    }

    internal sealed class PlaceboGetItemGateway : IGetItemGateway
    {
        public async Task<Item> Execute(long itemId)
        {
            List<Item> OrdersItems = new()
            {
                new Item(1, "Guitarra", 1000, 100, 30, 10, 3, 100, 0.03M),
                new Item(2, "Amplificador", 5000, 50, 50, 50, 20, 1, 1),
                new Item(3, "Cabo", 30, 10, 10, 10, 1, 1, 1),
            };

            return OrdersItems.Where(where => where.ItemId == itemId).FirstOrDefault();
        }
    }

    internal class DecrementStockGatewayFake : IDecrementStockGateway
    {
        public async Task Decrement(IDecrementStockGateway.Input input)
        {
            await Task.CompletedTask;
        }
    }

    internal class QueueFake : IQueue
    {
        public async Task Close()
        {
            await Task.CompletedTask;
        }

        public async Task Connect()
        {
            await Task.CompletedTask;
        }

        public async Task Consume<T>(string eventName, Func<T, Task> callback)
        {
            await Task.CompletedTask;
        }

        public void Dispose()
        {
            
        }

        public async Task Publish(DomainEvent domainEvent)
        {
            await Task.CompletedTask;
        }
    }
}
