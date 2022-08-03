using eCommerce.Infrastructure.CLI;

namespace eCommerce.App.eCommerceConsole;

public sealed class StdinAdapter : IInputDevice
{
	public void OnData(Action<String> callback)
    {
		//process.stdin.on("data", function(chunk) {
		//	const text = chunk.toString();
		//	callback(text);
		//});

		// *** A FORMA COMO FOI IMPLEMENTADO ABAIXO PODE INTERFERIR OU SOFRER
		//     INTERFERÊNCIA DE OUTROS LOCAIS QUE TAMBÉM ESTEJAM EFETUANDO A
		//     LEITURA DO CONSOLE.
		//     PESQUISAR UMA FORMA DE LER A ENTRADA DO CONSOLE SEM CAUSAR O
		//     BLOQUEIO DA FONTE DE ENTRADA, OU USAR O ConsoleAdapter.

		Task.Factory.StartNew(() =>
		{
			while(true)
			{
				var text = Console.ReadLine();
				callback(text);
			}
		});
	}
}
