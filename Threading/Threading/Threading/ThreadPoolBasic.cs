using System.Net.NetworkInformation;

namespace Threading
{
    internal class ThreadPoolBasic
    {
        public void Main()
        {
            // Threads have default priority
            // You can set pool of threads, if one thread done its job - thread backs to the pool and is ready to work on new task
            ThreadPool.QueueUserWorkItem((o) =>
            {
                while (true)
                {
                    bool isNetworkUp = NetworkInterface.GetIsNetworkAvailable();

                    Console.WriteLine($"Is network avaiable: {isNetworkUp}");
                    Thread.Sleep(1000);
                }
            });

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread is working...");
                Task.Delay(500);
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
