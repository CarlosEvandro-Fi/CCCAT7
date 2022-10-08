using ECommerce.Stock.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Stock.Tests;

public sealed class TestingServiceProvider : IDisposable, IAsyncDisposable
{
    private ServiceProvider InternalServiceProvider { get; }

    public IServiceProvider ServiceProvider => InternalServiceProvider;

    public TestingServiceProvider()
    {
        var diServiceCollection = new ServiceCollection();

        var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(CreateConfigurationSettings())
            .Build();

        ConfigureServices(diServiceCollection, configuration);

        InternalServiceProvider = diServiceCollection.BuildServiceProvider();
    }

    private IServiceCollection ConfigureServices(IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureServices();
        return services;
    }

    private IDictionary<String, String> CreateConfigurationSettings() => new Dictionary<String, String>();

    public void Dispose() => InternalServiceProvider.Dispose();

    public async ValueTask DisposeAsync() => await InternalServiceProvider.DisposeAsync();
}
