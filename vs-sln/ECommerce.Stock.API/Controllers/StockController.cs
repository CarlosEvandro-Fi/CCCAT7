using ECommerce.Stock.Application;
using ECommerce.Stock.Infrastructure.Database;
using ECommerce.Stock.Infrastructure.HTTP;
using ECommerce.Stock.Infrastructure.Repository.Database;

namespace ECommerce.Stock.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class StockController : ControllerBase
{
    public IMediator Mediator { get; }

    private WebApiAdapter WebApiAdapter { get; }

    public StockController(IMediator mediator)
    {
        Mediator = mediator;
        var http = new WebApiAdapter();
        var connection = new PgPromiseAdapter();
        var stockEntryRepository = new StockEntryRepositoryDatabase(connection);
        var incrementStoke = new IncrementStock(stockEntryRepository);
        var decrementStoke = new DecrementStock(stockEntryRepository);
        var getStock = new GetStock(stockEntryRepository);
        _ = new ECommerce.Stock.Infrastructure.Controller.StockController(http, incrementStoke, decrementStoke, getStock);
        WebApiAdapter = http;
    }

    [HttpPost("DecrementStock")]
    public async Task<IActionResult> Decrement([FromBody] IEnumerable<WebApiAdapter.DecrementStockDTO> decremets)
    {
        await WebApiAdapter.DecrementStock(decremets);
        return Ok();
    }

    [HttpPost("IncrementStock")]
    public async Task<IActionResult> Increment([FromBody] IEnumerable<WebApiAdapter.IncrementStockDTO> incremets)
    {
        await WebApiAdapter.IncrementStock(incremets);
        return Ok();
    }

    [HttpGet("GetStock/{ItemId}")]
    public async Task<ActionResult<Int32>> Get([FromRoute(Name = "ItemId")] Int32 itemId)
    {
        var query = new GetStockQuery(itemId);
        return await Mediator.Send<GetStockQuery, Int32>(query, default);
    }
}
