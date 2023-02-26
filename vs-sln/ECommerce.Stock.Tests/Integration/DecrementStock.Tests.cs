using ECommerce.Stock.Application;
using ECommerce.Stock.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce.Stock.Tests.Integration;

public class DecrementStock_Tests : IClassFixture<TestingServiceProvider>
{
	public TestingServiceProvider TestingServiceProvider { get; }

	public DecrementStock_Tests(TestingServiceProvider iServiceProvider) => TestingServiceProvider = iServiceProvider;

    [Fact]
	public async Task Deve_Decrementar_o_Estoque()
	{
        using var scope = TestingServiceProvider.ServiceProvider.CreateScope();
        var stockEntryRepository = scope.ServiceProvider.GetRequiredService<IStockEntryRepository>();
        await stockEntryRepository.Clean();
        var handler = scope.ServiceProvider.GetRequiredService<IQueryHandler<GetStockQuery, Int32>>();
        var incremets = new List<IncrementStockDTO>()
		{
			new IncrementStockDTO { ItemId = 1, Quantity = 10 }
        };
		var incrementCommand = new IncrementStockCommand(incremets);
        var incrementHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<IncrementStockCommand>>();
		await incrementHandler.Handle(incrementCommand, default);
		var decremets = new List<DecrementStockDTO>()
		{
            new DecrementStockDTO { ItemId = 1, Quantity = 5 }
        };
		var decrementCommand = new DecrementStockCommand(decremets);
		var decrementHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DecrementStockCommand>>();
		await decrementHandler.Handle(decrementCommand, default);
		var getStockQuery = new GetStockQuery(itemId: 1);
		var stockCount = await handler.Handle(getStockQuery, default);
        Assert.Equal(5, stockCount);
	}

	[Fact]
	public async Task Nao_Deve_Decrementar_se_Nao_Houver_Estoque()
	{
        using var scope = TestingServiceProvider.ServiceProvider.CreateScope();
        var stockEntryRepository = scope.ServiceProvider.GetRequiredService<IStockEntryRepository>();
        await stockEntryRepository.Clean();
        var incremets = new List<IncrementStockDTO>()
        {
            new IncrementStockDTO { ItemId = 1, Quantity = 5 }
        };
        var incrementCommand = new IncrementStockCommand(incremets);
		var incrementHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<IncrementStockCommand>>();
		await incrementHandler.Handle(incrementCommand, default);
        var decremets = new List<DecrementStockDTO>()
        {
            new DecrementStockDTO { ItemId = 1, Quantity = 10 }
        };
        var decrementCommand = new DecrementStockCommand(decremets);
		var decrementHandler = scope.ServiceProvider.GetRequiredService<ICommandHandler<DecrementStockCommand>>();
		await Assert.ThrowsAsync<Exception>(async () => await decrementHandler.Handle(decrementCommand, default));
	}
}
