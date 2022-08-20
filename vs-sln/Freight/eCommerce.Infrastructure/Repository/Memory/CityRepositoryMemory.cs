using eCommerce.Domain;

namespace eCommerce.Infrastructure.Repository.Memory;

public sealed class CityRepositoryMemory : ICityRepository
{
	private static readonly List<City> Cities = new()
	{
		new City(1, "Florianópolis", -27.5945, -48.5477),
		new City(2, "Rio de Janeiro", -22.9129, -43.2003),
	};

	private static readonly List<ZipCode> ZipCodes = new()
	{
		new ZipCode("88015600", 1, "Rua Almirante Lamego", "Centro"),
		new ZipCode("22060030", 2, "Rua Aires Saldanha", "Copacabana"),
	};

	public async Task<City> GetByZipcode(String code)
	{
		var cities =
			from city in Cities
			join zips in ZipCodes on city.CityId equals zips.CityId
			where zips.Code == code
			select city;

		return cities.Any() ? cities.First() : null!;
	}
}
