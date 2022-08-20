using eCommerce.Application;

namespace eCommerce.Infrastructure.HTTP;

public interface IHTTP
{
    void OnCalculateFreight(Func<CalculateFreight.Input, Task<CalculateFreight.Output>> on);
}
