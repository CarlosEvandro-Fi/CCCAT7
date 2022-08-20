using ECommerce.Catalog.Domain;

namespace ECommerce.Catalog.Tests.Unitary;

public class Dimension_Tests
{
    [Fact]
    public void Nao_Deve_Ter_Dimensoes_Largura_Negativa()
    {
        Assert.Throws<Exception>(() => new Dimension(-1, 1, 1, 1));
    }
    [Fact]
    public void Nao_Deve_Ter_Dimensoes_Altura_Negativa()
    {
        Assert.Throws<Exception>(() => new Dimension(1, -1, 1, 1));
    }
    [Fact]
    public void Nao_Deve_Ter_Dimensoes_Profundidade_Negativa()
    {
        Assert.Throws<Exception>(() => new Dimension(1, 1, -1, 1));
    }
    [Fact]
    public void Nao_Deve_Ter_Dimensoes_Peso_Negativa()
    {
        Assert.Throws<Exception>(() => new Dimension(1, 1, 1, -1));
    }
}
