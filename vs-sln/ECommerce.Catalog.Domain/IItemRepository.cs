namespace ECommerce.Catalog.Domain;

public interface IItemRepository
{
    Task<Item> GetItem(Int32 itemId);
    Task<IEnumerable<Item>> List();
}