namespace AulaLib.Tests;

public class Coupon_Tests
{
    [Fact]
    public void Deve_Criar_Um_Cupom_de_Desconto()
    {
        var coupon = new Coupon("VALE20", 20, new DateTime(2022, 03, 01, 10, 0, 0));
        var discount = coupon.GetDiscount(1000);
        Assert.Equal(200, discount);
    }

    [Fact]
    public void Deve_Criar_Um_Cupom_de_Desconto_Expirado()
    {
        var coupon = new Coupon("VALE20", 20, new DateTime(2022, 03, 01, 10, 0, 0));
        var isExpired = coupon.IsExpired(new DateTime(2022, 03, 10, 10, 0, 0));
        Assert.True(isExpired);
    }
}
