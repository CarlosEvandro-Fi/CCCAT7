using eCommerce.Application;
using eCommerce.Infrastructure.Database;
using eCommerce.Infrastructure.Repository.Database;

namespace eCommerce.Tests;

public class Checkout_Tests
{
    [Fact]
    public async Task Deve_Fazer_um_Pedido()
    {
		var connection = new PgPromiseAdapter();
		var itemRepository = new ItemRepositoryDatabase(connection);
		var orderRepository = new OrderRepositoryDatabase(connection);
		await orderRepository.Clean();
		var checkout = new Checkout(itemRepository, orderRepository);
		var output = await checkout.Execute(
			new Checkout.Input
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
		Assert.Equal(6350, output.Total);
		Assert.Equal("202200000001", output.Code);
		await connection.Close();
	}
}
