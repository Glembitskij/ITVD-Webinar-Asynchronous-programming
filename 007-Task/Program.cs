/// Асинхронні делегати
/// Найбільш простим способом створення потоку є визначення
/// делегата та його виклик асинхронним чином. Делегати можуть виконувати
/// роль безпечних типів для посилань на методи. Крім цього клас
/// Delegate підтримує можливість асинхронного виклику цих методів.
/// Для вирішення поставленого завдання він створює "за лаштунками" окремий потік.
/// 


Console.WriteLine("Первинний потік: Id {0}", Thread.CurrentThread.ManagedThreadId);

Action myDelegate = new Action(Method);

// exception - https://github.com/dotnet/runtime/issues/16312
myDelegate.BeginInvoke(null, null);

// Ожидание завершения асинхронной операции (вторичного потока).
// myDelegate.EndInvoke(asyncResult);

Thread.Sleep(100);

Console.WriteLine("Первичный поток завершил работу.");

// Задержка
//Console.ReadKey();

/// <summary>
/// Метод для виконання в окремому потоці.
/// </summary>
static void Method()
{
    Console.WriteLine("Вторинний потік: Id {0}", Thread.CurrentThread.ManagedThreadId);

    for (int i = 0; i < 80; i++)
    {
        Thread.Sleep(100);
        Console.Write("2");
    }
}