// See https://aka.ms/new-console-template for more information
using System.Collections;
// Використання оператора yield return person

Collection collection = new Collection();

foreach (Person person in collection)
{
    Console.WriteLine($"{person.Name} - {person.Age}");
}

class Collection : IEnumerable
{
    private Person[] persons;

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
        foreach (var person in persons)
        {
            yield return person;
        }
    }
}

class Person
{
    public string Name { get; set; }

    public int Age { get; set; }
}