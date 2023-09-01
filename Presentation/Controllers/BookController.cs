using Business.Service;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private IBookService _bookService;
    
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet(Name = "GetBooks")]
    public IActionResult Get()
    {
        var books = _bookService.GetBooks();
        return Ok(books);
    }
}
