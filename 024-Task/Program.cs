using System.Collections;

// Декомпільований приклад з використанням yield return person

Collection collection = new Collection();

foreach (Person person in collection)
{
    Console.WriteLine($"{person.Name} - {person.Age}");
}

internal class Collection : IEnumerable
{
    private sealed class ClassGetEnumerator : IEnumerator
    {
        private int state;

        private int position;

        private object current;

        public Collection thisCollection;

        private Person[] persons;

        private Person person;

        public object Current
        {
            get
            {
                return current;
            }
        }

        public ClassGetEnumerator(int state)
        {
            this.state = state;
        }

        public bool MoveNext()
        {
            switch (state)
            {
                default:
                    return false;

                case 0:
                    state = -1;
                    persons = thisCollection.persons;
                    position = 0;
                    break;

                case 1:
                    state = -1;
                    person = null;
                    position++;
                    break;
            }
            if (position < persons.Length)
            {
                person = persons[position];
                current = person;

                state = 1;
                return true;
            }

            persons = null;
            return false;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }

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
        ClassGetEnumerator сollection = new ClassGetEnumerator(0);
        сollection.thisCollection = this;

        return сollection;
    }
}

class Person
{
    public string Name { get; set; }

    public int Age { get; set; }
}