namespace AulaLib.Tests;

public class FreightCalculator_Tests
{
    [Fact]
    public void Deve_Calcular_o_Frete()
    {
        var item = new Item(1, "Guitarra", 1000, new Dimension(100, 30, 10, 3));
        var freight = FreightCalculator.Calculate(item);
        Assert.Equal(30, freight);
    }
}
