using ECommerce.Checkout.Domain;

namespace ECommerce.Checkout.Application.Queue;

public interface IQueue : IDisposable
{
	Task Close();
	Task Connect();
	Task Consume<T>(String eventName, Func<T, Task> callback);
	Task Publish(DomainEvent domainEvent);
}
