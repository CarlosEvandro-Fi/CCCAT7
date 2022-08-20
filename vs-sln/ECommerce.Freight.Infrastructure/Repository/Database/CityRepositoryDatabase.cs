using ECommerce.Freight.Domain;
using ECommerce.Freight.Infrastructure.Database;

namespace ECommerce.Freight.Infrastructure.Repository.Database;

public sealed class CityRepositoryDatabase : ICityRepository
{
    private Repository.Memory.CityRepositoryMemory Memory = new();

    public IConnection Connection { get; }

    public CityRepositoryDatabase(IConnection connection) => Connection = connection;

    public Task<City> GetByZipcode(String code) => Memory.GetByZipcode(code);
}
