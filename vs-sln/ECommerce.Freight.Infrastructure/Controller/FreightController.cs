using ECommerce.Freight.Application;
using ECommerce.Freight.Infrastructure.Database;
using ECommerce.Freight.Infrastructure.HTTP;
using ECommerce.Freight.Infrastructure.Repository.Database;

namespace ECommerce.Freight.Infrastructure.Controller;

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
