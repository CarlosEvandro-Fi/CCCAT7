using eCommerce.Infrastructure.Database;
using eCommerce.Infrastructure.Repository.Database;
using System.Net.Http.Json;
using Testing.API.WebFactory;
using static eCommerce.Infrastructure.HTTP.WebApiAdapter;

namespace eCommerce.Tests.Integration;

public class API_Tests : IClassFixture<Api>
{
    private Api Api { get; }

    public API_Tests(Api api) => Api = api;

    [Fact]
    public async Task Deve_Obter_a_Quantidade_em_Estoque()
    {
        //var api = Api.ApiClienteWithBearerToken(bearerToken: "");
        //var input = new PreviewOrder.Input()
        //{
        //    CPF = "886.634.854-68",
        //    OrderItems = new List<PreviewOrder.InputItem>()
        //    {
        //        new() { ItemId = 1, Quantity = 1 },
        //        new() { ItemId = 2, Quantity = 1 },
        //        new() { ItemId = 3, Quantity = 3 },
        //    },
        //};
        //var response = await api.PostAsJsonAsync("api/Order/OrderPreview", input, default);
        //Assert.True(response.IsSuccessStatusCode);
        //PreviewOrder.Output? output = await response.Content.ReadFromJsonAsync<PreviewOrder.Output>();
        //Assert.NotNull(output);
        //Assert.Equal(6350, output.Total);


		var connection = new PgPromiseAdapter();
		var stockEntryRepository = new StockEntryRepositoryDatabase(connection);
		await stockEntryRepository.Clean();
		var api = Api.ApiClienteWithBearerToken(bearerToken: "");
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
