using ECommerce.Stock.Application;
using ECommerce.Stock.Infrastructure.Database;
using ECommerce.Stock.Infrastructure.Repository.Database;
using System.Net.Http.Json;

namespace ECommerce.Stock.Tests.Integration;

public class API_Tests : IClassFixture<Api>
{
    private Api Api { get; }

    public API_Tests(Api api) => Api = api;

    [Fact]
    public async Task Deve_Obter_a_Quantidade_em_Estoque()
    {
		var api = Api.GetApiHttpClient(bearerToken: "");
        var responseOriginal = await api.GetAsync("api/Stock/GetStock/2", cancellationToken: default);
        Assert.True(responseOriginal.IsSuccessStatusCode);
        var original = await responseOriginal.Content.ReadAsStringAsync();
        await api.PostAsJsonAsync("api/Stock/IncrementStock"
			, new List<IncrementStockDTO> { new() { ItemId = 2, Quantity = 10 } }
			, default);
		await api.PostAsJsonAsync("api/Stock/DecrementStock"
			, new List<DecrementStockDTO> { new() { ItemId = 2, Quantity = 5  } }
			, default);
		var response = await api.GetAsync("api/Stock/GetStock/2", cancellationToken: default);
		Assert.True(response.IsSuccessStatusCode);
		var count = await response.Content.ReadAsStringAsync();
		Assert.Equal("5", (Int32.Parse(count) - Int32.Parse(original)).ToString());
	}
}
