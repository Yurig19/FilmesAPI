using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string PublicArea { get; set; }
    public int Number { get; set; }
    public virtual MovieTheater MovieTheater { get; set; }
}
        