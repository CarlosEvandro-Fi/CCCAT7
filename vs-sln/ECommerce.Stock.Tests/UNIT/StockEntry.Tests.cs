using ECommerce.Stock.Domain;

namespace ECommerce.Stock.Tests.UNIT;

public class StockEntry_Tests
{
    [Fact]
    public void Deve_Criar_uma_Entrada_No_Estoque()
    {
        var stockEntry = new StockEntry(1, Operation.IN, 10);
        Assert.Equal(1, stockEntry.ItemId);
        Assert.Equal(Operation.IN, stockEntry.Operation);
        Assert.Equal(10, stockEntry.Quantity);
    }
}
