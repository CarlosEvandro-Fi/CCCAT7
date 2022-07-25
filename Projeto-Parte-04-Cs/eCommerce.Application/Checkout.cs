using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaLib
{
    public class Checkout
    {
        public ItemRepository ItemRepository { get; }
        public OrderRepository OrderRepository { get; }

        public Checkout(ItemRepository itemRepository, OrderRepository orderRepository)
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

        public class Input
        {
            public String CPF { get; set; } = "";
            public DateTime Date { get; set; }
            public (Int32 ItemId, Int32 Quantity)[] OrderItems { get; set; } = Array.Empty<(Int32, Int32)>();
        }
        public class Output
        {
            public String Code { get; set; } = "";
            public Decimal Total { get; set; }
        }
    }
}
