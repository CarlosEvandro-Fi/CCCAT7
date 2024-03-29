﻿using eCommerce.Infrastructure.Database;
using eCommerce.Infrastructure.HTTP;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class OrderController : ControllerBase
{
    [HttpPost("OrderPreview")]
    public async Task<ActionResult<WebApiAdapter.OrderPreviewResponseDTO>> OrderPreview([FromBody] WebApiAdapter.OrderPreviewDTO orderPreviewDTO)
    {
        var http = new WebApiAdapter();
        var connection = new PgPromiseAdapter();
        _ = new Infrastructure.Controller.HTTP.OrderController(http, connection);
        var orderPreviewResponseDTO = await http.OrderPreview(orderPreviewDTO);
        return Ok(orderPreviewResponseDTO);
    }
}
