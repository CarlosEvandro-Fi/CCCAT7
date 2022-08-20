namespace ECommerce.Checkout.Infrastructure.CLI;

public sealed class CLIManager
{
    private Dictionary<String, Func<String, Task<String>>> Commands { get; } = new();

    private IInputDevice InputDevice { get; }

    private IOutputDevice OutputDevice { get; }

    public CLIManager(IInputDevice inputDevice, IOutputDevice outputDevice)
    {
		InputDevice = inputDevice;
		OutputDevice = outputDevice;

		InputDevice.OnData(async (string text) => {
			await this.Type(text);
		});
	}

	public void AddCommand(String command, Func<String, Task<String>> callback)
	{
		Commands[command] = callback;
	}

	public async Task<String> Execute(String command)
	{
		var name = command.Split(" ");
		var @params = command.Replace(name + " ", "");
		var output = await this.Commands[name.First()].Invoke(@params);
		return output;
	}

	private async Task Type(string text)
	{
		var output = await this.Execute(text);
		if (!String.IsNullOrWhiteSpace(output)) OutputDevice.Write(output);
	}
}
