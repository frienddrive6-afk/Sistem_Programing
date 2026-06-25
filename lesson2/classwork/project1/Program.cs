using System.Diagnostics;
using MathLib;

//Информация о процессе
// try
// {
// 	Process p = GetProcessFromUser();
// 	Console.WriteLine($"{p.Id}\t{p.ProcessName}\t{p.BasePriority}\t{p.StartTime}");
// }
// catch (Exception ex)
// {
//    Console.WriteLine($"ERROR: {ex.Message}");
// }


//информация о потоках процесса
// try
// {
//     Process p = GetProcessFromUser();
//     ProcessThreadCollection threads = p.Threads;
//     foreach(ProcessThread t in threads)
//     {
//         Console.WriteLine($"{t.Id}\t{t.StartTime.ToShortTimeString()}\t{t.PriorityLevel}\t{p.VirtualMemorySize64}");
//     }
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"ERROR: {ex.Message}");
// }







// Process.Start("nautilus");
// Process.Start("kitty", "bash -c /home/nomantb/Sistem_Programing/lesson2/classwork/main");









// try
// {
//     Process p = GetProcessFromUser();
    
//     ProcessModuleCollection moduls = p.Modules;

//     foreach(ProcessModule m in moduls)
//     {
//         Console.WriteLine($"{m.ModuleName}\t{m.ModuleMemorySize}");
//     }
// }
// catch (Exception ex)
// {
//     Console.WriteLine($"ERROR: {ex.Message}");
// }




Class1 cl = new Class1();

Console.WriteLine(cl.Sum(1, 2));
Console.WriteLine(Class1.Factorial(5));















Process GetProcessFromUser()
{
    Console.Write("Enter PID: ");
    string? input = Console.ReadLine();

    if (input is null)
        throw new Exception("Invalid input");

    int pid = int.Parse(input);

    return Process.GetProcessById(pid);
}