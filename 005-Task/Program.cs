// Декомплельваний попередній приклад

DisplayClass displayClass = new DisplayClass();
//полю counter присвоюєтся значення 1.
displayClass.counter = 1;
Thread thread = new Thread(new ThreadStart(displayClass.Method));
thread.Start();
Console.WriteLine(displayClass.counter);

// Під капотом створюєтся класс, який містить в собі метод, що раніше
// був методом із лямбла виразу
internal sealed class DisplayClass
{
    public int counter;

    internal void Method()
    {
        Console.WriteLine("1. counter = {0}", ++counter);
    }
}