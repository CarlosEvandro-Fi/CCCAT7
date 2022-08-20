namespace Aula01Lib.FareCalculators;

public sealed class OvernightSundayFareCalculator : IFareCalculator
{
    private const Decimal FARE = 5M;

    public IFareCalculator? Next { get; }

    public OvernightSundayFareCalculator(IFareCalculator? next) => Next = next;

    public decimal Calculate(Segment segment)
    {
        if (segment.IsOvernight() && segment.IsSunday()) return segment.Distance * FARE;
        if (Next is null) throw new Exception("Nenhum Next Fare!");
        return Next.Calculate(segment);
    }
}