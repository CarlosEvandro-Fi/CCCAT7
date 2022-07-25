using eCommerce.Domain;

namespace eCommerce.Tests;

public class OrderCode_Tests
{
    [Fact]
    public void Deve_Gerar_o_Codigo_do_Pedido()
    {
        var date = new DateTime(2022, 03, 01, 10, 0, 0);
        var sequence = 1;
        var orderCode = new OrderCode(date, sequence);
        Assert.Equal("202200000001", orderCode.Value);
    }
}
