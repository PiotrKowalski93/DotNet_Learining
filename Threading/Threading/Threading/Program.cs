using System.Net.NetworkInformation;

// Passing Parameter to thread
var bgThread = new Thread((object? data) =>
{
    if (data is null) return;
    int counter = 0;
    var result = int.TryParse(data.ToString(), out int maxCount);

    if (!result) return;
    while (counter < maxCount)
    {
        bool isNetworkUp = NetworkInterface.GetIsNetworkAvailable();

        // Thread.CurrentThread.ManagedThreadId Thread unique Id
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} | Is network avaiable: {isNetworkUp} | {counter}");
        Thread.Sleep(10);
        counter++;
    }
});

// Passing Parameter to thread
bgThread.Start(12);

for (int i = 0; i < 10; i++)
{
    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} | Main thread is working...");
    Thread.Sleep(400);
}

Console.WriteLine("Done");
Console.ReadKey();
