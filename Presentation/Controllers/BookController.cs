using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.InteropServices.JavaScript;
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
    private readonly ILogger<BookController> _logger;
    
    public BookController(IBookService bookService, IMapper mapper, ILogger<BookController> logger)
    {
        _bookService = bookService;
        _mapper = mapper;
        _logger = logger;
    }

    [HttpGet]
    [Route("GetBooks")]
    public IActionResult GetBooks()
    {
        var books = _bookService.GetBooks();
        _logger.Log(LogLevel.Information, "GetBooks called, returning {0} books", books.Count);
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
        
        try
        {
            var newBook = _bookService.CreateBook(book);
            _logger.Log(LogLevel.Information, $"CreateBook was called, a new book has been created, called '{book.Name}'");
            return CreatedAtAction(nameof(GetBook), new { id = newBook.Id }, newBook);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Error, "An error occured when adding new Book: " + e.Message);
            return StatusCode(500);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBook(Guid id)
    {
        if (!_bookService.BookExists(id))
        {
            _logger.Log(LogLevel.Information, "No book exists with that ID");
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
