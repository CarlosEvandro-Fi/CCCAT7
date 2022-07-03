using Aula01Lib.FareCalculators;

namespace Aula01Lib.Tests;

public class Exemplo_Tests
{
    private Ride Ride { get; }

    public Exemplo_Tests()
    {
        var normalFareCalculator = new NormalFareCalculator(null!);
        var sundayFareCalculator = new SundayFareCalculator(normalFareCalculator);
        var overnightFareCalculator = new OvernightFareCalculator(sundayFareCalculator);
        var overnightSundayFareCalculator = new OvernightSundayFareCalculator(overnightFareCalculator);
        var specialDayFareCalculator = new SpecialDayFareCalculator(overnightSundayFareCalculator);
        Ride = new Ride(specialDayFareCalculator);
    }

    [Fact(DisplayName = "Deve calcular o valor da corrida de uma corrida normal")]
    public void Test1()
    {
        Ride.AddSegment(10, new DateTime(2021, 03, 01, 10, 00, 00));
        var fare = Ride.Finish();
        Assert.Equal(21, fare);
    }

    [Fact(DisplayName = "Deve calcular o valor da corrida de uma corrida noturna")]
    public void Test2()
    {
        Ride.AddSegment(10, new DateTime(2021, 03, 01, 23, 00, 00));
        var fare = Ride.Finish();
        Assert.Equal(39, fare);
    }

    [Fact(DisplayName = "Deve calcular o valor da corrida de uma corrida no domingo")]
    public void Test3()
    {
        Ride.AddSegment(10, new DateTime(2021, 03, 07, 10, 00, 00));
        var fare = Ride.Finish();
        Assert.Equal(29, fare);
    }

    [Fact(DisplayName = "Deve calcular o valor da corrida de uma corrida no domingo de noite")]
    public void Test4()
    {
        Ride.AddSegment(10, new DateTime(2021, 03, 07, 23, 00, 00));
        var fare = Ride.Finish();
        Assert.Equal(50, fare);
    }

    [Fact(DisplayName = "Deve calcular o valor da corrida no dia 10")]
    public void Test5()
    {
        Ride.AddSegment(10, new DateTime(2021, 03, 10, 10, 00, 00));
        var fare = Ride.Finish();
        Assert.Equal(15, fare);
    }

    [Fact(DisplayName = "Deve calcular o valor da corrida com a distância inválida")]
    public void Test6()
    {
        Assert.Throws<Exception>(() => Ride.AddSegment(-3, DateTime.Now));
    }

    [Fact(DisplayName = "Deve calcular o valor da corrida com a data inválida")]
    public void Test7()
    {
        Assert.Throws<Exception>(() => Ride.AddSegment(10, default));
    }

    [Fact(DisplayName = "Deve calcular o valor da corrida com tarifa mínima")]
    public void Test8()
    {
        Ride.AddSegment(3, new DateTime(2021, 03, 01, 10, 00, 00));
        var fare = Ride.Finish();
        Assert.Equal(10, fare);
    }
}