using Business.Service;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BorrowerController : Controller
{
    private readonly IBorrowerService _borrowerService;
    
    public BorrowerController(IBorrowerService borrowerService)
    {
        _borrowerService = borrowerService;
    }
    
    [HttpGet]
    [Route("GetBorrowers")]
    public IActionResult GetBorrowers()
    {
        var borrowers = _borrowerService.GetBorrowers();
        return Ok(borrowers);
    }

    [HttpGet("{id}")]
    public IActionResult GetBorrower(Guid id)
    {
        var borrower = _borrowerService.GetBorrower(id);
        if (borrower == null)
        {
            return NotFound();
        }
        return Ok(borrower);
    }

    [HttpPost]
    public IActionResult CreateBorrower([FromBody] Borrower borrower)
    {
        var newBorrower = _borrowerService.CreateBorrower(borrower);
        return CreatedAtAction(nameof(GetBorrower), new { id = newBorrower.Id }, newBorrower);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateBorrower(Guid id, [FromBody] Borrower borrower)
    {
        if (!_borrowerService.BorrowerExists(id))
        {
            return NotFound();
        }

        var updatedBook = _borrowerService.UpdateBorrower(id, borrower);
        return Ok(updatedBook);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteBorrower(Guid id)
    {
        if (!_borrowerService.BorrowerExists(id))
        {
            return NotFound();
        }

        _borrowerService.DeleteBorrower(id);
        return NoContent();
    }
}