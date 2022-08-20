// *** ESSA CLASSE TOMA LUGAR DO ExpressAdapter

using ECommerce.Catalog.Application;

namespace ECommerce.Catalog.Infrastructure.HTTP;

public sealed class WebApiAdapter : IHTTP
{
    private Func<Int32, Task<ItemDTO>>? OnGetItemFunction { get; set; }

    void IHTTP.OnGetItem(Func<Int32, Task<ItemDTO>> on) => OnGetItemFunction = on;

    public async Task<ItemDTO> GetItem(Int32 itemId)
    {
        if (OnGetItemFunction is null) throw new Exception("Configure o OnGetItem");

        return await OnGetItemFunction.Invoke(itemId);
    }

    //

    private Func<Task<IEnumerable<ItemDTO>>>? OnGetItemsFunction { get; set; }

    void IHTTP.OnGetItems(Func<Task<IEnumerable<ItemDTO>>> on) => OnGetItemsFunction = on;

    public async Task<IEnumerable<ItemDTO>> GetItems()
    {
        if (OnGetItemsFunction is null) throw new Exception("Configure o OnGetItems");

        return await OnGetItemsFunction.Invoke();
    }
}
