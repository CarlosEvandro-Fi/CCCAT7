using eCommerce.Domain;
using eCommerce.Infrastructure.Database;

namespace eCommerce.Infrastructure.Repository.Database;

public sealed class CityRepositoryDatabase : ICityRepository
{
    private Repository.Memory.CityRepositoryMemory Memory = new();

    public IConnection Connection { get; }

    public CityRepositoryDatabase(IConnection connection) => Connection = connection;

    public Task<City> GetByZipcode(String code) => Memory.GetByZipcode(code);
}
