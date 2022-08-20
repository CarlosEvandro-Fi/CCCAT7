using eCommerce.Domain;

namespace eCommerce.Tests.UNIT;

public class DistanceCalculator_Testes
{
    [Fact]
    public void Deve_Calcular_a_Distancia_Entre_Duas_Cidades()
    {
        var from = new Coordinate(-22.9129, -43.2003);
        var to = new Coordinate(-27.5945, -48.5477);
        var distance = DistanceCalculator.Calculate(from, to);
        Assert.Equal(748.2217780081631, distance);
    }
}
