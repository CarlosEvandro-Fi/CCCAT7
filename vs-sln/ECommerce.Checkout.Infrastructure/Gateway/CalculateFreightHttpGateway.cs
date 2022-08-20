using ECommerce.Checkout.Application.Gateway;
using System.Net.Http.Json;

namespace ECommerce.Checkout.Infrastructure.Gateway
{
    public sealed class CalculateFreightHttpGateway : ICalculateFreightGateway
    {
        public async Task<ICalculateFreightGateway.Output> Calculate(ICalculateFreightGateway.Input input)
        {
            HttpClient client = new HttpClient(); // *** Deveria usar o IHttpClientFactory
            var response = await client.PostAsJsonAsync("https://localhost:7099/api/Freight/CalculateFreight", input);
            var output = await response.Content.ReadFromJsonAsync<ICalculateFreightGateway.Output>();
            return output;
        }
    }
}
