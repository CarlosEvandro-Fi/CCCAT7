// *** ESSA CLASSE TOMA LUGAR DO ExpressAdapter

using ECommerce.Checkout.Application;
using static ECommerce.Checkout.Infrastructure.Controller.HTTP.OrderController;

namespace ECommerce.Checkout.Infrastructure.HTTP;

public sealed class WebApiAdapter : IHTTP
{
    private Func<PreviewOrder.Input, Task<PreviewOrder.Output>>? OnOrderPreviewFunction { get; set; }

    void IHTTP.OnOrderPreview(Func<PreviewOrder.Input, Task<PreviewOrder.Output>> on)
    {
        OnOrderPreviewFunction = on;
    }

    public async Task<OrderPreviewResponseDTO> OrderPreview(OrderPreviewDTO orderPreviewDTO)
    {
        if (OnOrderPreviewFunction is null) throw new Exception("Configure o On(OrderPreview)");

        var input = new PreviewOrder.Input()
        {
            CPF = orderPreviewDTO.CPF,
            OrderItems = orderPreviewDTO.OrderItems.Select(s => new PreviewOrder.InputItem() { ItemId = s.ItemId, Quantity = s.Quantity }).ToList(),
        };

        var output = await OnOrderPreviewFunction(input);

        return new OrderPreviewResponseDTO() { Total = output.Total };
    }

    public class OrderPreviewDTO
    {
        public String CPF { get; set; } = "";
        public List<OrderPreviewItemDTO> OrderItems { get; set; } = new();
    }

    public class OrderPreviewItemDTO
    {
        public Int32 ItemId { get; set; }
        public Int32 Quantity { get; set; }
    }

    public class OrderPreviewResponseDTO
    {
        public Decimal Total { get; set; }
    }
}
