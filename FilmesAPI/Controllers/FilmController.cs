using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class FilmController : ControllerBase
{
    private static List<Film> films = new List<Film>();
    private static int id = 0;

    [HttpPost]
    public void AddFilm([FromBody] Film film)
    {
        film.Id = id++;
        films.Add(film);
        Console.WriteLine(film.Title);
        Console.WriteLine(film.Duration);
    }

    [HttpGet]
    public IEnumerable<Film> ReadFilms([FromQuery] int skip = 0, [FromQuery] int take = 50)
    {
        return films.Skip(skip).Take(take);
    }

    [HttpGet("{id}")]
    public Film? ReadFilmId(int id)
    {
        return films.FirstOrDefault(film => film.Id == id);
    }
}
