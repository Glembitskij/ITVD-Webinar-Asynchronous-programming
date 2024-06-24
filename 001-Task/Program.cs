
// Створення єкземпляру делегата ThreadStart, та сполучення його з методом WriteSecond.
ThreadStart threadStart = new ThreadStart(WriteInfo);

// Створення вторинного потоку.
Thread thread = new Thread(threadStart);

// Запуск вторинного потоку
thread.Start();

// Виклик методу в контексті первинного потоку.
WriteInfo();

/// <summary>
/// Статичний метод, який планується виконувати одночасно
/// у головному (первинному) та у вторинному потоках.
/// </summary>
static void WriteInfo()
{
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(1000);
        Console.WriteLine($"Thread Id {Thread.CurrentThread.ManagedThreadId}, counter = {i}");
    }
}