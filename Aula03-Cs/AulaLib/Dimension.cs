namespace AulaLib;

public class Dimension
{
    public Decimal Width { get; } // cm
    public Decimal Height { get; } // cm
    public Decimal Lenght { get; } // cm
    public Decimal Weight { get; } // kg

    public Dimension(Decimal width = 0, Decimal height = 0, Decimal lenght = 0, Decimal weight = 0)
    {
        Width = width;
        Height = height;
        Lenght = lenght;
        Weight = weight;
    }

    public Decimal GetDensity()
    {
        if (GetVolume() == 0) return 0;
        return Weight / GetVolume();
    }

    public Decimal GetVolume()
    {
        return Width / 100 * Height / 100 * Lenght / 100;
    }
}
