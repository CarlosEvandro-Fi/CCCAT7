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
        public String Description { get; set; }
        public Int64 ItemId { get; set; }
        public Decimal Price { get; set; }
        public Decimal Height { get; set; } // cm
        public Decimal Lenght { get; set; } // cm
        public Decimal Weight { get; set; } // kg
        public Decimal Width { get; set; } // cm
        public Decimal Density { get; set; } // kg/m3
        public Decimal Volume { get; set; } // m3
    }
}
