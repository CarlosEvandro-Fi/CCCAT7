using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaLib
{
    public class SimulateFreight
	{
		public ItemRepository ItemRepository { get; }

		public SimulateFreight(ItemRepository itemRepository)
		{
			ItemRepository = itemRepository;
		}

		public async Task<Output> Execute(Input input)
		{
			decimal total = 0;
			foreach (var orderItem in input.OrderItems) {
				var item = await this.ItemRepository.GetItem(orderItem.ItemId);
				total += FreightCalculator.Calculate(item) * orderItem.Quantity;
			}
			return new Output { Total = total };
		}

		public class Input
		{
			public (Int32 ItemId, Int32 Quantity)[] OrderItems { get; set; } = Array.Empty<(Int32, Int32)>();
		}
		public class Output
		{
			public Decimal Total { get; set; }
		}
	}
}
