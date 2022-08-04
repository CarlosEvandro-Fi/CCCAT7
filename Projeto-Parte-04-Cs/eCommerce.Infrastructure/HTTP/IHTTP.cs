using eCommerce.Application;

namespace eCommerce.Infrastructure.HTTP;

public interface IHTTP
{
    // void Listen(int port);

    // void On(string method, string url, Action callback);

    public Func<PreviewOrder.Input, Task<PreviewOrder.Output>>? OrderPreview { get; internal set; }
}
