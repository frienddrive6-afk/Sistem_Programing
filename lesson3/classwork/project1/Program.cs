
// using MathLib;
// System.Console.WriteLine(Class1.Factorial(5));

#region AppDomain

// using System.Reflection;

// AppDomain domain = AppDomain.CurrentDomain;

// System.Console.WriteLine($"{domain.FriendlyName} - {domain.BaseDirectory}");

// foreach(Assembly a in domain.GetAssemblies())
// {
//     Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");
// }



#endregion





#region Dynamic loading

using System.Reflection;
using System.Runtime.Loader;

RenderAssembliesList("Before loading");

AssemblyLoadContext ctx = new AssemblyLoadContext("lib_ctx", true);
Assembly assembly = ctx.LoadFromAssemblyPath(Path.Combine(Directory.GetCurrentDirectory(), "project1/MathLib.dll"));
ctx.Unloading += ctx => System.Console.WriteLine("Asembly unloaded");

RenderAssembliesList("After loading");

Type? type = assembly.GetType("MathLib.Class1");


// // static call
// MethodInfo? method = type?.GetMethod("Factorial");
// if (method != null)
// {
//     int? result = (int?)method.Invoke(assembly, new object[] { 5 });
//     System.Console.WriteLine($"\nFactorial = {result}");
// }
// else
// {
//     System.Console.WriteLine("Метод 'Factorial' или класс 'Class1' не найдены. Проверьте имена!");
// }



// non static call
MethodInfo? method = type?.GetMethod("Sum");
object? cacl = Activator.CreateInstance(type);

if (method != null)
{
    int? result = (int?)method.Invoke(cacl, new object[] { 5, 4 });
    System.Console.WriteLine($"\nSum = {result}");
    ctx.Unload();
    GC.Collect();
    RenderAssembliesList("After unload");
}
else
{
    System.Console.WriteLine("Метод 'Sum' или класс 'Class1' не найдены. Проверьте имена!");
}





void RenderAssembliesList(string message)
{
    Console.WriteLine($"\n===================={message}====================");

    AppDomain domain = AppDomain.CurrentDomain;

    Console.WriteLine($"{domain.FriendlyName}/{domain.BaseDirectory}");

    foreach (Assembly a in domain.GetAssemblies())
        Console.WriteLine($"{a.GetName().Name}\t{a.GetName().Version}");
}

#endregion
