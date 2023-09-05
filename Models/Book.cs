namespace Models;

public class Book
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public bool Available { get; set; }

    public Book(string name, bool available = true)
    {
        Id = Guid.NewGuid();
        Name = name;
        Available = available;
    }
}