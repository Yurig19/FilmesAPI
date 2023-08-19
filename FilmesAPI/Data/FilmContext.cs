using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class FilmContext : DbContext
{
    public FilmContext(DbContextOptions<FilmContext> opts)
        : base(opts)
    {
        
    }

    public DbSet<Film> Films { get; set; } 
}
