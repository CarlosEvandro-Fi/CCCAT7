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

    [Fact]
    public void Deve_Calcular_o_Frete_com_Preco_Minimo()
    {
        var item = new Item(3, "Cabo", 30, new Dimension(10, 10, 10, 0.9M));
        var freight = FreightCalculator.Calculate(item);
        Assert.Equal(10, freight);
    }
}
