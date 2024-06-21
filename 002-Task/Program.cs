Thread primaryThread = Thread.CurrentThread;
primaryThread.Name = "Primary";

Console.WriteLine(
    $"Main почав робуту в потоці з ID {primaryThread.ManagedThreadId} та ім'ям {primaryThread.Name}");

//ThreadStart threadStart = new ThreadStart(WriteInfo);

//Thread secondaryThread = new Thread(threadStart);

Thread secondaryThread = new Thread(WriteInfo);
secondaryThread.Name = "Secondary";
secondaryThread.Start();

WriteInfo();

static void WriteInfo()
{
    Thread thread = Thread.CurrentThread;
    
    Console.WriteLine(
    $"WriteInfo почав робуту в потоці з ID {thread.ManagedThreadId} та ім'ям {thread.Name}");

    for (int counter = 0; counter < 10; counter++)
    {
        Thread.Sleep(1000);
        Console.WriteLine($"WriteInfo працює в потоці з ID {thread.ManagedThreadId} та ім'ям {thread.Name} - counter = {counter}");
    }
}