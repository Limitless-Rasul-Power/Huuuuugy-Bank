namespace Bank_Practice.Abstract_Classes
{
    public abstract class Person : UniqueId
    {        
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }

        public Person(in string name, in string surname, in int age)
        {
            Name = name;
            Surname = surname;
            Age = age;
        }

    }
}
