using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class MovieTheaterController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;
    public MovieTheaterController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]

    public IActionResult AddMovieTheater([FromBody] CreateMovieTheaterDto movieTheaterDto)
    {
        MovieTheater movieTheater = _mapper.Map<MovieTheater>(movieTheaterDto);
        _context.MovieTheaters.Add(movieTheater);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadMovieTheaterId), new { Id = movieTheater.Id }, movieTheaterDto);
    }

    [HttpGet]
    public  IEnumerable<ReadMovieTheaterDto> ReadMovieTheater()
    {
        var listMovieTheaterData = _context.MovieTheaters.ToList();
        var listMovieTheater = _mapper.Map<List<ReadMovieTheaterDto>>(_context.MovieTheaters.ToList());
        return listMovieTheater;
    }

    [HttpGet("{Id}")]

    public IActionResult ReadMovieTheaterId(int  id)
    {
        MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
        if(movieTheater != null)
        {
            ReadMovieTheaterDto movieTheaterDto = _mapper.Map<ReadMovieTheaterDto>(movieTheater);
            return Ok(movieTheaterDto);   
        }
        return  NotFound();
    }

    [HttpPut("{id}")]

    public IActionResult UpdateMovieTheater(int id, [FromBody] UpdateMovieTheaterDto movieTheaterDto)
    {
        MovieTheater movieTheater = _context.MovieTheaters.SingleOrDefault(movieTheater => movieTheater.Id == id);
        if(movieTheater == null)
        {
            return NotFound();
        }

        _mapper.Map(movieTheater, movieTheaterDto);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]

    public IActionResult DeleteMovieTheater(int id)
    {
        MovieTheater movieTheater = _context.MovieTheaters.FirstOrDefault(movieTheater => movieTheater.Id == id);
        if(movieTheater == null)
        {
            return NoContent();
        }
        _context.Remove(movieTheater);
        _context.SaveChanges();
        return NoContent();
    }
}
