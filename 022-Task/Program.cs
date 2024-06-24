// See https://aka.ms/new-console-template for more information
using System.Collections;


Collection collection = new Collection();

foreach (Person person in collection)
{
    Console.WriteLine($"{person.Name} - {person.Age}");
}


class Collection : IEnumerable, IEnumerator
{
    private Person[] persons;

    private int position = -1;
    public object Current => persons[position];

    public Collection()
    {
        persons = new Person[]
        {
            new Person(){Name = "Alex", Age = 20 },
            new Person(){Name = "Peta", Age = 30 },
            new Person(){Name = "Vasa", Age = 40 }
        };
    }

    public IEnumerator GetEnumerator()
    {
        return (IEnumerator)this;
    }

    public bool MoveNext()
    {
        if (position < persons.Length-1)
        {
            position++;
            return true;
        }
        else
        {
            Reset();
            return false;
        }
    }

    public void Reset()
    {
        position = -1;
    }
}

class Person
{
    public string Name { get; set; }

    public int Age { get; set; }
}