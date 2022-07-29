using eCommerce.Application;
using eCommerce.Infrastructure.CLI;
using eCommerce.Infrastructure.DB;
using eCommerce.Infrastructure.Repository.DB;

namespace eCommerce.Infrastructure.Controller.CLI;

public sealed class CLIController
{
    public CLIController(CLIManager cliManager, IConnection connection)
    {
		var cpf = "";
        List<(Int32 ItemId, Int32 Quantity)> orderItems = new();

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
