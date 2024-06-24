// Задачі продовження

int a = 2;
int b = 3;

Task<int> task = new Task<int>(() => Calc(a, b));
task.Start();

task.ContinueWith(Continuation);

Console.ReadKey();

static int Calc(int a, int b)
{
    Console.WriteLine($"Task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
    return a + b;
}

static void Continuation(Task<int> t)
{
    Console.WriteLine($"\nПродовження task Id #{Task.CurrentId}. Thread Id #{Thread.CurrentThread.ManagedThreadId}.");
    Console.WriteLine($"Результат асинхронної операції - {t.Result}");
}