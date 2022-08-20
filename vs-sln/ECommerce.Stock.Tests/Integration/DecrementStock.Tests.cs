using ECommerce.Stock.Application;
using ECommerce.Stock.Infrastructure.Database;
using ECommerce.Stock.Infrastructure.Repository.Database;

namespace ECommerce.Stock.Tests.Integration;

public class DecrementStock_Tests
{
	[Fact]
	public async Task Deve_Decrementar_o_Estoque()
	{
		var connection = new PgPromiseAdapter();
		var stockEntryRepository = new StockEntryRepositoryDatabase(connection);
		await stockEntryRepository.Clean();
		var incrementStock = new IncrementStock(stockEntryRepository);
		await incrementStock.Execute(new List<IncrementStock.Input> { new() { ItemId = 1, Quantity = 10 } });
		var decrementStock = new DecrementStock(stockEntryRepository);
		await decrementStock.Execute(new List<DecrementStock.Input> { new() { ItemId = 1, Quantity = 5 } });
		var getStock = new GetStock(stockEntryRepository);
		var output = await getStock.Execute(1);
		Assert.Equal(5, output);
		await connection.Close();
	}

	[Fact]
	public async Task Nao_Deve_Decrementar_se_Nao_Houver_Estoque()
	{
		var connection = new PgPromiseAdapter();
		var stockEntryRepository = new StockEntryRepositoryDatabase(connection);
		await stockEntryRepository.Clean();
		var incrementStock = new IncrementStock(stockEntryRepository);
		await incrementStock.Execute(new List<IncrementStock.Input> { new() { ItemId = 1, Quantity = 5 } });
		var decrementStock = new DecrementStock(stockEntryRepository);
		await Assert.ThrowsAsync<Exception>(async () => await decrementStock.Execute(new List<DecrementStock.Input> { new() { ItemId = 1, Quantity = 10 } }));
		await connection.Close();
	}
}
