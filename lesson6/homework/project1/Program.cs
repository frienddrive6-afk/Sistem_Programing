using PCQ;

namespace WordCounterApp;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Инициализация приложения подсчета слов (асинхронная модель)...");

        string[] filesToProcess = { "file_small.txt", "file_medium.txt", "file_large.txt", "file_empty.txt" };
        
        File.WriteAllText("file_small.txt", "Hello world! This is PCQ library test."); 
        File.WriteAllText("file_medium.txt", "The quick brown fox jumps over the lazy dog. Multithreading in C# is powerful when done right.");
        File.WriteAllText("file_large.txt", "Words, words, words. More words here to count. Let's make sure this file has a bit more content than others. Yes, it does!");
        File.WriteAllText("file_empty.txt", ""); 

        int workersCount = 2;
        QueuManager qm = new QueuManager(workersCount);

        Dictionary<string, int> wordCounts = new Dictionary<string, int>();
        
        object dictionaryLock = new object();

        List<Task> tasks = new List<Task>();

        Console.WriteLine("Добавление задач в очередь PCQ...");
        foreach (string file in filesToProcess)
        {
            var tcs = new TaskCompletionSource();
            
            tasks.Add(tcs.Task);

            qm.AddJob(new WordCountJob(file, wordCounts, dictionaryLock, tcs));
        }

        Console.WriteLine("Главный поток асинхронно ожидает завершения обработки всех файлов...");
        
        try
        {
            await Task.WhenAll(tasks);
        }
        catch (Exception)
        {
        }

        Console.WriteLine("\n================ Результаты подсчета ================");
        int totalWords = 0;
        
        foreach (var result in wordCounts)
        {
            string fileName = Path.GetFileName(result.Key);
            int count = result.Value;
            
            if (count >= 0)
            {
                Console.WriteLine($"Файл: {fileName} \t Слов: {count}");
                totalWords += count;
            }
            else
            {
                Console.WriteLine($"Файл: {fileName} \t [Ошибка обработки]");
            }
        }
        Console.WriteLine($"Всего подсчитано слов во всех файлах: {totalWords}");
        Console.WriteLine("=====================================================");

        foreach (string file in filesToProcess)
        {
            if (File.Exists(file)) File.Delete(file);
        }

        Console.WriteLine("Приложение завершило работу.");
    }
}