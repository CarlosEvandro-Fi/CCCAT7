using ECommerce.Checkout.Application.Gateway;
using ECommerce.Checkout.Domain;
using System.Net.Http.Json;

namespace ECommerce.Checkout.Infrastructure.Gateway;

public sealed class GetItemHttpGateway : IGetItemGateway
{
    public async Task<Item> Execute(Int64 itemId)
    {
        HttpClient client = new HttpClient(); // *** Deveria usar o IHttpClientFactory
        var response = await client.GetAsync($"https://localhost:7074/api/Items/{itemId}");
        var output = await response.Content.ReadFromJsonAsync<ItemDTO>();
        return new Item(
            output.ItemId,
            output.Description,
            output.Price,
            output.Width,
            output.Height,
            output.Lenght,
            output.Weight,
            output.Density,
            output.Volume);
    }

    private sealed class ItemDTO
    {
        public String Description { get; }
        public Int64 ItemId { get; }
        public Decimal Price { get; }
        public Decimal Height { get; } // cm
        public Decimal Lenght { get; } // cm
        public Decimal Weight { get; } // kg
        public Decimal Width { get; } // cm
        public Decimal Density { get; } // kg/m3
        public Decimal Volume { get; } // m3
    }
}
