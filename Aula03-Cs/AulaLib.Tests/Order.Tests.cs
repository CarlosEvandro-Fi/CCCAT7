namespace AulaLib.Tests;

public class Order_Tests
{
    [Fact]
    public void Deve_Criar_Pedido_Vazio()
    {
        var order = new Order("886.634.854-68");
        var total = order.GetTotal();
        Assert.Equal(0, total);
    }

    [Fact]
    public void Nao_Deve_Criar_Com_CPF_Invalido()
    {
        Assert.Throws<Exception>(() => new Order("111.111.111-11"));
    }

    [Fact]
    public void Deve_Criar_Pedido_Com_3_Itens()
    {
        var order = new Order("886.634.854-68");
        order.AddItem(new Item(1, "Guitarra", 1000), 1);
        order.AddItem(new Item(2, "Amplificador", 5000), 1);
        order.AddItem(new Item(3, "Cabo", 30), 3);
        var total = order.GetTotal();
        Assert.Equal(6090, total);
    }

    [Fact]
    public void Deve_Criar_Pedido_Com_3_Itens_Com_Cupon_Desconto()
    {
        var order = new Order("886.634.854-68");
        order.AddItem(new Item(1, "Guitarra", 1000), 1);
        order.AddItem(new Item(2, "Amplificador", 5000), 1);
        order.AddItem(new Item(3, "Cabo", 30), 3);
        order.AddCoupon(new Coupon("VALE20", 20, DateTime.Now.AddDays(1)));
        var total = order.GetTotal();
        Assert.Equal(4872, total);
    }

    [Fact]
    public void Deve_Criar_Pedido_Com_3_Itens_Com_Cupon_Desconto_Expirado()
    {
        var order = new Order("886.634.854-68", new DateTime(2022, 03, 10, 10, 0, 0));
        order.AddItem(new Item(1, "Guitarra", 1000), 1);
        order.AddItem(new Item(2, "Amplificador", 5000), 1);
        order.AddItem(new Item(3, "Cabo", 30), 3);
        order.AddCoupon(new Coupon("VALE20", 20, new DateTime(2022, 03, 01, 10, 0, 0)));
        var total = order.GetTotal();
        Assert.Equal(6090, total);
    }

    [Fact]
    public void Nao_Deve_Criar_Pedido_Com_Item_Duplicado()
    {
        var order = new Order("886.634.854-68");
        order.AddItem(new Item(1, "Guitarra", 1000), 1);
        Assert.Throws<Exception>(() => order.AddItem(new Item(1, "Guitarra", 1000), 1));
    }

}
