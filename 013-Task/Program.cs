// Декомпільований 12-й приклад

using System;

Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
Console.WriteLine("Основний потік запущено.");
Task task = new Task(LambdaClass.action ?? (LambdaClass.action = new Action(LambdaClass.lambda.Method)));
task.Start();

int num = 0;
while (num < 80)
{
    Thread.Sleep(20);
    Console.Write("-");
    num++;
}

Console.WriteLine("Основний потік завершено.");

internal sealed class LambdaClass
{
    public static readonly LambdaClass lambda = new LambdaClass();

    public static Action action;

    internal void Method()
    {
        Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        int num = 0;
        while (num < 80)
        {
            Thread.Sleep(20);
            Console.Write(".");
            num++;
        }
    }
}