namespace AulaLib;

public interface IOrderRepository
{
    Task<Int32> Count();

    Task Save(Order order);

    Task Clean();
}
