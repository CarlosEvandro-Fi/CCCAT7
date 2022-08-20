using ECommerce.Catalog.Application;
using ECommerce.Catalog.Infrastructure.Database;
using ECommerce.Catalog.Infrastructure.HTTP;
using ECommerce.Catalog.Infrastructure.Repository.Database;

namespace ECommerce.Catalog.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class ItemsController : ControllerBase
{
    private WebApiAdapter WebApiAdapter { get; }

    public ItemsController()
    {
        WebApiAdapter = new WebApiAdapter();
        var connection = new PgPromiseAdapter();
        var itemRepository = new ItemRepositoryDatabase(connection);
        _ = new Catalog.Infrastructure.Controller.HTTP.ItemController(WebApiAdapter, new GetItem(itemRepository), new GetItems(itemRepository));
    }

    [HttpGet("{itemId}")]
    public async Task<ActionResult<ItemDTO>> GetItem(Int32 itemId)
    {
        var itemDTO = await WebApiAdapter.GetItem(itemId);
        return Ok(itemDTO);
    }

    [HttpGet("")]
    public async Task<ActionResult<IEnumerable<ItemDTO>>> GetItems()
    {
        var enumerableItemDTO = await WebApiAdapter.GetItems();
        return Ok(enumerableItemDTO);
    }
}
