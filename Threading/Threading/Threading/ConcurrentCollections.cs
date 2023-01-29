using System.Collections.Concurrent;

namespace Threading
{
    public class ConcurrentCollections
    {
        // most common collections in concurrent programming
        ConcurrentBag<int> bag = new ConcurrentBag<int>();
        ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        ConcurrentStack<int> stack = new ConcurrentStack<int>();
        BlockingCollection<int> blockingCollection = new BlockingCollection<int>();
        ConcurrentDictionary<int, string> dict = new ConcurrentDictionary<int, string>();


    }
}
