using System.Diagnostics;
using System.Runtime.CompilerServices;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"Метод Main почав свою роботу у потоці {Thread.CurrentThread.ManagedThreadId}.");
        WriteCharAsync('#');
        WriteChar('*');
        Console.WriteLine($"Метод Main закінчив свою роботу у потоці {Thread.CurrentThread.ManagedThreadId}.");
        Console.ReadKey();
    }

    internal static Task WriteCharAsync(char symbol)
    {
        // Створення екземпляра кінцевого автомата
        ClassWriteCharAsync stateMachine = new ClassWriteCharAsync();
        // Заповнення полів кінцевого автомата
        stateMachine.builder = AsyncTaskMethodBuilder.Create();
        stateMachine.symbol = symbol;
        stateMachine.state = -1;
        // Запуск кінцевого автомата (всередині виклик методу MoveNext())
        stateMachine.builder.Start(ref stateMachine);
        return stateMachine.builder.Task;
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

    private sealed class DisplayClass
    {
        public char symbol;

        internal void LambdaMethod()
        {
            WriteChar(symbol);
        }
    }

    private sealed class ClassWriteCharAsync : IAsyncStateMachine
    {
        // Відкриті поля кінцевого автомата їх заповнення під час створення екземпляра.
        public int state;

        public AsyncTaskMethodBuilder builder;

        public char symbol;

        // Закриті поля кінцевого автомата задля збереження значень
        // локальних змінних методу при зупинці.

        private DisplayClass displayClass;

        private TaskAwaiter taskAwaiter;

        private void MoveNext()
        {
            // Отримання стану кінцевого автомата з поля state.
            int num = state;
            try
            {
                // Створення об'єкта очікування завершення асинхронного завдання
                TaskAwaiter awaiter;
               
                if (num != 0)
                {
                    // Створення екземпляра класу, який представляє лямбда-вираз:
                    displayClass = new DisplayClass();
                    displayClass.symbol = symbol;
                    
                    Console.WriteLine($"Метод WriteCharAsync почав свою роботу в потоці {Thread.CurrentThread.ManagedThreadId}.");

                    // Робота оператора await:
                    Task task = Task.Run(new Action(displayClass.LambdaMethod));
                    //Thread.Sleep(10000);
                    awaiter = task.GetAwaiter();

                    // Перевірка: чи завершилася робота завдання.
                    if (!awaiter.IsCompleted)
                    {
                        num = (state = 0);

                        taskAwaiter = awaiter;

                        ClassWriteCharAsync stateMachine = this;

                        // Метод створить та встановить продовження для асинхронного завдання.
                        builder.AwaitUnsafeOnCompleted(ref awaiter, ref stateMachine);
                        return;
                    }
                }
                else
                {
                    awaiter = taskAwaiter;
                    taskAwaiter = default(TaskAwaiter);
                    num = (state = -1);
                }

                awaiter.GetResult();
                Console.WriteLine($"Метод WriteCharAsync закінчив свою роботу в потоці {Thread.CurrentThread.ManagedThreadId}.");
            }
            catch (Exception exception)
            {
                state = -2;
                displayClass = null;
                builder.SetException(exception);
                return;
            }

            state = -2;
            displayClass = null;
            builder.SetResult();
        }

        void IAsyncStateMachine.MoveNext()
        {
            //ILSpy generated this explicit interface implementation from .override directive in MoveNext
            this.MoveNext();
        }

        [DebuggerHidden]
        private void SetStateMachine(IAsyncStateMachine stateMachine)
        {
        }

        void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
        {
            //ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
            this.SetStateMachine(stateMachine);
        }
    }
}
