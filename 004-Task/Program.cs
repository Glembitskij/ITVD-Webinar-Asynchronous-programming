
int counter = 0;
counter++;

// Створюємо Thread з використання лямбда-виразу
Thread thread = new Thread(delegate ()
{
    Console.WriteLine("1. counter = {0}", ++counter);  // 1
});

// стартуємо потік 
thread.Start();

Thread.Sleep(1000);

Console.WriteLine(counter);