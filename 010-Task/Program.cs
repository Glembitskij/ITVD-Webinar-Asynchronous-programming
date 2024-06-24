Task task = new Task(MyTask);
task.Start();

Thread.Sleep(500);

Console.WriteLine("\ntask.IsCompleted = " + task.IsCompleted);

// Очікування завершення асинхронного завдання.

// Варіант 1:
// Wait() Очікує завершення виконання завдання System.Threading.Tasks.Task.
task.Wait();

// Варіант 2:
// IsCompleted - IsCompleted - Повертає значення, яке показує, чи завершилося завдання

//while (!task.IsCompleted)
//{
//    Thread.Sleep(100);
//}

Console.WriteLine("\ntask.IsCompleted = " + task.IsCompleted);


/// <summary>
/// Метод, який буде виконаний асинхронно.
/// </summary>
static void MyTask()
{
    for (int i = 0; i < 80; i++)
    {
        Thread.Sleep(25);
        Console.Write(".");
    }
}