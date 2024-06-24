// Створення єкземпляру делегата ParameterizedThreadStart,
// та сполучення його з методом WriteInfo, який має 1 аргумент типу object.
ParameterizedThreadStart writeSecond = new ParameterizedThreadStart(WriteInfo);

// Створюємо та запускаємо вторинний потік
Thread thread = new Thread(writeSecond);
thread.Start((object)"Second");

// Виклик методу в контексті первинного потоку.
WriteInfo((object)"Primary");

/// <summary>
/// Статичний метод, який планується виконувати одночасно
/// у головному (первинному) та у вторинному потоках.
/// </summary>
static void WriteInfo(object argument)
{
    for (int i = 0; i < 10; i++)
    {
        Thread.Sleep(1000);
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} - {argument}");
    }
}