
#region Task properties

// Task t = new Task(() =>
// {
//     Console.WriteLine("Start");
//     Thread.Sleep(1000);
//     Console.WriteLine("End");
// });

// t.Start();

// Console.WriteLine(t.Id);
// Console.WriteLine(t.Status);
// Console.WriteLine(t.IsCompleted);
// Console.WriteLine(t.Exception);



#endregion







#region Embedded  task


// Task t1 = new Task(() =>
// {
//     Console.WriteLine("t1 started");

//     Task t2 = new Task(() => 
//     {
//         Console.WriteLine("t2 started");
//         Thread.Sleep(1000);
//         Console.WriteLine("t2 finished");
//     });
//     t2.Start();
//     // t2.Wait();


// });

// t1.Start();
// t1.Wait();

// System.Console.WriteLine("Main Finished");




#endregion





#region Rask array

// long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;


// List<Task> tasks = new List<Task>()
// {
//     new Task(() =>
//     {
//         Thread.Sleep(1000);
//         Console.WriteLine("Task 1000ms finished");
//     }),
//     new Task(() =>
//     {
//         Thread.Sleep(1200);
//         Console.WriteLine("Task 1200ms finished");
//     }),new Task(() =>
//     {
//         Thread.Sleep(2000);
//         Console.WriteLine("Task 2000ms finished");
//     }),
// };

// tasks.ForEach(t => t.Start());

// // Task.WaitAll(tasks.ToArray());
// Task.WaitAny(tasks.ToArray());


// System.Console.WriteLine("Main Finished");
// System.Console.WriteLine(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - time);



#endregion





#region Returns



// Task<int> t = new Task<int>(() =>
// {
//     Thread.Sleep(1000);
//     return 10;
// });

// t.Start();

// int result = t.Result;

// Console.WriteLine(result);



// int a = 4;
// int b = 6;
// Task<int> t = new Task<int>(() => Sum(a, b));
// t.Start();
// Console.WriteLine(t.Result);

// int Sum(int a, int b) => a + b;







// Task<Thread> t = new Task<Thread>(() =>
// {
//     Thread thread = new Thread(() => Console.WriteLine("Hello"));

//     return thread;
// }); 


// t.Start();

// Thread thread = t.Result;
// thread.Start();







#endregion



#region Task chain


// using System.Text;

// Photo photo = new Photo();

// Task<Photo> t1 = new Task<Photo>(() =>
// {
//     Thread.Sleep(1000);
//     photo.Filters.Add("filter_1");
//     return photo;
// });

// Task<Photo> taskResult = t1.ContinueWith((t) =>
// {
//     Photo res = t.Result;
//     res.Filters.Add("filter_2");

//     return res;
// }).ContinueWith((t) =>
// {
//     Photo res = t.Result;
//     res.Filters.Add("filter_3");

//     return res;
// });

// t1.Start();

// Photo result = taskResult.Result;
// Console.WriteLine(result);




// class Photo
// {
//     public List<string> Filters { get; set; } = new List<string>();

//     public override string ToString()
//     {
//         StringBuilder sb = new StringBuilder();
//         Filters.ForEach(f => sb.Append($"{f} "));

//         return sb.ToString();
//     }
// }










// Task t1 = new Task(() => Console.WriteLine("start stask"));

// Task chain = t1
//     .ContinueWith((t) => Console.WriteLine(t.Id))
//     .ContinueWith((t) => Console.WriteLine(t.Id))
//     .ContinueWith((t) => Console.WriteLine(t.Id))
//     .ContinueWith((t) => Console.WriteLine(t.Id))
//     .ContinueWith((t) => Console.WriteLine(t.Id))
//     .ContinueWith((t) => Console.WriteLine(t.Id))
//     .ContinueWith((t) => Console.WriteLine(t.Id))
//     .ContinueWith((t) => Console.WriteLine(t.Id))
//     .ContinueWith((t) => Console.WriteLine(t.Id))
//     .ContinueWith((t) => Console.WriteLine(t.Id))
//     .ContinueWith((t) => Console.WriteLine(t.Id));

// t1.Start();
// chain.Wait();











#endregion





#region class Parallel



// Parallel.Invoke(
//     () =>
//     {
//         Thread.Sleep(1000);
//         Console.WriteLine("Task 1000 ms finished");
//     },
//     () =>
//     {
//         Thread.Sleep(1200);
//         Console.WriteLine("Task 1200 ms finished");
//     },
//     () =>
//     {
//         Thread.Sleep(2000);
//         Console.WriteLine("Task 2000 ms finished");
//     }
// );



// long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

// Parallel.For(0, 20, i =>
// {
//    Console.WriteLine($"{Task.CurrentId}: {i}");
//    Thread.Sleep(1000);
// });



// System.Console.WriteLine("Main Finished");
// System.Console.WriteLine(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - time);




// ThreadPool.SetMinThreads(10, 2);

// long time = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

// List<int> nums = [0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19];

// Parallel.ForEach(nums, n =>
// {
//     Console.WriteLine($"{Task.CurrentId}: {n}");
//     Thread.Sleep(1000);
// });


// System.Console.WriteLine(DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond - time);






#endregion





#region Cancelation token


//****



#endregion













