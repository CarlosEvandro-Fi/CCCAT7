namespace eCommerce.Infrastructure.CLI;

public sealed class StdoutAdapter : IOutputDevice
{
    public void Write(string text)
    {
        // process.stdout.write(text);

        Console.WriteLine(text);
    }
}
