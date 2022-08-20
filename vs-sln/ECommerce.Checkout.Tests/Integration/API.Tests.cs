using ECommerce.Checkout.Application;
using Testing.API.WebFactory;

using System.Net.Http.Json;

namespace ECommerce.Checkout.Tests.Integration;

public class API_Tests : IClassFixture<Api>
{
    private Api Api { get; }

    public API_Tests(Api api) => Api = api;

    [Fact]
    public async Task Deve_Simular_uma_Compra()
    {
        var api = Api.ApiClienteWithBearerToken(bearerToken: "");
        var input = new PreviewOrder.Input()
        {
            CPF = "886.634.854-68",
            OrderItems = new List<PreviewOrder.InputItem>()
            {
                new() { ItemId = 1, Quantity = 1 },
                new() { ItemId = 2, Quantity = 1 },
                new() { ItemId = 3, Quantity = 3 },
            },
        };
        var response = await api.PostAsJsonAsync("api/Order/OrderPreview", input, default);
        Assert.True(response.IsSuccessStatusCode);
        PreviewOrder.Output? output = await response.Content.ReadFromJsonAsync<PreviewOrder.Output>();
        Assert.NotNull(output);
        Assert.Equal(6090, output.Total);
    }
}
