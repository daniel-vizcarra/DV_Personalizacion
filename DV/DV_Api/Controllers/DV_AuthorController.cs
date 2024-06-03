// Controllers/DV_AuthorController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DV_Api.Data;
using DV_Api.Models;

[Route("api/[controller]")]
[ApiController]
public class DV_AuthorController : ControllerBase
{
    private readonly DV_Context _context;

    public DV_AuthorController(DV_Context context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DV_Author>>> GetAuthors()
    {
        return await _context.DV_Authors.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DV_Author>> GetAuthor(int id)
    {
        var author = await _context.DV_Authors.FindAsync(id);

        if (author == null)
        {
            return NotFound();
        }

        return author;
    }

    [HttpPost]
    public async Task<ActionResult<DV_Author>> PostAuthor(DV_Author author)
    {
        _context.DV_Authors.Add(author);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAuthor", new { id = author.DV_AuthorId }, author);
    }
}
