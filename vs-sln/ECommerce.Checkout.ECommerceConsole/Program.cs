using ECommerce.Checkout.Infrastructure.CLI;
using ECommerce.Checkout.Infrastructure.Controller.CLI;
using ECommerce.Checkout.Infrastructure.Database;

namespace eCommerce.App.eCommerceConsole;

internal class Program
{
    static async Task Main(string[] args)
    {
        // cpf 886.634.854-68
        // add-item 1 1
        // preview
        await UsingConsoleAdapter();
    }

    static async Task UsingConsoleAdapter()
    {
        var consoleAdapter = new ConsoleAdapter();
        var connection = new PgPromiseAdapter();
        var cliManager = new CLIManager(consoleAdapter, consoleAdapter);
        new CLIController(cliManager, connection);
        consoleAdapter.Run();
        await connection.Close();
    }
}