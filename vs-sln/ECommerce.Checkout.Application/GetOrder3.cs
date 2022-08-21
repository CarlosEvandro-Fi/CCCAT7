using ECommerce.Checkout.Application.Query;

namespace ECommerce.Checkout.Application;

public sealed class GetOrder3
{
    private IOrderQuery OrderQuery { get; set; }

    public GetOrder3(IOrderQuery orderQuery)
    {
        OrderQuery = orderQuery;
    }

    public async Task<OrderDTO> Execute(string guid)
    {
        return await OrderQuery.GetOrderProjection(guid);
    }
}
