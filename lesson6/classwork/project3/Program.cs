

#region Постановка Task в очередь


// Task t1 = new Task(() => System.Console.WriteLine("Vasia"));
// t1.Start();

// Task t2 = Task.Factory.StartNew(() => System.Console.WriteLine("Petya"));

// Task t3 = Task.Run(() => System.Console.WriteLine("Dima"));


// t1.Wait();          //BLOKING
// t2.Wait();          //BLOKING  
// t3.Wait();          //BLOKING

#endregion



#region RunSynchronously()


Task t = new Task(() => 
{
    Console.WriteLine("Start");
    Thread.Sleep(1000);
    Console.WriteLine("End");

});

// t.Start();               // async call
t.RunSynchronously();       // sync call

Console.WriteLine("from Main");
Console.ReadLine();








#endregion









