using PCQ;
using project2.Jobs;


const int emailsCount = 1000;
const int workersCount = 100;

QueuManager qm = new QueuManager(workersCount);

for(int i = 0; i < emailsCount; i++)
{
    qm.AddJob(new SendEmailJob(){Email = $"user{i}@mail.com"});
}


for(int i = 0; i < 200; ++i)
{
    Thread.Sleep(100);
    Console.WriteLine($"Main: {i}");
}





