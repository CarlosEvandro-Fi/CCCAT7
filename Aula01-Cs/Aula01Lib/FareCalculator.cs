namespace Aula01Lib;

//public abstract class FareCalculator
//{
//    public abstract FareCalculator? Next { get; }

//    public abstract decimal Calculate(Segment segment);
//}

public interface IFareCalculator
{
    IFareCalculator? Next { get; }

    decimal Calculate(Segment segment);
}
