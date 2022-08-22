using ECommerce.Checkout.Application;
using ECommerce.Checkout.Application.Gateway;
using ECommerce.Checkout.Domain;
using ECommerce.Checkout.Infrastructure.CLI;
using ECommerce.Checkout.Infrastructure.Controller.CLI;
using ECommerce.Checkout.Infrastructure.Database;
using ECommerce.Checkout.Infrastructure.Gateway;

namespace ECommerce.Checkout.Tests.Integration;

public class CLI_Tests
{
    internal sealed class PlaceboInputDevice : IInputDevice
    {
        public void OnData(Action<String> callback) { }
    }

    internal sealed class PlacceboOutoutDevice : IOutputDevice
    {
        public void Write(String text) { }
    }

    internal sealed class PlaceboGetItemGateway : IGetItemGateway
    {
        public async Task<Item> Execute(long itemId)
        {
            List<Item> OrdersItems = new()
            {
                new Item(1, "Guitarra", 1000, 100, 30, 10, 3, 100, 0.03M),
                new Item(2, "Amplificador", 5000, 50, 50, 50, 20, 1, 1),
                new Item(3, "Cabo", 30, 10, 10, 10, 1, 1, 1),
            };

            return OrdersItems.Where(where => where.ItemId == itemId).FirstOrDefault();
        }
    }

    [Fact]
    public async void Deve_Testar_o_CLI()
    {
		var inputDevice = new PlaceboInputDevice(); // { onData: () => { } };
        var outputDevice = new PlacceboOutoutDevice(); // { write: () => { } };
		var connection = new PgPromiseAdapter();
		var cliManager = new CLIManager(inputDevice, outputDevice);
        // var getItemGateway = new GetItemHttpGateway();
        var getItemGateway = new PlaceboGetItemGateway();
        var previewOrder = new PreviewOrder(getItemGateway);
        _ = new CLIController(cliManager, previewOrder);
		await cliManager.Execute("cpf 886.634.854-68");
		await cliManager.Execute("add-item 1 1");
		var output = await cliManager.Execute("preview");
        Assert.Equal("Total: 1000", output);
		await connection.Close();
	}
}
