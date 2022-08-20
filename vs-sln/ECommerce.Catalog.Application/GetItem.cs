using ECommerce.Catalog.Domain;

namespace ECommerce.Catalog.Application;

public sealed class GetItem
{
    public IItemRepository ItemRepository { get; }

	public GetItem(IItemRepository itemRepository) => ItemRepository = itemRepository;

    public async Task<ItemDTO> Execute(Int32 itemId)
	{
		var item = await ItemRepository.GetItem(itemId);
		return ItemDTO.FromItem(item);
	}
}
