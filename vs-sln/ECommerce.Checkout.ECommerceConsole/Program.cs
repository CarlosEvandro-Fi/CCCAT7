using ECommerce.Checkout.Application;
using ECommerce.Checkout.Application.Gateway;
using ECommerce.Checkout.Infrastructure.CLI;
using ECommerce.Checkout.Infrastructure.Controller.CLI;
using ECommerce.Checkout.Infrastructure.Database;
using ECommerce.Checkout.Infrastructure.Gateway;

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
        var getItemGateway = new GetItemHttpGateway();
        var previewOrder = new PreviewOrder(getItemGateway);
        new CLIController(cliManager, previewOrder);
        consoleAdapter.Run();
        await connection.Close();
    }
}