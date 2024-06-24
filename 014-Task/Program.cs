// Повертаймі значення Task

int a = 3, b = 2;

Box box;
box.a = a;
box.b = b;

Task<int> task = new Task<int>(Calc, box);
task.Start();

// При зверненні до властивості Result поточний потік зупиняє виконання
// і чекає, коли буде отримано результат виконуваного завдання.
Console.WriteLine(task.Result);

static int Calc(object arg)
{
    Box box = (Box)arg;
    return box.a + box.b;
}

public struct Box
{
    public int a;
    public int b;
}