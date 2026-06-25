using PCQ;

namespace project2.Jobs;

public class SendEmailJob : IJob
{
    private Random random;
    public required string Email { get; init; }

    public SendEmailJob()
    {
        random = new Random();
    }

    public void Execute()
    {
        Thread.Sleep(random.Next(50,200));
        // System.Console.WriteLine($"Email to {Email} was sent ...");   //FIXME: for debug
    }

    public string GetInfo()
    {
        return $"Email = {Email}";
    }
    
}