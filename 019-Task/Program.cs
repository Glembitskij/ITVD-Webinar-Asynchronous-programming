
Console.WriteLine($"Метод Main почав свою роботу у потоці {Thread.CurrentThread.ManagedThreadId}.");

// Запуск методу асинхронно
WriteCharAsync('#');

// Запуск методу синхронно
WriteChar('*'); 

Console.WriteLine($"Метод Main закінчив свою роботу у потоці {Thread.CurrentThread.ManagedThreadId}.");
Console.ReadKey();

static async Task WriteCharAsync(char symbol)
{
    Console.WriteLine($"Метод WriteCharAsync почав свою роботу в потоці {Thread.CurrentThread.ManagedThreadId}.");

    await Task.Run(() => WriteChar(symbol));

    Console.WriteLine($"Метод WriteCharAsync закінчив свою роботу в потоці {Thread.CurrentThread.ManagedThreadId}.");
}

static void WriteChar(char symbol)
{
    Console.WriteLine($"Id {symbol} потока - [{Thread.CurrentThread.ManagedThreadId}]. Id задачі - [{Task.CurrentId}]");
    Thread.Sleep(500);

    for (int i = 0; i < 80; i++)
    {
        Console.Write(symbol);
        Thread.Sleep(100);
    }
}