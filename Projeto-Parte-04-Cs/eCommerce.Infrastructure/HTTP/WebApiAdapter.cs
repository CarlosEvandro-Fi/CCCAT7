// *** ESSA CLASSE TOMA LUGAR DO ExpressAdapter

using eCommerce.Application;
using static eCommerce.Infrastructure.Controller.HTTP.OrderController;

namespace eCommerce.Infrastructure.HTTP;

public sealed class WebApiAdapter : IHTTP
{
    public Func<PreviewOrder.Input, Task<PreviewOrder.Output>>? OrderPreview { get; set; }

    public async Task<OrderPreviewResponseDTO> On(OrderPreviewDTO orderPreviewDTO)
    {
        if (OrderPreview is null) throw new Exception("Configure o On(OrderPreview)");

        var input = new PreviewOrder.Input()
        {
            CPF = orderPreviewDTO.CPF,
            OrderItems = orderPreviewDTO.OrderItems.Select(s => new PreviewOrder.InputItem() { ItemId = s.ItemId, Quantity = s.Quantity }).ToList(),
        };

        var output = await OrderPreview(input);

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
