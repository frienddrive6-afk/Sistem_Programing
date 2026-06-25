#region Ex_2
async Task<string> FetchDataAsync(string url)
{
    using HttpClient client = new HttpClient();

    try
    {
        Task<string> responseTask = client.GetStringAsync(url);
        return await responseTask;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"ERROR: {ex.Message}");
        return string.Empty;
    }
}

async Task<Dictionary<string, string>> FetchMultipleDataAsync(IEnumerable<string> urls)
{
    var tasks = new Dictionary<string, Task<string>>();

    foreach(string url in urls)
    {
        tasks.Add(url, FetchDataAsync(url));
    }

    await Task.WhenAll(tasks.Values);

    return tasks.ToDictionary(
        pair => pair.Key,
        pair => pair.Value.Result
    );
}




async Task StoreDataAsync(Dictionary<string, string> data)
{
    foreach(KeyValuePair<string, string> pair in data)
    {
        Console.WriteLine($"{pair.Key}: {pair.Value}");

        string filename = Guid.NewGuid().ToString();

        using FileStream fs = File.OpenWrite($"{filename}.html");
        using StreamWriter sw = new StreamWriter(fs);

        await sw.WriteAsync(pair.Value);
    }
}

try
{
    Dictionary<string, string> result = await FetchMultipleDataAsync(new[]
    {
        "https://habr.com/ru/articles/",
        "https://habr.com/ru/companies/selectel/articles/1044854/",
        "https://habr.com/ru/articles/top/daily/",
    });

    await StoreDataAsync(result);
}
catch (Exception ex)
{
    Console.WriteLine($"ERROR: {ex.Message}");
}







#endregion