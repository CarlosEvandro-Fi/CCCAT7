namespace AulaLib;

public class FreightCalculator
{
    public static Decimal Calculate(Item item)
    {
        return item.GetVolume() * 1000 * (item.GetDensity() / 100);
    }
}
