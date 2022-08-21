using ECommerce.Checkout.Application.Query;

namespace ECommerce.Checkout.Application;

public sealed class GetOrder2
{
    private IOrderQuery OrderQuery { get; set; }

    public GetOrder2(IOrderQuery orderQuery)
    {
        OrderQuery = orderQuery;
    }

    public async Task<OrderDTO> Execute(string guid)
    {
		return await OrderQuery.GetByGuid(guid);
	}
}
