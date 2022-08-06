using eCommerce.Domain;

namespace eCommerce.Infrastructure.Repository.Memory;

public sealed class CityRepositoryMemory : ICityRepository
{
    private static readonly List<City> Cities = new();

	private static readonly List<ZipCode> ZipCodes = new();

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
