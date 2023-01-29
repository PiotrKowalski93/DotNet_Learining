using System.Collections.Concurrent;
using System.Net.NetworkInformation;
using Threading;

ConcurrentBag<int> bag = new ConcurrentBag<int>();
ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
ConcurrentStack<int> stack = new ConcurrentStack<int>();

Console.ReadKey();