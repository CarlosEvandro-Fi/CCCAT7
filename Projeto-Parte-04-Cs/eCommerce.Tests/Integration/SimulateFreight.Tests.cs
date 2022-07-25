using eCommerce.Application;
using eCommerce.Infrastructure.DB;
using eCommerce.Infrastructure.Repository.DB;

namespace eCommerce.Tests;

public class SimulateFreight_Tests
{
    [Fact]
    public async Task Deve_Simular_o_Frete()
    {
		var connection = new PgPromiseAdapter();
		var itemRepository = new ItemRepositoryDatabase(connection);
		var simulateFreight = new SimulateFreight(itemRepository);
		var output = await simulateFreight.Execute(
			new SimulateFreight.Input()
			{
				OrderItems = new (Int32 ItemId, Int32 Quantity)[]
				{
						new(1, 1),
						new(2, 1),
						new(3, 3)
				},
			});
		Assert.Equal(260, output.Total);
		await connection.Close();
	}
}
