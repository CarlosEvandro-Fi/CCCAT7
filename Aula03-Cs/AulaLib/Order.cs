namespace AulaLib;

public sealed class Order
{
    private List<OrderItem> Items { get; }
    private CPF CPF { get; }
    private Coupon? Coupon { get; set; }
    private DateTime Date { get; }

    public Order(CPF cpf, DateTime? date = null)
    {
        CPF = cpf;
        Items = new();
        Date = date ?? DateTime.Now;
    }

    public void AddItem(Item item, Int32 quantity)
    {
        Items.Add(new OrderItem(item.ItemId, item.Price, quantity));
    }

    public void AddCoupon(Coupon coupon)
    {
        if (coupon.IsExpired(Date)) return;
        Coupon = coupon;
    }
    
    public Decimal GetTotal()
    {
        var total = Items.Sum(item => item.GetTotal());

        total -= (Coupon is null ? 0 : Coupon.GetDiscount(total));

        return total;
    }
}
