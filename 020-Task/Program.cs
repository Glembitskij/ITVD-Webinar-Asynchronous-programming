int x = 3, y = 5;

Task<int> additionTask = AdditionAsync("[асинхронно]", x, y);

int syncSum = Addition("[синхронно]", x, y);
Console.WriteLine($"Результат синхронного виконання {syncSum}");

int asyncSum = 0;

// Разные способы получения результата из асинхронной задачи:
//asyncSum = additionTask.Result;

asyncSum = await additionTask;

Continuation(asyncSum);

Console.WriteLine($"Метод Main завершив свою роботу");


static async Task<int> AdditionAsync(string operationName, int x, int y)
{
    return await Task.Run<int>(() => Addition(operationName, x, y));
}

static int Addition(string operationName, int x, int y)
{
    Console.WriteLine($"Метод Addition викликаний {operationName} в потоці: {Thread.CurrentThread.ManagedThreadId}");
    // імітація навантаженої та важкої роботи
    Thread.Sleep(3000);
    return x + y;
}

static void Continuation(int argument)
{
    Console.WriteLine($"Метод Continuation працює в потоці {Thread.CurrentThread.ManagedThreadId}.");
    Console.WriteLine($"Результат асинхронного виконання {argument}");
}