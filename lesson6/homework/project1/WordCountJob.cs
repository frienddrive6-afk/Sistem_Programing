using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using PCQ;

namespace WordCounterApp;

public class WordCountJob : IJob
{
    private readonly string _filePath;
    private readonly Dictionary<string, int> _results;
    private readonly object _lockObj;
    private readonly TaskCompletionSource _tcs;

    public WordCountJob(
        string filePath, 
        Dictionary<string, int> results, 
        object lockObj, 
        TaskCompletionSource tcs)
    {
        _filePath = filePath;
        _results = results;
        _lockObj = lockObj; 
        _tcs = tcs;         
    }

    public void Execute()
    {
        try
        {
            int count = 0;

            if (File.Exists(_filePath))
            {
                string text = File.ReadAllText(_filePath);
                char[] separators = { ' ', '\r', '\n', '\t', '.', ',', '!', '?', ';', ':', '-' };
                string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                count = words.Length;
            }

            lock (_lockObj)
            {
                _results[_filePath] = count;
            }

            _tcs.SetResult();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при обработке файла {_filePath}: {ex.Message}");
            
            lock (_lockObj)
            {
                _results[_filePath] = -1; 
            }

            _tcs.SetException(ex);
        }
    }

    public string GetInfo()
    {
        return $"File: {Path.GetFileName(_filePath)}";
    }
}