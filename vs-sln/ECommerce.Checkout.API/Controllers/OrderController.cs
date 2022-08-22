using ECommerce.Checkout.Application;
using ECommerce.Checkout.Application.Gateway;
using ECommerce.Checkout.Infrastructure.Database;
using ECommerce.Checkout.Infrastructure.Gateway;
using ECommerce.Checkout.Infrastructure.HTTP;
using ECommerce.Checkout.Infrastructure.Queue;

namespace ECommerce.Checkout.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class OrderController : ControllerBase
{
    [HttpPost("OrderPreview")]
    public async Task<ActionResult<WebApiAdapter.OrderPreviewResponseDTO>> OrderPreview([FromBody] WebApiAdapter.OrderPreviewDTO orderPreviewDTO)
    {
        var http = new WebApiAdapter();
        var getItemGateway = new GetItemHttpGateway();
        var previewOrder = new PreviewOrder(getItemGateway);
        var queue = new RabbitMQAdapter();
        var checkouting = new Checkouting(queue);
        _ = new Infrastructure.Controller.HTTP.OrderController(http, previewOrder, checkouting);
        var orderPreviewResponseDTO = await http.OrderPreview(orderPreviewDTO);
        return Ok(orderPreviewResponseDTO);
    }
}
