using System.Net.NetworkInformation;

public class BackgroundTask
{
    public void Main()
    {
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

        // Not critical - can be terminated when main thread is closed
        bgThread.IsBackground = true;
        bgThread.Start();

        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine("Main thread is working...");
            Task.Delay(500);
        }

        Console.WriteLine("Done");
        Console.ReadKey();
    }
}