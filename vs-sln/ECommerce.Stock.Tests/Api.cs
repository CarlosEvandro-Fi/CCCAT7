using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ECommerce.Stock.Tests;

public sealed class Api : IAsyncLifetime
{
    private WebApplicationFactory<ECommerce.Stock.API.Program> Factory { get; }

    public Api() 
    {
        Factory = new WebApplicationFactory<ECommerce.Stock.API.Program>();
    }

    #region "XUnit IAsyncLifetime"

    public async Task DisposeAsync()
    {
        await Task.CompletedTask;
    }

    public async Task InitializeAsync()
    {
        // TOKEN?
        await Task.CompletedTask;
    }

    #endregion

    public HttpClient GetApiHttpClient(String bearerToken = "")
    {
        var cliente = Factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false,
        });

        if (!String.IsNullOrWhiteSpace(bearerToken))
        {
            cliente.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
        }

        return cliente;
    }
}
