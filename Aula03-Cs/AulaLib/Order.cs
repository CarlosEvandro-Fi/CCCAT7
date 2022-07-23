namespace AulaLib;

public sealed class Order
{
    private CPF CPF { get; }
    private Coupon? Coupon { get; set; }
    private DateTime Date { get; }
    private List<OrderItem> OrderItems { get; }

    public Order(CPF cpf, DateTime? date = null)
    {
        CPF = cpf;
        OrderItems = new();
        Date = date ?? DateTime.Now;
    }

    public void AddItem(Item item, Int32 quantity)
    {
        if (OrderItems.Any(orderItem => orderItem.ItemId == item.ItemId)) throw new Exception("Duplicated Item.");
        OrderItems.Add(new OrderItem(item.ItemId, item.Price, quantity));
    }

    public void AddCoupon(Coupon coupon)
    {
        if (coupon.IsExpired(Date)) return;
        Coupon = coupon;
    }
    
    public Decimal GetTotal()
    {
        var total = OrderItems.Sum(item => item.GetTotal());

        total -= (Coupon is null ? 0 : Coupon.GetDiscount(total));

        return total;
    }
}
