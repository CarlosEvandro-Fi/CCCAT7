﻿namespace eCommerce.Infrastructure.CLI;

public sealed class CLIManager
{
    private IInputDevice InputDevice { get; }

    private IOutputDevice OutputDevice { get; }

    private Dictionary<String, Func<String, Task<String>>> Commands { get; } = new();

    public CLIManager(IInputDevice inputDevice, IOutputDevice outputDevice)
    {
		InputDevice = inputDevice;

		InputDevice.OnData(async (string text) => {
			await this.Type(text);
		});
	}

	public void AddCommand(String command, Func<String, Task<String>> callback)
	{
		Commands[command] = callback;
	}

	public async Task<String> execute(String command)
	{
		var name = command.Split(" ");
		var @params = command.Replace(name + " ", "");
		var output = await this.Commands[name.First()].Invoke(@params);
		return output;
	}

	private async Task Type(string text)
	{
		var output = await this.execute(text);
		if (!String.IsNullOrWhiteSpace(output)) OutputDevice.Write(output);
	}
}
