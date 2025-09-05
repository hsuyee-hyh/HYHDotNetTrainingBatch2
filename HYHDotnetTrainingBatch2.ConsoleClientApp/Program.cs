// See https://aka.ms/new-console-template for more information
using HYHDotnetTrainingBatch2.ConsoleClientApp;

Console.WriteLine("Hello, World!");

HttpClientService httpClientService = new HttpClientService();
await httpClientService.RunAsync();
Console.ReadKey();
