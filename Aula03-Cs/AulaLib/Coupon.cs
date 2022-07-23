namespace AulaLib;

public sealed class Coupon
{
    public String Code { get; set; } = "";
    public Decimal Percentage { get; set; }

    public Coupon(String code, Decimal percentage)
    {
        Code = code;
        Percentage = percentage;
    }

    public Decimal GetDiscount(Decimal total) => total * Percentage / 100;
}
