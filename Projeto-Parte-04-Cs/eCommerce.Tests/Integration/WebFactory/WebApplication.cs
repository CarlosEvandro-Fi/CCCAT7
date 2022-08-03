using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Testing.API.WebFactory;

public abstract class WebApplication<TStartup> : IDisposable where TStartup : class
{
    private WebApplicationFactory<TStartup> Custom { get; }

    protected WebApplicationFactory<TStartup> Factory { get; }

    public WebApplication(WebApplicationFactory<TStartup> factory)
    {
        Factory = factory ?? throw new Exception("Factory Nulo!");
        Custom = CustomWebApplicationFactory();
    }

    public IScope CreateScope() => new Scope(Custom.Services.CreateScope());

    public void Dispose() => Factory.Dispose();

    protected virtual WebApplicationFactory<TStartup> CustomWebApplicationFactory()
    {
        return Factory.WithWebHostBuilder(iWebHostBuilder =>
        {
            iWebHostBuilder.ConfigureServices(services =>
            {
            });
        });
    }
}
