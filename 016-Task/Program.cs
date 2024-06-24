// Повертаймі значення Task (техніка замикання)
// - декомпільваний попередній приклад
class Program
{
    static void Main()
    {
        LambdaClass lambdaClass = new LambdaClass();
        lambdaClass.a = 5;
        lambdaClass.b = 5;
        Task<int> task = Task.Run(new Func<int>(lambdaClass.Method));
        Console.WriteLine(task.Result);
    }

    public static int Calc(int a, int b)
    {
        return a + b;
    }

    internal sealed class LambdaClass
    {
        public int a;

        public int b;

        internal int Method()
        {
            return Program.Calc(a, b);
        }
    }
}


