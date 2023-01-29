using System.Net.NetworkInformation;

namespace Threading
{
    public class SchedulingThreads
    {
        public void Main()
        {
            var networkingWork = new SchedulingThreads();

            var bgThread1 = new Thread(networkingWork.CheckNetworkStatus);
            var bgThread2 = new Thread(networkingWork.CheckNetworkStatus);
            var bgThread3 = new Thread(networkingWork.CheckNetworkStatus);
            var bgThread4 = new Thread(networkingWork.CheckNetworkStatus);
            var bgThread5 = new Thread(networkingWork.CheckNetworkStatus);

            bgThread1.Priority = ThreadPriority.Lowest;
            bgThread2.Priority = ThreadPriority.BelowNormal;
            bgThread3.Priority = ThreadPriority.Normal;
            bgThread4.Priority = ThreadPriority.AboveNormal;
            bgThread5.Priority = ThreadPriority.Highest;

            bgThread1.Start("Lowest");
            bgThread2.Start("BelowNormal");
            bgThread3.Start("Normal");
            bgThread4.Start("AboveNormal");
            bgThread5.Start("Highest");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main thread working...");
            }
        }


        public void CheckNetworkStatus(object data)
        {
            for (int i = 0; i < 12; i++)
            {
                bool isNetworkUp = NetworkInterface.GetIsNetworkAvailable();
                Console.WriteLine($"Thread priority {(string)data}; Is network available? Answer: {isNetworkUp}");
                i++;
            }
        }
    }
}
