using ECommerce.Catalog.Application;
using Testing.API.WebFactory;

using System.Net.Http.Json;

namespace ECommerce.Catalog.Tests.Integration;

public class API_Tests : IClassFixture<Api>
{
    private Api Api { get; }

    public API_Tests(Api api) => Api = api;

    [Fact]
    public async Task Deve_Obter_um_Item_da_API()
    {
        var api = Api.ApiClienteWithBearerToken(bearerToken: "");
        var response = await api.GetAsync("api/Items/1", default(CancellationToken));
        Assert.True(response.IsSuccessStatusCode);
        var output = await response.Content.ReadFromJsonAsync<ItemDTO>();
        Assert.NotNull(output);
        Assert.Equal("Guitarra", output.Description);
        Assert.Equal(1000, output.Price);
    }

    [Fact]
    public async Task Deve_Obter_os_Itens_da_API()
    {
        var api = Api.ApiClienteWithBearerToken(bearerToken: "");
        var response = await api.GetAsync("api/Items", default(CancellationToken));
        Assert.True(response.IsSuccessStatusCode);
        var output = await response.Content.ReadFromJsonAsync<List<ItemDTO>>();
        Assert.NotNull(output);
        Assert.Equal(3, output.Count);
    }
}
