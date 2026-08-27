using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BibliotecaJOVEMAPI.Models;

[Route("api/[controller]")]
[ApiController]
public class AutorController : ControllerBase
{
    private readonly BibliotecaDbContext _context;
    public AutorController(BibliotecaDbContext context)
    {
        _context = context;
    }

    // GET: api/Autor
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Autor>>> GetAutor()
    {
        return await _context.Autores.ToListAsync();
    }

    // GET: api/Autor/5
    [HttpGet("{autorid}")]
    public async Task<ActionResult<Autor>> GetAutor(int autorid)
    {
        var autor = await _context.Autores.FindAsync(autorid);

        if (autor == null)
        {
            return NotFound();
        }

        return autor;
    }

    // PUT: api/Autor/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{autorid}")]
    public async Task<IActionResult> PutAutor(int? autorid, Autor autor)
    {
        if (autorid != autor.AutorId)
        {
            return BadRequest();
        }

        _context.Entry(autor).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AutorExists(autorid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Autor
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Autor>> PostAutor(Autor autor)
    {
        _context.Autores.Add(autor);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAutor", new { autorid = autor.AutorId }, autor);
    }

    // DELETE: api/Autor/5
    [HttpDelete("{autorid}")]
    public async Task<IActionResult> DeleteAutor(int? autorid)
    {
        var autor = await _context.Autores.FindAsync(autorid);
        if (autor == null)
        {
            return NotFound();
        }

        _context.Autores.Remove(autor);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AutorExists(int? autorid)
    {
        return _context.Autores.Any(e => e.AutorId == autorid);
    }
}
