using Microsoft.AspNetCore.Mvc.Testing;

namespace Testing.API.WebFactory;

public class Api : WebApplication<ECommerce.Stock.API.Program>, IApi, IAsyncLifetime
{
    public Api() : base(new WebApplicationFactory<ECommerce.Stock.API.Program>())
    { }

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
        var c = Factory.CreateClient(new WebApplicationFactoryClientOptions
        {
            AllowAutoRedirect = false,
        });

        if (!String.IsNullOrWhiteSpace(bearerToken))
        {
            c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", bearerToken);
        }

        return c;
    }

    protected override WebApplicationFactory<ECommerce.Stock.API.Program> CustomWebApplicationFactory()
    {
        return Factory.WithWebHostBuilder(iWebHostBuilder =>
        {
            iWebHostBuilder.ConfigureServices(services =>
            {

            });
        });
    }
}
