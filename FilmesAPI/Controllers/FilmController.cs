using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class FilmController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;

    public FilmController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddFilm([FromBody] CreateFilmDto filmDto)
    {
        Film film = _mapper.Map<Film>(filmDto);
        _context.Films.Add(film);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadFilmId), new {id = film.Id}, film);
    }

    [HttpGet]
    public IEnumerable<ReadFilmDto> ReadFilms([FromQuery] int skip = 0, [FromQuery] int take = 50, [FromQuery] string? nameMovies = null)
    {
        if(nameMovies == null)
        {
            return _mapper.Map<List<ReadFilmDto>>(_context.Films.Skip(skip).Take(take).ToList());
        }
        return _mapper.Map<List<ReadFilmDto>>(_context.Films.Skip(skip).Take(take).Where(film => film.Sessions.Any(session => session.MovieTheater.Name == nameMovies)).ToList());

    }

    [HttpGet("{id}")]
    public IActionResult ReadFilmId(int id)
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);    
        if (film == null) return NotFound();
        var filmDto = _mapper.Map<ReadFilmDto>(film);
        return Ok(filmDto);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateFilm(int id, [FromBody] UpdateFilmDto filmDto ) 
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null) return NotFound();
        _mapper.Map(filmDto, film);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public IActionResult UpdateFilmPatch(int id, JsonPatchDocument<UpdateFilmDto> patch)
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null) return NotFound();

        var filmUpdate = _mapper.Map<UpdateFilmDto>(film);

        patch.ApplyTo(filmUpdate, ModelState);

        if (!TryValidateModel(filmUpdate))
        {
            return ValidationProblem(ModelState);
        }
        _mapper.Map(filmUpdate, film);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteFilm(int id)
    {
        var film = _context.Films.FirstOrDefault(film => film.Id == id);
        if (film == null) return NotFound();
        _context.Remove(film);
        _context.SaveChanges();
        return NoContent();
    }
}
