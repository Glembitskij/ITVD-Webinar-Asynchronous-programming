// TaskStatus - статуси задач.

Task task = new Task(MyTask);

Console.WriteLine("1. " + task.Status); // Задача не запущена.

task.Start();
Console.WriteLine("2. " + task.Status); // Задача у процесі запуску..

Thread.Sleep(1000);
Console.WriteLine("3. " + task.Status); // Задача виконуєтся.

Thread.Sleep(3000);
Console.WriteLine("4. " + task.Status); // Задача завершилась.



/// <summary>
/// Метод, який буде виконаний асинхронно.
/// </summary>
static void MyTask()
{
    Thread.Sleep(3000);
}