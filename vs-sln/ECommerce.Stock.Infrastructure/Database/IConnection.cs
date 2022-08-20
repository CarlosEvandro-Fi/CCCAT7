namespace ECommerce.Stock.Infrastructure.Database
{
    public interface IConnection
    {
        Task Close();

        Task<T> Query<T>(String statement, params Object[] parameters);
    }
}
