

// void Run()
// {
//     System.Console.WriteLine($"Message from {Thread.CurrentThread.Name }");
// }

// Thread.CurrentThread.Name = "main";


// Thread t = new Thread(Run)
// {
//     Name = "worker",
// };

// t.Start();
// Run();










// Thread t = new Thread(() => Console.ReadLine());

// if(args.Length == 0)
// {
//     t.IsBackground = true;
    
// }
// t.Start();






#region TPL

// Task, Task<T>, ValueTask, ValueTask<T>, Parallel

// void Run()
// {
//     Console.WriteLine($"Vasia");

// }

// Task task = new Task(Run);
// task.Start();

// Console.WriteLine("main");

// task.Wait();                      //BLOCKING







// using System.Net;

// string DownloadPageSrc(string url)
// {
//     WebClient client = new WebClient();

//     return client.DownloadString(url);
// }

// string url = "https://habr.com/ru/feed/";

// //Console.WriteLine(DownloadPageSrc(url));

// Task<string> t = new Task<string>(() => DownloadPageSrc(url));
// t.Start();

// Console.WriteLine("HELLO FROM MAIN");

// string content = t.Result;      //BLOCKING








// ThreadPool.SetMinThreads(100, 10);

// ThreadPool.GetMinThreads(out int count, out int iocout);
// Console.WriteLine($"count = {count}, iocout = {iocout}");














#endregion






