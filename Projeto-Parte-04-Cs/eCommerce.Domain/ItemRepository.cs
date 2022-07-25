namespace AulaLib;

public interface IItemRepository
{
    Task<Item> GetItem(Int32 itemId);
}