namespace EventSourcingSample
{
    record Person
    {
        public Person(int ıd, string name, int age)
        {
            Id = ıd;
            Name = name;
            Age = age;
        }

        public int Id { get; init; }
        public string Name { get; private set; }
        public int Age { get; private set; }

        public void ChangeName(string name) => Name = name;
        public void ChangeAge(int age) => Age = age;
    }

    class PersonSource
    {
        public static List<Person> PersonList { get; } = new()
        {
            new(1, "Gençay", 28),
            new(2, "Hilmi", 30),
            new(3, "Coşgun", 42),
            new(4, "Rıfkı", 32)
        };
    }
}
