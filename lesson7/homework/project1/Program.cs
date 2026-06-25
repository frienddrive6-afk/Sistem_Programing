using project1;


SuperParallel.Invoke(() => 
{
    Console.WriteLine($"Task 1 started on Thread: {Thread.CurrentThread.ManagedThreadId}");
    Thread.Sleep(1000);
    Console.WriteLine("Task 1 finished");
},() => 
{
Console.WriteLine($"Task 2 started on Thread: {Thread.CurrentThread.ManagedThreadId}");
Thread.Sleep(500);
Console.WriteLine("Task 2 finished");
});


SuperParallel.For(0, 5, (index) => {
    Console.WriteLine($"Iteration {index} executed on Thread: {Thread.CurrentThread.ManagedThreadId}");
    Thread.Sleep(300);
});


string[] names = { "Alice", "Bob", "Charlie", "Diana" };
        
SuperParallel.ForEach(names, (name) =>
{
    Console.WriteLine($"Hello, {name}! (Processed on Thread: {Thread.CurrentThread.ManagedThreadId})");
    Thread.Sleep(400);
        
});
