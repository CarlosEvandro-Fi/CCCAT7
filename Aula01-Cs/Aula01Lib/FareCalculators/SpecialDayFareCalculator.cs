namespace Aula01Lib.FareCalculators;

public sealed class SpecialDayFareCalculator : FareCalculator
{
    private const Decimal FARE = 15M;

    public override FareCalculator? Next { get; }

    public SpecialDayFareCalculator(FareCalculator? next) => Next = next;

    public override decimal Calculate(Segment segment)
    {
        if (segment.Date.Day == 10) return FARE;
        if (Next is null) throw new Exception("Nenhum Next Fare!");
        return Next.Calculate(segment);
    }
}
