using ECommerce.Stock.Domain;

namespace ECommerce.Stock.Tests.UNIT;

public class StockCalculator_Tests
{
    [Fact]
    public void Deve_Calcular_o_Estoque_de_um_Item()
    {
		var stockEntries = new List<StockEntry>()
		{
			new StockEntry(1, Operation.IN, 10),
			new StockEntry(1, Operation.OUT, 5),
			new StockEntry(1, Operation.IN, 2),
		};
		var total = StockCalculator.Calculate(stockEntries);
		Assert.Equal(7, total);
	}
}
