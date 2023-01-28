using System.Net.NetworkInformation;

namespace Threading
{
    public class SchedulingThreads
    {
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
