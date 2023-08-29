using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Data;

public class FilmContext : DbContext
{
    public FilmContext(DbContextOptions<FilmContext> opts)
        : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Session>().HasKey(Session => new { Session.FilmId, Session.MovieTheaterId });
        modelBuilder.Entity<Session>().HasOne(session => session.MovieTheater).WithMany(movieTheater => movieTheater.Sessions).HasForeignKey(session => session.MovieTheaterId);
        modelBuilder.Entity<Session>().HasOne(session => session.Film).WithMany(film => film.Sessions).HasForeignKey(session => session.FilmId);
        modelBuilder.Entity<Address>().HasOne(address => address.MovieTheater).WithOne(movieTheater => movieTheater.Address).OnDelete(DeleteBehavior.Restrict);
    }

    public DbSet<Film> Films { get; set; } 
    public DbSet<MovieTheater> MovieTheaters { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Session> Sessions { get; set; }
}
