// *** ESSA CLASSE TOMA LUGAR DO ExpressAdapter

using eCommerce.Application;
using static eCommerce.Application.CalculateFreight;

namespace eCommerce.Infrastructure.HTTP;

public sealed class WebApiAdapter : IHTTP
{
    //  DECREMENT STOCK

    private Func<CalculateFreight.Input, Task<CalculateFreight.Output>>? OnCalculateFreightFunction { get; set; }

    void IHTTP.OnCalculateFreight(Func<CalculateFreight.Input, Task<CalculateFreight.Output>> on) => OnCalculateFreightFunction = on;

    public async Task<Decimal> CalculateFreight(CalculateFreightDTO info)
    {
        if (OnCalculateFreightFunction is null) throw new Exception("Configure o CalculateFreight");

        List<OrderItem> orderItems = new();

        foreach (var item in info.OrderItems)
        {
            orderItems.Add(new() { Density = item.Density, Quantity = item.Quantity, Volume = item.Volume});
        }

        CalculateFreight.Input input = new()
        {
            From = info.From,
            To = info.To,
            OrderItems = orderItems,
        };

        var output = await OnCalculateFreightFunction.Invoke(input);

        return output.Total;
    }

    public sealed class CalculateFreightDTO
    {
        public String From { get; set; } = "";
        public String To { get; set; } = "";
        public IEnumerable<OrderItemDTO> OrderItems { get; set; } = Array.Empty<OrderItemDTO>();
    }

    public sealed class OrderItemDTO
    {
        public Double Density { get; set; }
        public Int32 Quantity { get; set; }
        public Double Volume { get; set; }
    }
}
