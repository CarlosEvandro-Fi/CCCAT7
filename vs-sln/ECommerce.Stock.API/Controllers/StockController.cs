using ECommerce.Stock.Application;

namespace ECommerce.Stock.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class StockController : ControllerBase
{
    public IMediator Mediator { get; }

    public StockController(IMediator iMediator) => Mediator = iMediator;
    

    [HttpPost("DecrementStock")]
    public async Task<IActionResult> Decrement([FromBody] IEnumerable<DecrementStockDTO> decremets)
    {
        await Mediator.Send(new DecrementStockCommand(decremets), default(CancellationToken));
        return Ok();
    }

    [HttpPost("IncrementStock")]
    public async Task<IActionResult> Increment([FromBody] IEnumerable<IncrementStockDTO> incremets)
    {
        await Mediator.Send(new IncrementStockCommand(incremets), default(CancellationToken));
        return Ok();
    }

    [HttpGet("GetStock/{ItemId}")]
    public async Task<ActionResult<Int32>> Get([FromRoute(Name = "ItemId")] Int32 itemId)
    {
        var query = new GetStockQuery(itemId);
        return await Mediator.Send<GetStockQuery, Int32>(query, default(CancellationToken));
    }
}
