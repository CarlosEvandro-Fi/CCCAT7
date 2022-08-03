namespace eCommerce.Infrastructure.HTTP;

public interface IHttp
{
	void Listen(int port);

    void On(string method, string url, Action callback);
}
