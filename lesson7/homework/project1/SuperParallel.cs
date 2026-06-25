namespace project1;

public static class SuperParallel
{
    public static void Invoke(params Action[] actions)
    {
        if (actions == null || actions.Length == 0) return;

        Task[] tasks = new Task[actions.Length];

        for (int i = 0; i < actions.Length; i++)
        {
            Action action = actions[i];
            tasks[i] = Task.Run(action);
        }

        Task.WaitAll(tasks);
    }

    public static void For(int fromInclusive, int toExclusive, Action<int> body)
    {
        if (body == null) return;
        int iterationsCount = toExclusive - fromInclusive;
        if (iterationsCount <= 0) return;

        Task[] tasks = new Task[iterationsCount];

        for (int i = fromInclusive; i < toExclusive; i++)
        {
            int index = i; 
            
            tasks[i - fromInclusive] = Task.Run(() => body(index));
        }

        Task.WaitAll(tasks);
    }

    public static void ForEach<T>(IEnumerable<T> source, Action<T> body)
    {
        if (source == null || body == null) return;

        List<Task> tasks = new List<Task>();

        foreach (T item in source)
        {
            T localItem = item;
            
            tasks.Add(Task.Run(() => body(localItem)));
        }

        Task.WaitAll(tasks.ToArray());
    }
}