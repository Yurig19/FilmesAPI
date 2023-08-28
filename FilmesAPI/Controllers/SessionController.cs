using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class SessionController: ControllerBase
    {
        private FilmContext _context;
        private IMapper _mapper;

        public SessionController(FilmContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AddSession(CreateSessionDto sessionDto)
        {
            Session session = _mapper.Map<Session>(sessionDto);
            _context.Sessions.Add(session);
            _context.SaveChanges();
            return CreatedAtAction(nameof(ReadSessionId), new { Id = session.Id }, session);
        }

        [HttpGet]
        public IEnumerable<ReadSessionDto> ReadSession()
        {
            return _mapper.Map<List<ReadSessionDto>>(_context.Sessions.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult ReadSessionId(int id)
        {
            Session session = _context.Sessions.FirstOrDefault(session => session.Id == id);
            if (session != null)
            {
                ReadSessionDto sessionDto = _mapper.Map<ReadSessionDto>(session);
                return Ok(sessionDto);
            }
            return NotFound();
        }
    }
}
