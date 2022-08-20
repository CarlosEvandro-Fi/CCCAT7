using ECommerce.Checkout.Application;
using ECommerce.Checkout.Infrastructure.CLI;
using ECommerce.Checkout.Infrastructure.Database;
using ECommerce.Checkout.Infrastructure.Repository.Database;

namespace ECommerce.Checkout.Infrastructure.Controller.CLI;

public sealed class CLIController
{
    public CLIController(CLIManager cliManager, IConnection connection)
    {
		var cpf = "";
        List<PreviewOrder.InputItem> orderItems = new();

        cliManager.AddCommand("cpf",
            async (string @params) =>
            {
                cpf = @params;
                return await Task.FromResult("");
            });

        cliManager.AddCommand("add-item",
            async (string @params) =>
            {
                var values = @params.Split(" ");
                orderItems.Add(new() { ItemId = int.Parse(values[1]), Quantity = int.Parse(values[1]) });
                return await Task.FromResult("");
            });

        cliManager.AddCommand("preview", 
            async (string s) =>
            {
                var itemRepository = new ItemRepositoryDatabase(connection);
                var previewOrder = new PreviewOrder(itemRepository);
                var input = new PreviewOrder.Input() { CPF = cpf, OrderItems = orderItems };
                var output = await previewOrder.Execute(input);
                return $"Total: {output.Total}";
            });
    }
}
