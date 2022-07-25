namespace eCommerce.Infrastructure.DB
{
    public interface IConnection
    {
        Task Close();

        Task<T> Query<T>(String statement, params Object[] parameters);
    }
}
