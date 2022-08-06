using Microsoft.Extensions.DependencyInjection;

namespace Testing.API.WebFactory;

public sealed class Scope : IScope, IDisposable
{
    private CancellationTokenSource CancellationTokenSource { get; }

    public CancellationToken CancellationToken => CancellationTokenSource.Token;

    // public IMediator Mediator { get; }

    public IServiceScope ServiceScope { get; }

    public IServiceProvider ServiceProvider { get; }

    public Scope(IServiceScope scope)
    {
        ServiceScope = scope ?? throw new Exception("IServiceScope Nulo!");

        ServiceProvider = ServiceScope.ServiceProvider;

        // Mediator = ServiceProvider.GetRequiredService<IMediator>();

        if (System.Diagnostics.Debugger.IsAttached)
        {
            CancellationTokenSource = new CancellationTokenSource(600000);
        }
        else
        {
            CancellationTokenSource = new CancellationTokenSource(120000);
        }
    }

    public void Dispose()
    {
        ServiceScope?.Dispose();
        CancellationTokenSource?.Dispose();
    }
}
