using ECommerce.Catalog.Domain;

namespace ECommerce.Catalog.Application;

public sealed class GetItems
{
    public IItemRepository ItemRepository { get; }

    public GetItems(IItemRepository itemRepository) => ItemRepository = itemRepository;

    public async Task<IEnumerable<ItemDTO>> Execute()
	{
		var items = await ItemRepository.List();
		var itemsDTO = new List<ItemDTO>();
		foreach (var item in items)
		{
			itemsDTO.Add(ItemDTO.FromItem(item));
		}
		return itemsDTO;
	}
}
