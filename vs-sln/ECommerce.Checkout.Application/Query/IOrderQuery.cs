namespace ECommerce.Checkout.Application.Query;

public interface IOrderQuery
{
    Task<OrderDTO> GetByGuid(string guid);
    Task<OrderDTO> GetByGuid2(string guid);
    Task<OrderDTO> GetProjectionByGuid(string guid);
    Task<OrderDTO> SaveOrderProjection(string guid, OrderDTO order);
    Task<OrderDTO> GetOrderProjection(string guid);
}

public sealed class OrderDTO
{
    public String Guid { get; set; } = "";

    public IEnumerable<OrderItemDTO> OrderItems { get; set; } = Enumerable.Empty<OrderItemDTO>();
}

public sealed class OrderItemDTO
{
    public Int64 ItemId { get; set; }

    public String Description { get; set; } = "";
}
