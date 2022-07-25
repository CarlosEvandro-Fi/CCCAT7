using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaLib
{
    public class ItemRepository
    {
        private readonly List<Item> Items = new()
        {
            new Item(1, "Guitarra", 1000, new Dimension(100, 30, 10, 3)),
            new Item(2, "Guitarra", 5000, new Dimension(50, 50, 50, 20)),
            new Item(3, "Guitarra", 30, new Dimension(10, 10, 10, 1)),
        };

        public async Task<Item> GetItem(Int32 itemId)
        {
            foreach (var item in Items)
            {
                if (item.ItemId == itemId) return item;
            }

            throw new Exception("ITEM NOT FOUND");
        }
    }

    public class ItemRepositoryDatabase : ItemRepository
    {
        public Connection Connection { get; }

        public ItemRepositoryDatabase(Connection connection)
        {
            Connection = connection;
        }
    }
}
