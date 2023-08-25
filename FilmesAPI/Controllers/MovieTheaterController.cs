﻿using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FilmesAPI.Controllers
{
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
            return CreatedAtAction(nameof(ReadFilmId), new { Id = movieTheater.Id }, movieTheaterDto);
        }

        [HttpGet("{Id}")]

        public IActionResult ReadFilmId(int  id)
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
}