ParameterizedThreadStart writeSecond = new ParameterizedThreadStart(WriteInfo);

Thread thread = new Thread(writeSecond);
thread.Start((object)"Second");

WriteInfo((object)"Primary");

static void WriteInfo(object argument)
{
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(1000);
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {argument}");
    }
}