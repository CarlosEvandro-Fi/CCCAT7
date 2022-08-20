namespace Aula01Lib.FareCalculators;

public sealed class SundayFareCalculator : IFareCalculator
{
    private const Decimal FARE = 2.9M;

    public IFareCalculator? Next { get; }

    public SundayFareCalculator(IFareCalculator? next) => Next = next;

    public decimal Calculate(Segment segment)
    {
        if (!segment.IsOvernight() && segment.IsSunday()) return segment.Distance * FARE;
        if (Next is null) throw new Exception("Nenhum Next Fare!");
        return Next.Calculate(segment);
    }
}
