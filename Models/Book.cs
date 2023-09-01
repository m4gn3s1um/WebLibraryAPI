namespace Presentation;

public class Book
{
    public int Id { get; private set; }
    public string Name { get; private set; }

    public Book(int id, string name)
    {
        Id = id;
        Name = name;
    }
}