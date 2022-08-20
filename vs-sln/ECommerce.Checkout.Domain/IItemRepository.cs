namespace ECommerce.Checkout.Domain;

public interface IItemRepository
{
    Task<Item> GetItem(Int32 itemId);
}