using ECommerce.Stock.Application;
using ECommerce.Stock.Domain;

namespace ECommerce.Stock.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class StockController : ControllerBase
{
    [HttpPost("DecrementStock")]
    public async Task<IActionResult> Decrement([FromBody] IEnumerable<DecrementStockDTO> decremets,
		[FromServices] ICommandHandler<DecrementStockCommand> handler)
	{
        await handler.Handle(new DecrementStockCommand(decremets), default(CancellationToken));
        return Ok();
    }

    [HttpPost("IncrementStock")]
    public async Task<IActionResult> Increment([FromBody] IEnumerable<IncrementStockDTO> incremets,
		[FromServices] ICommandHandler<IncrementStockCommand> handler)
	{
        await handler.Handle(new IncrementStockCommand(incremets), default(CancellationToken));
        return Ok();
    }

    [HttpGet("GetStock/{ItemId}")]
    public async Task<ActionResult<Int32>> Get([FromRoute(Name = "ItemId")] Int32 itemId,
        [FromServices] IQueryHandler<GetStockQuery, Int32> handler)
    {
        var query = new GetStockQuery(itemId);
        return await handler.Handle(query, default(CancellationToken));
    }
}
