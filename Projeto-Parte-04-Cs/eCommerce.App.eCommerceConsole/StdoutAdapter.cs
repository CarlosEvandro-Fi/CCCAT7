using eCommerce.Infrastructure.CLI;

namespace eCommerce.App.eCommerceConsole;

public sealed class StdoutAdapter : IOutputDevice
{
    public void Write(string text)
    {
        // process.stdout.write(text);

        Console.WriteLine(text);
    }
}
