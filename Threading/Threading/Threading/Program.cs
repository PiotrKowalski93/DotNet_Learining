// See https://aka.ms/new-console-template for more information
using System.Net.NetworkInformation;


Console.WriteLine("Hello, World!");
var bgThread = new Thread(() =>
{
    while (true)
    {
        bool isNetworkUp = NetworkInterface.GetIsNetworkAvailable();

        Console.WriteLine($"Is network avaiable: {isNetworkUp}");
        Thread.Sleep(1000);
    }
});

bgThread.IsBackground = true;
bgThread.Start();

for (int i = 0; i < 10; i++)
{
    Console.WriteLine("Main thread is working...");
    Task.Delay(500);
}

Console.WriteLine("Done");
Console.ReadKey();