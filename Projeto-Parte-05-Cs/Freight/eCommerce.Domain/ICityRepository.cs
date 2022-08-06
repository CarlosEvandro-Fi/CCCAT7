namespace eCommerce.Domain;

public interface ICityRepository
{
    Task<City> GetByZipcode(String code);
}
