﻿namespace eCommerce.Infrastructure.Repository.Memory;

public sealed class OrderRepositoryMemory : IOrderRepository
{
    public Connection Connection { get; }

    public OrderRepositoryMemory(Connection connection)
    {
        Connection = connection;
    }

    private readonly List<Order> Orders = new();
    private readonly List<OrderItem> OrdersItems = new();
    //{
    //    new Item(1, "Guitarra", 1000, new Dimension(100, 30, 10, 3)),
    //    new Item(1, "Guitarra", 5000, new Dimension(50, 50, 50, 20)),
    //    new Item(1, "Guitarra", 30, new Dimension(10, 10, 10, 1)),
    //};

    public async Task<int> Count()
    {
        return Orders.Count();
    }

    public async Task Save(Order order)
    {
        Orders.Add(order);
        foreach (var orderItem in order.Items)
        {
            OrdersItems.Add(orderItem);
        }
        await Task.CompletedTask;
    }

    public async Task Clean()
    {
        await Task.CompletedTask;
    }
}
