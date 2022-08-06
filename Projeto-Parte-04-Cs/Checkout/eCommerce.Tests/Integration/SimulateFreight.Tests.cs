using eCommerce.Application;
using eCommerce.Application.Gateway;
using eCommerce.Infrastructure.Database;
using eCommerce.Infrastructure.Repository.Database;

namespace eCommerce.Tests;

public class SimulateFreight_Tests
{
    [Fact]
    public async Task Deve_Simular_o_Frete()
    {
		var connection = new PgPromiseAdapter();
		var itemRepository = new ItemRepositoryDatabase(connection);
		// var calculateFreightGateway = new CalculateFreightHttpGateway();
		var calculateFreightGateway = new CalculateFreightGatewayFake();
		var simulateFreight = new SimulateFreight(itemRepository, calculateFreightGateway);
		var output = await simulateFreight.Execute(
			new SimulateFreight.Input()
			{
				From = "22060030",
				To = "88015600",
				OrderItems = new List<SimulateFreight.OrderItem>
				{
					new SimulateFreight.OrderItem { ItemId = 1, Quantity = 1 },
					new SimulateFreight.OrderItem { ItemId = 2, Quantity = 1 },
					new SimulateFreight.OrderItem { ItemId = 3, Quantity = 3 },
				},
			});
		Assert.Equal(202.09M, output.Total);
		await connection.Close();

	}
    internal class CalculateFreightGatewayFake : ICalculateFreightGateway
    {
        public async Task<ICalculateFreightGateway.Output> Calculate(ICalculateFreightGateway.Input input)
        {
			return new ICalculateFreightGateway.Output() { Total = 202.09M };
        }
    }
}
