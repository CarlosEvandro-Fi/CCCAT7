namespace Aula02Lib;

public sealed class Order
{
    private List<OrderItem> Items { get; } = new();
    private CPF CPF { get; }
    private Coupon? Coupon { get; set; }

    public Order(CPF cpf) => CPF = cpf;

    public void AddItem(Item item, Int32 quantity)
    {
        Items.Add(new OrderItem(item.ItemId, item.Price, quantity));
    }

    public void AddCoupon(Coupon coupon) => Coupon = coupon;
    
    public Decimal GetTotal()
    {
        var total = Items.Sum(item => item.GetTotal());

        total -= (Coupon is null ? 0 : Coupon.GetDiscount(total));

        return total;
    }
}
