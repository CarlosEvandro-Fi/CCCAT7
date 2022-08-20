using eCommerce.Infrastructure.CLI;
using eCommerce.Infrastructure.Controller.CLI;
using eCommerce.Infrastructure.Database;

namespace eCommerce.Tests.Integration;

public class CLI_Tests
{
    public sealed class PlaceboInputDevice : IInputDevice
    {
        public void OnData(Action<String> callback) { }
    }

    public sealed class PlacceboOutoutDevice : IOutputDevice
    {
        public void Write(String text) { }
    }

    [Fact]
    public async void Deve_Testar_o_CLI()
    {
		var inputDevice = new PlaceboInputDevice(); // { onData: () => { } };
        var outputDevice = new PlacceboOutoutDevice(); // { write: () => { } };
		var connection = new PgPromiseAdapter();
		var cliManager = new CLIManager(inputDevice, outputDevice);
		new CLIController(cliManager, connection);
		await cliManager.Execute("cpf 886.634.854-68");
		await cliManager.Execute("add-item 1 1");
		var output = await cliManager.Execute("preview");
        Assert.Equal("Total: 1000", output);
		await connection.Close();
	}
}
