namespace ECommerce.Checkout.Application.Gateway;

public interface IGetItemGateway
{
    Task<Item> Execute(Int64 itemId);
}
