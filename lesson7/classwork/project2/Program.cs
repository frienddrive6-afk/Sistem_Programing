

// async Task MethodAsync()
// {
//     Console.WriteLine("Start");

//     Task t = new Task(() => Thread.Sleep(1000));
//     t.Start();

//     // t.Wait();
//     await t;

//     Console.WriteLine("End");
// }

// Console.WriteLine("Main start");

// Task t = MethodAsync();

// Console.WriteLine("CONTINUE");
// //
// //
// //
// await t;




async Task DownloadAsync (string usr)
{
    HttpClient client = new HttpClient();
    string content =await client.GetStringAsync(usr);

    Console.WriteLine(content);

}


_ = DownloadAsync("https://www.google.com");


