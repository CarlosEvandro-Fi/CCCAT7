using ECommerce.Stock.Infrastructure.Database;
using ECommerce.Stock.Infrastructure.Repository.Database;
using System.Net.Http.Json;
using Testing.API.WebFactory;
using static ECommerce.Stock.Infrastructure.HTTP.WebApiAdapter;

namespace ECommerce.Stock.Tests.Integration;

public class API_Tests : IClassFixture<Api>
{
    private Api Api { get; }

    public API_Tests(Api api) => Api = api;

    [Fact]
    public async Task Deve_Obter_a_Quantidade_em_Estoque()
    {
		var connection = new PgPromiseAdapter();
		var stockEntryRepository = new StockEntryRepositoryDatabase(connection);
		await stockEntryRepository.Clean();
		var api = Api.GetApiHttpClient(bearerToken: "");
		await api.PostAsJsonAsync("api/Stock/IncrementStock"
			, new List<IncrementStockDTO> { new() { ItemId = 2, Quantity = 10 } }
			, default);
		await api.PostAsJsonAsync("api/Stock/DecrementStock"
			, new List<DecrementStockDTO> { new() { ItemId = 2, Quantity = 5  } }
			, default);
		var response = await api.GetAsync("api/Stock/GetStock/2", cancellationToken: default);
		Assert.True(response.IsSuccessStatusCode);
		var count = await response.Content.ReadAsStringAsync();
		Assert.Equal("5", count);
		await connection.Close();
	}
}
