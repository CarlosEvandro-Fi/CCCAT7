using ECommerce.Checkout.Application;
using ECommerce.Checkout.Infrastructure.Database;
using ECommerce.Checkout.Infrastructure.Repository.Database;

namespace ECommerce.Checkout.Tests;

public class PreviewOrder_Tests
{
    [Fact]
    public async Task Deve_Simular_um_Pedido()
    {
		var connection = new PgPromiseAdapter();
		var itemRepository = new ItemRepositoryDatabase(connection);
		var orderRepository = new OrderRepositoryDatabase(connection);
		await orderRepository.Clean();
		var checkout = new Checkouting(itemRepository, orderRepository);
		var output = await checkout.Execute(
			new Checkouting.Input
			{
				CPF = "886.634.854-68",
				OrderItems = new (Int32 ItemId, Int32 Quantity)[]
				{
					new(1, 1),
					new(2, 1),
					new(3, 3)
				},
				Date = new DateTime(2022, 03, 01, 10, 00, 00)
			}
		);
		Assert.Equal(6090, output.Total);
		await connection.Close();
	}
}
