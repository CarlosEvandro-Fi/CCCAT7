using ECommerce.Checkout.Application;
using ECommerce.Checkout.Application.Gateway;
using ECommerce.Checkout.Domain;

namespace ECommerce.Checkout.Tests;

public class PreviewOrder_Tests
{
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
    public async Task Deve_Simular_um_Pedido()
    {
        //var connection = new PgPromiseAdapter();
        // var getItemGateway = new GetItemHttpGateway();
        var getItemGateway = new PlaceboGetItemGateway();
		var previewOrder = new PreviewOrder(getItemGateway);
		var output = await previewOrder.Execute(
			new PreviewOrder.Input
			{
				CPF = "886.634.854-68",
				OrderItems = new List<PreviewOrder.InputItem>
				{
					new PreviewOrder.InputItem { ItemId = 1, Quantity = 1 },
                    new PreviewOrder.InputItem { ItemId = 2, Quantity = 1 },
                    new PreviewOrder.InputItem { ItemId = 3, Quantity = 3 },
                },
				Date = new DateTime(2022, 03, 01, 10, 00, 00)
			}
		);
		Assert.Equal(6090, output.Total);
		//await connection.Close();
	}
}
