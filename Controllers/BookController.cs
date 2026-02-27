using interndotnet.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace interndotnet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        var books = await _bookService.GetAllAsync();
        return Ok(books);
    }
    
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var book = await _bookService.GetByIdAsync(id);
        if (book == null)
            return NotFound();
        return Ok(book);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] Book book)
    {
        if (book.PublishedDate == default || book.PublishedDate.Kind == DateTimeKind.Unspecified)
        {
            book.PublishedDate = DateTime.UtcNow;
        }
        else
        {
            book.PublishedDate = book.PublishedDate.ToUniversalTime();
        }
        var createdBook = await _bookService.CreateAsync(book);
        return CreatedAtAction(nameof(GetById), new { id = createdBook.Id }, createdBook);
    }
    
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> Update(int id, [FromBody] Book book)
    {
        var updatedBook = await _bookService.UpdateAsync(id, book);
        if (updatedBook == null)
            return NotFound();
        return Ok(updatedBook);
    }

   
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _bookService.DeleteAsync(id);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}