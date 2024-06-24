
/// <summary>
// В основі бібліотеки TPL лежить концепція задач, кожна з яких описує
// окрему тривалу операцію. У бібліотеці класів .NET задача представлена
// спеціальним класом - класом Task, який знаходиться у просторі імен
// System.Threading.Tasks. Цей клас описує окреме завдання, яке
// асинхронно запускається в одному з потоків з пулу потоків.
// Хоча її також можна запускати синхронно у поточному потоці.
/// </summary>

int threadId = Thread.CurrentThread.ManagedThreadId;

Console.WriteLine("Main: запущен в потоке # {0}", threadId);

Task task = new Task(MyTask);
task.Start();

for (int i = 0; i < 10; i++)
{
    Console.Write(". ");
    Thread.Sleep(200);
}

Console.WriteLine("\nMain: завершен в потоке # {0}", threadId);
Console.ReadKey();

static void MyTask()
{
    int threadId = Thread.CurrentThread.ManagedThreadId;

    Console.WriteLine("\nMyTask: запущен в потоке # {0}", threadId);

    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(200);
        Console.Write("+ ");
    }

    Console.WriteLine("\nMyTask: завершен в потоке # {0}", threadId);
}