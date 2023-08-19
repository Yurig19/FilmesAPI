using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class FilmController : ControllerBase
{
    private FilmContext _context;

    public FilmController(FilmContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddFilm([FromBody] Film film)
    {
        _context.Films.Add(film);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadFilmId), new {id = film.Id}, film);
    }

    [HttpGet]
    public IEnumerable<Film> ReadFilms([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return _context.Films.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public IActionResult ReadFilmId(int id)
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null) return NotFound();
        return Ok(film);
    }
}
