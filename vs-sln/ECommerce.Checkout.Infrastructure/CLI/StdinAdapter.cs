// *** A FORMA COMO FOI IMPLEMENTADO ABAIXO PODE INTERFERIR OU SOFRER
//     INTERFERÊNCIA DE OUTROS LOCAIS QUE TAMBÉM ESTEJAM EFETUANDO A
//     LEITURA DO CONSOLE.
//     PESQUISAR UMA FORMA DE LER A ENTRADA DO CONSOLE SEM CAUSAR O
//     BLOQUEIO DA FONTE DE ENTRADA, OU USAR O ConsoleAdapter.

//namespace ECommerce.Checkout.Infrastructure.CLI;

//public sealed class StdinAdapter : IInputDevice
//{
//	public void OnData(Action<String> callback)
//    {
//		Task.Factory.StartNew(() =>
//		{
//			while(true)
//			{
//				var text = Console.ReadLine();
//				callback(text);
//			}
//		});
//	}
//}
