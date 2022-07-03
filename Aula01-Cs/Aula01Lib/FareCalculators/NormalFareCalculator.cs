namespace Aula01Lib.FareCalculators;

public sealed class NormalFareCalculator : FareCalculator
{
    private const Decimal FARE = 2.1M;

    public override FareCalculator? Next { get; }

    public NormalFareCalculator(FareCalculator? next) => Next = next;

    public override decimal Calculate(Segment segment)
    {
        if (!segment.IsOvernight() && !segment.IsSunday()) return segment.Distance * FARE;
        if (Next is null) throw new Exception("Nenhum Next Fare!");
        return Next.Calculate(segment);
    }
}
