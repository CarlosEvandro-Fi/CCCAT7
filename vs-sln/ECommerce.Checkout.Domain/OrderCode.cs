namespace ECommerce.Checkout.Domain;

public class OrderCode
{
    public String Value { get; }

    public OrderCode(DateTime date, Int32 sequence)
    {
        Value = GenerateCode(date, sequence);
    }

    private String GenerateCode(DateTime date, Int32 sequence)
    {
        return date.Year + sequence.ToString().PadLeft(8, '0');
    }
}
