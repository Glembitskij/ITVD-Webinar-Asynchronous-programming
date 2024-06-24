// Повертаймі значення Task (техніка замикання)

int a = 5;
int b = 5;

Task<int> taskRun = Task<int>.Run<int>(() =>
{
    return Calc(a, b);
});

Console.WriteLine(taskRun.Result);

static int Calc(int a, int b)
{
    return a + b;
}
