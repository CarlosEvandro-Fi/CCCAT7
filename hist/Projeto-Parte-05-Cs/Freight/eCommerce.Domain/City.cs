namespace eCommerce.Domain;

public sealed class City
{
	public Int32 CityId { get; }

	public Coordinate Coordinate { get; }

	public String Name { get; }

	public Double Latitude { get; }

	public Double Longitude { get; }

	public City(Int32 cityId, String name, Double latitude, Double longitude) {
		CityId = cityId;
		Name = name;
		Latitude = latitude;
		Longitude = longitude;
		Coordinate = new Coordinate(Latitude, Longitude);
	}
}
