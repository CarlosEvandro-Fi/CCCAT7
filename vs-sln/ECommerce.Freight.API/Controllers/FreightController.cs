using ECommerce.Freight.Infrastructure.Database;
using ECommerce.Freight.Infrastructure.HTTP;
using static ECommerce.Freight.Infrastructure.HTTP.WebApiAdapter;

namespace ECommerce.Freight.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class FreightController : ControllerBase
{
    private WebApiAdapter WebApiAdapter { get; }

    public FreightController()
    {
        var http = new WebApiAdapter();
        var connection = new PgPromiseAdapter();
        _ = new ECommerce.Freight.Infrastructure.Controller.FreightController(http, connection);
        WebApiAdapter = http;
    }

    [HttpPost("CalculateFreight")]
    public async Task<ActionResult<CalculateFreightResponseDTO>> CalculateFreight([FromBody] WebApiAdapter.CalculateFreightDTO data)
    {
        var total = await WebApiAdapter.CalculateFreight(data);
        return Ok(total);
    }
}
