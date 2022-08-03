using eCommerce.Infrastructure.CLI;
using System.Diagnostics.CodeAnalysis;

namespace eCommerce.App.eCommerceConsole;

public sealed class ConsoleAdapter : IInputDevice, IOutputDevice
{
    private Action<String>? Callback { get; set; }

	private Boolean IsBreakCommand([NotNullWhen(false)] String? text)
    {
		return String.Compare("exit", text, StringComparison.OrdinalIgnoreCase) == 0
			|| String.IsNullOrEmpty(text);
	}

	public void OnData(Action<String> callback) => Callback = callback;

	public void Run()
	{
		while (true)
		{
			var text = Console.ReadLine();
			if (IsBreakCommand(text)) break;
			Callback?.Invoke(text);
		}
	}

	public void Write(String text) => Console.WriteLine(text);
}
