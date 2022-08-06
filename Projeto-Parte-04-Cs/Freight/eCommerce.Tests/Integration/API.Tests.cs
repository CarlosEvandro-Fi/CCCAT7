using eCommerce.Application;
using System.Net.Http.Json;
using Testing.API.WebFactory;
using static eCommerce.Application.CalculateFreight;
using static eCommerce.Infrastructure.HTTP.WebApiAdapter;

namespace eCommerce.Tests.Integration;

public class API_Tests : IClassFixture<Api>
{
    private Api Api { get; }

    public API_Tests(Api api) => Api = api;

    [Fact]
    public async Task Deve_Calcular_o_Frete()
    {
        var api = Api.GetApiHttpClient(bearerToken: "");
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
		var response = await api.PostAsJsonAsync("api/Freight/CalculateFreight", input, default);
        Assert.True(response.IsSuccessStatusCode);
        var output = await response.Content.ReadFromJsonAsync<CalculateFreightResponseDTO>();
		Assert.Equal(22.45M, output.Total);
    }
}
