using ECommerce.Stock.Domain;

namespace ECommerce.Stock.Infrastructure.Queue;

public interface IQueue
{
	Task Connect();
	Task Close();
	Task Consume<T>(String eventName, Action<T> callback);
	Task Publish(DomainEvent domainEvent);
}
