namespace Aula01Lib;

public sealed class Ride
{
    private const decimal MINIMUM_FARE = 10.00M;

    public FareCalculator FareCalculator { get; }

    private List<Segment> Segments { get; } = new List<Segment>();

    public Ride(FareCalculator fareCalculator)
    {
        FareCalculator = fareCalculator 
            ?? throw new Exception($"Informou um '{nameof(Aula01Lib.FareCalculator)}' nulo em '{nameof(Aula01Lib.Ride)}'.");
    }

    public void AddSegment(Decimal distance, DateTime date)
    {
        Segments.Add(new Segment(distance, date));
    }

    public Decimal Finish()
    {
        Decimal fare = 0;
        foreach (var segment in Segments)
        {
            fare += FareCalculator.Calculate(segment);
        }
        return fare < MINIMUM_FARE ? MINIMUM_FARE : fare;
    }
}
