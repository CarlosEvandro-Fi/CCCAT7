using eCommerce.Application;
using eCommerce.Infrastructure.Database;
using eCommerce.Infrastructure.Repository.Database;

namespace eCommerce.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public sealed class OrderController : ControllerBase
{
    [HttpPost("OrderPreview")]
    public async Task<ActionResult<PreviewOrder.Output>> OrderPreview([FromBody] PreviewOrder.Input input)
    {
        var connection = new PgPromiseAdapter();
        var itemRepository = new ItemRepositoryDatabase(connection);
        var previewOrder = new PreviewOrder(itemRepository);
        var output = await previewOrder.Execute(input);
        await connection.Close();
        return Ok(output);
    }
}
