

DisplayClass displayClass = new DisplayClass();
displayClass.counter = 1;
Thread thread = new Thread(new ThreadStart(displayClass.Method));
thread.Start();
Console.WriteLine(displayClass.counter);


internal sealed class DisplayClass
{
    public int counter;

    internal void Method()
    {
        Console.WriteLine("1. counter = {0}", ++counter);
    }
}