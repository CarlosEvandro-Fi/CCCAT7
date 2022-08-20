namespace ECommerce.Checkout.Application;

public sealed class Checkouting
{
    public IItemRepository ItemRepository { get; }
    public IOrderRepository OrderRepository { get; }

    public Checkouting(IItemRepository itemRepository, IOrderRepository orderRepository)
    {
        ItemRepository = itemRepository;
        OrderRepository = orderRepository;
    }

    public async Task<Output> Execute(Input input)
    {
        var sequence = await this.OrderRepository.Count() + 1;
        var order = new Order(input.CPF, input.Date, sequence);
        foreach (var orderItem in input.OrderItems)
        {
            var item = await this.ItemRepository.GetItem(orderItem.ItemId);
            order.AddItem(item, orderItem.Quantity);
        }
        await this.OrderRepository.Save(order);
        var total = order.GetTotal();
        return new Output { Code = order.GetCode(), Total = total };
    }

    public sealed class Input
    {
        public String CPF { get; set; } = "";
        public DateTime Date { get; set; }
        public (Int32 ItemId, Int32 Quantity)[] OrderItems { get; set; } = Array.Empty<(Int32, Int32)>();
    }
    public sealed class Output
    {
        public String Code { get; set; } = "";
        public Decimal Total { get; set; }
    }
}
