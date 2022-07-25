using eCommerce.Infrastructure.DB;

namespace eCommerce.Infrastructure.Repository.DB;

public sealed class ItemRepositoryDatabase
{
    public IConnection Connection { get; }

    public ItemRepositoryDatabase(IConnection connection)
    {
        Connection = connection;
    }
}
