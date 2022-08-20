namespace ECommerce.Checkout.Domain;

public sealed class Coupon
{
    public String Code { get; } = "";

    public DateTime ExpireDate { get; }

    public Decimal Percentage { get; }

    public Coupon(String code, Decimal percentage, DateTime expireDate)
    {
        Code = code;
        Percentage = percentage;
        ExpireDate = expireDate;
    }

    public Decimal GetDiscount(Decimal total)
    {
        if (IsExpired(ExpireDate)) return 0;
        return total * Percentage / 100;
    }

    public Boolean IsExpired(DateTime expireDate)
    {
        return ExpireDate < expireDate;
    }
}
