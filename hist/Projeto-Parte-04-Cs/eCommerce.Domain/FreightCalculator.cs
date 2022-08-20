namespace eCommerce.Domain;

public sealed class FreightCalculator
{
    const Decimal MINIMUM_FREIGHT = 10M;

    public static Decimal Calculate(Item item)
    {
        var freight = item.GetVolume() * 1000 * (item.GetDensity() / 100);
        if (freight == 0) return 0;
        return Math.Max(freight, MINIMUM_FREIGHT);
    }
}
