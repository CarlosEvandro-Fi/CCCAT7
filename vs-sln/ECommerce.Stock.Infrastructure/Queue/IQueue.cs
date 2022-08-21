using ECommerce.Stock.Domain;

namespace ECommerce.Stock.Infrastructure.Queue;

public interface IQueue : IDisposable
{
	Task Close();
	Task Connect();
	Task Consume<T>(String eventName, Func<T, Task> callback);
	Task Publish(DomainEvent domainEvent);
}
