using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[Controller]")]

public class AddressController : ControllerBase
{
    private FilmContext _context;
    private IMapper _mapper;

    public AddressController(FilmContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult AddAddress([FromBody] CreateAddressDto addressDto)
    {
        Address address = _mapper.Map<Address>(addressDto);
        _context.Addresses.Add(address);
        _context.SaveChanges();
        return CreatedAtAction(nameof(ReadAddressId), new { Id = address.Id }, address);
    }


    [HttpGet]
    public IEnumerable<ReadAddressDto> ReadAddress(int id)
    {
        return _mapper.Map<List<ReadAddressDto>>(_context.Addresses);
    }

    [HttpGet("{id}")]
    public IActionResult ReadAddressId(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if(address != null)
        {
            ReadAddressDto addressDto = _mapper.Map<ReadAddressDto>(address);
            return Ok(addressDto);
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateAddress(int id, [FromBody] UpdateAddressDto addressDto)
    {
        Address address = _context.Addresses.FirstOrDefault(address => address.Id == id);
        if( address == null )
        {
            return NotFound();
        }
        _mapper.Map(addressDto, address);
        _context.SaveChanges();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteAddress(int id)
    {
        Address address = _context.Addresses.FirstOrDefault(_address => _address.Id == id);
        if(address == null )
        {
            return NotFound();
        }
        _context.Remove(address);
        _context.SaveChanges();
        return NoContent();
    }
}
