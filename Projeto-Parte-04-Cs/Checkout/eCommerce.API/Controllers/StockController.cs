using eCommerce.Application;
using eCommerce.Infrastructure.Database;
using eCommerce.Infrastructure.HTTP;
using eCommerce.Infrastructure.Repository.Database;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class StockController : ControllerBase
{
    private WebApiAdapter WebApiAdapter { get; }

    public StockController()
    {
        var http = new WebApiAdapter();
        var connection = new PgPromiseAdapter();
        var stockEntryRepository = new StockEntryRepositoryDatabase(connection);
        var incrementStoke = new IncrementStock(stockEntryRepository);
        var decrementStoke = new DecrementStock(stockEntryRepository);
        var getStock = new GetStock(stockEntryRepository);
        _ = new eCommerce.Infrastructure.Controller.StockController(http, incrementStoke, decrementStoke, getStock);
        WebApiAdapter = http;
    }

    [HttpPost("DecrementStock")]
    public async Task<IActionResult> Decrement([FromBody] IEnumerable<WebApiAdapter.DecrementStockDTO> decremets)
    {
        //var http = new WebApiAdapter();
        //var stockEntryRepository = new StockEntryRepositoryDatabase();
        //var incrementStoke = new IncrementStock(stockEntryRepository);
        //var decrementStoke = new DecrementStock(stockEntryRepository);
        //var getStock = new GetStock(stockEntryRepository);
        //_ = new eCommerce.Infrastructure.Controller.StockController(http, incrementStoke, decrementStoke, getStock);
        //await http.DecrementStock(decremets);
        //return Ok();

        await WebApiAdapter.DecrementStock(decremets);
        return Ok();
    }

    [HttpPost("IncrementStock")]
    public async Task<IActionResult> Increment([FromBody] IEnumerable<WebApiAdapter.IncrementStockDTO> incremets)
    {
        //var http = new WebApiAdapter();
        //var stockEntryRepository = new StockEntryRepositoryDatabase();
        //var incrementStoke = new IncrementStock(stockEntryRepository);
        //var decrementStoke = new DecrementStock(stockEntryRepository);
        //var getStock = new GetStock(stockEntryRepository);
        //_ = new eCommerce.Infrastructure.Controller.StockController(http, incrementStoke, decrementStoke, getStock);
        //await http.IncrementStock(incremets);
        //return Ok();

        await WebApiAdapter.IncrementStock(incremets);
        return Ok();
    }

    [HttpGet("GetStock/{ItemId}")]
    public async Task<ActionResult<Int32>> Get([FromRoute(Name = "ItemId")] Int32 itemId)
    {
        //var stockEntryRepository = new StockEntryRepositoryDatabase();
        //var http = new WebApiAdapter();
        //var incrementStoke = new IncrementStock(stockEntryRepository);
        //var decrementStoke = new DecrementStock(stockEntryRepository);
        //var getStock = new GetStock(stockEntryRepository);
        //new Infrastructure.Controller.StockController(http, incrementStoke, decrementStoke, getStock);
        //var total = await getStock.Execute(itemId);
        //return Ok(total);

        var total = await WebApiAdapter.GetStock(itemId);
        return Ok(total);
    }
}
