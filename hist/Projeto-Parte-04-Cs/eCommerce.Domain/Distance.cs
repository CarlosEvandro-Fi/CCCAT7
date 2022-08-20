namespace eCommerce.Domain;

public sealed class Coordinate
{
    public Double Latitude { get; set; }
    public Double Longitude { get; set; }
}

public sealed class Distance
{
	public Double GetDistanceBetweenTwoPoints(Coordinate cord1, Coordinate cord2)
	{
		if (cord1.Latitude == cord2.Latitude && cord1.Longitude == cord2.Longitude) return 0;
		var radlat1 = (Math.PI * cord1.Latitude) / 180;
		var radlat2 = (Math.PI * cord2.Latitude) / 180;
		var theta = cord1.Longitude -cord2.Longitude;
		var radtheta = (Math.PI * theta) / 180;
		var dist = Math.Sin(radlat1) * Math.Sin(radlat2) + Math.Cos(radlat1) * Math.Cos(radlat2) * Math.Cos(radtheta);
		if (dist > 1) dist = 1;
		dist = Math.Acos(dist);
		dist = (dist * 180) / Math.PI;
		dist = dist * 60 * 1.1515;
		dist = dist * 1.609344; //convert miles to km
		return dist;
	}

	public readonly Coordinate a = new() {
		Latitude = -27.5945,
		Longitude = -48.5477
	};

	public readonly Coordinate b = new() {
		Latitude = -22.9129,
		Longitude = -43.2003
	};
}
