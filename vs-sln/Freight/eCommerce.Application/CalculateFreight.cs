namespace eCommerce.Application;

public sealed class CalculateFreight
{
    public ICityRepository CityRepository { get; }

    public CalculateFreight(ICityRepository cityRepository) => CityRepository = cityRepository;

	public async Task<Output> Execute(Input input)
	{
		var from = await CityRepository.GetByZipcode(input.From);
		var to = await CityRepository.GetByZipcode(input.To);
		var distance = DistanceCalculator.Calculate(from.Coordinate, to.Coordinate);
		var total = 0M;
		foreach (var orderItem in input.OrderItems)
		{
			total += FreightCalculator.Calculate(distance, orderItem.Volume, orderItem.Density) * orderItem.Quantity;
		}
		total = Math.Round(total*100)/100;
		return new Output() { Total = total };
	}

	public sealed class Input
	{
		public String From { get; set; } = "";
		public String To { get; set; } = "";
		public List<OrderItem> OrderItems { get; set; } = new();
	}

	public sealed class OrderItem
    {
		public Double Density { get; set; }
		public Int32 Quantity { get; set; }
		public Double Volume { get; set; }
    }

	public sealed class Output
    {
		public Decimal Total { get; set; }
    }
}
