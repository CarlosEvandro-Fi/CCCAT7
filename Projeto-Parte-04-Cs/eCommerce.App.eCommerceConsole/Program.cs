﻿using eCommerce.Infrastructure.CLI;
using eCommerce.Infrastructure.Controller.CLI;
using eCommerce.Infrastructure.DB;

namespace eCommerce.App.eCommerceConsole;

internal class Program
{
    static async Task Main(string[] args)
    {
        // cpf 886.634.854-68
        // add-item 1 1
        // preview
        
        // await UsingStandardAdapter();
        await UsingConsoleAdapter();
    }

    //static async Task UsingStandardAdapter()
    //{
    //    using var cancellation = new CancellationTokenSource();
    //    var inputDevice = new StdinAdapter();
    //    var outputDevice = new StdoutAdapter();
    //    var connection = new PgPromiseAdapter();
    //    var cliManager = new CLIManager(inputDevice, outputDevice);
    //    new CLIController(cliManager, connection);
    //    while (!cancellation.IsCancellationRequested) await Task.Delay(1000);
    //    await connection.Close();
    //}

    static async Task UsingConsoleAdapter()
    {
        var consoleAdapter = new ConsoleAdapter();
        var connection = new PgPromiseAdapter();
        var cliManager = new CLIManager(consoleAdapter, consoleAdapter);
        new CLIController(cliManager, connection);
        consoleAdapter.Run();
        await connection.Close();
    }
}