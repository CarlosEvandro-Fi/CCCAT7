using eCommerce.Infrastructure.DB;

namespace eCommerce.Infrastructure.Repository.DB;

public sealed class OrderRepositoryDatabase
{
    public IConnection Connection { get; }

    public OrderRepositoryDatabase(IConnection connection)
    {
        Connection = connection;
    }
}
