namespace ECommerce.Stock.Domain;

public interface IQuery<out TResponse>
{ }

public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
{
	Task<TResponse> Handle(TQuery query, CancellationToken cancellation);
}
