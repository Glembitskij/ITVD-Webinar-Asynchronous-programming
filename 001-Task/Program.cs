
ThreadStart threadStart = new ThreadStart(WriteInfo);

Thread thread = new Thread(threadStart);
thread.Start();

WriteInfo();

static void WriteInfo()
{
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(1000);
        Console.WriteLine($"Thread Id {Thread.CurrentThread.ManagedThreadId}, counter = {i}");
    }
}