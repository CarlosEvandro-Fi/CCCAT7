namespace ECommerce.Freight.Domain;

public interface ICityRepository
{
    Task<City> GetByZipcode(String code);
}
