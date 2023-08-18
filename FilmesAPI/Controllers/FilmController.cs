using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class FilmController: ControllerBase
{  
    private static List<Film> films = new List<Film>();

    [HttpPost]
    public void AddFilm([FromBody]Film film)
    {  
       films.Add(film);
       Console.WriteLine(film.Title);
       Console.WriteLine(film.Duration); 
    }
        
}
