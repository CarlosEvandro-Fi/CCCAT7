namespace Aula01Lib;

public abstract class FareCalculator
{
    public abstract FareCalculator? Next { get; }

    public abstract decimal Calculate(Segment segment);
}
