namespace Aula01Lib;

public interface IFareCalculator
{
    IFareCalculator? Next { get; }

    decimal Calculate(Segment segment);
}
