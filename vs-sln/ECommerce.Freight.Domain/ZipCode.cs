namespace ECommerce.Freight.Domain;

public sealed class ZipCode
{
    public String Code { get; }

    public Int32 CityId { get; }

    public String Street { get; }

    public String Neighborhood { get; }

    public ZipCode(String code, Int32 cityId, String street, String neighborhood)
    {
        Code = code;
        CityId = cityId;
        Street = street;
        Neighborhood = neighborhood;
	}
}
