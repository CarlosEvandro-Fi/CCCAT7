using ECommerce.Checkout.Application;
using ECommerce.Checkout.Application.Gateway;
using ECommerce.Checkout.Domain;

namespace ECommerce.Checkout.Tests;

public class SimulateFreight_Tests
{

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

    [Fact]
    public async Task Deve_Simular_o_Frete()
    {
        //var connection = new PgPromiseAdapter();
        // var getItemGateway = new GetItemHttpGateway();
        var getItemGateway = new PlaceboGetItemGateway();
        // var calculateFreightGateway = new CalculateFreightHttpGateway();
        var calculateFreightGateway = new CalculateFreightGatewayFake();
		var simulateFreight = new SimulateFreight(getItemGateway, calculateFreightGateway);
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
		//await connection.Close();
	}
    internal class CalculateFreightGatewayFake : ICalculateFreightGateway
    {
        public async Task<ICalculateFreightGateway.Output> Calculate(ICalculateFreightGateway.Input input)
        {
			return new ICalculateFreightGateway.Output() { Total = 202.09M };
        }
    }
}
