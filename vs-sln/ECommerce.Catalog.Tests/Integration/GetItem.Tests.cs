using ECommerce.Catalog.Application;
using ECommerce.Catalog.Infrastructure.Database;
using ECommerce.Catalog.Infrastructure.Repository.Database;

namespace ECommerce.Catalog.Tests.Integration;

public class GetItem_Tests
{
    [Fact]
    public async Task Deve_Obter_um_Item()
    {
        var connection = new PgPromiseAdapter();
        var itemRepository = new ItemRepositoryDatabase(connection);
        var getItem = new GetItem(itemRepository);
        var item = await getItem.Execute(1);
        Assert.Equal("Guitarra", item.Description);
        Assert.Equal(1000M, item.Price);
        Assert.Equal(0.03M, item.Volume);
        Assert.Equal(100M, item.Density);
        await connection.Close();
    }
}
