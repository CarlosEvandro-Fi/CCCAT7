﻿namespace ECommerce.Checkout.Domain;

public sealed class Order
{
    private OrderCode Code { get; }
    private Coupon? Coupon { get; set; }
    private CPF CPF { get; }
    private DateTime Date { get; }
    private List<OrderItem> OrderItems { get; }
    public IEnumerable<OrderItem> Items => OrderItems;
    private Decimal Freight { get; set; }

    public Order(CPF cpf, DateTime? date = null, Int32 sequence = 1)
    {
        Date = date ?? DateTime.Now;
        CPF = cpf;
        OrderItems = new();
        Code = new OrderCode(Date, sequence);
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

    public String GetCode() => Code.Value;

    public Decimal GetTotal()
    {
        var total = OrderItems.Sum(item => item.GetTotal());

        total -= (Coupon is null ? 0 : Coupon.GetDiscount(total));

        total += Freight;

        return total;
    }
}
