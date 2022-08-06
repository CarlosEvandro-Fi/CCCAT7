namespace Testing.API.WebFactory;

public interface IApi : IDisposable
{
    IScope CreateScope();
}
