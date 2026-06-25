

#region потокобезопасный код

// bool done = false;
// object locker = new object();
 
// void Run()
// {
//     lock(locker)
//     {
//         if(!done)
//         {
//             done = true;
//             Console.WriteLine("DONE");
//         }
//     }

// }


// Thread t = new Thread(Run);
// t.Start();
// Run();


#endregion


#region что-то


// void Run()
// {
//     for(int i = 0; i < 1000;++i)
//     {
//         Console.Write('*');
//     }


// }

    
// Console.WriteLine("Main started");

// Thread t = new Thread(Run);
// t.Start();

// // Thread.Sleep(5);                        //Блокировка текущего потока (таймер)
// t.Join();                                  //Блокировка текущего потока (событие -> завершение потока t)


// Console.WriteLine("Main finished");






#endregion




#region Create / Start



// void Run()
// {
//     System.Console.WriteLine("hellow from Run");

// }


// Thread t = new Thread(Run);
// t.Start();







// Thread t = new Thread( () => System.Console.WriteLine("hellow from lambda"));
// t.Start();







// string email = "vasia@mail.com";
// Thread t = new Thread(() => Console.WriteLine($"Email: {email}"));
// t.Start();




// void Sum(int a,int b)
// {
//     System.Console.WriteLine($"a + b = {a + b}");
// }

// int a = 4;
// int b = 5;

// Thread t = new Thread(() => Sum(a,b));
// t.Start();




void Render(string messege, ConsoleColor color)
{
    Console.ForegroundColor = color;
    Console.WriteLine(messege);
    Console.ResetColor();
}










#endregion







