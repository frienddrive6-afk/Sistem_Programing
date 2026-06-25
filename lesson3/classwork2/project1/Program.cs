
#region intro


// void ShowPlus()
// {
//     for(int i = 0;i < 1000;++i)
//     {
//         Console.Write("+");
//     }
// }

// Thread t = new Thread(ShowPlus);
// t.Start();

// System.Console.WriteLine(t.IsAlive);

// for(int i = 0;i < 1000;++i)
// {
//     Console.Write("0");
// }

#endregion



#region primer

// void Run()
// {
//     for(int i = 0; i < 1000; ++i)
//     {
//         Console.Write("0");
//     }
// }

// new Thread(Run).Start();


// Run();


// System.Console.WriteLine("Main end");




#endregion





#region primer 2

bool done = false;

void Run()
{
    if(!done)
    {
        done = true;
        System.Console.WriteLine("DONE");
    }
}

new Thread(Run).Start();
Run();





#endregion









