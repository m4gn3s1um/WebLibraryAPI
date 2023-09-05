using AutoMapper;
using Business.Service;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;
    
    public BookController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [HttpGet]
    [Route("GetBooks")]
    public IActionResult GetBooks()
    {
        var books = _bookService.GetBooks();
        return Ok(books);
    }

    [HttpGet("{id}")]
    public IActionResult GetBook(Guid id)
    {
        var book = _bookService.GetBook(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public IActionResult CreateBook([FromBody] Book book)
    {
        var newBook = _bookService.CreateBook(book);
        return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(Guid id)
    {
        if (!_bookService.BookExists(id))
        {
            return NotFound();
        }

        _bookService.DeleteBook(id);
        return NoContent();
    }

    [HttpGet]
    [Route("GetAvailableBooks")]
    public IActionResult GetAvailableBooks()
    {
        var books = _bookService.GetAvailableBooks();
        return Ok(books);
    }
    
    [HttpPut("availability/{id}")]
    public IActionResult UpdateAvailability(Guid id, [FromBody] BookAvailabilityDto bookAvailabilityDto)
    {
        var book = _bookService.GetBook(id);

        if (book == null)
        {
            return NotFound();
        }
        
        _mapper.Map(bookAvailabilityDto, book);
        var updatedBook = _bookService.UpdateBook(id, book);
        return Ok(updatedBook);
    }
}
