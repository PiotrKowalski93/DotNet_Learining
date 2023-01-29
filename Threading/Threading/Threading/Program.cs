using System.Net.NetworkInformation;
using Threading;

Parallel.Invoke(
    () =>
    {
        Console.WriteLine($"Hello from lambda expression. Thread id: {Thread.CurrentThread.ManagedThreadId}");
    },
    new Action(() =>
    {
        Console.WriteLine($"Hello from Action. Thread id: {Thread.CurrentThread.ManagedThreadId}");
    }),
    delegate ()
    {
        Console.WriteLine($"Hello from delegate. Thread id: {Thread.CurrentThread.ManagedThreadId}");
    }
);

var numbers = new List<int>()
{
    1,2, 3, 4, 5, 6, 7
};

Parallel.ForEach(numbers, number =>
{
    bool timeContainsNumber = DateTime.Now.ToLongTimeString().Contains(number.ToString());
    if (timeContainsNumber)
    {
        Console.WriteLine($"The current time contains number {number}. Thread id: {Thread.CurrentThread.ManagedThreadId}");
    }
    else
    {
        Console.WriteLine($"The current time does not contain number {number}. Thread id: {Thread.CurrentThread.ManagedThreadId}");
    }
});


var evenNumbers = numbers.Where(n => n % 2 == 0);
var evenNumbersP = numbers.AsParallel().Where(n =>
{
    Task.Delay(100);
    return n % 2 == 0;
});

var numberString = string.Join(",", evenNumbers);
var numberStringP = string.Join(",", evenNumbersP);

Console.WriteLine($"Number string: {numberString}");
Console.WriteLine($"Number string: {numberStringP}");

Console.ReadKey();