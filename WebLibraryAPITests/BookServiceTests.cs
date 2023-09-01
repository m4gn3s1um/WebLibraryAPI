using Business.Service;
using NUnit.Framework;
using WebLibraryAPITests.Fake;

namespace WebLibraryAPITests;

[TestFixture]
public class BookServiceTests
{
    private IBookService _service;
    
    [SetUp]
    public void Setup()
    {
        _service = new BookService(new FakeBookRepository());
    }

    [Test]
    public void CanReturnAListOfBooks()
    {
        var actual = _service.GetBooks();
        Assert.That(actual.Count, Is.EqualTo(3));
    }
}