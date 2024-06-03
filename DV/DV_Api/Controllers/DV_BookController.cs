// Controllers/DV_BookController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DV_Api.Data;
using DV_Api.Models;

[Route("api/[controller]")]
[ApiController]
public class DV_BookController : ControllerBase
{
    private readonly DV_Context _context;

    public DV_BookController(DV_Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DV_Book>>> GetBooks()
    {
        return await _context.DV_Books.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DV_Book>> GetBook(int id)
    {
        var book = await _context.DV_Books.FindAsync(id);

        if (book == null)
        {
            return NotFound();
        }

        return book;
    }

    [HttpPost]
    public async Task<ActionResult<DV_Book>> PostBook(DV_Book book)
    {
        _context.DV_Books.Add(book);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetBook", new { id = book.DV_BookId }, book);
    }
}
