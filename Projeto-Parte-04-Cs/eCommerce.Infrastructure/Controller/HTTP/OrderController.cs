using eCommerce.Application;
using eCommerce.Infrastructure.DB;
using eCommerce.Infrastructure.HTTP;
using eCommerce.Infrastructure.Repository.DB;

namespace eCommerce.Infrastructure.Controller.HTTP;

public sealed class OrderController
{
    public OrderController(IHttp http, IConnection connection)
    {
        //http.on("post", "/orderPreview", function (params: any, body: any) {
        //    const itemRepository = new ItemRepositoryDatabase(connection);
        //    const previewOrder = new PreviewOrder(itemRepository);
        //    const output = previewOrder.execute(body);
        //    return output;
        //});

        //http.On("post", "/orderPreview", (String @params, PreviewOrder.Input body) => {
        //    var itemRepository = new ItemRepositoryDatabase(connection);
        //    var previewOrder = new PreviewOrder(itemRepository);
        //    var output = previewOrder.Execute(body);
        //    return output;
        //});
    }
}
