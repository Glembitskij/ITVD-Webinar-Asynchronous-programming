// Задачі продовження

Task task = new Task(new Action<object>(OperationAsync), "Hello world");
Task continuation = task.ContinueWith(Continuation);

Console.WriteLine($"Статус продовження - {continuation.Status}");

task.Start();

Console.ReadKey();

static void OperationAsync(object arg)
{
    Console.WriteLine($"Задача #{Task.CurrentId} почалась в потоці {Thread.CurrentThread.ManagedThreadId}.");
    Console.WriteLine($"Argument value - {arg.ToString()}");
    Console.WriteLine($"Задача #{Task.CurrentId} завершилась в потоці {Thread.CurrentThread.ManagedThreadId}.");
}

static void Continuation(Task task)
{
    Console.Write($"\nПродовження #{Task.CurrentId} спрацювало в потоці {Thread.CurrentThread.ManagedThreadId}. ");
    Console.WriteLine($"Параметри задачі - {task.AsyncState}");
    Console.WriteLine($"Одразу після виконання задачі.");
}