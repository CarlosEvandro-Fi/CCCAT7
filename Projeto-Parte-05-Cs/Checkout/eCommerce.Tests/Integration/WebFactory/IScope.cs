using Microsoft.Extensions.DependencyInjection;

namespace Testing.API.WebFactory;

public interface IScope : IDisposable
{
    CancellationToken CancellationToken { get; }

    // IMediator Mediator { get; }

    IServiceProvider ServiceProvider { get; }

    IServiceScope ServiceScope { get; }
}
