using eCommerce.Application;

namespace eCommerce.Infrastructure.HTTP;

public interface IHTTP
{
    void OnOrderPreview(Func<PreviewOrder.Input, Task<PreviewOrder.Output>> on);
}
