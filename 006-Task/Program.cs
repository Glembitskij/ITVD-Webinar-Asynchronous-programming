/// Потоки
/// Створювати список потоків самостійно не знадобиться.
/// Для керування таким списком передбачений клас ThreadPool,
/// який у міру необхідності зменшує та збільшує кількість потоків
/// у пулі до максимально допустимого. Значення максимально допустимої кількості
/// потоків у пулі може змінюватися. У разі двоядерного ЦП воно за умовчанням становить 1023
/// робочих потоків та 1000 потоків введення-виведення.
/// </summary>

Console.WriteLine("Початок роботи програми");
Report();

// Запуск Task1 в потоці потоків, що входить в пул
ThreadPool.QueueUserWorkItem(new WaitCallback(Task1));
Report();

// апуск Task2 в потоці потоків, що входить в пул
ThreadPool.QueueUserWorkItem(Task2);
Report();

Thread.Sleep(3000);
Console.WriteLine("Завершення роботи програми");
Report();


/// <summary>
/// Метод для виконання у потоці 1
/// </summary>
static void Task1(Object state)
{
    Thread.CurrentThread.Name = "1";
    Console.WriteLine("Запущений потік {0}\n", Thread.CurrentThread.Name);
    Thread.Sleep(2000);
    Console.WriteLine("Потік {0} завершив роботу\n", Thread.CurrentThread.Name);
}

/// <summary>
/// Метод для виконання у потоці 2
/// </summary>
static void Task2(Object state)
{
    Thread.CurrentThread.Name = "2";
    Console.WriteLine("Запущений потік {0}\n", Thread.CurrentThread.Name);
    Thread.Sleep(500);
    Console.WriteLine("Потік {0} завершив роботу\n", Thread.CurrentThread.Name);
}

/// <summary>
/// Метод для відображення в потоці
/// </summary>
static void Report()
{
    Thread.Sleep(200);

    int availableWorkThreads;
    int availableIOThreads;
    int maxWorkThreads;
    int maxIOThreads;

    // Доступно робочих потоків у пулі
    ThreadPool.GetAvailableThreads(out availableWorkThreads, out availableIOThreads);

    // Доступно потоків введення-виведення в пулі
    ThreadPool.GetMaxThreads(out maxWorkThreads, out maxIOThreads);

    Console.WriteLine("Доступно робочих потоків у пулі     :{0} из {1}", availableWorkThreads, maxWorkThreads);
    Console.WriteLine("Доступно потоків введення-виведення в пулі:{0} из {1}\n", availableIOThreads, maxIOThreads);
}