﻿using eCommerce.Infrastructure.Database;
using eCommerce.Infrastructure.HTTP;
using static eCommerce.Infrastructure.HTTP.WebApiAdapter;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class FreightController : ControllerBase
{
    private WebApiAdapter WebApiAdapter { get; }

    public FreightController()
    {
        var http = new WebApiAdapter();
        var connection = new PgPromiseAdapter();
        _ = new eCommerce.Infrastructure.Controller.FreightController(http, connection);
        WebApiAdapter = http;
    }

    [HttpPost("CalculateFreight")]
    public async Task<ActionResult<CalculateFreightResponseDTO>> CalculateFreight([FromBody] WebApiAdapter.CalculateFreightDTO data)
    {
        var total = await WebApiAdapter.CalculateFreight(data);
        return Ok(total);
    }
}
