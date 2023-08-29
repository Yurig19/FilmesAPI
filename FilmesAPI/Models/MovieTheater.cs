using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Models;

public class MovieTheater
{
    [Key]
    [Required] 
    public int Id { get; set; }
    [Required(ErrorMessage = "O campo de nome é obrigatório")] 
    public string Name { get; set; }
    public int AddressId { get; set; }
    public virtual Address Address { get; set; }
    public virtual ICollection<Session> Sessions { get; set; }

}
