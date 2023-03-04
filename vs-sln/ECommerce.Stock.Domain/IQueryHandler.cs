using System.Diagnostics;

namespace ECommerce.Stock.Domain;

public interface IQuery<out TResponse>
{ }

public interface IQueryHandler<in TQuery, TResponse> where TQuery : IQuery<TResponse>
{
	Task<TResponse> Handle(TQuery query, CancellationToken cancellation);
}

public class QueryHandlerDecorator<TQuery, TResponse> : IQueryHandler<TQuery, TResponse>
	where TQuery : IQuery<TResponse>
{
	public IQueryHandler<TQuery, TResponse> Decorated { get; }

	public QueryHandlerDecorator(IQueryHandler<TQuery, TResponse> decorated)
	{
		Decorated = decorated;
	}

	public async Task<TResponse> Handle(TQuery query, CancellationToken cancellation)
	{
		System.Diagnostics.Debug.WriteLine($"Query {query.ToString()}.");
		var sw = new Stopwatch();
		sw.Start();
		var handled = await Decorated.Handle(query, cancellation);
		sw.Stop();
		System.Diagnostics.Debug.WriteLine($"Handled in {sw.ElapsedMilliseconds}ms.");
		return handled;
	}
}