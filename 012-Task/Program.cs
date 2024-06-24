Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
Console.WriteLine("Основний потік запущено.");

// Використання лямбда-оператора для визначення задачі.
Task task = new Task(new Action(() =>
{
    Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
    {
        for (int i = 0; i < 80; i++)
        {
            Thread.Sleep(20);
            Console.Write(".");
        }
    }
}));

task.Start();

int num = 0;
while (num < 80)
{
    Thread.Sleep(20);
    Console.Write("-");
    num++;
}

Console.WriteLine("Основний потік завершено.");