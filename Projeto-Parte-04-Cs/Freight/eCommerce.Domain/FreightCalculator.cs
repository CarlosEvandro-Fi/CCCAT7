namespace eCommerce.Domain;

public sealed class FreightCalculator
{
    const Decimal MINIMUM_FREIGHT = 10M;

    public static Decimal Calculate(Double distance, Double volume, Double density)
    {
        var freight = volume * distance * (density / 100);
        if (freight == 0) return 0;
        return Math.Max(Convert.ToDecimal(freight), MINIMUM_FREIGHT);
    }
}
