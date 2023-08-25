using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class Address
{
    [Key]
    [Required]
    public int Id { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
}
