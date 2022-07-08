namespace Aula01Lib.FareCalculators;

public sealed class SpecialDayFareCalculator : IFareCalculator
{
    private const Decimal FARE = 15M;

    public IFareCalculator? Next { get; }

    public SpecialDayFareCalculator(IFareCalculator? next) => Next = next;

    public decimal Calculate(Segment segment)
    {
        if (segment.Date.Day == 10) return FARE;
        if (Next is null) throw new Exception("Nenhum Next Fare!");
        return Next.Calculate(segment);
    }
}
