namespace eCommerce.Domain;

public sealed class Coordinate
{
    public Double Latitude { get; set; }
    public Double Longitude { get; set; }

    public Coordinate(Double latitude, Double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}