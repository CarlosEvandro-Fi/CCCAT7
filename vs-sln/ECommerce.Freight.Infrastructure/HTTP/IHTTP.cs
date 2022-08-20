using ECommerce.Freight.Application;

namespace ECommerce.Freight.Infrastructure.HTTP;

public interface IHTTP
{
    void OnCalculateFreight(Func<CalculateFreight.Input, Task<CalculateFreight.Output>> on);
}
