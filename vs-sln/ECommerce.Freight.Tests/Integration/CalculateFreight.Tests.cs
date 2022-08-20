using ECommerce.Freight.Application;
using ECommerce.Freight.Infrastructure.Database;
using ECommerce.Freight.Infrastructure.Repository.Database;
using static ECommerce.Freight.Application.CalculateFreight;

namespace ECommerce.Freight.Tests.Integration;

public class CalculateFreight_Tests
{
	[Fact]
	public async Task Deve_Calcular_o_Frete_Entre_Dois_Ceps()
	{
		var input = new CalculateFreight.Input()
		{
			From = "22060030",
			To = "88015600",
			OrderItems = new List<OrderItem>()
			{
				new OrderItem()
				{
					Volume = 0.03,
					Density = 100,
					Quantity = 1,
				}
			},
		};
		var connection = new PgPromiseAdapter();
		var cityRepository = new CityRepositoryDatabase(connection);
		var calculateFreight = new CalculateFreight(cityRepository);
		var output = await calculateFreight.Execute(input);
		Assert.Equal(22.45M, output.Total);
		await connection.Close();
	}
}
