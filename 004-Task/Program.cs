
int counter = 0;

Thread thread = new Thread(delegate ()
{
    Console.WriteLine("1. counter = {0}", ++counter);  // 1
});

thread.Start();

Thread.Sleep(1000);

Console.WriteLine(counter);