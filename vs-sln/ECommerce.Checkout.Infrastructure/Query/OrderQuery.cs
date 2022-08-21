using ECommerce.Checkout.Application.Query;
using ECommerce.Checkout.Infrastructure.Database;

namespace ECommerce.Checkout.Infrastructure.Query;

public sealed class OrderQuery : IOrderQuery
{
    public IConnection Connection { get; }

    public OrderQuery(IConnection iConnection) => Connection = iConnection;

    public async Task<OrderDTO> GetByGuid(string guid)
    {
        //const [orderData] = await this.connection.query("select * from ccca.order where guid = $1", [guid]);
        //orderData.orderItems = await this.connection.query("select * from ccca.order_item where id_order = $1", [orderData.id_order]);
        //for (const orderItemData of orderData.orderItems) {
        //    const [itemData] = await this.connection.query("select * from ccca_catalog.item where id_item = $1", [orderItemData.id_item]);
        //    orderItemData.description = itemData.description;
        //}
        //return orderData;

        return new OrderDTO
        {
            Guid = guid,
            OrderItems = Enumerable.Empty<OrderItemDTO>(),
        };
    }

    public async Task<OrderDTO> GetByGuid2(string guid)
    {
        //const [orderData] = await this.connection.query("select * from ccca.order where guid = $1", [guid]);
        //orderData.orderItems = await this.connection.query("select * from ccca.order_item where id_order = $1", [orderData.id_order]);
        //return orderData;

        return new OrderDTO
        {
            Guid = guid,
            OrderItems = Enumerable.Empty<OrderItemDTO>(),
        };
    }

    public async Task<OrderDTO> GetProjectionByGuid(string guid)
    {
        //const [orderData] = await this.connection.query("select * from ccca.order_projection where guid = $1", [guid]);
        //return orderData;

        return new OrderDTO
        {
            Guid = guid,
            OrderItems = Enumerable.Empty<OrderItemDTO>(),
        };
    }

    public async Task<OrderDTO> SaveOrderProjection(string guid, object order)
    {
        //await this.connection.query("insert into ccca.order_projection (guid, data) values ($1, $2)", [guid, order]);

        return new OrderDTO
        {
            Guid = guid,
            OrderItems = Enumerable.Empty<OrderItemDTO>(),
        };
    }

    public async Task<OrderDTO> GetOrderProjection(string guid)
    {
        //const [orderData] = await this.connection.query("select * from ccca.order_projection where guid = $1", [guid]);
        //return orderData;

        return new OrderDTO
        {
            Guid = guid,
            OrderItems = Enumerable.Empty<OrderItemDTO>(),
        };
    }
}
