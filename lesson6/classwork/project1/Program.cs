
#region Сигнализация

// object locker = new Object(); 
 
// void First() 
// { 
//    try 
//    { 
//        Monitor.Enter(locker); 
 
//        for (int i = 1; i <= 10; i += 2) 
//        { 
//            Thread.Sleep(200); 
//            Console.Write($"{i} "); 
//            Monitor.Pulse(locker);          // Перевод locker в сигнальное состояние 
//            Monitor.Wait(locker);           // Ожидание следующего сигнального состояния 
//        } 
//    } 
//    finally 
//    { 
//        Monitor.Exit(locker); 
//    } 
// } 

// void Second() 
// { 
//    try 
//    { 
//        Monitor.Enter(locker); 
 
//        for (int i = 0; i <= 10; i += 2) 
//        { 
//            Thread.Sleep(200); 
//            Console.Write($"{i} "); 
//            Monitor.Pulse(locker); 
//            Monitor.Wait(locker); 
//        } 
//    } 
//    finally 
//    { 
//        Monitor.Exit(locker); 
//    } 
// } 
 
// Thread t1 = new Thread(First); 
// Thread t2 = new Thread(Second); 
 
// t2.Start(); 
// Thread.Sleep(100); 
// t1.Start();








// object loker1 = new object();
// object loker2 = new object();


// Thread t1 = new Thread(() =>
// {
//     System.Console.WriteLine("t1 startet");
//     Monitor.Enter(loker1);
//     System.Console.WriteLine("t1 unblocked");
//     Thread.Sleep(5000);
//     Console.WriteLine("Hello from t1");
//     Monitor.Pulse(loker1);
// });

// Thread t2 = new Thread(() =>
// {
//     System.Console.WriteLine("t2 startet");
//     Monitor.Enter(loker2);
//     System.Console.WriteLine("t1 unblocked");
//     Thread.Sleep(5000);
//     Console.WriteLine("Hello from t2");
//     Monitor.Pulse(loker2);
// });

// Monitor.Enter(loker1);
// Monitor.Enter(loker2);

// t1.Start();
// t2.Start();

// Thread.Sleep(3000);

// // Monitor.Exit(loker1);
// Monitor.Exit(loker1);
// Thread.Sleep(3000);
// Monitor.Exit(loker2);


// Monitor.Wait(loker1);
// System.Console.WriteLine("MAIN: t1 finished");

// Monitor.Wait(loker2);
// System.Console.WriteLine("MAIN: t2 finished");





// SimpleWaitHandle.Run(); 
// static class SimpleWaitHandle 
// { 
//    static EventWaitHandle wh = new AutoResetEvent(false); 
 
//    public static void Run() 
//    { 
//        new Thread(Work).Start(); 
//        Thread.Sleep(3000); 
//        wh.Set();                   // Перевод в сигнальное состояние 
//    } 
 
//    public static void Work() 
//    { 
//        Console.WriteLine("Work(): waiting..."); 
//        wh.WaitOne();               // Ожидание сигнального состояние 
//        Console.WriteLine("Working..."); 
//    } 
// }








// AutoResetEvent are = new AutoResetEvent(false); 
 
// for (int i = 0; i < 5; ++i) 
// { 
//    Thread t = new Thread(Render) 
//    { 
//        Name = $"thread_{i}", 
//    }; 
//    t.Start(); 
// } 
// Thread.Sleep(3000); 
// are.Set(); 
 
// void Render() 
// { 
//    are.WaitOne(); 
//    for (int i = 0; i < 10; i++) 
//    { 
//        Console.WriteLine($"{Thread.CurrentThread.Name}: {i}"); 
//        Thread.Sleep(200);    
//    } 
//    are.Set(); 
// }








// ManualResetEvent mre = new ManualResetEvent(false); 
 
// UserThread ut1 = new UserThread("first", mre); 
// Console.WriteLine("Waiting"); 
// mre.WaitOne(); 
// Console.WriteLine("first working"); 
// mre.Reset(); 
 
// UserThread ut2 = new UserThread("second", mre); 
// mre.WaitOne(); 
// Console.WriteLine("second working"); 
// mre.Reset(); 
 
// class UserThread 
// { 
//    private ManualResetEvent mre; 
//    public Thread Thread { get; set; } 
 
//    public UserThread(string name, ManualResetEvent mre) 
//    { 
//        this.mre = mre; 
 
//        Thread = new Thread(Run) 
//        { 
//            Name = name, 
//        }; 
 
//        Thread.Start(); 
//    } 
 
//    private void Run() 
//    { 
//        Console.WriteLine($"{Thread.Name} started..."); 
 
//        for (int i = 0; i < 5; ++i) 
//        { 
//            Console.WriteLine($"{Thread.Name}: {i}"); 
//            Thread.Sleep(200); 
//        } 
 
//        mre.Set(); 
//    } 
 
// }

#endregion





#region Не блокирующие методы синхронизации / Interlocked

int count = 0;

Interlocked.Add(ref count, 10);

#endregion
