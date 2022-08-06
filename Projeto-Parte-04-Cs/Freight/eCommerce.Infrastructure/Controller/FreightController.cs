using eCommerce.Application;
using eCommerce.Infrastructure.Database;
using eCommerce.Infrastructure.HTTP;
using eCommerce.Infrastructure.Repository.Database;

namespace eCommerce.Infrastructure.Controller;

public sealed class FreightController
{
    public FreightController(IHTTP http, IConnection connection)
    {
        http.OnCalculateFreight(
            async (input) =>
            {
                var cityRepository = new CityRepositoryDatabase(connection);
                var calculateFreight = new CalculateFreight(cityRepository);
                var output = await calculateFreight.Execute(input);
                return output;
            });
    }
}
